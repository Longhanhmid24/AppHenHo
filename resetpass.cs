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

namespace WinformGUI
{
    public partial class resetpass : Form
    {
        public resetpass()
        {
            InitializeComponent();
        }
        private const string FirebaseApiKey = "AIzaSyBerr-A5A7Nc6V4GGpSdhBUA76tAM-VE8Y";
        private  void resetpass_Load(object sender, EventArgs e)
        {
            
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> SendPasswordResetEmail(string email)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={FirebaseApiKey}";

            var payload = new
            {
                requestType = "PASSWORD_RESET",
                email = email
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
                        return true;
                    }
                    else
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Lỗi: {responseBody}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



        private async void btnResetPassword_Click_1(object sender, EventArgs e)
        {

            string email = txt_gmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                lblStatus.Text = "Vui lòng nhập email!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!IsValidEmail(email))
            {
                lblStatus.Text = "Email không hợp lệ!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }
            using (var db = new Model1())
            {
                var info_email = db.thong_tin_user.FirstOrDefault(i => i.gmail == email);
                if (info_email != null)
                {
                    // Gửi yêu cầu đặt lại mật khẩu
                    bool isSuccessful = await SendPasswordResetEmail(email);
                    if (isSuccessful)
                    {
                        lblStatus.Text = "Đã gửi email đặt lại mật khẩu!";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblStatus.Text = "Gửi yêu cầu thất bại. Vui lòng thử lại!";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblStatus.Text = "email này chưa tạo tài khoản";
                }
            }
        }
    }
}
