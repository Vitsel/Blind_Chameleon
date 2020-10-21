namespace Blind_Client.BlindChatUI
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
            this.Button_LayoutPanel = new System.Windows.Forms.Panel();
            this.btn_More = new System.Windows.Forms.Button();
            this.btn_Chat = new System.Windows.Forms.Button();
            this.btn_Member = new System.Windows.Forms.Button();
            this.Function_LayoutPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Button_LayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_LayoutPanel
            // 
            this.Button_LayoutPanel.Controls.Add(this.btn_More);
            this.Button_LayoutPanel.Controls.Add(this.btn_Chat);
            this.Button_LayoutPanel.Controls.Add(this.btn_Member);
            this.Button_LayoutPanel.Controls.Add(this.panel1);
            this.Button_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Button_LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.Button_LayoutPanel.Name = "Button_LayoutPanel";
            this.Button_LayoutPanel.Size = new System.Drawing.Size(150, 500);
            this.Button_LayoutPanel.TabIndex = 0;
            // 
            // btn_More
            // 
            this.btn_More.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_More.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_More.FlatAppearance.BorderSize = 0;
            this.btn_More.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_More.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_More.Location = new System.Drawing.Point(0, 150);
            this.btn_More.Name = "btn_More";
            this.btn_More.Size = new System.Drawing.Size(150, 50);
            this.btn_More.TabIndex = 3;
            this.btn_More.Text = "More";
            this.btn_More.UseVisualStyleBackColor = false;
            this.btn_More.Click += new System.EventHandler(this.btn_More_Click);
            // 
            // btn_Chat
            // 
            this.btn_Chat.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Chat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Chat.FlatAppearance.BorderSize = 0;
            this.btn_Chat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Chat.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Chat.Location = new System.Drawing.Point(0, 100);
            this.btn_Chat.Name = "btn_Chat";
            this.btn_Chat.Size = new System.Drawing.Size(150, 50);
            this.btn_Chat.TabIndex = 2;
            this.btn_Chat.Text = "Chat";
            this.btn_Chat.UseVisualStyleBackColor = false;
            this.btn_Chat.Click += new System.EventHandler(this.btn_Chat_Click);
            // 
            // btn_Member
            // 
            this.btn_Member.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Member.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Member.FlatAppearance.BorderSize = 0;
            this.btn_Member.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Member.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Member.Location = new System.Drawing.Point(0, 50);
            this.btn_Member.Name = "btn_Member";
            this.btn_Member.Size = new System.Drawing.Size(150, 50);
            this.btn_Member.TabIndex = 1;
            this.btn_Member.Text = "Member";
            this.btn_Member.UseVisualStyleBackColor = false;
            this.btn_Member.Click += new System.EventHandler(this.btn_Member_Click);
            // 
            // Function_LayoutPanel
            // 
            this.Function_LayoutPanel.BackColor = System.Drawing.Color.SeaGreen;
            this.Function_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Function_LayoutPanel.Location = new System.Drawing.Point(150, 0);
            this.Function_LayoutPanel.Name = "Function_LayoutPanel";
            this.Function_LayoutPanel.Size = new System.Drawing.Size(550, 500);
            this.Function_LayoutPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 50);
            this.panel1.TabIndex = 4;
            // 
            // ChatMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Function_LayoutPanel);
            this.Controls.Add(this.Button_LayoutPanel);
            this.DoubleBuffered = true;
            this.Name = "ChatMain";
            this.Size = new System.Drawing.Size(700, 500);
            this.Load += new System.EventHandler(this.ChatMain_Load);
            this.Button_LayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Button_LayoutPanel;
        private System.Windows.Forms.Button btn_More;
        private System.Windows.Forms.Button btn_Chat;
        private System.Windows.Forms.Button btn_Member;
        private System.Windows.Forms.Panel Function_LayoutPanel;
        private System.Windows.Forms.Panel panel1;
    }
}
