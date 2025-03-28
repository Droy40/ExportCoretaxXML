using System.Drawing;
using System.Windows.Forms;

namespace Export
{
    partial class FormInvoice
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnNext;
            System.Windows.Forms.Button btnPrev;
            this._dtpStart = new System.Windows.Forms.DateTimePicker();
            this._dtpEnd = new System.Windows.Forms.DateTimePicker();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.btnXMLExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            btnNext = new System.Windows.Forms.Button();
            btnPrev = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnNext.Location = new System.Drawing.Point(718, 28);
            btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(52, 23);
            btnNext.TabIndex = 8;
            btnNext.Text = "->";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnPrev.Location = new System.Drawing.Point(660, 28);
            btnPrev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new System.Drawing.Size(52, 23);
            btnPrev.TabIndex = 9;
            btnPrev.Text = "<-";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // _dtpStart
            // 
            this._dtpStart.CustomFormat = "yyyy-MM-dd";
            this._dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpStart.Location = new System.Drawing.Point(12, 26);
            this._dtpStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dtpStart.Name = "_dtpStart";
            this._dtpStart.Size = new System.Drawing.Size(150, 22);
            this._dtpStart.TabIndex = 0;
            // 
            // _dtpEnd
            // 
            this._dtpEnd.CustomFormat = "yyyy-MM-dd";
            this._dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpEnd.Location = new System.Drawing.Point(204, 26);
            this._dtpEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dtpEnd.Name = "_dtpEnd";
            this._dtpEnd.Size = new System.Drawing.Size(150, 22);
            this._dtpEnd.TabIndex = 1;
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.ColumnHeadersHeight = 29;
            this._dataGridView.Location = new System.Drawing.Point(12, 62);
            this._dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.RowHeadersWidth = 51;
            this._dataGridView.Size = new System.Drawing.Size(776, 306);
            this._dataGridView.TabIndex = 3;
            // 
            // btnXMLExport
            // 
            this.btnXMLExport.Location = new System.Drawing.Point(360, 7);
            this.btnXMLExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXMLExport.Name = "btnXMLExport";
            this.btnXMLExport.Size = new System.Drawing.Size(100, 40);
            this.btnXMLExport.TabIndex = 4;
            this.btnXMLExport.Text = "XML Export";
            this.btnXMLExport.Click += new System.EventHandler(this.btnXMLExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal Transaksi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "s/d";
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Location = new System.Drawing.Point(660, 7);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(44, 16);
            this.lblPageNumber.TabIndex = 7;
            this.lblPageNumber.Text = "label3";
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Location = new System.Drawing.Point(466, 26);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(44, 16);
            this.lblTotalRecords.TabIndex = 10;
            this.lblTotalRecords.Text = "label3";
            // 
            // FormInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 377);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(btnPrev);
            this.Controls.Add(btnNext);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXMLExport);
            this.Controls.Add(this._dtpStart);
            this.Controls.Add(this._dtpEnd);
            this.Controls.Add(this._dataGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker _dtpStart;
        private DateTimePicker _dtpEnd;
        private DataGridView _dataGridView;
        private Button btnXMLExport;
        private Label label1;
        private Label label2;
        private Label lblPageNumber;
        private Label lblTotalRecords;
    }
}
