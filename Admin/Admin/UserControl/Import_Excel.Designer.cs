namespace Admin.UserControl
{
    partial class Import__Excel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_import = new System.Windows.Forms.Button();
            btn_save = new System.Windows.Forms.Button();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            panel1 = new System.Windows.Forms.Panel();
            label9 = new System.Windows.Forms.Label();
            btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btn_import
            // 
            btn_import.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            btn_import.Font = new System.Drawing.Font("Tahoma", 13.8F);
            btn_import.ForeColor = System.Drawing.Color.White;
            btn_import.Location = new System.Drawing.Point(983, 256);
            btn_import.Name = "btn_import";
            btn_import.Size = new System.Drawing.Size(443, 86);
            btn_import.TabIndex = 0;
            btn_import.Text = "import";
            btn_import.UseVisualStyleBackColor = false;
            btn_import.Click += btn_import_Click;
            // 
            // btn_save
            // 
            btn_save.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            btn_save.Font = new System.Drawing.Font("Tahoma", 13.8F);
            btn_save.ForeColor = System.Drawing.Color.White;
            btn_save.Location = new System.Drawing.Point(983, 499);
            btn_save.Name = "btn_save";
            btn_save.Size = new System.Drawing.Size(443, 87);
            btn_save.TabIndex = 0;
            btn_save.Text = "save";
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(3, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new System.Drawing.Size(956, 915);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Navy;
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1448, 125);
            panel1.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label9.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label9.Location = new System.Drawing.Point(1106, 173);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(208, 48);
            label9.TabIndex = 22;
            label9.Text = "Thêm file";
            // 
            // btnExport
            // 
            btnExport.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            btnExport.Font = new System.Drawing.Font("Tahoma", 13.8F);
            btnExport.ForeColor = System.Drawing.Color.White;
            btnExport.Location = new System.Drawing.Point(983, 375);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(443, 87);
            btnExport.TabIndex = 23;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // Import__Excel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(btnExport);
            Controls.Add(label9);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(btn_save);
            Controls.Add(btn_import);
            Name = "Import__Excel";
            Size = new System.Drawing.Size(1448, 935);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExport;
    }
}
