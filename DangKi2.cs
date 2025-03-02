
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformGUI.models;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinformGUI
{
    public partial class DangKi2 : UserControl
    {
        public string username_session { get; set; }
        public string password_session { get; set; }
        public DangKi2()
        {
            InitializeComponent();

        }
       
        public event EventHandler QuayLaiClicked;
        private void btnBack_Click(object sender, EventArgs e)
        {
            QuayLaiClicked?.Invoke(this, EventArgs.Empty);
        }
        private bool IsOver18(DateTime birthDate)
        {
            // Tính tuổi
            int age = DateTime.Now.Year - birthDate.Year;

            // Kiểm tra nếu ngày sinh nhật chưa tới trong năm nay
            if (birthDate.Date > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            // Trả về true nếu trên hoặc đủ 18 tuổi, ngược lại trả về false
            return age >= 18;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string hoVaTen = txt_hovaten.Text.Trim();
                string gmail = txt_gmail.Text.Trim();
                string gioiTinh = cbb_gioitinh.Text.Trim();
                string diaChi = cbb_noio.Text.Trim();
                DateTime ngaySinh = dtp_ngaysinh.Value;

                bool isOver18 = IsOver18(ngaySinh);
                if (string.IsNullOrEmpty(hoVaTen))
                {
                    MessageBox.Show("vui lòng nhập họ và tên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               if (string.IsNullOrEmpty(gmail))
                {
                    MessageBox.Show("vui lòng gmail", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsValidEmail(gmail))
                {
                    MessageBox.Show("Email không hợp lệ. Vui lòng nhập đúng định dạng email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (isOver18 == false)
                {
                    MessageBox.Show("vui lòng chọn ngày sinh trên 18", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool isRegistered = await RegisterUserWithFirebase(gmail, password_session);
                DialogResult result = DialogResult.None;
                if (isRegistered)
                {
                    
                    using (var db = new Model1())
                    {   
                        var user = new Userr
                        {
                            account_name = username_session,
                            password = password_session,
                            Status  = "normal"
                        };
                        db.Userrs.Add(user);
                        db.SaveChanges();
                        var info_user = new thong_tin_user
                        {
                            account_name = username_session,
                            gioitinh = gioiTinh,
                            gmail = gmail,
                            hovaten = hoVaTen,
                            ngaysinh = ngaySinh,
                            diachi = diaChi

                        };
                        db.thong_tin_user.Add(info_user);
                        db.SaveChanges();
                        SaveDefaultImage();
                    }
                    
                     result = MessageBox.Show("đăng ký thành công", "thông báo", MessageBoxButtons.OK);
                    
                    
                }
                if (result == DialogResult.OK)
                {
                    if (ParentForm != null)
                    {
                        ParentForm.Close();
                    }
                    this.Hide();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void SaveDefaultImage()
        {
            string defaultImagePath = @"D:\C# Can Ban\WinformGUI\WinformGUI\img\user.jpg";

    // Kiểm tra nếu ảnh mặc định có tồn tại
    if (!File.Exists(defaultImagePath))
    {
        MessageBox.Show("Không tìm thấy ảnh mặc định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    // Đọc dữ liệu ảnh vào mảng byte[]
    byte[] imageBytes;
    using (FileStream fs = new FileStream(defaultImagePath, FileMode.Open, FileAccess.Read))
    {
        using (BinaryReader br = new BinaryReader(fs))
        {
            imageBytes = br.ReadBytes((int)fs.Length);
        }
    }

    // Lưu ảnh vào cơ sở dữ liệu
    using (var context = new Model1())
    {
        var image = new Images
        {
            account_name = username_session, // Tên tài khoản
            ImageData = imageBytes,           // Dữ liệu ảnh
            Status = "default"
        };

        context.Images.Add(image);
        context.SaveChanges();
    }
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
        private const string FirebaseApiKey = "AIzaSyBerr-A5A7Nc6V4GGpSdhBUA76tAM-VE8Y";
        private async Task<bool> RegisterUserWithFirebase(string username, string password)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={FirebaseApiKey}";

            var payload = new
            {
                email = txt_gmail.Text.Trim(),
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
                        return true; // Đăng ký thành công
                    }
                    else
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Đăng ký thất bại: {responseBody}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến Firebase: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_hovaten_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
