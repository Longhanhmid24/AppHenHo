namespace WinformGUI
{
    partial class Messenger
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Messenger));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_name = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGuiTInNhan = new System.Windows.Forms.Button();
            this.rtxtMessage = new System.Windows.Forms.RichTextBox();
            this.flHienThiTinNhan = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lb_name);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 100);
            this.panel1.TabIndex = 0;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.ForeColor = System.Drawing.Color.Black;
            this.lb_name.Location = new System.Drawing.Point(135, 38);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(98, 32);
            this.lb_name.TabIndex = 9;
            this.lb_name.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(25, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 63);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button7.Location = new System.Drawing.Point(778, 21);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(71, 60);
            this.button7.TabIndex = 7;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.btnGuiTInNhan);
            this.panel2.Controls.Add(this.rtxtMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 549);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(869, 97);
            this.panel2.TabIndex = 1;
            // 
            // btnGuiTInNhan
            // 
            this.btnGuiTInNhan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuiTInNhan.BackgroundImage")));
            this.btnGuiTInNhan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuiTInNhan.Location = new System.Drawing.Point(733, 18);
            this.btnGuiTInNhan.Name = "btnGuiTInNhan";
            this.btnGuiTInNhan.Size = new System.Drawing.Size(84, 61);
            this.btnGuiTInNhan.TabIndex = 1;
            this.btnGuiTInNhan.UseVisualStyleBackColor = true;
            this.btnGuiTInNhan.Click += new System.EventHandler(this.btnGuiTInNhan_Click);
            // 
            // rtxtMessage
            // 
            this.rtxtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtMessage.Location = new System.Drawing.Point(81, 32);
            this.rtxtMessage.Name = "rtxtMessage";
            this.rtxtMessage.Size = new System.Drawing.Size(585, 30);
            this.rtxtMessage.TabIndex = 0;
            this.rtxtMessage.Text = "";
            // 
            // flHienThiTinNhan
            // 
            this.flHienThiTinNhan.AutoScroll = true;
            this.flHienThiTinNhan.Dock = System.Windows.Forms.DockStyle.Right;
            this.flHienThiTinNhan.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flHienThiTinNhan.Location = new System.Drawing.Point(0, 100);
            this.flHienThiTinNhan.Name = "flHienThiTinNhan";
            this.flHienThiTinNhan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flHienThiTinNhan.Size = new System.Drawing.Size(869, 449);
            this.flHienThiTinNhan.TabIndex = 2;
            this.flHienThiTinNhan.WrapContents = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Messenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flHienThiTinNhan);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Messenger";
            this.Size = new System.Drawing.Size(869, 646);
            this.Load += new System.EventHandler(this.Messenger_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGuiTInNhan;
        private System.Windows.Forms.RichTextBox rtxtMessage;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.FlowLayoutPanel flHienThiTinNhan;
        private System.Windows.Forms.Timer timer1;
    }
}
