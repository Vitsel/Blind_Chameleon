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
            this.Function_LayoutPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Function_LayoutPanel
            // 
            this.Function_LayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.Function_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Function_LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.Function_LayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Function_LayoutPanel.Name = "Function_LayoutPanel";
            this.Function_LayoutPanel.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.Function_LayoutPanel.Size = new System.Drawing.Size(800, 620);
            this.Function_LayoutPanel.TabIndex = 1;
            // 
            // ChatMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.Function_LayoutPanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ChatMain";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Size = new System.Drawing.Size(800, 625);
            this.Load += new System.EventHandler(this.ChatMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Function_LayoutPanel;
    }
}
