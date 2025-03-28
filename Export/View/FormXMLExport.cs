using Export.Model;
using Export.ViewModel;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Export.View
{
    public partial class FormXMLExport : Form
    {
        private XMLExportViewModel _viewModel;
        private FormXMLExport()
        {
            InitializeComponent();
        }

        public FormXMLExport( DateTime startDate, DateTime endDate) : this()
        {            
            _viewModel = new XMLExportViewModel(startDate, endDate);
            LoadLabel();
            dataGridView1.DataSource = _viewModel.ExportSelections;
            FormatDataGrid();
        }
        private void FormatDataGrid()
        {
            dataGridView1.Columns["TotalVAT"].DefaultCellStyle.Format = "C";
            dataGridView1.Columns["TotalVAT"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");

            dataGridView1.Columns["ExportVAT"].DefaultCellStyle.Format = "C";
            dataGridView1.Columns["ExportVAT"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");

            dataGridView1.Columns["ExportPercentage"].DefaultCellStyle.Format = "N0";            
        }

        private void LoadLabel()
        {
            lblGrandTotalVAT.Text = _viewModel.GrandTotalVAT.ToString("C", new CultureInfo("id-ID"));
            Binding binding = new Binding("Text", _viewModel, "GrandTotalExportVAT", true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += (s, e) =>
            {
                if (e.Value is decimal value)
                {
                    e.Value = value.ToString("C2", new CultureInfo("id-ID"));
                }
            };
            lblGrandTotalExportVAT.DataBindings.Add(binding);

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _viewModel.UpdateExportVAT();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_viewModel.ExportToXml())
                {
                    MessageBox.Show("Export Berhasil");
                }
                else
                {
                    MessageBox.Show("Export Gagal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
