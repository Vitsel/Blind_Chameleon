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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MainControlPanel = new System.Windows.Forms.Panel();
            this.document_Center = new Blind_Client.Document_Center();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ActivateChat = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Button_DocCenter = new System.Windows.Forms.Button();
            this.BlindLockTimer = new System.Windows.Forms.Timer(this.components);
            this.panel_Fore = new System.Windows.Forms.Panel();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_maximize = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ellipseControl1 = new Blind_Client.BlindChatUI.EllipseControl();
            this.ellipseControl2 = new Blind_Client.BlindChatUI.EllipseControl();
            this.ellipseControl3 = new Blind_Client.BlindChatUI.EllipseControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.MainControlPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_Fore.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.MainControlPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(698, 381);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // MainControlPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.MainControlPanel, 2);
            this.MainControlPanel.Controls.Add(this.document_Center);
            this.MainControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainControlPanel.Location = new System.Drawing.Point(0, 0);
            this.MainControlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainControlPanel.Name = "MainControlPanel";
            this.tableLayoutPanel1.SetRowSpan(this.MainControlPanel, 2);
            this.MainControlPanel.Size = new System.Drawing.Size(698, 343);
            this.MainControlPanel.TabIndex = 5;
            // 
            // document_Center
            // 
            this.document_Center.BackColor = System.Drawing.SystemColors.Control;
            this.document_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.document_Center.Location = new System.Drawing.Point(0, 0);
            this.document_Center.Margin = new System.Windows.Forms.Padding(0);
            this.document_Center.Name = "document_Center";
            this.document_Center.Size = new System.Drawing.Size(698, 343);
            this.document_Center.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ActivateChat);
            this.panel1.Location = new System.Drawing.Point(352, 345);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 34);
            this.panel1.TabIndex = 6;
            // 
            // btn_ActivateChat
            // 
            this.btn_ActivateChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ActivateChat.FlatAppearance.BorderSize = 0;
            this.btn_ActivateChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ActivateChat.Font = new System.Drawing.Font("KoPub돋움체 Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ActivateChat.Location = new System.Drawing.Point(0, 0);
            this.btn_ActivateChat.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ActivateChat.Name = "btn_ActivateChat";
            this.btn_ActivateChat.Size = new System.Drawing.Size(343, 34);
            this.btn_ActivateChat.TabIndex = 0;
            this.btn_ActivateChat.Text = "커뮤니티";
            this.btn_ActivateChat.UseVisualStyleBackColor = true;
            this.btn_ActivateChat.Click += new System.EventHandler(this.btn_ActivateChat_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Button_DocCenter);
            this.panel3.Location = new System.Drawing.Point(3, 345);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 34);
            this.panel3.TabIndex = 7;
            // 
            // Button_DocCenter
            // 
            this.Button_DocCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_DocCenter.FlatAppearance.BorderSize = 0;
            this.Button_DocCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_DocCenter.Font = new System.Drawing.Font("KoPub돋움체 Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button_DocCenter.Location = new System.Drawing.Point(0, 0);
            this.Button_DocCenter.Margin = new System.Windows.Forms.Padding(0);
            this.Button_DocCenter.Name = "Button_DocCenter";
            this.Button_DocCenter.Size = new System.Drawing.Size(343, 34);
            this.Button_DocCenter.TabIndex = 0;
            this.Button_DocCenter.Text = "문서\r\n중앙화";
            this.Button_DocCenter.UseVisualStyleBackColor = true;
            this.Button_DocCenter.Click += new System.EventHandler(this.Button_DocCenter_Click);
            // 
            // BlindLockTimer
            // 
            this.BlindLockTimer.Tick += new System.EventHandler(this.BlindChatTimer_Tick);
            // 
            // panel_Fore
            // 
            this.panel_Fore.Controls.Add(this.btn_minimize);
            this.panel_Fore.Controls.Add(this.btn_maximize);
            this.panel_Fore.Controls.Add(this.btn_close);
            this.panel_Fore.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Fore.Location = new System.Drawing.Point(3, 3);
            this.panel_Fore.Name = "panel_Fore";
            this.panel_Fore.Size = new System.Drawing.Size(698, 25);
            this.panel_Fore.TabIndex = 3;
            this.panel_Fore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Fore_MouseDown);
            this.panel_Fore.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Fore_MouseMove);
            this.panel_Fore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Fore_MouseUp);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_minimize.ForeColor = System.Drawing.Color.Gray;
            this.btn_minimize.Location = new System.Drawing.Point(608, 0);
            this.btn_minimize.Margin = new System.Windows.Forms.Padding(0);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(30, 25);
            this.btn_minimize.TabIndex = 2;
            this.btn_minimize.Text = "—";
            this.btn_minimize.UseVisualStyleBackColor = true;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            this.btn_minimize.MouseLeave += new System.EventHandler(this.btn_minimize_MouseLeave);
            this.btn_minimize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_minimize_MouseMove);
            // 
            // btn_maximize
            // 
            this.btn_maximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_maximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_maximize.FlatAppearance.BorderSize = 0;
            this.btn_maximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_maximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_maximize.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_maximize.ForeColor = System.Drawing.Color.Gray;
            this.btn_maximize.Location = new System.Drawing.Point(638, 0);
            this.btn_maximize.Margin = new System.Windows.Forms.Padding(0);
            this.btn_maximize.Name = "btn_maximize";
            this.btn_maximize.Size = new System.Drawing.Size(30, 25);
            this.btn_maximize.TabIndex = 1;
            this.btn_maximize.Text = "▭";
            this.btn_maximize.UseVisualStyleBackColor = true;
            this.btn_maximize.Click += new System.EventHandler(this.btn_maximize_Click);
            this.btn_maximize.MouseLeave += new System.EventHandler(this.btn_maximize_MouseLeave);
            this.btn_maximize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_maximize_MouseMove);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.Gray;
            this.btn_close.Location = new System.Drawing.Point(668, 0);
            this.btn_close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(30, 25);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "X";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            this.btn_close.MouseLeave += new System.EventHandler(this.btn_close_MouseLeave);
            this.btn_close.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_close_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 381);
            this.panel2.TabIndex = 4;
            // 
            // ellipseControl1
            // 
            this.ellipseControl1.CorenerRadius = 5;
            this.ellipseControl1.TargetControl = this;
            // 
            // ellipseControl2
            // 
            this.ellipseControl2.CorenerRadius = 5;
            this.ellipseControl2.TargetControl = this.tableLayoutPanel1;
            // 
            // ellipseControl3
            // 
            this.ellipseControl3.CorenerRadius = 5;
            this.ellipseControl3.TargetControl = this.panel_Fore;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(704, 412);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_Fore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.MainControlPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel_Fore.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_ActivateChat;
        private System.Windows.Forms.Timer BlindLockTimer;
        private System.Windows.Forms.Panel panel_Fore;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_maximize;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel2;
        private BlindChatUI.EllipseControl ellipseControl1;
        private BlindChatUI.EllipseControl ellipseControl2;
        private BlindChatUI.EllipseControl ellipseControl3;
        public Document_Center document_Center;
        private System.Windows.Forms.Button Button_DocCenter;
        private System.Windows.Forms.Panel MainControlPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
    }
}

