namespace Blind_Client.BlindChatUI.RoomUI
{
    partial class MessageRoom
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_menu = new System.Windows.Forms.Button();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tb_Message = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.message_LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 80);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("KoPub돋움체 Bold", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(42, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_menu
            // 
            this.btn_menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_menu.FlatAppearance.BorderSize = 0;
            this.btn_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_menu.Image = global::Blind_Client.Properties.Resources.hamburger1;
            this.btn_menu.Location = new System.Drawing.Point(2, 33);
            this.btn_menu.Name = "btn_menu";
            this.btn_menu.Size = new System.Drawing.Size(60, 47);
            this.btn_menu.TabIndex = 2;
            this.btn_menu.UseVisualStyleBackColor = true;
            this.btn_menu.Click += new System.EventHandler(this.btn_menu_Click);
            // 
            // lbl_ID
            // 
            this.lbl_ID.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_ID.Font = new System.Drawing.Font("KoPub돋움체 Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ID.Location = new System.Drawing.Point(0, 50);
            this.lbl_ID.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lbl_ID.Size = new System.Drawing.Size(220, 30);
            this.lbl_ID.TabIndex = 1;
            this.lbl_ID.Text = "label1";
            this.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_ID.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseDown);
            this.lbl_ID.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseMove);
            this.lbl_ID.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseUp);
            // 
            // lbl_Title
            // 
            this.lbl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Title.Font = new System.Drawing.Font("KoPub돋움체 Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbl_Title.Size = new System.Drawing.Size(220, 50);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "label1";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseDown);
            this.lbl_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseMove);
            this.lbl_Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.btn_Send);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 399);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 60);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tb_Message);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(207, 60);
            this.panel5.TabIndex = 1;
            // 
            // tb_Message
            // 
            this.tb_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Message.Location = new System.Drawing.Point(3, 3);
            this.tb_Message.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Message.Multiline = true;
            this.tb_Message.Name = "tb_Message";
            this.tb_Message.Size = new System.Drawing.Size(201, 54);
            this.tb_Message.TabIndex = 2;
            this.tb_Message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Message_KeyDown);
            // 
            // btn_Send
            // 
            this.btn_Send.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Send.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Send.FlatAppearance.BorderSize = 0;
            this.btn_Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Send.Font = new System.Drawing.Font("KoPub돋움체 Medium", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Send.Location = new System.Drawing.Point(207, 0);
            this.btn_Send.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 60);
            this.btn_Send.TabIndex = 0;
            this.btn_Send.Text = "전송";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.message_LayoutPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel3.Size = new System.Drawing.Size(282, 319);
            this.panel3.TabIndex = 2;
            // 
            // message_LayoutPanel
            // 
            this.message_LayoutPanel.AutoScroll = true;
            this.message_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.message_LayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.message_LayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.message_LayoutPanel.Name = "message_LayoutPanel";
            this.message_LayoutPanel.Size = new System.Drawing.Size(276, 316);
            this.message_LayoutPanel.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(282, 459);
            this.panel4.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_menu);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(220, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(62, 80);
            this.panel6.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lbl_ID);
            this.panel7.Controls.Add(this.lbl_Title);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(220, 80);
            this.panel7.TabIndex = 5;
            // 
            // MessageRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageRoom";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageRoom";
            this.Load += new System.EventHandler(this.MessageRoom_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel message_LayoutPanel;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Button btn_menu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tb_Message;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
    }
}