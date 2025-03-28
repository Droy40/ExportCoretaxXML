using Export.Model;
using Export.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace Export.ViewModel
{
    public class RetailInvoiceViewModel : INotifyPropertyChanged
    {
        private BindingList<InvoiceExportSelection> _exportSelections;
        private BindingList<RetailInvoice> _retailInvoice;
        private int _totalRecords = 0;
        private int _currentPage = 1;
        private int _pageSize = 25;
        private int _totalPages;
        private DateTime? _startDate;
        private DateTime? _endDate;

        public BindingList<InvoiceExportSelection> ExportSelections
        {
            get { return _exportSelections; }
            set { _exportSelections = value; OnPropertyChanged(); }
        }
        public BindingList<RetailInvoice> RetailInvoice
        {
            get { return _retailInvoice; }
            set { _retailInvoice = value; OnPropertyChanged(); }
        }
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; OnPropertyChanged(); }
        }
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(); }
        }
        public int TotalPages
        {
            get { return _totalPages; }
            set { _totalPages = value; OnPropertyChanged(); }
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

        public RetailInvoiceViewModel()
        {
            ExportSelections = new BindingList<InvoiceExportSelection>();
            RetailInvoice = new BindingList<RetailInvoice>();
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            EndDate = DateTime.Now;
            LoadTotalPages();
            LoadExportSelections();
        }
        public void LoadTotalPages()
        {
            TotalRecords = RetailInvoiceRepository.GetTotalRecords(StartDate, EndDate);
            TotalPages = (int)System.Math.Ceiling((double)TotalRecords / _pageSize);
        }
        public void LoadExportSelections()
        {
            if (StartDate == null || EndDate == null) return;
            
            var groupedByDate = RetailInvoice
                .GroupBy(i => i.TransactionDate)
                .Select(g => new InvoiceExportSelection
                {
                    Date = g.Key,
                    TotalInvoices = g.Count(),
                    ExportPercentage = 100,
                    TotalVAT = g.Sum(i => i.VAT),
                    ExportVAT = g.Sum(i => i.VAT)
                })
                .ToList();

            ExportSelections.Clear();
            foreach (var item in groupedByDate)
            {
                ExportSelections.Add(item);
            }
        }
        public void UpdateExportVAT()
        {
            foreach (var selection in ExportSelections)
            {
                var allInvoices = RetailInvoice
                    .Where(i => i.TransactionDate == selection.Date)
                    .OrderByDescending(i => i.TransactionDate)
                    .Take((int)Math.Ceiling(selection.TotalInvoices * (selection.ExportPercentage / 100.0)))
                    .ToList();

                selection.ExportVAT = allInvoices.Sum(i => i.VAT);
            }
            OnPropertyChanged(nameof(ExportSelections));
        }
        public void LoadData()
        {
            List<RetailInvoice> retailInvoiceFromDb = RetailInvoiceRepository.GetRetailInvoice(CurrentPage, _pageSize,StartDate,EndDate);
            RetailInvoice.Clear();
            foreach (var person in retailInvoiceFromDb)
            {
                RetailInvoice.Add(person);
            }
        }
        public void NextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                LoadData();
            }
        }
        public void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                LoadData();
            }
        }    
        
        public Boolean ExportToXml(String TIN="")
        {
            List<RetailInvoice> allData = RetailInvoiceRepository.GetAllRetailInvoice(StartDate, EndDate);

            if (allData.Count == 0)
            {
                throw new Exception("Tidak ada data untuk diekspor!");                      
            }

            if (!(StartDate.Value.Month == EndDate.Value.Month && StartDate.Value.Year == EndDate.Value.Year))
            {
                throw new Exception("Ekspor hanya bisa dilakukan di periode bulan dan tahun yang sama!");
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
                        XmlSerializer serializer = new XmlSerializer(typeof (RetailInvoiceExport));
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
