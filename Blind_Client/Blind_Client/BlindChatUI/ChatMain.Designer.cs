﻿namespace Blind_Client.BlindChatUI
{
    partial class ChatMain
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Function_LayoutPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_LayoutPanel = new System.Windows.Forms.Panel();
            this.btn_Chat = new System.Windows.Forms.Button();
            this.btn_Member = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.Button_LayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Function_LayoutPanel
            // 
            this.Function_LayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.Function_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Function_LayoutPanel.Location = new System.Drawing.Point(80, 0);
            this.Function_LayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Function_LayoutPanel.Name = "Function_LayoutPanel";
            this.Function_LayoutPanel.Size = new System.Drawing.Size(620, 500);
            this.Function_LayoutPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Button_LayoutPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(80, 500);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Button_LayoutPanel
            // 
            this.Button_LayoutPanel.Controls.Add(this.btn_Chat);
            this.Button_LayoutPanel.Controls.Add(this.btn_Member);
            this.Button_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_LayoutPanel.Location = new System.Drawing.Point(0, 166);
            this.Button_LayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Button_LayoutPanel.Name = "Button_LayoutPanel";
            this.Button_LayoutPanel.Size = new System.Drawing.Size(80, 166);
            this.Button_LayoutPanel.TabIndex = 1;
            // 
            // btn_Chat
            // 
            this.btn_Chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Chat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Chat.FlatAppearance.BorderSize = 0;
            this.btn_Chat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Chat.Image = global::Blind_Client.Properties.Resources.chat;
            this.btn_Chat.Location = new System.Drawing.Point(0, 83);
            this.btn_Chat.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btn_Chat.Name = "btn_Chat";
            this.btn_Chat.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btn_Chat.Size = new System.Drawing.Size(80, 83);
            this.btn_Chat.TabIndex = 2;
            this.btn_Chat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Chat.UseVisualStyleBackColor = false;
            this.btn_Chat.Click += new System.EventHandler(this.btn_Chat_Click);
            // 
            // btn_Member
            // 
            this.btn_Member.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Member.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Member.FlatAppearance.BorderSize = 0;
            this.btn_Member.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Member.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Member.Image = global::Blind_Client.Properties.Resources.user;
            this.btn_Member.Location = new System.Drawing.Point(0, 0);
            this.btn_Member.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btn_Member.Name = "btn_Member";
            this.btn_Member.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btn_Member.Size = new System.Drawing.Size(80, 83);
            this.btn_Member.TabIndex = 1;
            this.btn_Member.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Member.UseVisualStyleBackColor = false;
            this.btn_Member.Click += new System.EventHandler(this.btn_Member_Click);
            // 
            // ChatMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.Function_LayoutPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ChatMain";
            this.Size = new System.Drawing.Size(700, 500);
            this.Load += new System.EventHandler(this.ChatMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Button_LayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Function_LayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel Button_LayoutPanel;
        private System.Windows.Forms.Button btn_Chat;
        private System.Windows.Forms.Button btn_Member;
    }
}
