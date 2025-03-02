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
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;


namespace WinformGUI
{
    public partial class DangBai : UserControl
    {
        public string id_AVT { get; set; }
        public DangBai()
        {
            InitializeComponent();
            selectedImagePaths = new List<string>();
        }
        private List<string> selectedImagePaths;
  

        private void btn_chonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Chọn hình ảnh",
                Multiselect = true // Cho phép chọn nhiều ảnh
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                flowLayoutPanel1.Controls.Clear();// Xóa ảnh cũ nếu có
                foreach (string filePath in openFileDialog.FileNames)
                {
                    // Thêm đường dẫn ảnh vào danh sách
                    selectedImagePaths.Add(filePath);
                    // Hiển thị hình ảnh vừa chọn (nếu cần)
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = Image.FromFile(filePath),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 100,
                        Height = 100,
                        Margin = new Padding(5)
                    };
                    
                    flowLayoutPanel1.Controls.Add(pictureBox); // Hiển thị ảnh trong FlowLayoutPanel
                     
                    flowLayoutPanel1.AutoScroll = true; // Cho phép cuộn
                    flowLayoutPanel1.WrapContents = true;
                    
                }

            }
        }
        private void SaveImageToDatabase(int userId, string filePath)
        {
            byte[] imageBytes = File.ReadAllBytes(filePath); // Đọc dữ liệu ảnh thành byte[]
            DateTime ngay_dang = DateTime.Now;
            using (var context = new Model1())
            {
                var image = new dang_anh
                {
                    id_avt = userId,
                    images = imageBytes,
                    ngay_dang = ngay_dang

                };
                context.dang_anh.Add(image);
                context.SaveChanges();
            }
        }

        private void btn_dang_Click(object sender, EventArgs e)
        {
            if (selectedImagePaths.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một hình ảnh trước khi đăng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngay_dang = DateTime.Now;

            foreach (string filePath in selectedImagePaths)
            {
                SaveImageToDatabase(int.Parse(id_AVT), filePath);
            }

            MessageBox.Show("Đăng bài thành công!", "Thông báo", MessageBoxButtons.OK);
            // Xóa danh sách sau khi lưu
            selectedImagePaths.Clear();
            flowLayoutPanel1.Controls.Clear();
        }
    }
}
