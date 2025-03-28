using Export.Model;
using Export.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Export.ViewModel
{
    public class XMLExportViewModel: INotifyPropertyChanged
    {
        private BindingList<InvoiceExportSelection> _exportSelections;
        private List<RetailInvoice> _retailInvoice;
        private decimal grandTotalVAT;
        private decimal grandTotalExportVAT;
        private DateTime? _startDate;
        private DateTime? _endDate;

        public BindingList<InvoiceExportSelection> ExportSelections
        {
            get => _exportSelections;
            set
            {
                if (_exportSelections != value)
                {
                    _exportSelections = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal GrandTotalVAT
        {
            get => grandTotalVAT;
            set
            {
                if (grandTotalVAT != value)
                {
                    grandTotalVAT = value;
                    OnPropertyChanged();
                }
            }
        }
        public decimal GrandTotalExportVAT
        {
            get => grandTotalExportVAT;
            set
            {
                if (grandTotalExportVAT != value)
                {
                    grandTotalExportVAT = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime? StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged(); }
        }
        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value; OnPropertyChanged(); }
        }

        public XMLExportViewModel(            
            DateTime startDate,
            DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            _retailInvoice = RetailInvoiceRepository.GetAllRetailInvoice(StartDate,EndDate);
            LoadExportSelections();
        }

        public void LoadExportSelections()
        {
            if (StartDate == null || EndDate == null) return;

            var groupedByDate = _retailInvoice
                .Where(i => i.TransactionDate >= StartDate && i.TransactionDate <= EndDate) // Filter by date
                .OrderBy(i => i.TransactionDate.Date)
                .GroupBy(i => i.TransactionDate.Date)
                .Select(g => new InvoiceExportSelection
                {
                    Date = g.Key,
                    TotalInvoices = g.Count(),
                    ExportPercentage = 100,
                    TotalVAT = g.Sum(i => i.VAT),
                    ExportVAT = g.Sum(i => i.VAT)
                })
                .ToList();

            GrandTotalVAT = groupedByDate.Sum(g => g.TotalVAT);
            GrandTotalExportVAT = groupedByDate.Sum(g => g.ExportVAT);
            ExportSelections = new BindingList<InvoiceExportSelection>(groupedByDate);
            ExportSelections.ResetBindings();
        }
        
        public void UpdateExportVAT()
        {
            foreach (var selection in ExportSelections)
            {
                var allInvoices = _retailInvoice
                    .Where(i => i.TransactionDate.Date == selection.Date.Date)
                    .OrderBy(i => i.TransactionDate)
                    .Take(selection.TotalExportInvoices) // Gunakan nilai yang sudah dibulatkan
                    .ToList();

                selection.ExportVAT = allInvoices.Sum(i => i.VAT);
            }
            GrandTotalExportVAT = ExportSelections.Sum(g => g.ExportVAT);
            OnPropertyChanged(nameof(ExportSelections));
        }
        private List<RetailInvoice> GetSelectedInvoices()
        {
            List<RetailInvoice> selectedInvoices = new List<RetailInvoice>();

            foreach (var selection in ExportSelections)
            {
                var invoices = _retailInvoice
                    .Where(i => i.TransactionDate == selection.Date) // Filter berdasarkan tanggal transaksi
                    .OrderBy(i => i.TransactionDate) // Urut dari yang paling lama
                    .Take(selection.TotalExportInvoices) // Ambil sesuai jumlah yang diekspor
                    .ToList();

                selectedInvoices.AddRange(invoices); // Tambahkan ke list utama
            }

            return selectedInvoices;
        }
        public Boolean ExportToXml(String TIN = "")
        {
            List<RetailInvoice> allData = GetSelectedInvoices();

            if (allData.Count == 0)
            {
                throw new Exception("Tidak ada data untuk diekspor!");
            }

            RetailInvoiceExport toExport = new RetailInvoiceExport()
            {
                TIN = "NO_NPWP",
                TaxPeriodMonth = StartDate.Value.Month,
                TaxPeriodYear = StartDate.Value.Year,
                ListOfRetailInvoice = new RetailInvoiceList
                {
                    RetailInvoices = allData
                }
            };

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML File (*.xml)|*.xml",
                Title = "Simpan File XML",
                FileName = "ExportedData.xml"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(RetailInvoiceExport));
                        serializer.Serialize(fileStream, toExport);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
