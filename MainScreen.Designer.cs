namespace WinformGUI
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.btnTuongHop = new System.Windows.Forms.Button();
            this.btn_dangBai = new System.Windows.Forms.Button();
            this.plHinhAnh = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_listBlock = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.plNhanTin = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTuongHop
            // 
            this.btnTuongHop.BackColor = System.Drawing.Color.Lime;
            this.btnTuongHop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuongHop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuongHop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTuongHop.Location = new System.Drawing.Point(3, 103);
            this.btnTuongHop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTuongHop.Name = "btnTuongHop";
            this.btnTuongHop.Size = new System.Drawing.Size(247, 42);
            this.btnTuongHop.TabIndex = 4;
            this.btnTuongHop.Text = "Các tương hợp";
            this.btnTuongHop.UseVisualStyleBackColor = false;
            this.btnTuongHop.Click += new System.EventHandler(this.btnTuongHop_Click);
            // 
            // btn_dangBai
            // 
            this.btn_dangBai.BackColor = System.Drawing.Color.Red;
            this.btn_dangBai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dangBai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dangBai.ForeColor = System.Drawing.Color.White;
            this.btn_dangBai.Location = new System.Drawing.Point(256, 102);
            this.btn_dangBai.Name = "btn_dangBai";
            this.btn_dangBai.Size = new System.Drawing.Size(242, 42);
            this.btn_dangBai.TabIndex = 5;
            this.btn_dangBai.Text = "đăng bài";
            this.btn_dangBai.UseVisualStyleBackColor = false;
            this.btn_dangBai.Click += new System.EventHandler(this.btn_dangBai_Click);
            // 
            // plHinhAnh
            // 
            this.plHinhAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.plHinhAnh.Location = new System.Drawing.Point(3, 150);
            this.plHinhAnh.Name = "plHinhAnh";
            this.plHinhAnh.Size = new System.Drawing.Size(500, 634);
            this.plHinhAnh.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btn_listBlock);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_dangBai);
            this.panel1.Controls.Add(this.btnTuongHop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1390, 787);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::WinformGUI.Properties.Resources.logout;
            this.pictureBox2.Location = new System.Drawing.Point(441, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(54, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btn_listBlock
            // 
            this.btn_listBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listBlock.Location = new System.Drawing.Point(374, 13);
            this.btn_listBlock.Name = "btn_listBlock";
            this.btn_listBlock.Size = new System.Drawing.Size(61, 41);
            this.btn_listBlock.TabIndex = 10;
            this.btn_listBlock.Text = "...";
            this.btn_listBlock.UseVisualStyleBackColor = true;
            this.btn_listBlock.Click += new System.EventHandler(this.btn_listBlock_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 71);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // plNhanTin
            // 
            this.plNhanTin.AutoScroll = true;
            this.plNhanTin.Location = new System.Drawing.Point(501, 0);
            this.plNhanTin.Name = "plNhanTin";
            this.plNhanTin.Size = new System.Drawing.Size(886, 784);
            this.plNhanTin.TabIndex = 8;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 787);
            this.Controls.Add(this.plNhanTin);
            this.Controls.Add(this.plHinhAnh);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainScreen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTuongHop;
        private System.Windows.Forms.Button btn_dangBai;
        private System.Windows.Forms.FlowLayoutPanel plHinhAnh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plNhanTin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_listBlock;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}