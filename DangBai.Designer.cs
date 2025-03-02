namespace WinformGUI
{
    partial class DangBai
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_chonAnh = new System.Windows.Forms.Button();
            this.btn_dang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.GhostWhite;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(498, 391);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btn_chonAnh
            // 
            this.btn_chonAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_chonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chonAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chonAnh.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_chonAnh.Location = new System.Drawing.Point(3, 418);
            this.btn_chonAnh.Name = "btn_chonAnh";
            this.btn_chonAnh.Size = new System.Drawing.Size(250, 59);
            this.btn_chonAnh.TabIndex = 1;
            this.btn_chonAnh.Text = "Chọn Ảnh";
            this.btn_chonAnh.UseVisualStyleBackColor = false;
            this.btn_chonAnh.Click += new System.EventHandler(this.btn_chonAnh_Click);
            // 
            // btn_dang
            // 
            this.btn_dang.BackColor = System.Drawing.Color.Red;
            this.btn_dang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dang.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_dang.Location = new System.Drawing.Point(251, 418);
            this.btn_dang.Name = "btn_dang";
            this.btn_dang.Size = new System.Drawing.Size(250, 59);
            this.btn_dang.TabIndex = 2;
            this.btn_dang.Text = "Đăng Ảnh";
            this.btn_dang.UseVisualStyleBackColor = false;
            this.btn_dang.Click += new System.EventHandler(this.btn_dang_Click);
            // 
            // DangBai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.btn_dang);
            this.Controls.Add(this.btn_chonAnh);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DangBai";
            this.Size = new System.Drawing.Size(504, 499);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_chonAnh;
        private System.Windows.Forms.Button btn_dang;
    }
}
