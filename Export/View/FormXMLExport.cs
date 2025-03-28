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
            lblBulan.Text = startDate.Month.ToString();
            lblTahun.Text = startDate.Year.ToString();
            _viewModel = new XMLExportViewModel(startDate, endDate);
            LoadLabel();
            dataGridView1.DataSource = _viewModel.ExportSelections;
            FormatDataGrid();
            // Set semua kolom sebagai ReadOnly terlebih dahulu
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }

            // Hanya kolom "ExportPercentage" yang bisa diedit
            dataGridView1.Columns["ExportPercentage"].ReadOnly = false;
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
                int serialNoStart;
                if (!int.TryParse(txtSerialNoStart.Text,out serialNoStart))
                {
                    MessageBox.Show("Serial No Start harus Angka!!");
                    return;
                }
                if (_viewModel.ExportToXml("NPWP",serialNoStart))
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
