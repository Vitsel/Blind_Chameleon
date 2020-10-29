namespace Blind_Client.BlindChatUI.UserUI
{
    partial class User_Item
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
            this.Lbl_UserDepartment = new System.Windows.Forms.Label();
            this.Lbl_UserName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Lbl_UserDepartment);
            this.panel1.Controls.Add(this.Lbl_UserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 40);
            this.panel1.TabIndex = 0;
            // 
            // Lbl_UserDepartment
            // 
            this.Lbl_UserDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_UserDepartment.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_UserDepartment.ForeColor = System.Drawing.Color.DimGray;
            this.Lbl_UserDepartment.Location = new System.Drawing.Point(0, 23);
            this.Lbl_UserDepartment.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_UserDepartment.Name = "Lbl_UserDepartment";
            this.Lbl_UserDepartment.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.Lbl_UserDepartment.Size = new System.Drawing.Size(200, 17);
            this.Lbl_UserDepartment.TabIndex = 1;
            this.Lbl_UserDepartment.Text = "label1";
            this.Lbl_UserDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_UserDepartment.Click += new System.EventHandler(this.Lbl_UserName_Click);
            this.Lbl_UserDepartment.DoubleClick += new System.EventHandler(this.Lbl_UserName_DoubleClick);
            // 
            // Lbl_UserName
            // 
            this.Lbl_UserName.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_UserName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_UserName.Location = new System.Drawing.Point(0, 0);
            this.Lbl_UserName.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_UserName.Name = "Lbl_UserName";
            this.Lbl_UserName.Size = new System.Drawing.Size(200, 23);
            this.Lbl_UserName.TabIndex = 0;
            this.Lbl_UserName.Text = "label1";
            this.Lbl_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_UserName.Click += new System.EventHandler(this.Lbl_UserName_Click);
            this.Lbl_UserName.DoubleClick += new System.EventHandler(this.Lbl_UserName_DoubleClick);
            // 
            // User_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "User_Item";
            this.Size = new System.Drawing.Size(200, 40);
            this.Load += new System.EventHandler(this.User_Item_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lbl_UserDepartment;
        private System.Windows.Forms.Label Lbl_UserName;
    }
}
