using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformGUI.models;
using System.IO;
using DbMessage = WinformGUI.models.Message;

using System.Drawing.Drawing2D;

namespace WinformGUI
{
    public partial class Messenger : UserControl
    {
        Block Chan;
        Report BaoCao;
        public Messenger()
        {
            InitializeComponent();
            rtxtMessage.KeyDown += rtxtMessage_KeyDown;
        }
        public string username_session_receiver { get; set; }
        public string username_session_sender { get; set; }
        private void X_Click(object sender, EventArgs e)
        {
            Chan = new Block();
            Chan.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BaoCao = new Report();
            BaoCao.Show();

        }
        private void load_AVT()
        {
            using (var db = new Model1())
            {
                var imageEntity = db.Images.FirstOrDefault(i => i.account_name == username_session_receiver);
                var name = db.thong_tin_user.FirstOrDefault(i => i.account_name == username_session_receiver);
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
                        lb_name.Text = name.hovaten;
                    }
                }
            }

        }
        private void BlockUser()
        {
            using (var db = new Model1())
            {
                // Thêm người dùng vào bảng chặn
                var blockEntry = new block
                {
                    SenderId = username_session_sender, // Tên đăng nhập của người gửi
                    ReceiverId = username_session_receiver // Tên đăng nhập của người nhận
                };
                db.blocks.Add(blockEntry);
                db.SaveChanges();
            }

            // Gọi MainScreen để cập nhật giao diện và xóa người dùng bị chặn
            // Gọi MainScreen để xóa người dùng bị chặn khỏi giao diện
            MainScreen mainScreen = Application.OpenForms.OfType<MainScreen>().FirstOrDefault();
            if (mainScreen != null)
            {
                mainScreen.ReloadMainScreen(); // Gọi phương thức reload trong MainScreen
                mainScreen.OpenMessenger(mainScreen.firstUserId);
            }

            this.Dispose(); // Đóng form tin nhắn
        }

        private void Messenger_Load(object sender, EventArgs e)
        {
            load_AVT();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn chặn người dùng này không?",
                "chặn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Nếu người dùng chọn "No", thoát khỏi hàm
            if (result == DialogResult.No)
            {
                return;
            }

            using (var context = new Model1())
            {
                // Lưu thông tin người bị block
                var block = new block
                {
                    SenderId = username_session_sender,
                    ReceiverId = username_session_receiver
                };

                context.blocks.Add(block);
                context.SaveChanges();
            }

            // Reload MainScreen và lấy user đầu tiên để mở tin nhắn
            MainScreen mainScreen = Application.OpenForms.OfType<MainScreen>().FirstOrDefault();
            if (mainScreen != null)
            {
                mainScreen.ReloadMainScreen(); // Gọi lại hàm load danh sách
            }
            if (result == DialogResult.Yes)
            {
                BlockUser();  // Gọi phương thức BlockUser
            }
        }
        private void rtxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu phím nhấn là Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Ngăn RichTextBox xuống dòng
                e.SuppressKeyPress = true;

                // Gọi sự kiện nhấn nút Gửi
                btnGuiTInNhan_Click(sender, e);
            }
        }
        private void btnGuiTInNhan_Click(object sender, EventArgs e)
        {
            // Lấy nội dung tin nhắn từ RichTextBox
            string messageContent = rtxtMessage.Text.Trim();

            // Kiểm tra nếu nội dung tin nhắn rỗng
            if (string.IsNullOrEmpty(messageContent))
            {
                MessageBox.Show("Vui lòng nhập nội dung tin nhắn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu tin nhắn vào cơ sở dữ liệu
            using (var db = new Model1())
            {
                var message = new DbMessage
                {
                    Sender = username_session_sender,
                    Receiver = username_session_receiver,
                    Content = messageContent,
                    Timestamp = DateTime.Now
                };
                db.Messages.Add(message);
                db.SaveChanges();
            }

            // Hiển thị tin nhắn trong giao diện (bên phải cho người gửi)
            AddMessageToUI(messageContent, true);

            // Xóa nội dung trong RichTextBox sau khi gửi
            rtxtMessage.Clear();

        }
        private void AddMessageToUI(string messageContent, bool isSender)
        {
            // Tạo Panel chứa tin nhắn
            Panel messagePanel = new Panel();
            messagePanel.AutoSize = true;
            messagePanel.Padding = new Padding(5);
            messagePanel.Margin = new Padding(5);
            messagePanel.MaximumSize = new Size(flHienThiTinNhan.Width - 100, 0); // Giới hạn chiều rộng

            // Tạo Label hiển thị nội dung tin nhắn
            Label messageLabel = new Label();
            messageLabel.Text = messageContent;
            messageLabel.AutoSize = true;
            messageLabel.MaximumSize = new Size(280, 0);
            messageLabel.Padding = new Padding(10);
            messageLabel.Font = new Font("Arial", 10, FontStyle.Regular);

            // Tạo layout cho vị trí tin nhắn
            TableLayoutPanel messageContainer = new TableLayoutPanel();
            messageContainer.ColumnCount = 20;  // Tạo 20 cột
            messageContainer.AutoSize = true;
            messageContainer.Dock = DockStyle.Top;
            messageContainer.Padding = new Padding(5);

            // Định nghĩa tỉ lệ cột
            for (int i = 0; i < 20; i++)
            {
                if (isSender)
                {
                    messageContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, i < 18 ? 5F : 0F));  // 95% bên trái, 5% chứa tin nhắn
                }
                else
                {
                    messageContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, i == 0 ? 5F : 0F));  // Tin nhắn ở cột đầu, 95% bên phải
                }
            }

            // Căn chỉnh vị trí tin nhắn
            if (isSender)
            {
                messageLabel.BackColor = Color.LightBlue;


                for (int i = 0; i < 1; i++)
                {
                    messageContainer.Controls.Add(new Label(), i, 0);
                }

                messageContainer.Controls.Add(messageLabel, 5, 0);
            }
            else
            {
                messageLabel.BackColor = Color.LightGray;


                messageContainer.Controls.Add(messageLabel, 0, 0);

                // Thêm khoảng trắng bên phải
                for (int i = 1; i < 20; i++)
                {
                    messageContainer.Controls.Add(new Label(), i, 0);
                }
            }

            // Thêm vào FlowLayoutPanel
            flHienThiTinNhan.Controls.Add(messageContainer);
            flHienThiTinNhan.Controls.SetChildIndex(messageContainer, 0);  // Đẩy lên đầu

            // Cuộn đến tin nhắn mới nhất
            flHienThiTinNhan.ScrollControlIntoView(messageContainer);
        }
    
        private void LoadMessages()
        {
            flHienThiTinNhan.Controls.Clear();

            using (var db = new Model1())
            {
                var messages = db.Messages
                    .Where(m => (m.Sender == username_session_sender && m.Receiver == username_session_receiver) ||
                                (m.Sender == username_session_receiver && m.Receiver == username_session_sender))
                    .OrderBy(m => m.Timestamp)
                    .ToList();

                foreach (var message in messages)
                {
                    bool isSender = message.Sender == username_session_sender;
                    AddMessageToUI(message.Content, isSender);
                }
            }
        }
      

        private void Messenger_Load_1(object sender, EventArgs e)
        {
            load_AVT();
            LoadMessages();
            timer1.Interval = 3000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadMessages();
        }
    }
}