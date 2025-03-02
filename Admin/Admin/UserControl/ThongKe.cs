using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminDB;
using AdminDB.Model;
using DevExpress.CodeParser;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using OfficeOpenXml;
using System.IO;

namespace Admin.UserControl
{
    public partial class ThongKe : DevExpress.XtraEditors.XtraUserControl
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void LoadChartData()
        {
            try
            {
                using (var context = new Model1())
                {
                    // Lấy số lượng người dùng theo giới tính
                    int soNam = context.thong_tin_user.Count(u => u.gioitinh == "Nam");
                    int soNu = context.thong_tin_user.Count(u => u.gioitinh == "Nữ");
                    int soKhac = context.thong_tin_user.Count(u => u.gioitinh == "Khác");

                    // Cấu hình Series cho biểu đồ
                    Series series = new Series("Thống kê giới tính", ViewType.Pie);

                    // Thêm điểm dữ liệu vào biểu đồ
                    series.Points.Add(new SeriesPoint("Nam", soNam));
                    series.Points.Add(new SeriesPoint("Nữ", soNu));
                    series.Points.Add(new SeriesPoint("Khác", soKhac));

                    // Cấu hình hiển thị biểu đồ
                    series.Label.TextPattern = "{A}: {VP:p0}"; // Hiển thị phần trăm
                    ((PieSeriesView)series.View).ExplodedPoints.Add(series.Points[0]); // Tạo hiệu ứng nổ cho "Nam"
                    ((PieSeriesView)series.View).ExplodedDistancePercentage = 30;

                    // Thêm Series vào biểu đồ
                    chartControl1.Series.Clear();
                    chartControl1.Series.Add(series);

                    // Cập nhật thiết kế biểu đồ
                    chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            // Gọi hàm LoadChartData() để làm mới dữ liệu
            LoadChartData();

        }

        private void btnShowUsers_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một instance của báo cáo
                XtraReport1 report = new XtraReport1();

                using (var context = new Model1())
                {
                    // Lấy dữ liệu từ cơ sở dữ liệu
                    var data = context.Userrs
                        .Select(u => new
                        {

                            u.account_name,
                            u.password,
                            u.Status


                        })
                        .ToList();

                    // Gán dữ liệu cho báo cáo
                    report.DataSource = data;
                    report.DataMember = ""; // Để trống hoặc tên danh sách dữ liệu nếu cần
                }

                // Hiển thị báo cáo trong DocumentViewer
                DocumentViewer viewer = new DocumentViewer
                {
                    Dock = DockStyle.Fill,
                    DocumentSource = report
                };

                // Xóa các điều khiển cũ và thêm DocumentViewer mới vào panel
                plThongTinUser.Controls.Clear();
                plThongTinUser.Controls.Add(viewer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaiDang_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Model1())
                {
                    // Đưa dữ liệu vào bộ nhớ để kiểm tra danh sách Images
                    var users = context.Userrs.ToList();

                    // Đếm số lượng người dùng không có bài đăng (không có ảnh)
                    int khongDang = users.Count(z => z.Images == null || !z.Images.Any());

                    // Đếm số lượng người dùng có bài đăng (có ít nhất một ảnh)
                    int dang = users.Count(z => z.Images != null && z.Images.Any());

                    // Cấu hình Series cho biểu đồ
                    Series series = new Series("Thống kê bài đăng", ViewType.Pie);

                    // Thêm điểm dữ liệu vào biểu đồ
                    series.Points.Add(new SeriesPoint("Không Đăng", khongDang));
                    series.Points.Add(new SeriesPoint("Có Bài Đăng", dang));

                    // Cấu hình hiển thị biểu đồ
                    series.Label.TextPattern = "{A}: {VP:p0}"; // Hiển thị phần trăm
                    ((PieSeriesView)series.View).ExplodedPoints.Add(series.Points[0]); // Hiệu ứng nổ cho "Không Đăng"
                    ((PieSeriesView)series.View).ExplodedDistancePercentage = 30;

                    // Thêm Series vào biểu đồ
                    chartBaiDang.Series.Clear();
                    chartBaiDang.Series.Add(series);

                    // Cập nhật thiết kế biểu đồ
                    chartBaiDang.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // Đặt LicenseContext cho EPPlus
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Mở hộp thoại để chọn vị trí lưu file Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu file Excel"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (var context = new Model1())
                    {
                        // Lấy dữ liệu từ bảng Userrs
                        var data = context.Userrs
                            .Select(u => new
                            {
                                AccountName = u.account_name,
                                Password = u.password,
                                Status = u.Status
                            })
                            .ToList();

                        // Tạo file Excel
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            // Tạo worksheet mới
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("User Information");

                            // Thêm tiêu đề cột
                            worksheet.Cells[1, 1].Value = "Account Name";
                            worksheet.Cells[1, 2].Value = "Password";
                            worksheet.Cells[1, 3].Value = "Status";

                            int row = 2; // Bắt đầu từ dòng 2

                            // Thêm dữ liệu vào Excel từ danh sách
                            foreach (var user in data)
                            {
                                worksheet.Cells[row, 1].Value = user.AccountName;
                                worksheet.Cells[row, 2].Value = user.Password;
                                worksheet.Cells[row, 3].Value = user.Status;
                                row++;
                            }

                            // Định dạng bảng
                            worksheet.Cells.AutoFitColumns(); // Tự động điều chỉnh kích thước cột

                            // Lưu file Excel
                            FileInfo excelFile = new FileInfo(filePath);
                            package.SaveAs(excelFile);
                        }
                    }

                    MessageBox.Show("Đã xuất dữ liệu ra file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
