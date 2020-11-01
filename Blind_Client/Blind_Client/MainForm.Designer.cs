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
            this.components = new System.ComponentModel.Container();
            this.Button_DocCenter = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MainControlPanel = new System.Windows.Forms.Panel();
            this.btn_ActivateChat = new System.Windows.Forms.Button();
            this.document_Center = new Blind_Client.Document_Center();
            this.BlindLockTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.MainControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_DocCenter
            // 
            this.Button_DocCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_DocCenter.Location = new System.Drawing.Point(3, 2);
            this.Button_DocCenter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_DocCenter.Name = "Button_DocCenter";
            this.Button_DocCenter.Size = new System.Drawing.Size(87, 46);
            this.Button_DocCenter.TabIndex = 0;
            this.Button_DocCenter.Text = "문서중앙화";
            this.Button_DocCenter.UseVisualStyleBackColor = true;
            this.Button_DocCenter.Click += new System.EventHandler(this.Button_DocCenter_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Button_DocCenter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MainControlPanel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_ActivateChat, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 360);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // MainControlPanel
            // 
            this.MainControlPanel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.MainControlPanel, 2);
            this.MainControlPanel.Controls.Add(this.document_Center);
            this.MainControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainControlPanel.Location = new System.Drawing.Point(96, 53);
            this.MainControlPanel.Name = "MainControlPanel";
            this.MainControlPanel.Size = new System.Drawing.Size(601, 304);
            this.MainControlPanel.TabIndex = 3;
            this.tableLayoutPanel1.SetRowSpan(this.MainControlPanel, 2);
            // 
            // btn_ActivateChat
            // 
            this.btn_ActivateChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ActivateChat.Location = new System.Drawing.Point(3, 53);
            this.btn_ActivateChat.Name = "btn_ActivateChat";
            this.btn_ActivateChat.Size = new System.Drawing.Size(87, 44);
            this.btn_ActivateChat.TabIndex = 0;
            this.btn_ActivateChat.Text = "채팅";
            this.btn_ActivateChat.UseVisualStyleBackColor = true;
            this.btn_ActivateChat.Click += new System.EventHandler(this.btn_ActivateChat_Click);
            // 
            // BlindLockTimer
            // 
            this.BlindLockTimer.Tick += new System.EventHandler(this.BlindChatTimer_Tick);
            // 
            // document_Center
            // 
            this.document_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.document_Center.Location = new System.Drawing.Point(0, 0);
            this.document_Center.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.document_Center.Name = "document_Center";
            this.document_Center.Size = new System.Drawing.Size(688, 380);
            this.document_Center.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 360);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MainControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_DocCenter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_ActivateChat;
        private System.Windows.Forms.Panel MainControlPanel;
        public Document_Center document_Center;
        private System.Windows.Forms.Timer BlindLockTimer;
    }
}

