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
            this.CreateRoomIItem_LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_UserCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tb_RoomName = new System.Windows.Forms.TextBox();
            this.lbl_FormName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CreateRoomIItem_LayoutPanel);
            this.panel1.Controls.Add(this.lbl_UserCount);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 63);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panel1.Size = new System.Drawing.Size(278, 395);
            this.panel1.TabIndex = 0;
            // 
            // CreateRoomIItem_LayoutPanel
            // 
            this.CreateRoomIItem_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreateRoomIItem_LayoutPanel.Location = new System.Drawing.Point(10, 20);
            this.CreateRoomIItem_LayoutPanel.Name = "CreateRoomIItem_LayoutPanel";
            this.CreateRoomIItem_LayoutPanel.Size = new System.Drawing.Size(258, 285);
            this.CreateRoomIItem_LayoutPanel.TabIndex = 2;
            // 
            // lbl_UserCount
            // 
            this.lbl_UserCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_UserCount.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserCount.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_UserCount.Location = new System.Drawing.Point(10, 0);
            this.lbl_UserCount.Name = "lbl_UserCount";
            this.lbl_UserCount.Size = new System.Drawing.Size(258, 20);
            this.lbl_UserCount.TabIndex = 4;
            this.lbl_UserCount.Text = "인원 수(1/20)";
            this.lbl_UserCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.tb_RoomName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 80);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_Confirm);
            this.panel3.Controls.Add(this.btn_Cancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 20);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel3.Size = new System.Drawing.Size(258, 60);
            this.panel3.TabIndex = 3;
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Confirm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Confirm.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btn_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Confirm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Confirm.Location = new System.Drawing.Point(118, 10);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(70, 50);
            this.btn_Confirm.TabIndex = 2;
            this.btn_Confirm.Text = "확인";
            this.btn_Confirm.UseVisualStyleBackColor = false;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(188, 10);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(70, 50);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tb_RoomName
            // 
            this.tb_RoomName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_RoomName.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_RoomName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_RoomName.Location = new System.Drawing.Point(0, 0);
            this.tb_RoomName.Margin = new System.Windows.Forms.Padding(10);
            this.tb_RoomName.Name = "tb_RoomName";
            this.tb_RoomName.Size = new System.Drawing.Size(258, 20);
            this.tb_RoomName.TabIndex = 0;
            // 
            // lbl_FormName
            // 
            this.lbl_FormName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbl_FormName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_FormName.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FormName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_FormName.Location = new System.Drawing.Point(0, 0);
            this.lbl_FormName.Name = "lbl_FormName";
            this.lbl_FormName.Size = new System.Drawing.Size(278, 54);
            this.lbl_FormName.TabIndex = 0;
            this.lbl_FormName.Text = "대화 상대 선택";
            this.lbl_FormName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_FormName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseDown);
            this.lbl_FormName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseMove);
            this.lbl_FormName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_FormName_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 461);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.lbl_FormName);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(278, 54);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.button1);
            this.panel4.Location = new System.Drawing.Point(258, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 20);
            this.panel4.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateRoomForm";
            this.Text = "CreateRoomForm";
            this.Load += new System.EventHandler(this.CreateRoomForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
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
        private System.Windows.Forms.Label lbl_FormName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
    }
}