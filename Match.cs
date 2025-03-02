using DevExpress.Utils;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformGUI.models;
using static DevExpress.XtraEditors.Mask.MaskSettings;


namespace WinformGUI
{
    public partial class Match : UserControl
    {
        public event Action OnReloadMain;
        private byte[] imageByte;
        public string username_session_match { get; set; }
        private List<byte[]> userImages = new List<byte[]>(); // Danh sách ảnh của user
        private int currentImageIndex = 0;
        private int id_avt;
        public Match()
        {
            InitializeComponent();
        }

        private void Match_Load(object sender, EventArgs e)
        {

            LoadRandomUser();

        }
        public string ReceiverID { get; set; }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ReceiverID == null)
            {
                panel1.Controls.Clear();
                DisplayNoMoreUsers();
                return;
            }

            using (var db = new Model1())
            {
                // Kiểm tra quan hệ hiện có giữa hai người dùng
                var match = db.matchs
                    .FirstOrDefault(m =>
                        (m.SenderID == username_session_match && m.ReceiverID == ReceiverID) ||
                        (m.SenderID == ReceiverID && m.ReceiverID == username_session_match));

                if (match == null)
                {
                    // Trường hợp chưa có quan hệ, tạo mới với trạng thái Pending
                    match = new match
                    {
                        SenderID = username_session_match,
                        ReceiverID = ReceiverID,
                        Status = "pending"
                    };
                    db.matchs.Add(match);
                    db.SaveChanges();
                    //MessageBox.Show("Yêu cầu đã được gửi! Chờ phản hồi.", "Thông báo", MessageBoxButtons.OK);
                }

                else if (match.Status == "pending" && match.ReceiverID == username_session_match)
                {
                    // Trường hợp người kia đã gửi yêu cầu Pending, chuyển thành Matched
                    match.Status = "matched";
                    db.SaveChanges();
                    MessageBox.Show("Người này đã thích bạn. Cả hai có thể nhắn tin.", "Chúc hạnh phúc!", MessageBoxButtons.OK);
                    OnReloadMain?.Invoke(); // Gọi lại sự kiện tải chính
                }

                // Tải user mới
                LoadRandomUser();
            }
        }
        private void LoadRandomUser()
        {
            try
            {

                using (var context = new Model1())
                {
                    // Lấy danh sách các user cần loại trừ (Matched, Rejected hoặc Pending do bạn gửi)
                    var excludedUsers = context.matchs
                        .Where(m =>
                            (m.SenderID == username_session_match && m.Status == "rejected") ||
                            (m.ReceiverID == username_session_match && m.Status == "rejected") ||
                            (m.SenderID == username_session_match && m.Status == "matched") ||
                            (m.ReceiverID == username_session_match && m.Status == "matched") ||
                            (m.SenderID == username_session_match && m.Status == "pending")) // Bạn gửi yêu cầu pending
                        .Select(m => m.SenderID == username_session_match ? m.ReceiverID : m.SenderID)
                        .Distinct()
                        .ToList();

                    // Lấy danh sách các user đang pending mà họ gửi yêu cầu tới bạn
                    var pendingUsers = context.matchs
                        .Where(m => m.ReceiverID == username_session_match && m.Status == "pending") // Họ gửi yêu cầu pending
                        .Select(m => m.SenderID)
                        .Distinct()
                        .ToList();

                    // Lấy user ngẫu nhiên từ DB
                    var randomUser = context.Images
                        .Join(context.thong_tin_user,
                              img => img.account_name,
                              user => user.account_name,
                              (img, user) => new
                              {
                                  user.hovaten,
                                  img.ImageData,
                                  user.account_name,
                                  user.ngaysinh,
                                  user.diachi,
                                  user.gioitinh,
                                  img.id_avt,
                                  img.Status,
                              })
                        .Join(context.dang_anh, // Liên kết với bảng dang_anh
                              img => img.id_avt,
                              dangAnh => dangAnh.id_avt,
                              (img, dangAnh) => img) // Chỉ giữ thông tin từ Images
                         .Where(u =>
                            !excludedUsers.Contains(u.account_name) &&
                            u.account_name != username_session_match &&
                            u.Status != "default") // Loại bỏ những user có trạng thái mặc định
                        .OrderByDescending(u => pendingUsers.Contains(u.account_name) ? 1 : 0) // Ưu tiên pending
                        .ThenBy(r => Guid.NewGuid()) // Ngẫu nhiên với các user còn lại
                        .FirstOrDefault();



                    if (randomUser != null)
                    {
                        DisplayUser(randomUser);
                        id_avt = randomUser.id_avt;
                        LoadUserImages(); // Cập nhật hình ảnh hiện tại
                    }
                    else
                      // Nếu không còn người dùng ngẫu nhiên nào nữa
                    {
                        panel1.Controls.Clear();
                        DisplayNoMoreUsers(); 
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }      

        }
        private void LoadUserImages()
        {
            //int id = int.Parse(id_avt);
            using (var context = new Model1())
            {
                // Lấy danh sách ảnh từ database của user
                userImages = context.dang_anh
                    .Where(img => img.id_avt == id_avt)
                    .Select(img => img.images)
                    .ToList();

                if (userImages.Count > 0)
                {
                    currentImageIndex = 0; // Đặt lại chỉ số ảnh đầu tiên
                    DisplayImage(userImages[currentImageIndex]); // Hiển thị ảnh đầu tiên
                }
                else
                {
                    pictureBox3.Image = null; // Không có ảnh
                    //MessageBox.Show("User này không có ảnh nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void DisplayImage(byte[] imageData)
        {
            if (imageData == null)
            {
                pictureBox3.Image = null;
                return;
            }
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                pictureBox3.Image = Image.FromStream(ms);
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void DisplayUser(dynamic randomUser)
        {
            PictureBox userPicture = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = pictureBox1.Width,
                Height = pictureBox1.Height - 30,
                Dock = DockStyle.Top
            };

            if (randomUser.ImageData != null)
            {
                using (var ms = new MemoryStream(randomUser.ImageData))
                {
                    userPicture.Image = Image.FromStream(ms);
                }
            }

            pictureBox1.Controls.Clear();
            pictureBox1.Controls.Add(userPicture);
            lb_gioiTinh.Text = randomUser.gioitinh;
            lb_diaChi.Text = randomUser.diachi;
            lb_ngaySinh.Text = randomUser.ngaysinh != DateTime.MinValue
                        ? randomUser.ngaysinh.ToString("yyyy-MM-dd").Trim()
                        : string.Empty;
            lb_name.Text = randomUser.hovaten;

            ReceiverID = randomUser.account_name;
        }

        private void DisplayNoMoreUsers()
        {
            Label userNameLabel = new Label
            {
                Text = "mua premium để tiếp tục quẹt.",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Black
            };
            pictureBox3.Controls.Clear();
            pictureBox3.Image = null;
            pictureBox3.Controls.Add(userNameLabel);

            ReceiverID = null; // Ngăn các thao tác khác
            //LoadUserImages();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ReceiverID == null)
            {
                panel1.Controls.Clear();
                DisplayNoMoreUsers();
                return;
            }

            using (var context = new Model1())
            {
                var match = context.matchs
                    .FirstOrDefault(m =>
                        (m.SenderID == username_session_match && m.ReceiverID == ReceiverID) ||
                        (m.SenderID == ReceiverID && m.ReceiverID == username_session_match));

                if (match == null)
                {
                    // Tạo mới quan hệ với trạng thái Rejected
                    match = new match
                    {
                        SenderID = username_session_match,
                        ReceiverID = ReceiverID,
                        Status = "rejected"
                    };
                    context.matchs.Add(match);
                }
                else
                {
                    // Cập nhật trạng thái Rejected
                    match.Status = "rejected";
                }

                context.SaveChanges();
                //MessageBox.Show("Bạn đã từ chối người dùng này.", "Thông báo", MessageBoxButtons.OK);
            }

            LoadRandomUser(); // Tải user mới
            //LoadUserImages();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            if (ReceiverID == null)
            {
                return;
            }
            Report report = new Report();
            report.username_session_sender = username_session_match;
            report.username_session_report = ReceiverID;
            report.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userImages.Count == 0)
                return;

            currentImageIndex = (currentImageIndex + 1) % userImages.Count; // Tăng chỉ số (vòng tròn)
            DisplayImage(userImages[currentImageIndex]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (userImages.Count == 0)
                return;

            currentImageIndex = (currentImageIndex - 1 + userImages.Count) % userImages.Count; // Giảm chỉ số (vòng tròn)
            DisplayImage(userImages[currentImageIndex]);
        }
    }
}
