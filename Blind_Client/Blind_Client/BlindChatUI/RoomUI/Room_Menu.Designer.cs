namespace Blind_Client.BlindChatUI.RoomUI
{
    partial class Room_Menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_RoomName = new System.Windows.Forms.Label();
            this.btn_Invite = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_UserListBox = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_RoomName);
            this.panel1.Controls.Add(this.btn_Invite);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 50);
            this.panel1.TabIndex = 0;
            // 
            // lbl_RoomName
            // 
            this.lbl_RoomName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbl_RoomName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_RoomName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RoomName.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_RoomName.Location = new System.Drawing.Point(0, 0);
            this.lbl_RoomName.Name = "lbl_RoomName";
            this.lbl_RoomName.Size = new System.Drawing.Size(193, 50);
            this.lbl_RoomName.TabIndex = 2;
            this.lbl_RoomName.Text = "label2";
            this.lbl_RoomName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Invite
            // 
            this.btn_Invite.BackColor = System.Drawing.Color.Yellow;
            this.btn_Invite.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Invite.FlatAppearance.BorderSize = 0;
            this.btn_Invite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Invite.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Invite.Location = new System.Drawing.Point(193, 0);
            this.btn_Invite.Name = "btn_Invite";
            this.btn_Invite.Size = new System.Drawing.Size(75, 50);
            this.btn_Invite.TabIndex = 1;
            this.btn_Invite.Text = "초대";
            this.btn_Invite.UseVisualStyleBackColor = false;
            this.btn_Invite.Click += new System.EventHandler(this.btn_Invite_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_UserListBox);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 351);
            this.panel2.TabIndex = 1;
            // 
            // lb_UserListBox
            // 
            this.lb_UserListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_UserListBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_UserListBox.FormattingEnabled = true;
            this.lb_UserListBox.ItemHeight = 21;
            this.lb_UserListBox.Location = new System.Drawing.Point(0, 20);
            this.lb_UserListBox.Name = "lb_UserListBox";
            this.lb_UserListBox.Size = new System.Drawing.Size(268, 331);
            this.lb_UserListBox.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 20);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "참가중인 멤버";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Room_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(268, 401);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Room_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room_Menu";
            this.Load += new System.EventHandler(this.Room_Menu_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lb_UserListBox;
        private System.Windows.Forms.Label lbl_RoomName;
        private System.Windows.Forms.Button btn_Invite;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
    }
}