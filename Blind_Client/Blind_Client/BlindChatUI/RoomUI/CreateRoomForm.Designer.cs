namespace Blind_Client.BlindChatUI.RoomUI
{
    partial class CreateRoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_FormName = new System.Windows.Forms.Label();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.CreateRoomIItem_LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_RoomName = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_UserCount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CreateRoomIItem_LayoutPanel);
            this.panel1.Controls.Add(this.lbl_UserCount);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tb_Search);
            this.panel1.Controls.Add(this.lbl_FormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 461);
            this.panel1.TabIndex = 0;
            // 
            // lbl_FormName
            // 
            this.lbl_FormName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_FormName.Location = new System.Drawing.Point(0, 0);
            this.lbl_FormName.Name = "lbl_FormName";
            this.lbl_FormName.Size = new System.Drawing.Size(284, 50);
            this.lbl_FormName.TabIndex = 0;
            this.lbl_FormName.Text = "대화 상대 선택";
            this.lbl_FormName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Search
            // 
            this.tb_Search.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_Search.Location = new System.Drawing.Point(0, 50);
            this.tb_Search.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(284, 21);
            this.tb_Search.TabIndex = 1;
            // 
            // CreateRoomIItem_LayoutPanel
            // 
            this.CreateRoomIItem_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreateRoomIItem_LayoutPanel.Location = new System.Drawing.Point(0, 91);
            this.CreateRoomIItem_LayoutPanel.Name = "CreateRoomIItem_LayoutPanel";
            this.CreateRoomIItem_LayoutPanel.Size = new System.Drawing.Size(284, 290);
            this.CreateRoomIItem_LayoutPanel.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btn_Confirm);
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.tb_RoomName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 381);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 80);
            this.panel2.TabIndex = 3;
            // 
            // tb_RoomName
            // 
            this.tb_RoomName.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_RoomName.Location = new System.Drawing.Point(0, 0);
            this.tb_RoomName.Name = "tb_RoomName";
            this.tb_RoomName.Size = new System.Drawing.Size(284, 21);
            this.tb_RoomName.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Cancel.Location = new System.Drawing.Point(209, 21);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 59);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Confirm.Location = new System.Drawing.Point(134, 21);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 59);
            this.btn_Confirm.TabIndex = 2;
            this.btn_Confirm.Text = "확인";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(134, 59);
            this.panel3.TabIndex = 3;
            // 
            // lbl_UserCount
            // 
            this.lbl_UserCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_UserCount.Location = new System.Drawing.Point(0, 71);
            this.lbl_UserCount.Name = "lbl_UserCount";
            this.lbl_UserCount.Size = new System.Drawing.Size(284, 20);
            this.lbl_UserCount.TabIndex = 4;
            this.lbl_UserCount.Text = "인원 수(1/20)";
            this.lbl_UserCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreateRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.panel1);
            this.Name = "CreateRoomForm";
            this.Text = "CreateRoomForm";
            this.Load += new System.EventHandler(this.CreateRoomForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel CreateRoomIItem_LayoutPanel;
        private System.Windows.Forms.Label lbl_UserCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox tb_RoomName;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.Label lbl_FormName;
    }
}