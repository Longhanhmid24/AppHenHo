namespace WinformGUI
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plDangKy = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // plDangKy
            // 
            this.plDangKy.BackColor = System.Drawing.Color.Silver;
            this.plDangKy.Location = new System.Drawing.Point(0, 0);
            this.plDangKy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plDangKy.Name = "plDangKy";
            this.plDangKy.Size = new System.Drawing.Size(1035, 625);
            this.plDangKy.TabIndex = 1;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1026, 624);
            this.Controls.Add(this.plDangKy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Kí Tài Khoản";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel plDangKy;
    }
}