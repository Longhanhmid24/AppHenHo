namespace Admin.UserControl
{
    partial class BaoCao
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
            dgvBaoCao = new System.Windows.Forms.DataGridView();
            clmMaReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmLoaiReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmSender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmReceiver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btn_blockUser = new System.Windows.Forms.Button();
            btn_unlockUser = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            label8 = new System.Windows.Forms.Label();
            dgvBlock = new System.Windows.Forms.DataGridView();
            clmUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmBlocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBlock).BeginInit();
            SuspendLayout();
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.BackgroundColor = System.Drawing.Color.White;
            dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { clmMaReport, clmLoaiReport, clmNoiDung, clmTime, clmSender, clmReceiver });
            dgvBaoCao.Location = new System.Drawing.Point(30, 228);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.Size = new System.Drawing.Size(752, 763);
            dgvBaoCao.TabIndex = 0;
            dgvBaoCao.CellClick += dgvBaoCao_CellClick_1;
            // 
            // clmMaReport
            // 
            clmMaReport.HeaderText = "Mã Báo Cáo";
            clmMaReport.MinimumWidth = 6;
            clmMaReport.Name = "clmMaReport";
            // 
            // clmLoaiReport
            // 
            clmLoaiReport.HeaderText = "Loại Báo Cáo";
            clmLoaiReport.MinimumWidth = 6;
            clmLoaiReport.Name = "clmLoaiReport";
            // 
            // clmNoiDung
            // 
            clmNoiDung.HeaderText = "Nội Dung";
            clmNoiDung.MinimumWidth = 6;
            clmNoiDung.Name = "clmNoiDung";
            // 
            // clmTime
            // 
            clmTime.HeaderText = "Thời Gian";
            clmTime.MinimumWidth = 6;
            clmTime.Name = "clmTime";
            // 
            // clmSender
            // 
            clmSender.HeaderText = "Người Gửi Báo Cáo";
            clmSender.MinimumWidth = 6;
            clmSender.Name = "clmSender";
            // 
            // clmReceiver
            // 
            clmReceiver.HeaderText = "Người Bị Báo Cáo";
            clmReceiver.MinimumWidth = 6;
            clmReceiver.Name = "clmReceiver";
            // 
            // btn_blockUser
            // 
            btn_blockUser.BackColor = System.Drawing.Color.Red;
            btn_blockUser.Font = new System.Drawing.Font("Tahoma", 12F);
            btn_blockUser.ForeColor = System.Drawing.Color.White;
            btn_blockUser.Location = new System.Drawing.Point(800, 268);
            btn_blockUser.Name = "btn_blockUser";
            btn_blockUser.Size = new System.Drawing.Size(162, 85);
            btn_blockUser.TabIndex = 1;
            btn_blockUser.Text = "khóa tài khoản";
            btn_blockUser.UseVisualStyleBackColor = false;
            btn_blockUser.Click += btn_blockUser_Click;
            // 
            // btn_unlockUser
            // 
            btn_unlockUser.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            btn_unlockUser.Font = new System.Drawing.Font("Tahoma", 12F);
            btn_unlockUser.ForeColor = System.Drawing.Color.White;
            btn_unlockUser.Location = new System.Drawing.Point(800, 369);
            btn_unlockUser.Name = "btn_unlockUser";
            btn_unlockUser.Size = new System.Drawing.Size(162, 81);
            btn_unlockUser.TabIndex = 1;
            btn_unlockUser.Text = "mở tài khoản";
            btn_unlockUser.UseVisualStyleBackColor = false;
            btn_unlockUser.Click += btn_unlockUser_Click;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Navy;
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1518, 125);
            panel1.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label8.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label8.Location = new System.Drawing.Point(684, 148);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(448, 48);
            label8.TabIndex = 19;
            label8.Text = "Kiểm tra đơn báo cáo";
            // 
            // dgvBlock
            // 
            dgvBlock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvBlock.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dgvBlock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBlock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { clmUserName, clmBlocked });
            dgvBlock.Location = new System.Drawing.Point(977, 231);
            dgvBlock.Name = "dgvBlock";
            dgvBlock.RowHeadersWidth = 51;
            dgvBlock.Size = new System.Drawing.Size(422, 760);
            dgvBlock.TabIndex = 20;
            dgvBlock.CellClick += dgvBlock_CellClick;
            // 
            // clmUserName
            // 
            clmUserName.HeaderText = "Tài Khoản Bị Khóa";
            clmUserName.MinimumWidth = 6;
            clmUserName.Name = "clmUserName";
            // 
            // clmBlocked
            // 
            clmBlocked.HeaderText = "Trạng Thái Khóa";
            clmBlocked.MinimumWidth = 6;
            clmBlocked.Name = "clmBlocked";
            // 
            // BaoCao
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(dgvBlock);
            Controls.Add(label8);
            Controls.Add(panel1);
            Controls.Add(btn_unlockUser);
            Controls.Add(btn_blockUser);
            Controls.Add(dgvBaoCao);
            Name = "BaoCao";
            Size = new System.Drawing.Size(1518, 1002);
            Load += BaoCao_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBlock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLoaiReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSender;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmReceiver;
        private System.Windows.Forms.Button btn_blockUser;
        private System.Windows.Forms.Button btn_unlockUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvBlock;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBlocked;
    }
}
