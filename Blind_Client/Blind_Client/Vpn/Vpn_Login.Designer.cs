namespace Blind_Client
{
    partial class Vpn_Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vpn_Login));
            this.Vpn_Login_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.VPN_ID = new System.Windows.Forms.TextBox();
            this.VPN_PW = new System.Windows.Forms.TextBox();
            this.progressBar_VPNState = new System.Windows.Forms.ProgressBar();
            this.Vpn_EventTimer = new System.Windows.Forms.Timer(this.components);
            this.panel_Connection = new System.Windows.Forms.Panel();
            this.panel_Login = new System.Windows.Forms.Panel();
            this.EXIT_button = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.VPNConnectingExitbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_Connection.SuspendLayout();
            this.panel_Login.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Vpn_Login_Button
            // 
            this.Vpn_Login_Button.BackColor = System.Drawing.Color.SkyBlue;
            this.Vpn_Login_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Vpn_Login_Button.Font = new System.Drawing.Font("휴먼매직체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Vpn_Login_Button.ForeColor = System.Drawing.SystemColors.Control;
            this.Vpn_Login_Button.Location = new System.Drawing.Point(52, 168);
            this.Vpn_Login_Button.Name = "Vpn_Login_Button";
            this.Vpn_Login_Button.Size = new System.Drawing.Size(90, 50);
            this.Vpn_Login_Button.TabIndex = 3;
            this.Vpn_Login_Button.Text = "LOGIN";
            this.Vpn_Login_Button.UseVisualStyleBackColor = false;
            this.Vpn_Login_Button.Click += new System.EventHandler(this.Vpn_Login_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "USERID";
            // 
            // VPN_ID
            // 
            this.VPN_ID.BackColor = System.Drawing.SystemColors.Control;
            this.VPN_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VPN_ID.Location = new System.Drawing.Point(55, 46);
            this.VPN_ID.Multiline = true;
            this.VPN_ID.Name = "VPN_ID";
            this.VPN_ID.Size = new System.Drawing.Size(212, 18);
            this.VPN_ID.TabIndex = 1;
            // 
            // VPN_PW
            // 
            this.VPN_PW.BackColor = System.Drawing.SystemColors.Control;
            this.VPN_PW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VPN_PW.Location = new System.Drawing.Point(55, 123);
            this.VPN_PW.Multiline = true;
            this.VPN_PW.Name = "VPN_PW";
            this.VPN_PW.PasswordChar = '*';
            this.VPN_PW.Size = new System.Drawing.Size(215, 18);
            this.VPN_PW.TabIndex = 2;
            this.VPN_PW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VPN_PW_Press);
            // 
            // progressBar_VPNState
            // 
            this.progressBar_VPNState.ForeColor = System.Drawing.Color.SkyBlue;
            this.progressBar_VPNState.Location = new System.Drawing.Point(21, 105);
            this.progressBar_VPNState.Name = "progressBar_VPNState";
            this.progressBar_VPNState.Size = new System.Drawing.Size(294, 34);
            this.progressBar_VPNState.TabIndex = 7;
            // 
            // Vpn_EventTimer
            // 
            this.Vpn_EventTimer.Tick += new System.EventHandler(this.Vpn_EventTimer_Tick);
            // 
            // panel_Connection
            // 
            this.panel_Connection.Controls.Add(this.panel_Login);
            this.panel_Connection.Controls.Add(this.VPNConnectingExitbutton);
            this.panel_Connection.Controls.Add(this.label2);
            this.panel_Connection.Controls.Add(this.progressBar_VPNState);
            this.panel_Connection.Controls.Add(this.label3);
            this.panel_Connection.Location = new System.Drawing.Point(0, 154);
            this.panel_Connection.Name = "panel_Connection";
            this.panel_Connection.Size = new System.Drawing.Size(332, 226);
            this.panel_Connection.TabIndex = 7;
            // 
            // panel_Login
            // 
            this.panel_Login.Controls.Add(this.EXIT_button);
            this.panel_Login.Controls.Add(this.label1);
            this.panel_Login.Controls.Add(this.VPN_ID);
            this.panel_Login.Controls.Add(this.Vpn_Login_Button);
            this.panel_Login.Controls.Add(this.panel3);
            this.panel_Login.Controls.Add(this.label4);
            this.panel_Login.Controls.Add(this.panel2);
            this.panel_Login.Controls.Add(this.VPN_PW);
            this.panel_Login.Location = new System.Drawing.Point(0, -2);
            this.panel_Login.Name = "panel_Login";
            this.panel_Login.Size = new System.Drawing.Size(332, 227);
            this.panel_Login.TabIndex = 8;
            // 
            // EXIT_button
            // 
            this.EXIT_button.BackColor = System.Drawing.Color.SkyBlue;
            this.EXIT_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EXIT_button.Font = new System.Drawing.Font("휴먼매직체", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EXIT_button.ForeColor = System.Drawing.SystemColors.Control;
            this.EXIT_button.Location = new System.Drawing.Point(181, 168);
            this.EXIT_button.Name = "EXIT_button";
            this.EXIT_button.Size = new System.Drawing.Size(86, 50);
            this.EXIT_button.TabIndex = 13;
            this.EXIT_button.Text = "EXIT";
            this.EXIT_button.UseVisualStyleBackColor = false;
            this.EXIT_button.Click += new System.EventHandler(this.EXIT_button_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Location = new System.Drawing.Point(52, 140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 1);
            this.panel3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "PASSWORD";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(52, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 1);
            this.panel2.TabIndex = 10;
            // 
            // VPNConnectingExitbutton
            // 
            this.VPNConnectingExitbutton.BackColor = System.Drawing.Color.SkyBlue;
            this.VPNConnectingExitbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VPNConnectingExitbutton.Font = new System.Drawing.Font("휴먼매직체", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.VPNConnectingExitbutton.ForeColor = System.Drawing.SystemColors.Control;
            this.VPNConnectingExitbutton.Location = new System.Drawing.Point(81, 161);
            this.VPNConnectingExitbutton.Name = "VPNConnectingExitbutton";
            this.VPNConnectingExitbutton.Size = new System.Drawing.Size(167, 50);
            this.VPNConnectingExitbutton.TabIndex = 14;
            this.VPNConnectingExitbutton.Text = "EXIT";
            this.VPNConnectingExitbutton.UseVisualStyleBackColor = false;
            this.VPNConnectingExitbutton.Click += new System.EventHandler(this.VPNConnectingExitbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "VPN Connecting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "MAX Time: 30sec";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 151);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Blind_Client.Properties.Resources.drapes;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(91, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Vpn_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 379);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Connection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Vpn_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlindClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Connection.ResumeLayout(false);
            this.panel_Connection.PerformLayout();
            this.panel_Login.ResumeLayout(false);
            this.panel_Login.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Vpn_Login_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox VPN_ID;
        private System.Windows.Forms.TextBox VPN_PW;
        private System.Windows.Forms.ProgressBar progressBar_VPNState;
        private System.Windows.Forms.Timer Vpn_EventTimer;
        public System.Windows.Forms.Panel panel_Connection;
        public System.Windows.Forms.Panel panel_Login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button EXIT_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button VPNConnectingExitbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}