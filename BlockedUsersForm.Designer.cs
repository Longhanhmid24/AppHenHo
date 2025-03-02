namespace WinformGUI
{
    partial class BlockedUsersForm
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
            this.flowBlockedUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowBlockedUsers
            // 
            this.flowBlockedUsers.AutoScroll = true;
            this.flowBlockedUsers.Location = new System.Drawing.Point(3, 70);
            this.flowBlockedUsers.Name = "flowBlockedUsers";
            this.flowBlockedUsers.Size = new System.Drawing.Size(816, 465);
            this.flowBlockedUsers.TabIndex = 0;
            // 
            // BlockedUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowBlockedUsers);
            this.Name = "BlockedUsersForm";
            this.Size = new System.Drawing.Size(822, 535);
            this.Load += new System.EventHandler(this.BlockedUsersForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowBlockedUsers;
    }
}
