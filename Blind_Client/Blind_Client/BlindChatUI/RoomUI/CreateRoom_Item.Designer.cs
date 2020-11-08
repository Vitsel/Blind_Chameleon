namespace Blind_Client.BlindChatUI.RoomUI
{
    partial class CreateRoom_Item
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
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.btn_Check = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_UserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_UserName.Location = new System.Drawing.Point(0, 0);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(260, 50);
            this.lbl_UserName.TabIndex = 0;
            this.lbl_UserName.Text = "label1";
            this.lbl_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_UserName.Click += new System.EventHandler(this.lbl_UserName_Click);
            this.lbl_UserName.MouseLeave += new System.EventHandler(this.lbl_UserName_MouseLeave);
            this.lbl_UserName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_UserName_MouseMove);
            // 
            // btn_Check
            // 
            this.btn_Check.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Check.FlatAppearance.BorderSize = 0;
            this.btn_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Check.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Check.Location = new System.Drawing.Point(6, 6);
            this.btn_Check.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(18, 18);
            this.btn_Check.TabIndex = 1;
            this.btn_Check.UseVisualStyleBackColor = false;
            this.btn_Check.Click += new System.EventHandler(this.lbl_UserName_Click);
            this.btn_Check.MouseLeave += new System.EventHandler(this.lbl_UserName_MouseLeave);
            this.btn_Check.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_UserName_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel1.Controls.Add(this.btn_Check);
            this.panel1.Location = new System.Drawing.Point(216, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(30, 30);
            this.panel1.TabIndex = 2;
            // 
            // CreateRoom_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_UserName);
            this.Name = "CreateRoom_Item";
            this.Size = new System.Drawing.Size(260, 50);
            this.Load += new System.EventHandler(this.CreateRoom_Item_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.Panel panel1;
    }
}
