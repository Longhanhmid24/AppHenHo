namespace Admin.UserControl
{
    partial class BaoCao
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
            dataGridView1 = new System.Windows.Forms.DataGridView();
            clmUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmSoLan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { clmUsername, clmSoLan, clmNoiDung, clmThoiGian });
            dataGridView1.Location = new System.Drawing.Point(470, 102);
            dataGridView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new System.Drawing.Size(2145, 1525);
            dataGridView1.TabIndex = 0;
            // 
            // clmUsername
            // 
            clmUsername.HeaderText = "UserName";
            clmUsername.MinimumWidth = 6;
            clmUsername.Name = "clmUsername";
            // 
            // clmSoLan
            // 
            clmSoLan.HeaderText = "Số Lần Bị Báo Cáo";
            clmSoLan.MinimumWidth = 6;
            clmSoLan.Name = "clmSoLan";
            // 
            // clmNoiDung
            // 
            clmNoiDung.HeaderText = "Nội Dung Báo Cáo";
            clmNoiDung.MinimumWidth = 6;
            clmNoiDung.Name = "clmNoiDung";
            // 
            // clmThoiGian
            // 
            clmThoiGian.HeaderText = "Thời Gian";
            clmThoiGian.MinimumWidth = 6;
            clmThoiGian.Name = "clmThoiGian";
            // 
            // BaoCao
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            Name = "BaoCao";
            Size = new System.Drawing.Size(2685, 1712);
            Load += BaoCao_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSoLan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmThoiGian;
    }
}
