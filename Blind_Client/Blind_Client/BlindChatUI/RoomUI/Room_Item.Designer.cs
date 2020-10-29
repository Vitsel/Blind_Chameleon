namespace Blind_Client.BlindChatUI.RoomUI
{
    partial class Room_Item
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
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.btn_NewMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Name.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(0, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(400, 25);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "label1";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Name.Click += new System.EventHandler(this.lbl_Name_Click);
            this.lbl_Name.DoubleClick += new System.EventHandler(this.lbl_Name_DoubleClick);
            // 
            // lbl_Info
            // 
            this.lbl_Info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_Info.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Info.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Info.Location = new System.Drawing.Point(0, 25);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(400, 15);
            this.lbl_Info.TabIndex = 1;
            this.lbl_Info.Text = "label2";
            this.lbl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Info.Click += new System.EventHandler(this.lbl_Name_Click);
            this.lbl_Info.DoubleClick += new System.EventHandler(this.lbl_Name_DoubleClick);
            // 
            // btn_NewMessage
            // 
            this.btn_NewMessage.BackColor = System.Drawing.Color.Transparent;
            this.btn_NewMessage.Location = new System.Drawing.Point(377, 5);
            this.btn_NewMessage.Name = "btn_NewMessage";
            this.btn_NewMessage.Size = new System.Drawing.Size(20, 20);
            this.btn_NewMessage.TabIndex = 2;
            this.btn_NewMessage.UseVisualStyleBackColor = false;
            // 
            // Room_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_NewMessage);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.lbl_Name);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Room_Item";
            this.Size = new System.Drawing.Size(400, 40);
            this.Load += new System.EventHandler(this.Room_Item_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Button btn_NewMessage;
    }
}
