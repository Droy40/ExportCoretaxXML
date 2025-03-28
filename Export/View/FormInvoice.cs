using Export.View;
using Export.ViewModel;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Export
{
    public partial class FormInvoice : Form
    {
        private RetailInvoiceViewModel _viewModel;
        public FormInvoice()
        {
            InitializeComponent();
            _viewModel = new RetailInvoiceViewModel();
            _dtpStart.Value = _viewModel.StartDate.Value;
            _dtpEnd.Value = _viewModel.EndDate.Value;
            _viewModel.LoadData();
            _dataGridView.DataSource = _viewModel.RetailInvoice;
            UpdatePageLabel();
            UpdateTotalRecords();


            // Event handler untuk DateTimePicker
            _dtpStart.ValueChanged += DatePicker_ValueChanged;
            _dtpEnd.ValueChanged += DatePicker_ValueChanged;

            FormatDataGrid();
        }
        private void UpdatePageLabel()
        {
            lblPageNumber.Text = $"Page: {_viewModel.CurrentPage} / {_viewModel.TotalPages}";
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _viewModel.PreviousPage();
            UpdatePageLabel();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _viewModel.NextPage();
            UpdatePageLabel();
        }
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Set tanggal yang baru dipilih ke ViewModel
            _viewModel.StartDate = _dtpStart.Value;
            _viewModel.EndDate = _dtpEnd.Value;

            // Reset halaman ke pertama
            _viewModel.CurrentPage = 1;

            // Perbarui total halaman
            _viewModel.LoadTotalPages();
            UpdateTotalRecords();


            // Muat ulang data berdasarkan filter tanggal baru
            _viewModel.LoadData();

            // Perbarui label halaman
            UpdatePageLabel();
        }
        private void UpdateTotalRecords()
        {
            lblTotalRecords.Text = $"Total Records: {_viewModel.TotalRecords}";
        }
        private void FormatDataGrid()
        {
            _dataGridView.Columns["TaxBaseSellingPrice"].DefaultCellStyle.Format = "C";
            _dataGridView.Columns["TaxBaseSellingPrice"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");

            _dataGridView.Columns["OtherTaxBaseSellingPrice"].DefaultCellStyle.Format = "C";
            _dataGridView.Columns["OtherTaxBaseSellingPrice"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");

            _dataGridView.Columns["VAT"].DefaultCellStyle.Format = "C";
            _dataGridView.Columns["VAT"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");

            _dataGridView.Columns["STLG"].DefaultCellStyle.Format = "C";
            _dataGridView.Columns["STLG"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");
        }

        private void btnXMLExport_Click(object sender, EventArgs e)
        {
            FormXMLExport frmExport = new FormXMLExport(                
                _viewModel.StartDate.Value, 
                _viewModel.EndDate.Value);
            frmExport.Owner = this;
            frmExport.Show();                     
        }
    }
}
