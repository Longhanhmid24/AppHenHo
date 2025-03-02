using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminDB.Model;

namespace Admin.UserControl
{
    public partial class BaoCao : DevExpress.XtraEditors.XtraUserControl
    {
        private string selectedAccountName;
        private DanhSachUsers accountList;
        public BaoCao()
        {
            InitializeComponent();
            DanhSachUsers accountList1 = accountList;
            this.accountList = accountList1;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.CellSelect; // Cho phép chọn ô

        }
        public BaoCao(DanhSachUsers accountList)
        {
            InitializeComponent();
            this.accountList = accountList; // Gán tham chiếu
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvBlock.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // Cho phép chọn ô
        }

        private void LoadBaoCao()
        {
            using (var context = new Model1())
            {
                var report = context.reports.ToList();
                dgvBaoCao.Rows.Clear();
                foreach (var reports in report)
                {
                    dgvBaoCao.Rows.Add(reports.id, reports.loai, reports.noidun, reports.thoigian?.ToString("dd/MM/yyyy"), reports.sender, reports.Receiver);
                }
                var blockedUsers = context.Userrs.Where(u => u.Status == "Blocked").ToList();
                dgvBlock.Rows.Clear();
                foreach (var user in blockedUsers)
                {
                    dgvBlock.Rows.Add(user.account_name, user.Status);
                }
            }
        }
        private void BaoCao_Load(object sender, EventArgs e)
        {
            LoadBaoCao();

        }


        private void btn_blockUser_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có tên tài khoản nào đã được chọn không
            if (string.IsNullOrEmpty(selectedAccountName))
            {
                MessageBox.Show("Vui lòng chọn một báo cáo để chặn người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new Model1())
            {
                // Tìm người dùng trong cơ sở dữ liệu
                var user = context.Userrs.FirstOrDefault(u => u.account_name == selectedAccountName);
                var match = context.matchs.Where(m => m.SenderID == selectedAccountName || m.ReceiverID == selectedAccountName).ToList();
                var report = context.reports.Where(r => r.Receiver == selectedAccountName).ToList();

                if (user != null)
                {
                    // Cập nhật trạng thái người dùng
                    user.Status = "Blocked"; // Cập nhật trạng thái thành "Blocked"
                    context.Entry(user).State = EntityState.Modified;

                    foreach (var item in match)
                    {
                        context.matchs.Remove(item);
                    }
                    foreach (var item in report)
                    {
                        context.reports.Remove(item);
                    }

                    // Lưu thay đổi
                    context.SaveChanges();

                    // Gọi phương thức LoadMatchData từ DanhSachUsers để cập nhật dgvMatchs
                    //accountList.LoadMatchData(); // Gọi phương thức để làm mới dữ liệu
                    LoadBaoCao();

                    MessageBox.Show("Người dùng đã bị chặn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Người dùng không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvBaoCao_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvBaoCao.Columns["clmReceiver"].Index)
            {
                // Lấy tên tài khoản từ ô "clmReceiver"
                selectedAccountName = dgvBaoCao.Rows[e.RowIndex].Cells["clmReceiver"].Value?.ToString();
            }
        }

        private void btn_unlockUser_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có tài khoản nào được chọn không
            if (string.IsNullOrEmpty(selectedAccountName))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để mở khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new Model1())
            {
                // Tìm tài khoản trong cơ sở dữ liệu
                var user = context.Userrs.FirstOrDefault(u => u.account_name == selectedAccountName);

                if (user != null)
                {
                    if (user.Status == "Blocked")
                    {
                        // Cập nhật trạng thái tài khoản thành "Normal"
                        user.Status = "normal";
                        context.Entry(user).State = EntityState.Modified;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        context.SaveChanges();

                        // Xóa dòng hiển thị trong dgvBlock
                        foreach (DataGridViewRow row in dgvBlock.Rows)
                        {
                            if (row.Cells["clmUserName"].Value?.ToString() == selectedAccountName)
                            {
                                dgvBlock.Rows.Remove(row);
                                break;
                            }
                        }

                        MessageBox.Show("Tài khoản đã được mở khóa thành công và xóa khỏi danh sách hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvBlock_CellClick(object sender, DataGridViewCellEventArgs e)
        {  // Kiểm tra chỉ số hàng và cột hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dgvBlock.Rows.Count &&
                e.ColumnIndex >= 0 && e.ColumnIndex < dgvBlock.Columns.Count)
            {
                // Đảm bảo rằng cột được chọn là "clmUserName"
                if (dgvBlock.Columns[e.ColumnIndex].Name == "clmUserName")
                {
                    selectedAccountName = dgvBlock.Rows[e.RowIndex].Cells["clmUserName"].Value?.ToString();
                }
            }
        }
    }
}
