namespace Blind_Client.BlindLock
{
    partial class LockForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BlindLockPic = new System.Windows.Forms.PictureBox();
            this.tbl_InfoLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Escape = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.btn_Unlock = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlindLockPic)).BeginInit();
            this.tbl_InfoLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.BlindLockPic, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbl_InfoLayout, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BlindLockPic
            // 
            this.BlindLockPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlindLockPic.Location = new System.Drawing.Point(0, 0);
            this.BlindLockPic.Margin = new System.Windows.Forms.Padding(0);
            this.BlindLockPic.Name = "BlindLockPic";
            this.BlindLockPic.Size = new System.Drawing.Size(600, 450);
            this.BlindLockPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BlindLockPic.TabIndex = 0;
            this.BlindLockPic.TabStop = false;
            // 
            // tbl_InfoLayout
            // 
            this.tbl_InfoLayout.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tbl_InfoLayout.ColumnCount = 1;
            this.tbl_InfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_InfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl_InfoLayout.Controls.Add(this.btn_Escape, 0, 0);
            this.tbl_InfoLayout.Controls.Add(this.panel1, 0, 1);
            this.tbl_InfoLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_InfoLayout.Location = new System.Drawing.Point(603, 0);
            this.tbl_InfoLayout.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tbl_InfoLayout.Name = "tbl_InfoLayout";
            this.tbl_InfoLayout.RowCount = 3;
            this.tbl_InfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_InfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tbl_InfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_InfoLayout.Size = new System.Drawing.Size(197, 450);
            this.tbl_InfoLayout.TabIndex = 1;
            // 
            // btn_Escape
            // 
            this.btn_Escape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Escape.Location = new System.Drawing.Point(119, 3);
            this.btn_Escape.Name = "btn_Escape";
            this.btn_Escape.Size = new System.Drawing.Size(75, 42);
            this.btn_Escape.TabIndex = 1;
            this.btn_Escape.Text = "비상버튼";
            this.btn_Escape.UseVisualStyleBackColor = true;
            this.btn_Escape.Click += new System.EventHandler(this.btn_Escape_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_Password);
            this.panel1.Controls.Add(this.btn_Unlock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 125);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 200);
            this.panel1.TabIndex = 0;
            // 
            // tb_Password
            // 
            this.tb_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Password.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tb_Password.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Password.Location = new System.Drawing.Point(0, 138);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(197, 30);
            this.tb_Password.TabIndex = 2;
            this.tb_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Password_KeyDown);
            // 
            // btn_Unlock
            // 
            this.btn_Unlock.BackColor = System.Drawing.Color.White;
            this.btn_Unlock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Unlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Unlock.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Unlock.Location = new System.Drawing.Point(0, 168);
            this.btn_Unlock.Name = "btn_Unlock";
            this.btn_Unlock.Size = new System.Drawing.Size(197, 32);
            this.btn_Unlock.TabIndex = 1;
            this.btn_Unlock.Text = "UnLock";
            this.btn_Unlock.UseVisualStyleBackColor = false;
            this.btn_Unlock.Click += new System.EventHandler(this.btn_Unlock_Click);
            // 
            // LockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LockForm";
            this.Text = "LockForm";
            this.Load += new System.EventHandler(this.screenLock_Control1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlindLockPic)).EndInit();
            this.tbl_InfoLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox BlindLockPic;
        private System.Windows.Forms.TableLayoutPanel tbl_InfoLayout;
        private System.Windows.Forms.Button btn_Escape;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Button btn_Unlock;
    }
}