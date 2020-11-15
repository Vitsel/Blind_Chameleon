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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Room_Menu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_RoomName = new System.Windows.Forms.Label();
            this.btn_Invite = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_RoomName);
            this.panel1.Controls.Add(this.btn_Invite);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 48);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseUp);
            // 
            // lbl_RoomName
            // 
            this.lbl_RoomName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbl_RoomName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_RoomName.Font = new System.Drawing.Font("KoPub돋움체 Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_RoomName.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_RoomName.Location = new System.Drawing.Point(35, 0);
            this.lbl_RoomName.Name = "lbl_RoomName";
            this.lbl_RoomName.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.lbl_RoomName.Size = new System.Drawing.Size(171, 48);
            this.lbl_RoomName.TabIndex = 3;
            this.lbl_RoomName.Text = "label2";
            this.lbl_RoomName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_RoomName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseDown);
            this.lbl_RoomName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseMove);
            this.lbl_RoomName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseUp);
            // 
            // btn_Invite
            // 
            this.btn_Invite.BackColor = System.Drawing.Color.Yellow;
            this.btn_Invite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Invite.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Invite.FlatAppearance.BorderSize = 0;
            this.btn_Invite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Invite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Invite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Invite.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Invite.Image = global::Blind_Client.Properties.Resources.adduser1;
            this.btn_Invite.Location = new System.Drawing.Point(206, 0);
            this.btn_Invite.Name = "btn_Invite";
            this.btn_Invite.Size = new System.Drawing.Size(60, 48);
            this.btn_Invite.TabIndex = 1;
            this.btn_Invite.UseVisualStyleBackColor = false;
            this.btn_Invite.Click += new System.EventHandler(this.btn_Invite_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("KoPub돋움체 Bold", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_close.Image = global::Blind_Client.Properties.Resources.backArrow;
            this.btn_close.Location = new System.Drawing.Point(0, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btn_close.Size = new System.Drawing.Size(35, 48);
            this.btn_close.TabIndex = 3;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.panel2.Size = new System.Drawing.Size(266, 313);
            this.panel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 56);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(26, 4, 26, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(18, 0, 9, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(258, 257);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(4, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel6.Size = new System.Drawing.Size(258, 56);
            this.panel6.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Blind_Client.Properties.Resources.menuName;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(258, 40);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::Blind_Client.Properties.Resources.users1;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(164, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(69, 40);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("KoPub돋움체 Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "참가중인 멤버";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.btn_exit);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 1);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(266, 398);
            this.panel5.TabIndex = 2;
            // 
            // btn_exit
            // 
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Image = global::Blind_Client.Properties.Resources.exit1;
            this.btn_exit.Location = new System.Drawing.Point(0, 361);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(266, 37);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Room_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(268, 400);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Room_Menu";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room_Menu";
            this.Load += new System.EventHandler(this.Room_Menu_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Invite;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lbl_RoomName;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
    }
}