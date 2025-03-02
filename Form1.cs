using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformGUI
{
    public partial class QuanLy : Form
    {
      
        public QuanLy()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.ShowDialog();
            this.Hide();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {

        }
    }
}
