using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformGUI.models;

namespace WinformGUI
{
    public partial class DangKi1 : UserControl
    {
        public DangKi1()
        {
            InitializeComponent();
        }
        public class KeTiepEventArgs : EventArgs
        {
            public string Username { get; }
            public string password { get; }
            public KeTiepEventArgs(string username, string password)
            {
                this.Username = username;
                this.password = password;
            }
        }
       
        public event EventHandler<KeTiepEventArgs> KeTiepClicked;
        private void btnNext_Click(object sender, EventArgs e)
        {

            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();
            if(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var db = new Model1())
            {
                var existingUser = db.Userrs.FirstOrDefault(u => u.account_name == username);
                if (existingUser != null)
                {
                    MessageBox.Show("Username đã tồn tại. Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //var newUser = new Userr
                //{
                //    account_name = username,
                //    password = password // Nên hash mật khẩu trước khi lưu
                //};

                //db.Userrs.Add(newUser);
                //db.SaveChanges();

                KeTiepClicked?.Invoke(this, new KeTiepEventArgs(username,password));

            }
            
        }
    }
}
