namespace Blind_Client.BlindChatUI.RoomUI
{
    partial class Invitation_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.InvitationItem_LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Invite = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_UserCount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 80);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "초대";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lbl_UserCount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 381);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.InvitationItem_LayoutPanel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(284, 309);
            this.panel4.TabIndex = 2;
            // 
            // InvitationItem_LayoutPanel
            // 
            this.InvitationItem_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvitationItem_LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.InvitationItem_LayoutPanel.Name = "InvitationItem_LayoutPanel";
            this.InvitationItem_LayoutPanel.Size = new System.Drawing.Size(284, 309);
            this.InvitationItem_LayoutPanel.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_Invite);
            this.panel3.Controls.Add(this.btn_Cancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 321);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 60);
            this.panel3.TabIndex = 1;
            // 
            // btn_Invite
            // 
            this.btn_Invite.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Invite.Location = new System.Drawing.Point(134, 0);
            this.btn_Invite.Name = "btn_Invite";
            this.btn_Invite.Size = new System.Drawing.Size(75, 60);
            this.btn_Invite.TabIndex = 1;
            this.btn_Invite.Text = "초대";
            this.btn_Invite.UseVisualStyleBackColor = true;
            this.btn_Invite.Click += new System.EventHandler(this.btn_Invite_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Cancel.Location = new System.Drawing.Point(209, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 60);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_UserCount
            // 
            this.lbl_UserCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_UserCount.Location = new System.Drawing.Point(0, 0);
            this.lbl_UserCount.Name = "lbl_UserCount";
            this.lbl_UserCount.Size = new System.Drawing.Size(284, 12);
            this.lbl_UserCount.TabIndex = 0;
            this.lbl_UserCount.Text = "인원 수 (0/20)";
            // 
            // Invitation_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Invitation_Form";
            this.Text = "Invitation_Form";
            this.Load += new System.EventHandler(this.Invitation_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_UserCount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Invite;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.FlowLayoutPanel InvitationItem_LayoutPanel;
    }
}