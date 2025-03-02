namespace Admin.UserControl
{
    partial class DanhSachUsers
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
            this.tbDanhSach = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lmUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBirthDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.tbDanhSach)).BeginInit();
            this.tbDanhSach.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDanhSach
            // 
            this.tbDanhSach.Location = new System.Drawing.Point(45, 28);
            this.tbDanhSach.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tbDanhSach.Name = "tbDanhSach";
            this.tbDanhSach.SelectedTabPage = this.xtraTabPage2;
            this.tbDanhSach.Size = new System.Drawing.Size(2566, 1562);
            this.tbDanhSach.TabIndex = 0;
            this.tbDanhSach.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            this.tbDanhSach.TabStop = false;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.dataGridView2);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(2562, 1513);
            this.xtraTabPage2.Text = "Tài Khoản";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.clmPass});
            this.dataGridView2.Location = new System.Drawing.Point(638, 19);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(1920, 1466);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "UserName";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // clmPass
            // 
            this.clmPass.HeaderText = "Mật Khẩu";
            this.clmPass.MinimumWidth = 6;
            this.clmPass.Name = "clmPass";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.dataGridView1);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(2562, 1513);
            this.xtraTabPage1.Text = "Danh Sách Chung";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lmUserName,
            this.clmHoTen,
            this.clmGioiTinh,
            this.clmDiaChi,
            this.clmBirthDay,
            this.clmGmail});
            this.dataGridView1.Location = new System.Drawing.Point(638, 5);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1920, 1498);
            this.dataGridView1.TabIndex = 0;
            // 
            // lmUserName
            // 
            this.lmUserName.HeaderText = "UserName";
            this.lmUserName.MinimumWidth = 6;
            this.lmUserName.Name = "lmUserName";
            // 
            // clmHoTen
            // 
            this.clmHoTen.HeaderText = "Họ Tên";
            this.clmHoTen.MinimumWidth = 6;
            this.clmHoTen.Name = "clmHoTen";
            // 
            // clmGioiTinh
            // 
            this.clmGioiTinh.HeaderText = "Giới Tính";
            this.clmGioiTinh.MinimumWidth = 6;
            this.clmGioiTinh.Name = "clmGioiTinh";
            // 
            // clmDiaChi
            // 
            this.clmDiaChi.HeaderText = "Địa Chỉ";
            this.clmDiaChi.MinimumWidth = 6;
            this.clmDiaChi.Name = "clmDiaChi";
            // 
            // clmBirthDay
            // 
            this.clmBirthDay.HeaderText = "Ngày Tháng Năm Sinh";
            this.clmBirthDay.MinimumWidth = 6;
            this.clmBirthDay.Name = "clmBirthDay";
            // 
            // clmGmail
            // 
            this.clmGmail.HeaderText = "Gmail";
            this.clmGmail.MinimumWidth = 6;
            this.clmGmail.Name = "clmGmail";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(2562, 1513);
            this.xtraTabPage3.Text = "xtraTabPage3";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(2562, 1513);
            this.xtraTabPage4.Text = "xtraTabPage4";
            // 
            // DanhSachUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbDanhSach);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "DanhSachUsers";
            this.Size = new System.Drawing.Size(2616, 1966);
            this.Load += new System.EventHandler(this.DanhSachUsers_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.tbDanhSach)).EndInit();
            this.tbDanhSach.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tbDanhSach;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lmUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBirthDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGmail;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPass;
    }
}
