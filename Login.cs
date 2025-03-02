
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformGUI.models;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinformGUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txt_username.KeyDown += Txt_KeyDown;
            txt_password.KeyDown += Txt_KeyDown;
        }
        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick(); // Kích hoạt nút đăng nhập
                e.Handled = true;
                e.SuppressKeyPress = true; // Ngăn tiếng 'ding' mặc định của Windows
            }
        }

        private const string FirebaseApiKey = "AIzaSyBerr-A5A7Nc6V4GGpSdhBUA76tAM-VE8Y";
        public void Login_successful(string username)
        {
            MainScreen mainScreen = new MainScreen();
            mainScreen.username_session = username;
            mainScreen.Show();
            if (ParentForm != null)
            {
                ParentForm.Close();
            }
            this.Close();
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new Model1())
            {
                // Kiểm tra thông tin đăng nhập
                var user = db.Userrs.FirstOrDefault(u => u.account_name == username);
                if (user == null)
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (user.password == password && user.Status != "Blocked")
                {
                    Login_successful(username);
                    SaveLoginState(username, password);
                }else if (user.Status == "Blocked")
                {
                    MessageBox.Show("tài khoản của bạn đã bị khóa", "thông báo",MessageBoxButtons.OKCancel);
                }
                else
                {
                    var Email = db.thong_tin_user.FirstOrDefault(u => u.account_name == username);
                    bool isAuthenticatedWithFirebase = await AuthenticateWithFirebase(Email.gmail, password);
                    if (isAuthenticatedWithFirebase)
                    {
                        // Đồng bộ mật khẩu mới vào cơ sở dữ liệu
                        user.password = password;
                        db.SaveChanges();
                        Login_successful(username);
                    }
                    else
                    {
                        MessageBox.Show("mật khẩu không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
        private void SaveLoginState(string username, string password)
        {
            string filePath = "login_state.txt";

            // Ghi thông tin đăng nhập vào file
            File.WriteAllText(filePath, $"{username}|{password}");
        }
        private async Task<bool> AuthenticateWithFirebase(string email, string password)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={FirebaseApiKey}";

            var payload = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            using (var client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true; // Xác thực thành công
                    }
                    else
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Lỗi xác thực Firebase: {responseBody}");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            resetpass r = new resetpass();
            int x = this.Left + (this.Width - r.Width) / 2;
            int y = this.Top + (this.Height - r.Height) / 2;

            // Đặt vị trí của resetpass
            r.StartPosition = FormStartPosition.Manual;
            r.Location = new Point(x, y);
            r.ShowDialog();
            //this.Hide();
        }
    }
}
