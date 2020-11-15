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
            this.btn_close = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Invite = new System.Windows.Forms.Button();
            this.lbl_RoomName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_UserListBox = new System.Windows.Forms.ListBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 70);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseUp);
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("KoPub돋움체 Bold", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_close.Location = new System.Drawing.Point(243, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(20, 20);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "X";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbl_RoomName);
            this.panel4.Controls.Add(this.btn_Invite);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 20);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(266, 50);
            this.panel4.TabIndex = 2;
            // 
            // btn_Invite
            // 
            this.btn_Invite.BackColor = System.Drawing.Color.Yellow;
            this.btn_Invite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Invite.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Invite.FlatAppearance.BorderSize = 0;
            this.btn_Invite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Invite.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Invite.Image = global::Blind_Client.Properties.Resources.adduser1;
            this.btn_Invite.Location = new System.Drawing.Point(206, 0);
            this.btn_Invite.Name = "btn_Invite";
            this.btn_Invite.Size = new System.Drawing.Size(60, 50);
            this.btn_Invite.TabIndex = 1;
            this.btn_Invite.UseVisualStyleBackColor = false;
            this.btn_Invite.Click += new System.EventHandler(this.btn_Invite_Click);
            // 
            // lbl_RoomName
            // 
            this.lbl_RoomName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbl_RoomName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_RoomName.Font = new System.Drawing.Font("KoPub돋움체 Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_RoomName.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_RoomName.Location = new System.Drawing.Point(0, 0);
            this.lbl_RoomName.Name = "lbl_RoomName";
            this.lbl_RoomName.Size = new System.Drawing.Size(206, 50);
            this.lbl_RoomName.TabIndex = 3;
            this.lbl_RoomName.Text = "label2";
            this.lbl_RoomName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_RoomName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseDown);
            this.lbl_RoomName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseMove);
            this.lbl_RoomName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_UserListBox);
            this.panel2.Controls.Add(this.btn_exit);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 329);
            this.panel2.TabIndex = 1;
            // 
            // lb_UserListBox
            // 
            this.lb_UserListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_UserListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_UserListBox.Font = new System.Drawing.Font("KoPub돋움체 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_UserListBox.FormattingEnabled = true;
            this.lb_UserListBox.ItemHeight = 18;
            this.lb_UserListBox.Location = new System.Drawing.Point(0, 20);
            this.lb_UserListBox.Name = "lb_UserListBox";
            this.lb_UserListBox.Size = new System.Drawing.Size(266, 272);
            this.lb_UserListBox.TabIndex = 0;
            // 
            // btn_exit
            // 
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Image = global::Blind_Client.Properties.Resources.exit1;
            this.btn_exit.Location = new System.Drawing.Point(0, 292);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(266, 37);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(266, 20);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("KoPub돋움체 Medium", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "참가중인 멤버";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 1);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(266, 399);
            this.panel5.TabIndex = 2;
            // 
            // Room_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(268, 401);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Room_Menu";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room_Menu";
            this.Load += new System.EventHandler(this.Room_Menu_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lb_UserListBox;
        private System.Windows.Forms.Button btn_Invite;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_RoomName;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel5;
    }
}