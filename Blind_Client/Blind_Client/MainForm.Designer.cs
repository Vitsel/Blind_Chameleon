namespace Blind_Client
{
    partial class MainForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_DocCenter = new System.Windows.Forms.Button();
            this.document_Center = new Blind_Client.Document_Center();
            this.SuspendLayout();
            // 
            // Button_DocCenter
            // 
            this.Button_DocCenter.Location = new System.Drawing.Point(15, 17);
            this.Button_DocCenter.Name = "Button_DocCenter";
            this.Button_DocCenter.Size = new System.Drawing.Size(153, 65);
            this.Button_DocCenter.TabIndex = 0;
            this.Button_DocCenter.Text = "문서중앙화";
            this.Button_DocCenter.UseVisualStyleBackColor = true;
            this.Button_DocCenter.Click += new System.EventHandler(this.Button_DocCenter_Click);
            // 
            // document_Center
            // 
            this.document_Center.Location = new System.Drawing.Point(108, 88);
            this.document_Center.Name = "document_Center";
            this.document_Center.Size = new System.Drawing.Size(691, 361);
            this.document_Center.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.document_Center);
            this.Controls.Add(this.Button_DocCenter);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_DocCenter;
        private Document_Center document_Center;
    }
}

