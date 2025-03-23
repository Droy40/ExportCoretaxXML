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
            Button btnNext;
            Button btnPrev;
            _dtpStart = new DateTimePicker();
            _dtpEnd = new DateTimePicker();
            _dataGridView = new DataGridView();
            btnXMLExport = new Button();
            label1 = new Label();
            label2 = new Label();
            lblPageNumber = new Label();
            lblTotalRecords = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            ((System.ComponentModel.ISupportInitialize)_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Location = new Point(718, 35);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(52, 29);
            btnNext.TabIndex = 8;
            btnNext.Text = "->";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrev.Location = new Point(660, 35);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(52, 29);
            btnPrev.TabIndex = 9;
            btnPrev.Text = "<-";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // _dtpStart
            // 
            _dtpStart.CustomFormat = "yyyy-MM-dd";
            _dtpStart.Format = DateTimePickerFormat.Custom;
            _dtpStart.Location = new Point(12, 32);
            _dtpStart.Name = "_dtpStart";
            _dtpStart.Size = new Size(150, 27);
            _dtpStart.TabIndex = 0;
            // 
            // _dtpEnd
            // 
            _dtpEnd.CustomFormat = "yyyy-MM-dd";
            _dtpEnd.Format = DateTimePickerFormat.Custom;
            _dtpEnd.Location = new Point(204, 32);
            _dtpEnd.Name = "_dtpEnd";
            _dtpEnd.Size = new Size(150, 27);
            _dtpEnd.TabIndex = 1;
            // 
            // _dataGridView
            // 
            _dataGridView.AllowUserToAddRows = false;
            _dataGridView.AllowUserToDeleteRows = false;
            _dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridView.ColumnHeadersHeight = 29;
            _dataGridView.Location = new Point(12, 77);
            _dataGridView.Name = "_dataGridView";
            _dataGridView.RowHeadersWidth = 51;
            _dataGridView.Size = new Size(776, 382);
            _dataGridView.TabIndex = 3;
            // 
            // btnXMLExport
            // 
            btnXMLExport.Location = new Point(360, 9);
            btnXMLExport.Name = "btnXMLExport";
            btnXMLExport.Size = new Size(100, 50);
            btnXMLExport.TabIndex = 4;
            btnXMLExport.Text = "XML Export";
            btnXMLExport.Click += btnXMLExport_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 5;
            label1.Text = "Tanggal Transaksi :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 35);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 6;
            label2.Text = "s/d";
            // 
            // lblPageNumber
            // 
            lblPageNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPageNumber.AutoSize = true;
            lblPageNumber.Location = new Point(660, 9);
            lblPageNumber.Name = "lblPageNumber";
            lblPageNumber.Size = new Size(50, 20);
            lblPageNumber.TabIndex = 7;
            lblPageNumber.Text = "label3";
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Location = new Point(466, 32);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new Size(50, 20);
            lblTotalRecords.TabIndex = 10;
            lblTotalRecords.Text = "label3";
            // 
            // FormInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 471);
            Controls.Add(lblTotalRecords);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(lblPageNumber);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnXMLExport);
            Controls.Add(_dtpStart);
            Controls.Add(_dtpEnd);
            Controls.Add(_dataGridView);
            Name = "FormInvoice";
            Text = "List Invoice";
            ((System.ComponentModel.ISupportInitialize)_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
