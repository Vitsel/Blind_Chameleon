namespace Blind_Client.BlindChatUI.RoomUI
{
    partial class Invitation_Item
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.btn_Decline = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Decline);
            this.panel1.Controls.Add(this.btn_Accept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(150, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 50);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Accept
            // 
            this.btn_Accept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Accept.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Accept.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Accept.Location = new System.Drawing.Point(90, 0);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(60, 50);
            this.btn_Accept.TabIndex = 0;
            this.btn_Accept.Text = "수락";
            this.btn_Accept.UseVisualStyleBackColor = false;
            // 
            // btn_Decline
            // 
            this.btn_Decline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Decline.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Decline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Decline.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Decline.Location = new System.Drawing.Point(30, 0);
            this.btn_Decline.Name = "btn_Decline";
            this.btn_Decline.Size = new System.Drawing.Size(60, 50);
            this.btn_Decline.TabIndex = 1;
            this.btn_Decline.Text = "거절";
            this.btn_Decline.UseVisualStyleBackColor = false;
            // 
            // Invitation_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Invitation_Item";
            this.Size = new System.Drawing.Size(300, 50);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Decline;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Label label1;
    }
}
