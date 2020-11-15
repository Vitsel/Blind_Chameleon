namespace Blind_Client.BlindChatUI
{
    partial class Control_User
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.UserItem_LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.UserInfo_LayoutPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_user = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UserItem_LayoutPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(200, 428);
            this.panel1.TabIndex = 0;
            // 
            // UserItem_LayoutPanel
            // 
            this.UserItem_LayoutPanel.AutoScroll = true;
            this.UserItem_LayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.UserItem_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserItem_LayoutPanel.Location = new System.Drawing.Point(14, 0);
            this.UserItem_LayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.UserItem_LayoutPanel.Name = "UserItem_LayoutPanel";
            this.UserItem_LayoutPanel.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.UserItem_LayoutPanel.Size = new System.Drawing.Size(186, 428);
            this.UserItem_LayoutPanel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.UserInfo_LayoutPanel);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.panel3.Size = new System.Drawing.Size(457, 430);
            this.panel3.TabIndex = 3;
            // 
            // UserInfo_LayoutPanel
            // 
            this.UserInfo_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserInfo_LayoutPanel.Location = new System.Drawing.Point(200, 0);
            this.UserInfo_LayoutPanel.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.UserInfo_LayoutPanel.Name = "UserInfo_LayoutPanel";
            this.UserInfo_LayoutPanel.Padding = new System.Windows.Forms.Padding(2, 0, 10, 0);
            this.UserInfo_LayoutPanel.Size = new System.Drawing.Size(255, 428);
            this.UserInfo_LayoutPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12, 7, 5, 10);
            this.panel2.Size = new System.Drawing.Size(457, 70);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::Blind_Client.Properties.Resources.titleBack;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.lbl_user);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(12, 7);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(137, 53);
            this.panel4.TabIndex = 0;
            // 
            // lbl_user
            // 
            this.lbl_user.BackColor = System.Drawing.Color.Transparent;
            this.lbl_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_user.Font = new System.Drawing.Font("KoPub돋움체 Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_user.Location = new System.Drawing.Point(0, 0);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(137, 53);
            this.lbl_user.TabIndex = 1;
            this.lbl_user.Text = "사용자";
            this.lbl_user.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Control_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Control_User";
            this.Size = new System.Drawing.Size(457, 500);
            this.Load += new System.EventHandler(this.Control_User_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel UserItem_LayoutPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel UserInfo_LayoutPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_user;
    }
}
