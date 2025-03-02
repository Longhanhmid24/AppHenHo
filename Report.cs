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

namespace WinformGUI
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public string username_session_report { get; set; }
        public string username_session_sender { get; set; }
        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(var db = new Model1())
            {
                var report = new report
                {
                    Receiver = username_session_report,
                    loai = comboBox1.Text,
                    noidun = textBox1.Text,
                    thoigian = DateTime.Now,
                    sender = username_session_sender
                };
                db.reports.Add(report);
                db.SaveChanges();
                MessageBox.Show("Báo cáo đã được gửi! Chờ phản hồi.", "Thông báo", MessageBoxButtons.OK);
            }
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
