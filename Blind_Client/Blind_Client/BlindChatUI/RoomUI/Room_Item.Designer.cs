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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Name.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(0, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(262, 25);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "label1";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Name.Click += new System.EventHandler(this.lbl_Name_Click);
            this.lbl_Name.DoubleClick += new System.EventHandler(this.lbl_Name_DoubleClick);
            // 
            // lbl_Info
            // 
            this.lbl_Info.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Info.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Info.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Info.Location = new System.Drawing.Point(0, 25);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(262, 15);
            this.lbl_Info.TabIndex = 1;
            this.lbl_Info.Text = "label2";
            this.lbl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Info.Click += new System.EventHandler(this.lbl_Name_Click);
            this.lbl_Info.DoubleClick += new System.EventHandler(this.lbl_Name_DoubleClick);
            // 
            // btn_NewMessage
            // 
            this.btn_NewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_NewMessage.BackColor = System.Drawing.Color.Transparent;
            this.btn_NewMessage.FlatAppearance.BorderSize = 0;
            this.btn_NewMessage.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btn_NewMessage.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btn_NewMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewMessage.Location = new System.Drawing.Point(129, 20);
            this.btn_NewMessage.Name = "btn_NewMessage";
            this.btn_NewMessage.Size = new System.Drawing.Size(33, 20);
            this.btn_NewMessage.TabIndex = 2;
            this.btn_NewMessage.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Info);
            this.panel1.Controls.Add(this.lbl_Name);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 40);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_Time);
            this.panel2.Controls.Add(this.btn_NewMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(262, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 40);
            this.panel2.TabIndex = 4;
            // 
            // lbl_Time
            // 
            this.lbl_Time.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Time.Font = new System.Drawing.Font("KoPub돋움체 Medium", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Time.Location = new System.Drawing.Point(0, 0);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(138, 25);
            this.lbl_Time.TabIndex = 3;
            this.lbl_Time.Text = "label1";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Room_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.Name = "Room_Item";
            this.Size = new System.Drawing.Size(400, 40);
            this.Load += new System.EventHandler(this.Room_Item_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Button btn_NewMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Time;
    }
}
