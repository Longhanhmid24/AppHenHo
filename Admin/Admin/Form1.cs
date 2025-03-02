using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Admin.UserControl;
using DevExpress.XtraEditors;
using AdminDB.Model;

namespace Admin
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {


        public Form1()
        {
            InitializeComponent();

        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.TopMost = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo trước khi thoát chương trình
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát chương trình
            }
        }


        private void ShowUserControl(XtraUserControl xtraUser)
        {
            plControl.Controls.Clear(); // Xóa tất cả các control bên trong plControl
            xtraUser.Dock = DockStyle.Fill; // Đặt Dock để UserControl chiếm toàn bộ diện tích plControl
            plControl.Controls.Add(xtraUser); // Thêm UserControl vào plControl
            xtraUser.Show();
        }

        private void btnDsUsers_Click(object sender, EventArgs e)
        {
            ShowUserControl(new DanhSachUsers());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ShowUserControl(new ThongKe());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            ShowUserControl(new BaoCao());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.KeyPreview = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Import__Excel());
        }
    }
}
