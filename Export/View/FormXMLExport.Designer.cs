namespace Export.View
{
    partial class FormXMLExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblGrandTotalVAT = new System.Windows.Forms.Label();
            this.lblGrandTotalExportVAT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTahun = new System.Windows.Forms.Label();
            this.lblBulan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSerialNoStart = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(862, 472);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(772, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(98, 47);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblGrandTotalVAT
            // 
            this.lblGrandTotalVAT.AutoSize = true;
            this.lblGrandTotalVAT.Location = new System.Drawing.Point(327, 12);
            this.lblGrandTotalVAT.Name = "lblGrandTotalVAT";
            this.lblGrandTotalVAT.Size = new System.Drawing.Size(116, 16);
            this.lblGrandTotalVAT.TabIndex = 2;
            this.lblGrandTotalVAT.Text = "lblGrandTotalVAT";
            // 
            // lblGrandTotalExportVAT
            // 
            this.lblGrandTotalExportVAT.AutoSize = true;
            this.lblGrandTotalExportVAT.Location = new System.Drawing.Point(327, 36);
            this.lblGrandTotalExportVAT.Name = "lblGrandTotalExportVAT";
            this.lblGrandTotalExportVAT.Size = new System.Drawing.Size(154, 16);
            this.lblGrandTotalExportVAT.TabIndex = 3;
            this.lblGrandTotalExportVAT.Text = "lblGrandTotalExportVAT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total VAT : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Total Export VAT : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tahun : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bulan : ";
            // 
            // lblTahun
            // 
            this.lblTahun.AutoSize = true;
            this.lblTahun.Location = new System.Drawing.Point(86, 13);
            this.lblTahun.Name = "lblTahun";
            this.lblTahun.Size = new System.Drawing.Size(59, 16);
            this.lblTahun.TabIndex = 8;
            this.lblTahun.Text = "lblTahun";
            // 
            // lblBulan
            // 
            this.lblBulan.AutoSize = true;
            this.lblBulan.Location = new System.Drawing.Point(86, 36);
            this.lblBulan.Name = "lblBulan";
            this.lblBulan.Size = new System.Drawing.Size(55, 16);
            this.lblBulan.TabIndex = 9;
            this.lblBulan.Text = "lblBulan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(634, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "SerialNo Start :";
            // 
            // txtSerialNoStart
            // 
            this.txtSerialNoStart.Location = new System.Drawing.Point(637, 30);
            this.txtSerialNoStart.Name = "txtSerialNoStart";
            this.txtSerialNoStart.Size = new System.Drawing.Size(100, 22);
            this.txtSerialNoStart.TabIndex = 12;
            this.txtSerialNoStart.Text = "1";
            // 
            // FormXMLExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.txtSerialNoStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblBulan);
            this.Controls.Add(this.lblTahun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGrandTotalExportVAT);
            this.Controls.Add(this.lblGrandTotalVAT);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormXMLExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormXMLExport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblGrandTotalVAT;
        private System.Windows.Forms.Label lblGrandTotalExportVAT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTahun;
        private System.Windows.Forms.Label lblBulan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSerialNoStart;
    }
}