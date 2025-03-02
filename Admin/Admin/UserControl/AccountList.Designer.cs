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
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            groupBox2 = new System.Windows.Forms.GroupBox();
            txtGiamSat = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            btnXoaTaiKhoan = new System.Windows.Forms.Button();
            dgvAccountList = new System.Windows.Forms.DataGridView();
            clmUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmBlocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            gbSearchDSChung = new System.Windows.Forms.GroupBox();
            txtDsChung = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            txtPass = new System.Windows.Forms.TextBox();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnThem = new System.Windows.Forms.Button();
            txtGmail = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            cbbDiaChi = new System.Windows.Forms.ComboBox();
            cbbGioiTinh = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            txtHoTen = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            dgvDSC = new System.Windows.Forms.DataGridView();
            clmGUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmBirthDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmGmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tbDanhSach = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            label11 = new System.Windows.Forms.Label();
            btnThangThai = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            txtTimKiemMatchs = new System.Windows.Forms.TextBox();
            dgvMatchs = new System.Windows.Forms.DataGridView();
            clmMatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmNguoiGui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmNguoiNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            label10 = new System.Windows.Forms.Label();
            btnSuaAnh = new System.Windows.Forms.Button();
            btnXoaAnh = new System.Windows.Forms.Button();
            groupBox3 = new System.Windows.Forms.GroupBox();
            txtImgaes = new System.Windows.Forms.TextBox();
            dgvImage = new System.Windows.Forms.DataGridView();
            clmChuTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmImage = new System.Windows.Forms.DataGridViewImageColumn();
            clmAvt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panel1 = new System.Windows.Forms.Panel();
            xtraTabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccountList).BeginInit();
            xtraTabPage1.SuspendLayout();
            gbSearchDSChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDSC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDanhSach).BeginInit();
            tbDanhSach.SuspendLayout();
            xtraTabPage3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMatchs).BeginInit();
            xtraTabPage4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImage).BeginInit();
            SuspendLayout();
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Controls.Add(groupBox2);
            xtraTabPage2.Controls.Add(label9);
            xtraTabPage2.Controls.Add(btnXoaTaiKhoan);
            xtraTabPage2.Controls.Add(dgvAccountList);
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new System.Drawing.Size(1411, 859);
            xtraTabPage2.Text = "Tài Khoản";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = System.Drawing.Color.Navy;
            groupBox2.Controls.Add(txtGiamSat);
            groupBox2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox2.ForeColor = System.Drawing.Color.White;
            groupBox2.Location = new System.Drawing.Point(3, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(429, 76);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm Kiếm Tài Khoản";
            // 
            // txtGiamSat
            // 
            txtGiamSat.Location = new System.Drawing.Point(20, 28);
            txtGiamSat.Name = "txtGiamSat";
            txtGiamSat.Size = new System.Drawing.Size(390, 23);
            txtGiamSat.TabIndex = 0;
            txtGiamSat.TextChanged += txtGiamSat_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label9.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label9.Location = new System.Drawing.Point(57, 158);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(340, 36);
            label9.TabIndex = 21;
            label9.Text = "Giám Sát Người Dùng";
            // 
            // btnXoaTaiKhoan
            // 
            btnXoaTaiKhoan.BackColor = System.Drawing.Color.Navy;
            btnXoaTaiKhoan.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnXoaTaiKhoan.ForeColor = System.Drawing.Color.White;
            btnXoaTaiKhoan.Location = new System.Drawing.Point(3, 232);
            btnXoaTaiKhoan.Name = "btnXoaTaiKhoan";
            btnXoaTaiKhoan.Size = new System.Drawing.Size(429, 130);
            btnXoaTaiKhoan.TabIndex = 15;
            btnXoaTaiKhoan.Text = "Xóa Tài Khoản";
            btnXoaTaiKhoan.UseVisualStyleBackColor = false;
            btnXoaTaiKhoan.Click += btnXoaTaiKhoan_Click;
            // 
            // dgvAccountList
            // 
            dgvAccountList.AllowUserToAddRows = false;
            dgvAccountList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccountList.BackgroundColor = System.Drawing.Color.White;
            dgvAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccountList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { clmUsername, clmPass, clmBlocked });
            dgvAccountList.Location = new System.Drawing.Point(443, 15);
            dgvAccountList.Name = "dgvAccountList";
            dgvAccountList.RowHeadersWidth = 51;
            dgvAccountList.Size = new System.Drawing.Size(953, 934);
            dgvAccountList.TabIndex = 1;
            // 
            // clmUsername
            // 
            clmUsername.HeaderText = "Username";
            clmUsername.MinimumWidth = 6;
            clmUsername.Name = "clmUsername";
            clmUsername.ReadOnly = true;
            // 
            // clmPass
            // 
            clmPass.HeaderText = "Mật Khẩu";
            clmPass.MinimumWidth = 6;
            clmPass.Name = "clmPass";
            clmPass.ReadOnly = true;
            // 
            // clmBlocked
            // 
            clmBlocked.HeaderText = "Trạng Thái Tài Khoản";
            clmBlocked.MinimumWidth = 6;
            clmBlocked.Name = "clmBlocked";
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(gbSearchDSChung);
            xtraTabPage1.Controls.Add(label8);
            xtraTabPage1.Controls.Add(label7);
            xtraTabPage1.Controls.Add(txtPass);
            xtraTabPage1.Controls.Add(btnSua);
            xtraTabPage1.Controls.Add(btnXoa);
            xtraTabPage1.Controls.Add(btnThem);
            xtraTabPage1.Controls.Add(txtGmail);
            xtraTabPage1.Controls.Add(label6);
            xtraTabPage1.Controls.Add(dtNgaySinh);
            xtraTabPage1.Controls.Add(label5);
            xtraTabPage1.Controls.Add(label4);
            xtraTabPage1.Controls.Add(cbbDiaChi);
            xtraTabPage1.Controls.Add(cbbGioiTinh);
            xtraTabPage1.Controls.Add(label3);
            xtraTabPage1.Controls.Add(txtHoTen);
            xtraTabPage1.Controls.Add(label2);
            xtraTabPage1.Controls.Add(txtUsername);
            xtraTabPage1.Controls.Add(label1);
            xtraTabPage1.Controls.Add(dgvDSC);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new System.Drawing.Size(1411, 859);
            xtraTabPage1.Text = "Danh Sách Chung";
            // 
            // gbSearchDSChung
            // 
            gbSearchDSChung.BackColor = System.Drawing.Color.Navy;
            gbSearchDSChung.Controls.Add(txtDsChung);
            gbSearchDSChung.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            gbSearchDSChung.ForeColor = System.Drawing.Color.White;
            gbSearchDSChung.Location = new System.Drawing.Point(981, 25);
            gbSearchDSChung.Name = "gbSearchDSChung";
            gbSearchDSChung.Size = new System.Drawing.Size(427, 76);
            gbSearchDSChung.TabIndex = 19;
            gbSearchDSChung.TabStop = false;
            gbSearchDSChung.Text = "Tìm Kiếm Tài Khoản";
            // 
            // txtDsChung
            // 
            txtDsChung.Location = new System.Drawing.Point(20, 28);
            txtDsChung.Name = "txtDsChung";
            txtDsChung.Size = new System.Drawing.Size(367, 23);
            txtDsChung.TabIndex = 0;
            txtDsChung.TextChanged += txtDsChung_TextChanged_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label8.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label8.Location = new System.Drawing.Point(1016, 123);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(374, 28);
            label8.TabIndex = 18;
            label8.Text = "Quản Lý Thông Tin Người Dùng";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Verdana", 10.8F);
            label7.Location = new System.Drawing.Point(1029, 269);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(95, 22);
            label7.TabIndex = 17;
            label7.Text = "Password";
            // 
            // txtPass
            // 
            txtPass.Location = new System.Drawing.Point(1029, 302);
            txtPass.Name = "txtPass";
            txtPass.Size = new System.Drawing.Size(361, 23);
            txtPass.TabIndex = 16;
            // 
            // btnSua
            // 
            btnSua.BackColor = System.Drawing.Color.Yellow;
            btnSua.Font = new System.Drawing.Font("Tahoma", 10.2F);
            btnSua.Location = new System.Drawing.Point(1148, 744);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(125, 82);
            btnSua.TabIndex = 15;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = System.Drawing.Color.Red;
            btnXoa.Font = new System.Drawing.Font("Tahoma", 10.2F);
            btnXoa.ForeColor = System.Drawing.Color.White;
            btnXoa.Location = new System.Drawing.Point(1279, 744);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(111, 82);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = System.Drawing.Color.Green;
            btnThem.Font = new System.Drawing.Font("Tahoma", 10.2F);
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.Location = new System.Drawing.Point(1029, 744);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(113, 82);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtGmail
            // 
            txtGmail.Location = new System.Drawing.Point(1029, 694);
            txtGmail.Name = "txtGmail";
            txtGmail.Size = new System.Drawing.Size(361, 23);
            txtGmail.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Verdana", 10.8F);
            label6.Location = new System.Drawing.Point(1029, 661);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(63, 22);
            label6.TabIndex = 11;
            label6.Text = "Gmail";
            // 
            // dtNgaySinh
            // 
            dtNgaySinh.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dtNgaySinh.Location = new System.Drawing.Point(1029, 618);
            dtNgaySinh.Name = "dtNgaySinh";
            dtNgaySinh.Size = new System.Drawing.Size(355, 23);
            dtNgaySinh.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Verdana", 10.8F);
            label5.Location = new System.Drawing.Point(1029, 586);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(101, 22);
            label5.TabIndex = 9;
            label5.Text = "Ngày Sinh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Verdana", 10.8F);
            label4.Location = new System.Drawing.Point(1029, 501);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(75, 22);
            label4.TabIndex = 8;
            label4.Text = "Địa Chỉ";
            // 
            // cbbDiaChi
            // 
            cbbDiaChi.FormattingEnabled = true;
            cbbDiaChi.Items.AddRange(new object[] { "An Giang", "Bà Rịa-Vũng Tàu", "Bạc Liêu", "Bắc Giang", "Bắc Kạn", "Bắc Ninh", "Bến Tre", "Bình Dương", "Bình Định", "Bình Phước", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Cần Thơ", "Con Dao (huyện đảo)", "Đà Nẵng", "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nội", "Hà Nam", "Hải Dương", "Hải Phòng", "Hòa Bình", "Hậu Giang", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên-Huế", "Tiền Giang", "Trà Vinh", "Vĩnh Long", "Vĩnh Phúc", "Hồ Chí Minh" });
            cbbDiaChi.Location = new System.Drawing.Point(1029, 536);
            cbbDiaChi.Name = "cbbDiaChi";
            cbbDiaChi.Size = new System.Drawing.Size(355, 24);
            cbbDiaChi.TabIndex = 7;
            // 
            // cbbGioiTinh
            // 
            cbbGioiTinh.FormattingEnabled = true;
            cbbGioiTinh.Items.AddRange(new object[] { "Nam ", "Nữ", "Khác" });
            cbbGioiTinh.Location = new System.Drawing.Point(1029, 451);
            cbbGioiTinh.Name = "cbbGioiTinh";
            cbbGioiTinh.Size = new System.Drawing.Size(355, 24);
            cbbGioiTinh.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 10.8F);
            label3.Location = new System.Drawing.Point(1029, 428);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 22);
            label3.TabIndex = 5;
            label3.Text = "Giới Tính";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new System.Drawing.Point(1029, 381);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new System.Drawing.Size(361, 23);
            txtHoTen.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 10.8F);
            label2.Location = new System.Drawing.Point(1029, 348);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(74, 22);
            label2.TabIndex = 3;
            label2.Text = "Họ Tên";
            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(1029, 212);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(361, 23);
            txtUsername.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 10.8F);
            label1.Location = new System.Drawing.Point(1029, 179);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(102, 22);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // dgvDSC
            // 
            dgvDSC.AllowUserToAddRows = false;
            dgvDSC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSC.BackgroundColor = System.Drawing.Color.White;
            dgvDSC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDSC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { clmGUserName, clmHoTen, clmGioiTinh, clmDiaChi, clmBirthDay, clmGmail });
            dgvDSC.Location = new System.Drawing.Point(13, 6);
            dgvDSC.Name = "dgvDSC";
            dgvDSC.RowHeadersWidth = 51;
            dgvDSC.Size = new System.Drawing.Size(962, 959);
            dgvDSC.TabIndex = 0;
            dgvDSC.CellClick += dgvDSC_CellClick;
            // 
            // clmGUserName
            // 
            clmGUserName.HeaderText = "UserName";
            clmGUserName.MinimumWidth = 6;
            clmGUserName.Name = "clmGUserName";
            clmGUserName.ReadOnly = true;
            // 
            // clmHoTen
            // 
            clmHoTen.HeaderText = "Họ Tên";
            clmHoTen.MinimumWidth = 6;
            clmHoTen.Name = "clmHoTen";
            clmHoTen.ReadOnly = true;
            // 
            // clmGioiTinh
            // 
            clmGioiTinh.HeaderText = "Giới Tính";
            clmGioiTinh.MinimumWidth = 6;
            clmGioiTinh.Name = "clmGioiTinh";
            clmGioiTinh.ReadOnly = true;
            // 
            // clmDiaChi
            // 
            clmDiaChi.HeaderText = "Địa Chỉ";
            clmDiaChi.MinimumWidth = 6;
            clmDiaChi.Name = "clmDiaChi";
            clmDiaChi.ReadOnly = true;
            // 
            // clmBirthDay
            // 
            clmBirthDay.HeaderText = "Ngày Tháng Năm Sinh";
            clmBirthDay.MinimumWidth = 6;
            clmBirthDay.Name = "clmBirthDay";
            clmBirthDay.ReadOnly = true;
            // 
            // clmGmail
            // 
            clmGmail.HeaderText = "Gmail";
            clmGmail.MinimumWidth = 6;
            clmGmail.Name = "clmGmail";
            clmGmail.ReadOnly = true;
            // 
            // tbDanhSach
            // 
            tbDanhSach.Appearance.BackColor = System.Drawing.Color.White;
            tbDanhSach.Appearance.Options.UseBackColor = true;
            tbDanhSach.Location = new System.Drawing.Point(19, 145);
            tbDanhSach.Name = "tbDanhSach";
            tbDanhSach.SelectedTabPage = xtraTabPage2;
            tbDanhSach.Size = new System.Drawing.Size(1413, 889);
            tbDanhSach.TabIndex = 0;
            tbDanhSach.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2, xtraTabPage3, xtraTabPage4 });
            tbDanhSach.TabStop = false;
            tbDanhSach.SelectedPageChanged += tbDanhSach_SelectedPageChanged;
            // 
            // xtraTabPage3
            // 
            xtraTabPage3.Controls.Add(label11);
            xtraTabPage3.Controls.Add(btnThangThai);
            xtraTabPage3.Controls.Add(groupBox1);
            xtraTabPage3.Controls.Add(dgvMatchs);
            xtraTabPage3.Name = "xtraTabPage3";
            xtraTabPage3.Size = new System.Drawing.Size(1411, 859);
            xtraTabPage3.Text = "Đã Matchs";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label11.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label11.Location = new System.Drawing.Point(1118, 153);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(280, 28);
            label11.TabIndex = 25;
            label11.Text = "Những người đã match";
            // 
            // btnThangThai
            // 
            btnThangThai.BackColor = System.Drawing.Color.Navy;
            btnThangThai.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnThangThai.ForeColor = System.Drawing.Color.White;
            btnThangThai.Location = new System.Drawing.Point(1098, 239);
            btnThangThai.Name = "btnThangThai";
            btnThangThai.Size = new System.Drawing.Size(310, 93);
            btnThangThai.TabIndex = 24;
            btnThangThai.Text = "Xóa Trạng Thái";
            btnThangThai.UseVisualStyleBackColor = false;
            btnThangThai.Click += btnThangThai_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.Navy;
            groupBox1.Controls.Add(txtTimKiemMatchs);
            groupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(1098, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(310, 76);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm Kiếm Tài Khoản";
            // 
            // txtTimKiemMatchs
            // 
            txtTimKiemMatchs.Location = new System.Drawing.Point(17, 31);
            txtTimKiemMatchs.Name = "txtTimKiemMatchs";
            txtTimKiemMatchs.Size = new System.Drawing.Size(283, 23);
            txtTimKiemMatchs.TabIndex = 0;
            txtTimKiemMatchs.TextChanged += txtTimKiemMatchs_TextChanged;
            // 
            // dgvMatchs
            // 
            dgvMatchs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvMatchs.BackgroundColor = System.Drawing.Color.White;
            dgvMatchs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatchs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { clmMatchID, clmNguoiGui, clmNguoiNhan, clmTrangThai });
            dgvMatchs.Location = new System.Drawing.Point(40, 39);
            dgvMatchs.Name = "dgvMatchs";
            dgvMatchs.RowHeadersWidth = 51;
            dgvMatchs.Size = new System.Drawing.Size(1052, 920);
            dgvMatchs.TabIndex = 0;
            // 
            // clmMatchID
            // 
            clmMatchID.HeaderText = "Mã Matchs";
            clmMatchID.MinimumWidth = 6;
            clmMatchID.Name = "clmMatchID";
            // 
            // clmNguoiGui
            // 
            clmNguoiGui.HeaderText = "Người Gửi";
            clmNguoiGui.MinimumWidth = 6;
            clmNguoiGui.Name = "clmNguoiGui";
            // 
            // clmNguoiNhan
            // 
            clmNguoiNhan.HeaderText = "Người Nhận";
            clmNguoiNhan.MinimumWidth = 6;
            clmNguoiNhan.Name = "clmNguoiNhan";
            // 
            // clmTrangThai
            // 
            clmTrangThai.HeaderText = "Trạng Thái";
            clmTrangThai.MinimumWidth = 6;
            clmTrangThai.Name = "clmTrangThai";
            // 
            // xtraTabPage4
            // 
            xtraTabPage4.Controls.Add(label10);
            xtraTabPage4.Controls.Add(btnSuaAnh);
            xtraTabPage4.Controls.Add(btnXoaAnh);
            xtraTabPage4.Controls.Add(groupBox3);
            xtraTabPage4.Controls.Add(dgvImage);
            xtraTabPage4.Name = "xtraTabPage4";
            xtraTabPage4.Size = new System.Drawing.Size(1411, 859);
            xtraTabPage4.Text = "Hình Ảnh";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label10.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label10.Location = new System.Drawing.Point(1132, 126);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(257, 28);
            label10.TabIndex = 23;
            label10.Text = "Hình ảnh người dùng";
            // 
            // btnSuaAnh
            // 
            btnSuaAnh.BackColor = System.Drawing.Color.Green;
            btnSuaAnh.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold);
            btnSuaAnh.ForeColor = System.Drawing.Color.White;
            btnSuaAnh.Location = new System.Drawing.Point(1108, 380);
            btnSuaAnh.Name = "btnSuaAnh";
            btnSuaAnh.Size = new System.Drawing.Size(300, 60);
            btnSuaAnh.TabIndex = 22;
            btnSuaAnh.Text = "Sửa Ảnh";
            btnSuaAnh.UseVisualStyleBackColor = false;
            btnSuaAnh.Click += btnSuaAnh_Click;
            // 
            // btnXoaAnh
            // 
            btnXoaAnh.BackColor = System.Drawing.Color.Teal;
            btnXoaAnh.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold);
            btnXoaAnh.ForeColor = System.Drawing.Color.White;
            btnXoaAnh.Location = new System.Drawing.Point(1108, 289);
            btnXoaAnh.Name = "btnXoaAnh";
            btnXoaAnh.Size = new System.Drawing.Size(300, 57);
            btnXoaAnh.TabIndex = 21;
            btnXoaAnh.Text = "Xóa Ảnh";
            btnXoaAnh.UseVisualStyleBackColor = false;
            btnXoaAnh.Click += btnXoaAnh_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = System.Drawing.Color.Navy;
            groupBox3.Controls.Add(txtImgaes);
            groupBox3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox3.ForeColor = System.Drawing.Color.White;
            groupBox3.Location = new System.Drawing.Point(1108, 34);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(300, 76);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tìm Kiếm Tài Khoản";
            // 
            // txtImgaes
            // 
            txtImgaes.Location = new System.Drawing.Point(13, 33);
            txtImgaes.Name = "txtImgaes";
            txtImgaes.Size = new System.Drawing.Size(276, 23);
            txtImgaes.TabIndex = 0;
            txtImgaes.TextChanged += txtImgaes_TextChanged;
            // 
            // dgvImage
            // 
            dgvImage.AllowUserToAddRows = false;
            dgvImage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvImage.BackgroundColor = System.Drawing.Color.White;
            dgvImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvImage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { clmChuTaiKhoan, clmImage, clmAvt });
            dgvImage.Location = new System.Drawing.Point(50, 34);
            dgvImage.Name = "dgvImage";
            dgvImage.RowHeadersWidth = 51;
            dgvImage.RowTemplate.Height = 200;
            dgvImage.Size = new System.Drawing.Size(1052, 920);
            dgvImage.TabIndex = 1;
            // 
            // clmChuTaiKhoan
            // 
            clmChuTaiKhoan.HeaderText = "UserName";
            clmChuTaiKhoan.MinimumWidth = 6;
            clmChuTaiKhoan.Name = "clmChuTaiKhoan";
            // 
            // clmImage
            // 
            clmImage.HeaderText = "Ảnh";
            clmImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            clmImage.MinimumWidth = 6;
            clmImage.Name = "clmImage";
            // 
            // clmAvt
            // 
            clmAvt.HeaderText = "AvatarID";
            clmAvt.MinimumWidth = 6;
            clmAvt.Name = "clmAvt";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Navy;
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1782, 125);
            panel1.TabIndex = 1;
            // 
            // DanhSachUsers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panel1);
            Controls.Add(tbDanhSach);
            Name = "DanhSachUsers";
            Size = new System.Drawing.Size(1782, 1071);
            Load += DanhSachUsers_Load;
            xtraTabPage2.ResumeLayout(false);
            xtraTabPage2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccountList).EndInit();
            xtraTabPage1.ResumeLayout(false);
            xtraTabPage1.PerformLayout();
            gbSearchDSChung.ResumeLayout(false);
            gbSearchDSChung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDSC).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDanhSach).EndInit();
            tbDanhSach.ResumeLayout(false);
            xtraTabPage3.ResumeLayout(false);
            xtraTabPage3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMatchs).EndInit();
            xtraTabPage4.ResumeLayout(false);
            xtraTabPage4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.DataGridView dgvAccountList;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.DataGridView dgvDSC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBirthDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGmail;
        private DevExpress.XtraTab.XtraTabControl tbDanhSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtGmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbDiaChi;
        private System.Windows.Forms.ComboBox cbbGioiTinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnXoaTaiKhoan;
        private System.Windows.Forms.GroupBox gbSearchDSChung;
        private System.Windows.Forms.TextBox txtDsChung;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtGiamSat;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private System.Windows.Forms.DataGridView dgvMatchs;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNguoiGui;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNguoiNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTrangThai;
        private System.Windows.Forms.DataGridView dgvImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChuTaiKhoan;
        private System.Windows.Forms.DataGridViewImageColumn clmImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAvt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtImgaes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimKiemMatchs;
        private System.Windows.Forms.Button btnSuaAnh;
        private System.Windows.Forms.Button btnThangThai;
        private System.Windows.Forms.Button btnXoaAnh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBlocked;
    }
}
