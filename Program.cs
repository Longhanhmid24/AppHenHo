using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformGUI.models;
using System.IO;

namespace WinformGUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            autoLogin();
        }

        /// <summary>
        /// Kiểm tra trạng thái đăng nhập từ file.
        /// </summary>
        /// <returns>Thông tin đăng nhập: username và password, hoặc (null, null) nếu không hợp lệ.</returns>
        static (string username, string password) CheckLoginState()
        {
            string filePath = "login_state.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    // Đọc thông tin đăng nhập từ file
                    string[] loginInfo = File.ReadAllText(filePath).Split('|');
                    if (loginInfo.Length == 2)
                    {
                        return (loginInfo[0], loginInfo[1]); // Trả về username và password
                    }
                }
                catch
                {
                    // Xử lý lỗi nếu file có vấn đề
                    MessageBox.Show("Lỗi khi đọc file login_state.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return (null, null); // Không có file hoặc file không hợp lệ
        }

        /// <summary>
        /// Thực hiện logic tự động đăng nhập hoặc điều hướng đến giao diện chính.
        /// </summary>
        static void autoLogin()
        {
            (string username, string password) = CheckLoginState();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                using (var db = new Model1())
                {
                    var user = db.Userrs.FirstOrDefault(u => u.account_name == username);

                    if (user != null && user.password == password)
                    {
                        MainScreen mainScreen = new MainScreen(); // Mở form chính
                                                                  // Nếu thông tin đăng nhập hợp lệ
                        mainScreen.username_session = username; // Gán thông tin đăng nhập
                        Application.Run(mainScreen);
                        return;
                    }
                }
            }

            // Nếu không hợp lệ hoặc không có file, điều hướng đến giao diện quản lý
            Application.Run(new QuanLy());
        }
    }
}
