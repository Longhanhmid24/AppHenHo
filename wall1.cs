using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformGUI.models;
using DrawingImage = System.Drawing.Image;
using ModelsImage = WinformGUI.models.Images;

namespace WinformGUI
{
    public partial class wall1 : UserControl
    {
        public string username_session_wall { get; set; }

        public wall1()
        {
            InitializeComponent();
        }
        public event Action OnUploadCompleted;
        private void LoadUserInfo()
        {
            using (var db = new Model1())
            {
                var imageEntity = db.Images.FirstOrDefault(i => i.account_name == username_session_wall);
                var user = db.thong_tin_user.FirstOrDefault(u => u.account_name == username_session_wall);

                if (user != null)
                {
                    // Hiển thị thông tin người dùng
                    txt_name.Text = user.hovaten;
                    txt_gmail.Text = user.gmail;
                    txt_gioiTinh.Text = user.gioitinh;
                    // Kiểm tra null cho ngaysinh
                    txt_ngaySinh.Text = user.ngaysinh.HasValue
                        ? user.ngaysinh.Value.ToString("yyyy-MM-dd").Trim()
                        : string.Empty;
                    txt_diachi.Text = user.diachi;
                }

                // Kiểm tra nếu có hình ảnh và hiển thị
                if (imageEntity != null && imageEntity.ImageData != null)
                {
                    byte[] imageData = imageEntity.ImageData;

                    // Chuyển mảng byte thành Image và hiển thị lên PictureBox
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        GraphicsPath path = new GraphicsPath();
                        path.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.Region = new Region(path);
                    }
                }
                else if (user == null)
                {
                    MessageBox.Show("Không tìm thấy người dùng.", "Thông báo", MessageBoxButtons.OK);
                }


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

        private void SaveUserInfo(string username_session_wall)
        {
            using (var context = new Model1())
            {
                var user = context.thong_tin_user.FirstOrDefault(u => u.account_name == username_session_wall);

                if (user != null)
                {
                    // Cập nhật thông tin cá nhân
                    user.hovaten = txt_name.Text.Trim();
                    user.gmail = txt_gmail.Text.Trim();
                    user.gioitinh = txt_gioiTinh.Text.Trim();
                    user.ngaysinh = DateTime.TryParse(txt_ngaySinh.Text.Trim(), out DateTime ngaySinh) ? ngaySinh : user.ngaysinh;
                    user.diachi = txt_diachi.Text.Trim();

                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();

                    //MessageBox.Show("Thông tin cá nhân đã được cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng để cập nhật thông tin.");
                }
            }
        }

        private void SaveImageToDatabase(byte[] imageData, string username_session_wall, string status)
        {
            int thongBao = 0;
            using (var context = new Model1())
            {
                // Tìm ảnh của user
                var existingImage = context.Images.FirstOrDefault(i => i.account_name == username_session_wall);

                if (existingImage != null)
                {
                    // Cập nhật ảnh nếu đã tồn tại
                    existingImage.ImageData = imageData;
                    existingImage.Status = status;
                    context.Entry(existingImage).State = EntityState.Modified;
                    thongBao = 0;
                }
                else
                {
                    // Tạo mới nếu chưa có
                    var newImage = new models.Images
                    {
                        account_name = username_session_wall,
                        ImageData = imageData,
                        Status = status
                    };
                    context.Images.Add(newImage);
                    thongBao = 1;
                }

                context.SaveChanges();
            }
            if (thongBao == 0)
                MessageBox.Show("cập nhật thành công!");
            else
                MessageBox.Show("Ảnh đã được lưu thành công!");
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            string defaultImagePath = @"D:\C# Can Ban\WinformGUI\WinformGUI\img\user.jpg";
            byte[] imageBytes;
            using (FileStream fs = new FileStream(defaultImagePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    imageBytes = br.ReadBytes((int)fs.Length);
                }
            }
            string status = "default";
            if (pictureBox1.Image != null)
            {
                byte[] imageData = ImageToByteArray(pictureBox1.Image);
                if (!imageData.SequenceEqual(imageBytes))
                {
                    status = "custom";
                }
                // Lưu mảng byte vào cơ sở dữ liệu bằng Entity Framework
                SaveImageToDatabase(imageData, username_session_wall,status);
            }
            // Lưu thông tin cá nhân vào cơ sở dữ liệu
            SaveUserInfo(username_session_wall);
            //MainScreen mainScreen = Application.OpenForms.OfType<MainScreen>().FirstOrDefault();
            //if (mainScreen != null)
            //{
            //    mainScreen.ReloadMainScreen(); // Gọi phương thức reload trong MainScreen
            //}
            OnUploadCompleted?.Invoke();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif", // Lọc file ảnh
                Title = "Chọn một ảnh"
            };

            // Hiển thị hộp thoại và kiểm tra nếu người dùng chọn file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị ảnh lên PictureBox
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Co dãn ảnh cho vừa PictureBox
            }
        }
        public void LoadUserImages()
        {
            using (var context = new Model1())
            {
                // Truy vấn để lấy danh sách ảnh từ cơ sở dữ liệu
                var userImages = context.Images
                    .Join(context.dang_anh,
                          img => img.id_avt,
                          da => da.id_avt,
                          (img, da) => new
                          {
                              img.account_name,
                              da.images,
                              da.id_avt
                          })
                    .Where(data => data.account_name == username_session_wall) // `username_session_wall` là username hiện tại
                    .ToList();

                flowLayoutPanelWall.Controls.Clear(); // Xóa các ảnh cũ trước khi thêm mới



                foreach (var image in userImages)
                {
                    // Tạo PictureBox để hiển thị ảnh
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = ByteArrayToImage(image.images), // Chuyển byte[] thành Image
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 150,
                        Height = 150,
                        Margin = new Padding(5),
                        Cursor = Cursors.Hand // Cho phép click
                    };

                    pictureBox.Click += (sender, e) =>
                    {
                        // Gọi hàm xử lý khi click vào ảnh (hiển thị nút xóa)
                        ShowDeleteButton(image.id_avt);
                    };

                    flowLayoutPanelWall.Controls.Add(pictureBox); // Thêm vào FlowLayoutPanel
                }
            }
        }

        // Chuyển đổi byte[] thành Image
        private DrawingImage ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return DrawingImage.FromStream(ms);
            }
        }

        // Hàm hiển thị nút xóa cho ảnh
        private void ShowDeleteButton(int imageId)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa ảnh này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteImage(imageId); // Xóa ảnh khỏi cơ sở dữ liệu
                LoadUserImages(); // Tải lại danh sách ảnh
            }
        }

        // Hàm xóa ảnh khỏi cơ sở dữ liệu
        private void DeleteImage(int imageId)
        {
            using (var context = new Model1())
            {
                var imageToDelete = context.dang_anh.FirstOrDefault(img => img.id_avt  == imageId);
                if (imageToDelete != null)
                {
                    context.dang_anh.Remove(imageToDelete);
                    context.SaveChanges();
                }
            }
        }

        private void wall1_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
            //chịu
        }
    }
}
