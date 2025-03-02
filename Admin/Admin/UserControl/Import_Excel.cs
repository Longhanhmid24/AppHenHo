using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using DevExpress.XtraEditors;
using AdminDB.Model;
using DevExpress.Utils;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace Admin.UserControl
{
    public partial class Import__Excel : DevExpress.XtraEditors.XtraUserControl
    {
        public Import__Excel()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DataTable ReadExcelFile(string filePath)
        {
            DataTable dt = new DataTable();

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Lấy Sheet đầu tiên
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column; // Số cột
                int rowCount = worksheet.Dimension.End.Row; // Số dòng

                // Thêm cột vào DataTable
                for (int col = 1; col <= colCount; col++)
                {
                    dt.Columns.Add(worksheet.Cells[1, col].Text);
                }

                // Thêm dữ liệu vào DataTable
                for (int row = 2; row <= rowCount; row++)
                {
                    DataRow newRow = dt.NewRow();
                    for (int col = 1; col <= colCount; col++)
                    {
                        newRow[col - 1] = worksheet.Cells[row, col].Text;
                    }
                    dt.Rows.Add(newRow);
                }
            }

            return dt;
        }
        private void btn_import_Click(object sender, EventArgs e)
        {

            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Mở hộp thoại để chọn file Excel
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Chọn file Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Đọc dữ liệu từ file Excel
                    DataTable dataTable = ReadExcelFile(filePath);

                    // Hiển thị dữ liệu lên DataGridView (nếu cần)
                    dataGridView1.DataSource = dataTable;

                    MessageBox.Show("Đã đọc file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đọc file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Model1())
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow) // Skip empty rows
                        {
                            var accountName = row.Cells["account_name"].Value?.ToString();
                            if (string.IsNullOrWhiteSpace(accountName)) // Check if account_name is empty
                            {
                                continue; // Skip this row
                            }

                            // Create a new user object
                            var user = new thong_tin_user
                            {
                                account_name = accountName,
                                hovaten = row.Cells["hovaten"].Value?.ToString(),
                                gioitinh = row.Cells["gioitinh"].Value?.ToString(),
                                gmail = row.Cells["gmail"].Value?.ToString(),
                                ngaysinh = DateTime.TryParse(row.Cells["ngaysinh"].Value?.ToString(), out DateTime dob) ? dob : (DateTime?)null,
                                diachi = row.Cells["diachi"].Value?.ToString()
                            };

                            var password = row.Cells["password"].Value?.ToString();

                            // Check if user already exists
                            if (!context.Userrs.Any(u => u.account_name == user.account_name))
                            {
                                // Add new user to Userr table
                                var newUser = new Userr
                                {
                                    account_name = user.account_name,
                                    password = password,
                                    Status = "normal"
                                };
                                context.Userrs.Add(newUser);
                                context.thong_tin_user.Add(user); // Add to thong_tin_user table

                                // Handle image upload if necessary
                                string imagePath = @"D:\C# Can Ban\WinformGUI\WinformGUI\img\user.jpg";
                                if (File.Exists(imagePath))
                                {
                                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                                    var image = new AdminDB.Model.Images
                                    {
                                        account_name = accountName,
                                        ImageData = imageBytes,
                                        Status = "default"
                                    };
                                    context.Images.Add(image);
                                }
                            }
                        }
                    }

                    context.SaveChanges(); // Save all changes to the database
                    MessageBox.Show("Đã lưu dữ liệu vào cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationError in ex.EntityValidationErrors)
                {
                    foreach (var error in validationError.ValidationErrors)
                    {
                        MessageBox.Show($"Property: {error.PropertyName}, Error: {error.ErrorMessage}", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Set LicenseContext
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Open a dialog to choose the save location for the Excel file
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
                    // Connect to the database
                    using (var connection = new SqlConnection("Server=DESKTOP-IOK2NSN\\PHILONG;Database=do_an_windown;Integrated Security=True;"))
                    {
                        connection.Open();
                        // Query to get user data
                        string query = @"
                    SELECT 
                        u.account_name, 
                        u.password, 
                        t.hovaten, 
                        t.gmail, 
                        t.gioitinh, 
                        t.ngaysinh, 
                        t.diachi 
                    FROM 
                        Userr u
                    JOIN 
                        thong_tin_user t ON u.account_name = t.account_name";

                        using (var command = new SqlCommand(query, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                using (ExcelPackage package = new ExcelPackage())
                                {
                                    // Create a new worksheet
                                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("User  Information");

                                    // Add column headers
                                    worksheet.Cells[1, 1].Value = "account_name";
                                    worksheet.Cells[1, 2].Value = "password"; // Include password
                                    worksheet.Cells[1, 3].Value = "hovaten";
                                    worksheet.Cells[1, 4].Value = "gmail";
                                    worksheet.Cells[1, 5].Value = "gioitinh";
                                    worksheet.Cells[1, 6].Value = "ngaysinh";
                                    worksheet.Cells[1, 7].Value = "diachi";

                                    int row = 2; // Start from row 2

                                    // Add data from SqlDataReader to worksheet
                                    while (reader.Read())
                                    {
                                        worksheet.Cells[row, 1].Value = reader["account_name"];
                                        worksheet.Cells[row, 2].Value = reader["password"]; // Add password to the worksheet
                                        worksheet.Cells[row, 3].Value = reader["hovaten"];
                                        worksheet.Cells[row, 4].Value = reader["gmail"];
                                        worksheet.Cells[row, 5].Value = reader["gioitinh"];

                                        // Handle the date correctly
                                        if (reader["ngaysinh"] != DBNull.Value)
                                        {
                                            DateTime ngaysinh = (DateTime)reader["ngaysinh"];
                                            worksheet.Cells[row, 6].Value = ngaysinh; // Set the date value
                                            worksheet.Cells[row, 6].Style.Numberformat.Format = "dd/MM/yyyy"; // Set the date format
                                        }
                                        else
                                        {
                                            worksheet.Cells[row, 6].Value = ""; // Handle null date
                                        }

                                        worksheet.Cells[row, 7].Value = reader["diachi"];
                                        row++;
                                    }

                                    // Save the Excel file
                                    FileInfo excelFile = new FileInfo(filePath);
                                    package.SaveAs(excelFile);
                                }
                            }
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
