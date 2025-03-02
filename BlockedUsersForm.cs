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

namespace WinformGUI
{
    public partial class BlockedUsersForm : UserControl
    {
        public string CurrentUserId { get; set; }
        public BlockedUsersForm(string currentUserId)
        {
            InitializeComponent();
            CurrentUserId = currentUserId;
        }
        

        private void BlockedUsersForm_Load(object sender, EventArgs e)
        {
            LoadBlockedUsers();
        }
        private void LoadBlockedUsers()
        {
            flowBlockedUsers.Controls.Clear(); // Xóa danh sách cũ

            using (var context = new Model1())
            {
                // Lấy danh sách người dùng bị chặn
                var blockedUsers = context.blocks
                    .Where(b => b.SenderId == CurrentUserId) // Chỉ lấy người bị bạn chặn
                    .Select(b => b.ReceiverId)
                    .Distinct()
                    .ToList();

                foreach (var userId in blockedUsers)
                {
                    // Lấy thông tin người dùng
                    var user = context.thong_tin_user.FirstOrDefault(u => u.account_name == userId);
                    var imageRecord = context.Images.FirstOrDefault(i => i.account_name == userId);

                    if (user != null)
                    {
                        // Tạo Panel cho từng user
                        Panel userPanel = new Panel
                        {
                            Width = flowBlockedUsers.Width - 25,
                            Height = 80,
                            Margin = new Padding(5),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Ảnh đại diện
                        PictureBox avatar = new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Width = 60,
                            Height = 60,
                            Left = 5,
                            Top = 10

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
                        else
                        {
                            // Ảnh mặc định nếu không có ảnh
                            //avatar.Image = Properties.Resources.DefaultAvatar; // Thay bằng ảnh mặc định
                        }

                        // Tên người dùng
                        Label nameLabel = new Label
                        {
                            Text = user.hovaten,
                            AutoSize = true,
                            Left = 75,
                            Top = 20,
                            Font = new Font("Arial", 12, FontStyle.Regular)
                        };

                        // Nút bỏ chặn
                        Button unblockButton = new Button
                        {
                            Text = "Bỏ chặn",
                            Width = 80,
                            Height = 30,
                            Left = flowBlockedUsers.Width - 110,
                            Top = 20,
                            BackColor = Color.LightCoral,
                            FlatStyle = FlatStyle.Flat
                        };
                        unblockButton.Click += (sender, e) => UnblockUser(userId, userPanel);

                        // Thêm các thành phần vào Panel
                        userPanel.Controls.Add(avatar);
                        userPanel.Controls.Add(nameLabel);
                        userPanel.Controls.Add(unblockButton);

                        // Thêm Panel vào FlowLayoutPanel
                        flowBlockedUsers.Controls.Add(userPanel);
                    }
                }
            }
        }

        private void UnblockUser(string userId, Panel userPanel)
        {
            // Xác nhận trước khi bỏ chặn
            var result = MessageBox.Show($"Bạn có chắc muốn bỏ chặn không?",
                                         "Xác nhận",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (var context = new Model1())
                {
                    // Xóa người dùng khỏi bảng Block
                    var block = context.blocks.FirstOrDefault(b => b.SenderId == CurrentUserId && b.ReceiverId == userId);
                    if (block != null)
                    {
                        context.blocks.Remove(block);
                        context.SaveChanges();

                        // Xóa Panel tương ứng khỏi FlowLayoutPanel
                        flowBlockedUsers.Controls.Remove(userPanel);
                        //MessageBox.Show("Đã bỏ chặn người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                MainScreen mainScreen = Application.OpenForms.OfType<MainScreen>().FirstOrDefault();
                if (mainScreen != null)
                {
                    mainScreen.ReloadMainScreen(); // Gọi phương thức reload trong MainScreen
                }
            }

        }
    }
}
