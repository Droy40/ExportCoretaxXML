using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export.Model
{
    public class InvoiceExportSelection : INotifyPropertyChanged
    {
        private decimal _exportVAT;
        private int _totalExportInvoices;
        public DateTime Date { get; set; }
        public int TotalInvoices { get; set; }
        public decimal TotalVAT { get; set; }

        private double _exportPercentage = 100;
        public double ExportPercentage
        {
            get => _exportPercentage;
            set
            {
                if (value < 0 )
                {
                    _exportPercentage = 0;
                }
                else if(value > 100)
                {
                    _exportPercentage = 100;
                }
                else
                {
                    _exportPercentage = value;
                }

                UpdateExportValues();
            }
        }

        public int TotalExportInvoices
        {
            get { return _totalExportInvoices; }
            private set
            {
                if (_totalExportInvoices != value)
                {
                    _totalExportInvoices = value;
                    OnPropertyChanged(nameof(TotalExportInvoices));
                }
            }
        }
        public decimal ExportVAT 
        {
            get { return _exportVAT;  } 
            set
            {
                if (_exportVAT != value)
                {
                    _exportVAT = value;
                    OnPropertyChanged(nameof(ExportVAT));
                }
            }
        }

        private void UpdateExportValues()
        {            
            int calculatedExportInvoices = (int)Math.Ceiling(TotalInvoices * (_exportPercentage / 100.0));         
            double adjustedExportPercentage = (calculatedExportInvoices / (double)TotalInvoices) * 100;         
            TotalExportInvoices = calculatedExportInvoices;
            _exportPercentage = adjustedExportPercentage; // Update persentase sesuai hasil pembulatan
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
