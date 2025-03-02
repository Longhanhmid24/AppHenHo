using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinformGUI
{
    public partial class Register : Form
    {
       
        public Register()
        {
            InitializeComponent();
        }


        private void ShowsForm(UserControl form)
        {   
            plDangKy.Controls.Clear();
            form.Dock = DockStyle.Fill;
            plDangKy.Controls.Add(form);
            form.Show();

        }

        private void Register_Load(object sender, EventArgs e)
        {
            // Khởi tạo các UserControl
            DangKi1 dangki1 = new DangKi1();
            DangKi2 dangki2 = new DangKi2();

            // Đăng ký sự kiện chuyển tiếp giữa các UserControl
            dangki1.KeTiepClicked += (s, ev) =>
            {
                ShowsForm(dangki2); // Hiển thị DangKi2
                dangki2.username_session = ev.Username;
                dangki2.password_session = ev.password;
            };

            dangki2.QuayLaiClicked += (s, ev) =>
            {
                ShowsForm(dangki1); // Quay lại DangKi1
            };

            // Hiển thị DangKi1 ban đầu
            ShowsForm(dangki1);
        }

        private void DangKi1_KeTiepClicked(object sender, EventArgs e)
        {
            DangKi2 dangki2 = new DangKi2();
            ShowsForm(dangki2);
        }

        private void DangKi12_QuayLaiClicked(object sender, EventArgs e)
        {
            DangKi1 dangki1 = new DangKi1();
            ShowsForm(dangki1);
        }

    }
}
