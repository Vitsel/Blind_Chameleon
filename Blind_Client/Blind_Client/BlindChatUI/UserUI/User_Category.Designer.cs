namespace Blind_Client.BlindChatUI.UserUI
{
    partial class User_Category
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
            this.Lbl_Category = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbl_Category
            // 
            this.Lbl_Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Lbl_Category.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Category.Font = new System.Drawing.Font("KoPub돋움체 Bold", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lbl_Category.Location = new System.Drawing.Point(0, 0);
            this.Lbl_Category.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_Category.Name = "Lbl_Category";
            this.Lbl_Category.Padding = new System.Windows.Forms.Padding(2);
            this.Lbl_Category.Size = new System.Drawing.Size(200, 18);
            this.Lbl_Category.TabIndex = 0;
            this.Lbl_Category.Text = "Category";
            this.Lbl_Category.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // User_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.Lbl_Category);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "User_Category";
            this.Size = new System.Drawing.Size(200, 18);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Category;
    }
}
