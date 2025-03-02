using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminDB.Model;
using DevExpress.XtraEditors;
using System.Security.Cryptography;
using Microsoft.VisualBasic.ApplicationServices;
using DevExpress.Utils.About;
using System.Data.Entity.Validation;
using System.IO;
using System.Windows.Controls;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using DevExpress.XtraBars.Customization;
using System.Text.RegularExpressions;


namespace Admin.UserControl
{
    public partial class DanhSachUsers : DevExpress.XtraEditors.XtraUserControl
    {
        public DanhSachUsers()
        {
            InitializeComponent();


        }

        private void DanhSachUsers_Load(object sender, EventArgs e)
        {
            tbDanhSach.SelectedTabPage = xtraTabPage1;
            LoadUserData(); // Tải dữ liệu cho tab đầu tiên
        }

        private void LoadUserData()
        {
            using (var context = new Model1())
            {
                var users = context.thong_tin_user.ToList();
                // Xóa dữ liệu cũ trong DataGridView
                dgvDSC.Rows.Clear();
                // Thêm dữ liệu vào DataGridView
                foreach (var user in users)
                {
                    dgvDSC.Rows.Add(user.account_name, user.hovaten, user.gioitinh, user.diachi, user.ngaysinh?.ToString("dd/MM/yyyy"), user.gmail);
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển đổi mật khẩu thành mảng byte
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Chuyển đổi mảng byte thành chuỗi hex
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return Convert.ToBase64String(bytes).Substring(0, 30);
            }

        }

        private void LoadAccountData()
        {
            using (var context = new Model1())
            {
                var accounts = context.Userrs.ToList();
                // Xóa dữ liệu cũ trong DataGridView
                dgvAccountList.Rows.Clear();
                // Thêm dữ liệu vào DataGridView
                foreach (var account in accounts)
                {
                    // Mã hóa mật khẩu trước khi thêm vào DataGridView
                    string hashedPassword = HashPassword(account.password);
                    dgvAccountList.Rows.Add(account.account_name, hashedPassword, account.Status);
                }
            }
        }

        public void LoadMatchData()
        {
            using (var context = new Model1())
            {
                var match = context.matchs.ToList();
                dgvMatchs.Rows.Clear();
                foreach (var matchs in match)
                {
                    dgvMatchs.Rows.Add(matchs.MatchID, matchs.SenderID, matchs.ReceiverID, matchs.Status);
                }
            }
        }

        private void LoadImages()
        {
            try
            {
                using (var context = new Model1())
                {
                    // Lấy danh sách ảnh từ cơ sở dữ liệu
                    var images = context.Images.ToList();

                    // Xóa dữ liệu cũ trong DataGridView
                    dgvImage.Rows.Clear();

                    // Hiển thị ảnh lên DataGridView
                    foreach (var img in images)
                    {
                        System.Drawing.Image image;

                        // Kiểm tra nếu ImageData có giá trị
                        if (img.ImageData != null && img.ImageData.Length > 0)
                        {
                            using (var ms = new System.IO.MemoryStream(img.ImageData))
                            {
                                image = System.Drawing.Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            image = System.Drawing.Image.FromFile("download (7).jpg"); // Hình mặc định nếu không có dữ liệu
                        }

                        // Thêm hàng mới vào DataGridView với dữ liệu trong các cột khác
                        int rowIndex = dgvImage.Rows.Add();
                        dgvImage.Rows[rowIndex].Cells["clmChuTaiKhoan"].Value = img.account_name; // Cập nhật cột UserName
                        dgvImage.Rows[rowIndex].Cells["clmAvt"].Value = img.id_avt; // Cập nhật cột AvatarID
                        dgvImage.Rows[rowIndex].Cells["clmImage"].Value = image; // Cập nhật cột Ảnh
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbDanhSach_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == xtraTabPage1)
            {
                LoadUserData(); // Tải dữ liệu cho tab "Danh Sách Chung"
            }
            else if (e.Page == xtraTabPage2)
            {
                LoadAccountData(); // Tải dữ liệu cho tab "Tài Khoản"
            }
            else if (e.Page == xtraTabPage3)
            {
                LoadMatchData();
            }
            else if (e.Page == xtraTabPage4)
            {
                LoadImages();
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string accountName = txtUsername.Text.Trim();
                string password = txtPass.Text.Trim();
                string hoVaTen = txtHoTen.Text.Trim();

                // Kiểm tra giá trị ComboBox Giới tính
                string gioiTinh = cbbGioiTinh.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(gioiTinh))
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra giá trị ComboBox Địa chỉ
                string diaChi = cbbDiaChi.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(diaChi))
                {
                    MessageBox.Show("Vui lòng chọn địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime? ngaySinh = dtNgaySinh.Value; // DateTimePicker chọn ngày sinh
                string email = txtGmail.Text.Trim();

                // Mã hóa mật khẩu
                string hashedPassword = HashPassword(password);

                // Thêm vào cơ sở dữ liệu
                using (var context = new Model1())
                {
                    // Thêm vào bảng Userrs
                    Userr newAccount = new Userr
                    {
                        account_name = accountName,
                        password = hashedPassword,
                        Status = "normal"
                    };
                    context.Userrs.Add(newAccount);

                    // Thêm vào bảng thong_tin_user
                    thong_tin_user newUserInfo = new thong_tin_user
                    {
                        account_name = accountName,
                        hovaten = hoVaTen,
                        gioitinh = gioiTinh,
                        diachi = diaChi,
                        ngaysinh = ngaySinh,
                        gmail = email
                    };
                    context.thong_tin_user.Add(newUserInfo);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();
                }

                MessageBox.Show("Thêm tài khoản và thông tin người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách dữ liệu
                LoadAccountData();
                LoadUserData();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        sb.AppendLine($"Property: {validationError.PropertyName} - Error: {validationError.ErrorMessage}");
                    }
                }
                MessageBox.Show($"Validation failed: {sb.ToString()}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            txtUsername.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            cbbGioiTinh.SelectedIndex = -1;
            cbbDiaChi.SelectedIndex = -1;
            dtNgaySinh.Value = DateTime.Now;
            txtGmail.Text = string.Empty;
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tên tài khoản từ textbox
                string accountName = txtUsername.Text.Trim();
                if (string.IsNullOrEmpty(accountName))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var context = new Model1())
                {
                    // Tìm tài khoản trong bảng Userrs
                    var account = context.Userrs.FirstOrDefault(a => a.account_name == accountName);
                    var userInfo = context.thong_tin_user.FirstOrDefault(u => u.account_name == accountName);

                    // Kiểm tra tài khoản có tồn tại
                    if (account == null || userInfo == null)
                    {
                        MessageBox.Show("Tên tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cập nhật các thông tin từ các điều khiển
                    if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
                    {
                        userInfo.hovaten = txtHoTen.Text.Trim();
                    }

                    if (!string.IsNullOrWhiteSpace(txtPass.Text))
                    {
                        account.password = HashPassword(txtPass.Text.Trim()); // Mã hóa mật khẩu
                    }

                    if (cbbGioiTinh.SelectedItem != null)
                    {
                        userInfo.gioitinh = cbbGioiTinh.SelectedItem.ToString();
                    }

                    if (cbbDiaChi.SelectedItem != null)
                    {
                        userInfo.diachi = cbbDiaChi.SelectedItem.ToString();
                    }

                    // Xử lý ngày sinh từ DateTimePicker
                    if (dtNgaySinh.Checked)
                    {
                        userInfo.ngaysinh = dtNgaySinh.Value;
                    }

                    if (!string.IsNullOrWhiteSpace(txtGmail.Text))
                    {
                        userInfo.gmail = txtGmail.Text.Trim();
                    }

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại danh sách
                    LoadAccountData();
                    LoadUserData();

                    // Xóa các ô nhập liệu
                    ClearInputFields();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong DataGridView
                if (dgvDSC.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng có tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy tên tài khoản từ dòng được chọn
                string accountName = dgvDSC.SelectedRows[0].Cells[0]?.Value?.ToString();




                if (string.IsNullOrEmpty(accountName))
                {
                    MessageBox.Show("Không thể xác định tài khoản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hỏi xác nhận xóa
                DialogResult confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{accountName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                using (var context = new Model1())
                {
                    // Tìm và xóa trong bảng Userrs
                    var account = context.Userrs.FirstOrDefault(a => a.account_name == accountName);
                    if (account != null)
                    {
                        context.Userrs.Remove(account);
                    }

                    // Tìm và xóa trong bảng thong_tin_user
                    var userInfo = context.thong_tin_user.FirstOrDefault(u => u.account_name == accountName);
                    if (userInfo != null)
                    {
                        context.thong_tin_user.Remove(userInfo);
                    }

                    // Lưu thay đổi
                    context.SaveChanges();
                }

                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách
                LoadAccountData();
                LoadUserData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong DataGridView
                if (dgvAccountList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một dòng có tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận xóa
                DialogResult confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa {dgvAccountList.SelectedRows.Count} tài khoản đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                using (var context = new Model1())
                {
                    // Lưu danh sách các tài khoản để xóa
                    List<string> accountNamesToDelete = new List<string>();

                    // Lặp qua tất cả các dòng được chọn
                    foreach (DataGridViewRow selectedRow in dgvAccountList.SelectedRows)
                    {
                        string accountName = selectedRow.Cells[0]?.Value?.ToString();
                        if (!string.IsNullOrEmpty(accountName))
                        {
                            accountNamesToDelete.Add(accountName);
                        }
                    }

                    // Xóa các tài khoản trong bảng Images
                    foreach (var accountName in accountNamesToDelete)
                    {
                        var userImage = context.Images.FirstOrDefault(im => im.account_name == accountName);
                        if (userImage != null)
                        {
                            var listimage = context.dang_anh.Where(i => i.id_avt == userImage.id_avt).ToList();
                            foreach (var item in listimage)
                            {
                                context.dang_anh.Remove(item);
                            }
                            context.Images.Remove(userImage);
                        }

                        // Tìm và xóa trong bảng thong_tin_user
                        var userInfo = context.thong_tin_user.FirstOrDefault(u => u.account_name == accountName);
                        if (userInfo != null)
                        {
                            context.thong_tin_user.Remove(userInfo);
                        }

                        // Xóa user trong bảng match (nếu có)
                        var userMatch = context.matchs.Where(u => u.SenderID == accountName || u.ReceiverID == accountName).ToList();
                        foreach (var item in userMatch)
                        {
                            context.matchs.Remove(item);
                        }

                        // Xóa user trong bảng báo cáo (nếu có)
                        var userReport = context.reports.Where(r => (r.sender == accountName) || (r.Receiver == accountName)).ToList();
                        foreach (var item in userReport)
                        {
                            context.reports.Remove(item);
                        }

                        // Tìm và xóa trong bảng Userrs
                        var account = context.Userrs.FirstOrDefault(a => a.account_name == accountName);
                        if (account != null)
                        {
                            context.Userrs.Remove(account);
                        }
                    }

                    // Lưu thay đổi
                    context.SaveChanges();
                }

                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách
                LoadAccountData();
                LoadUserData();
                LoadImages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtDsChung_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtDsChung.Text.Trim().ToLower(); // Đảm bảo lấy đúng TextBox
                Model1 context = new Model1(); // Khởi tạo context
                List<thong_tin_user> allUsers = context.thong_tin_user.ToList(); // Lấy toàn bộ dữ liệu từ bảng thông_tin_user

                // Lọc dữ liệu dựa trên account_name
                var filteredUsers = allUsers.Where(user => user.account_name.ToLower().Contains(searchValue)).ToList();

                // Hiển thị dữ liệu đã lọc trong DataGridView
                dgvDSC.Rows.Clear();
                foreach (var user in filteredUsers)
                {
                    int index = dgvDSC.Rows.Add();
                    dgvDSC.Rows[index].Cells[0].Value = user.account_name;
                    dgvDSC.Rows[index].Cells[1].Value = user.hovaten;
                    dgvDSC.Rows[index].Cells[2].Value = user.gioitinh;
                    dgvDSC.Rows[index].Cells[3].Value = user.diachi;
                    dgvDSC.Rows[index].Cells[4].Value = user.ngaysinh.HasValue
                ? user.ngaysinh.Value.ToString("dd/MM/yyyy")
                : ""; // Định dạng ngày sinh
                    dgvDSC.Rows[index].Cells[5].Value = user.gmail;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGiamSat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtGiamSat.Text.Trim().ToLower(); // Đảm bảo lấy đúng TextBox
                Model1 context = new Model1(); // Khởi tạo context
                List<Userr> allUsers = context.Userrs.ToList(); // Lấy toàn bộ dữ liệu từ bảng Userrs

                // Lọc dữ liệu dựa trên account_name
                var filteredUsers = allUsers.Where(user => user.account_name.ToLower().Contains(searchValue)).ToList();

                // Hiển thị dữ liệu đã lọc trong DataGridView
                dgvAccountList.Rows.Clear(); // Xóa các hàng cũ trong DataGridView
                foreach (var user in filteredUsers)
                {
                    int index = dgvAccountList.Rows.Add(); // Thêm một hàng mới
                    dgvAccountList.Rows[index].Cells[0].Value = user.account_name; // Gán giá trị vào cột 0
                    dgvAccountList.Rows[index].Cells[1].Value = user.password;    // Gán giá trị vào cột 1
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImgaes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtImgaes.Text.Trim().ToLower(); // Đảm bảo lấy đúng TextBox
                Model1 context = new Model1(); // Khởi tạo context
                List<AdminDB.Model.Images> allUsers = context.Images.ToList(); // Lấy toàn bộ dữ liệu từ bảng Images

                // Lọc dữ liệu dựa trên account_name
                var filteredUsers = allUsers.Where(user => user.account_name.ToLower().Contains(searchValue)).ToList();

                // Hiển thị dữ liệu đã lọc trong DataGridView
                dgvImage.Rows.Clear(); // Xóa các hàng cũ trong DataGridView
                foreach (var user in filteredUsers)
                {
                    int index = dgvImage.Rows.Add(); // Thêm một hàng mới
                    dgvImage.Rows[index].Cells[0].Value = user.account_name; // Gán giá trị vào cột 0

                    // Chuyển đổi byte[] sang Image nếu dữ liệu ảnh được lưu dưới dạng byte[]
                    if (user.ImageData != null && user.ImageData.Length > 0)
                    {
                        using (var ms = new MemoryStream(user.ImageData))
                        {
                            // Sử dụng System.Drawing.Image để tránh xung đột
                            dgvImage.Rows[index].Cells[1].Value = System.Drawing.Image.FromStream(ms); // Hiển thị ảnh
                        }
                    }
                    else
                    {
                        dgvImage.Rows[index].Cells[1].Value = null; // Nếu không có ảnh, để trống
                    }

                    dgvImage.Rows[index].Cells[2].Value = user.id_avt; // Gán giá trị vào cột khác
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong DataGridView
                if (dgvImage.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng có ảnh cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy account_name từ dòng được chọn
                string accountName = dgvImage.SelectedRows[0].Cells["clmChuTaiKhoan"]?.Value?.ToString();
                int avatarId = (int)dgvImage.SelectedRows[0].Cells["clmAvt"]?.Value; // Giả sử bạn có cột AvatarID

                if (string.IsNullOrEmpty(accountName))
                {
                    MessageBox.Show("Không thể xác định ảnh để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận xóa
                DialogResult confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa ảnh của tài khoản '{accountName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                using (var context = new Model1())
                {
                    // Tìm và xóa trong bảng Images
                    var imageToDelete = context.Images.FirstOrDefault(img => img.id_avt == avatarId);
                    if (imageToDelete != null)
                    {
                        context.Images.Remove(imageToDelete);
                        context.SaveChanges();
                    }
                }

                MessageBox.Show("Xóa ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách ảnh
                LoadImages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaAnh_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong DataGridView
                if (dgvImage.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng có ảnh cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy account_name từ dòng được chọn
                string accountName = dgvImage.SelectedRows[0].Cells["clmChuTaiKhoan"]?.Value?.ToString();
                int avatarId = (int)dgvImage.SelectedRows[0].Cells["clmAvt"]?.Value; // Giả sử bạn có cột AvatarID

                // Mở hộp thoại để chọn ảnh mới
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Lấy đường dẫn ảnh đã chọn
                        string filePath = openFileDialog.FileName;

                        // Chuyển đổi ảnh thành mảng byte
                        byte[] imageData;
                        using (var ms = new MemoryStream())
                        {
                            using (var image = System.Drawing.Image.FromFile(filePath))
                            {
                                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                imageData = ms.ToArray();
                            }
                        }

                        using (var context = new Model1())
                        {
                            // Tìm ảnh cần sửa trong bảng Images
                            var imageToUpdate = context.Images.FirstOrDefault(img => img.id_avt == avatarId);
                            if (imageToUpdate != null)
                            {
                                imageToUpdate.ImageData = imageData; // Cập nhật dữ liệu ảnh
                                context.SaveChanges(); // Lưu thay đổi
                            }
                        }

                        MessageBox.Show("Sửa ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật lại danh sách ảnh
                        LoadImages();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThangThai_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong DataGridView
                if (dgvMatchs.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một dòng có tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hỏi xác nhận xóa
                DialogResult confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa {dgvMatchs.SelectedRows.Count} tương hợp đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                using (var context = new Model1())
                {
                    // Lưu danh sách các MatchID để xóa
                    List<int> matchIdsToDelete = new List<int>();

                    // Lặp qua tất cả các dòng được chọn
                    foreach (DataGridViewRow selectedRow in dgvMatchs.SelectedRows)
                    {
                        string matchingString = selectedRow.Cells[0]?.Value?.ToString();

                        if (int.TryParse(matchingString, out int matching))
                        {
                            matchIdsToDelete.Add(matching);
                        }
                    }

                    // Tìm và xóa các tương hợp trong bảng matchs
                    var matchesToDelete = context.matchs.Where(a => matchIdsToDelete.Contains(a.MatchID)).ToList();
                    if (matchesToDelete.Any())
                    {
                        context.matchs.RemoveRange(matchesToDelete); // Xóa tất cả các đối tượng matchted
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tương hợp để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lưu thay đổi
                    context.SaveChanges();
                }

                MessageBox.Show("Xóa tương hợp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách
                LoadMatchData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiemMatchs_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDSC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấp vào một ô hợp lệ không
            if (e.RowIndex >= 0) // e.RowIndex < 0 có thể là tiêu đề cột
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvDSC.Rows[e.RowIndex];

                // Lấy thông tin từ các ô trong dòng đã chọn
                txtUsername.Text = selectedRow.Cells["clmGUserName"].Value?.ToString();
                txtHoTen.Text = selectedRow.Cells["clmHoTen"].Value?.ToString();
                cbbGioiTinh.SelectedItem = selectedRow.Cells["clmGioiTinh"].Value?.ToString();
                cbbDiaChi.SelectedItem = selectedRow.Cells["clmDiaChi"].Value?.ToString();

                // Chuyển đổi ngày sinh từ chuỗi sang DateTime nếu có
                if (DateTime.TryParse(selectedRow.Cells["clmBirthDay"].Value?.ToString(), out DateTime birthDate))
                {
                    dtNgaySinh.Value = birthDate;
                }
                else
                {
                    dtNgaySinh.Checked = false; // Nếu không có ngày sinh, bỏ chọn
                }

                txtGmail.Text = selectedRow.Cells["clmGmail"].Value?.ToString();
            }
        }
    }
}
