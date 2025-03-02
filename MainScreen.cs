using DevExpress.Drawing.Internal.Fonts.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformGUI.models;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace WinformGUI
{
    public partial class MainScreen : Form
    {
        public string username_session { get; set; }
        DangBai dangBai;
        public MainScreen()
        {
            InitializeComponent();

        }
        private void MainScreen_Load(object sender, EventArgs e)
        {

            btnTuongHop_Click(sender, e);
            LoadAVT();
        }
        private void LoadAVT()
        {
            using (var db = new Model1())
            {
                var imageEntity = db.Images.FirstOrDefault(i => i.account_name == username_session);

                // Kiểm tra nếu có hình ảnh và hiển thị
                if (imageEntity != null && imageEntity.ImageData != null)
                {
                    byte[] imageData = imageEntity.ImageData;

                    // Chuyển mảng byte thành Image và hiển thị lên PictureBox
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Cursor = Cursors.Hand;
                        GraphicsPath path = new GraphicsPath();
                        path.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.Region = new Region(path);
                    }
                    dangBai = new DangBai
                    {
                        id_AVT = imageEntity.id_avt.ToString(),
                    };
                }
                pictureBox1.Click += pictureBox1_Click;
            }

        }

        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Tạo bản sao của hình ảnh để tránh lỗi GDI
                using (var clonedImage = new Bitmap(image))
                {
                    clonedImage.Save(ms, image.RawFormat);
                }
                return ms.ToArray();
            }

        }

        public string firstUserId = null;
        private void LoadMatchedUsers(string currentUserId)
        {
            using (var context = new Model1())
            {
                var matchedUsers = context.matchs
                    .Where(m => m.SenderID == currentUserId && m.Status == "matched" || m.ReceiverID == currentUserId && m.Status == "matched")
                    .Select(m => m.SenderID == currentUserId ? m.ReceiverID : m.SenderID)
                    .Distinct()
                    .ToList();

                // Loại bỏ các user đã bị block
                var blockedUsers = context.blocks
                    .Where(b => b.SenderId == currentUserId)
                    .Select(b => b.SenderId == currentUserId ? b.ReceiverId : b.SenderId)
                    .ToList();

                matchedUsers = matchedUsers.Except(blockedUsers).ToList();

                plHinhAnh.Controls.Clear(); // Xóa danh sách cũ trong FlowLayoutPanel

                if (matchedUsers.Count > 0)
                {
                    // Lấy user đầu tiên
                    firstUserId = matchedUsers[0];

                    // Tạo Panel cho từng user
                    foreach (var userId in matchedUsers)
                    {
                        var user = context.thong_tin_user.FirstOrDefault(u => u.account_name == userId);
                        if (user != null)
                        {
                            Panel userPanel = new Panel { Width = 200, Height = 60, Margin = new Padding(5) };
                            var imageRecord = context.Images.FirstOrDefault(i => i.account_name == user.account_name);

                            // Avatar
                            PictureBox avatar = new PictureBox
                            {
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Width = 50,
                                Height = 50,
                                Cursor = Cursors.Hand
                            };
                            GraphicsPath path = new GraphicsPath();
                            path.AddEllipse(0, 0, avatar.Width, avatar.Height);
                            avatar.Region = new Region(path);

                            if (imageRecord != null && imageRecord.ImageData != null)
                            {
                                using (var ms = new MemoryStream(imageRecord.ImageData))
                                {
                                    avatar.Image = Image.FromStream(ms);
                                }
                            }
                            avatar.Click += (sender, e) =>
                            {
                                OpenMessenger(user.account_name);
                            };

                            // Tên
                            Label nameLabel = new Label
                            {
                                Text = user.hovaten,
                                AutoSize = true,
                                Location = new Point(60, 20),
                                Cursor = Cursors.Hand,
                                Font = new Font("Arial", 10, FontStyle.Bold) // Cỡ chữ to và in đậm
                            };
                            nameLabel.Click += (sender, e) =>
                            {
                                OpenMessenger(user.account_name);
                            };

                            userPanel.Controls.Add(avatar);
                            userPanel.Controls.Add(nameLabel);

                            plHinhAnh.Controls.Add(userPanel);
                        }
                    }

                    // Mở tin nhắn với user đầu tiên
                    
                }
                else
                {
                    //MessageBox.Show("Không có người dùng nào trong danh sách matched.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Hàm mở form Messenger
        public void OpenMessenger(string receiverId)
        {
            var messenger = new Messenger
            {
                username_session_sender = username_session,
                username_session_receiver = receiverId
            };
            ShowsForm(messenger);
        }

        private void ShowsForm(UserControl form)
        {
            plNhanTin.Controls.Clear();

            form.Dock = DockStyle.Fill;
            form.Dock = DockStyle.None; // Hủy Dock mặc định nếu có
            form.Left = (plNhanTin.Width - form.Width) / 2;
            form.Top = (plNhanTin.Height - form.Height) / 2;
            plNhanTin.Controls.Add(form);
            form.Show();
        }

        private void btnTuongHop_Click(object sender, EventArgs e)
        {
            //ShowsForm(new Match());
            plHinhAnh.Controls.Clear();
            LoadMatchedUsers(username_session);
            Match match = new Match
            {
                username_session_match = username_session
            };
            match.OnReloadMain += ReloadMainScreen;
            ShowsForm(match);
        }
        public void ReloadMainScreen()
        {
            LoadMatchedUsers(username_session); // Gọi lại hàm load của MainScreen
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            plNhanTin.Controls.Clear();
            wall1 wall = new wall1
            {
                username_session_wall = username_session
            };
            wall.LoadUserImages();
            wall.OnUploadCompleted += LoadAVT;

            ShowsForm(wall);
        }

        private void btn_dangBai_Click(object sender, EventArgs e)
        {
            if (dangBai == null)
            {
                dangBai = new DangBai(); // Khởi tạo đối tượng nếu chưa được khởi tạo
            }
            plNhanTin.Controls.Clear();
            ShowsForm(dangBai);
        }

        private void btn_listBlock_Click(object sender, EventArgs e)
        {
            BlockedUsersForm blockedUsersForm = new BlockedUsersForm(username_session);
            ShowsForm(blockedUsersForm);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Logout()
        {
            string filePath = "login_state.txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath); // Xóa file
            }

            //MessageBox.Show("Đăng xuất thành công!");
            this.Hide();
            QuanLy quanLy = new QuanLy();
            quanLy.Show();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}