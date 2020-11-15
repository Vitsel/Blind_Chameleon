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
            this.VPN_ID = new System.Windows.Forms.TextBox();
            this.VPN_PW = new System.Windows.Forms.TextBox();
            this.Vpn_EventTimer = new System.Windows.Forms.Timer(this.components);
            this.VPNConnectingExitbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BLIND = new System.Windows.Forms.Label();
            this.panel_Connect = new System.Windows.Forms.Panel();
            this.panel_Login = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EXIT_button = new System.Windows.Forms.Button();
            this.Vpn_Login_Button = new System.Windows.Forms.Button();
            this.pictureBox_Login = new System.Windows.Forms.PictureBox();
            this.pictureBox_Exit = new System.Windows.Forms.PictureBox();
            this.pictureBox_ConnectingExit = new System.Windows.Forms.PictureBox();
            this.pictureBox_Loading = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel_Connect.SuspendLayout();
            this.panel_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ConnectingExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Loading)).BeginInit();
            this.SuspendLayout();
            // 
            // VPN_ID
            // 
            this.VPN_ID.BackColor = System.Drawing.Color.White;
            this.VPN_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VPN_ID.ForeColor = System.Drawing.Color.White;
            this.VPN_ID.Location = new System.Drawing.Point(52, 43);
            this.VPN_ID.Multiline = true;
            this.VPN_ID.Name = "VPN_ID";
            this.VPN_ID.Size = new System.Drawing.Size(215, 18);
            this.VPN_ID.TabIndex = 1;
            // 
            // VPN_PW
            // 
            this.VPN_PW.BackColor = System.Drawing.Color.White;
            this.VPN_PW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VPN_PW.ForeColor = System.Drawing.Color.White;
            this.VPN_PW.Location = new System.Drawing.Point(52, 120);
            this.VPN_PW.Multiline = true;
            this.VPN_PW.Name = "VPN_PW";
            this.VPN_PW.PasswordChar = '*';
            this.VPN_PW.Size = new System.Drawing.Size(215, 18);
            this.VPN_PW.TabIndex = 2;
            this.VPN_PW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VPN_PW_Press);
            // 
            // Vpn_EventTimer
            // 
            this.Vpn_EventTimer.Tick += new System.EventHandler(this.Vpn_EventTimer_Tick);
            // 
            // VPNConnectingExitbutton
            // 
            this.VPNConnectingExitbutton.BackColor = System.Drawing.Color.SkyBlue;
            this.VPNConnectingExitbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VPNConnectingExitbutton.Font = new System.Drawing.Font("휴먼매직체", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.VPNConnectingExitbutton.ForeColor = System.Drawing.SystemColors.Control;
            this.VPNConnectingExitbutton.Location = new System.Drawing.Point(149, 156);
            this.VPNConnectingExitbutton.Name = "VPNConnectingExitbutton";
            this.VPNConnectingExitbutton.Size = new System.Drawing.Size(48, 48);
            this.VPNConnectingExitbutton.TabIndex = 14;
            this.VPNConnectingExitbutton.Text = "EXIT";
            this.VPNConnectingExitbutton.UseVisualStyleBackColor = false;
            this.VPNConnectingExitbutton.Click += new System.EventHandler(this.VPNConnectingExitbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("KoPub돋움체 Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(94, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "VPN Connecting";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.BLIND);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 78);
            this.panel1.TabIndex = 9;
            // 
            // BLIND
            // 
            this.BLIND.AutoSize = true;
            this.BLIND.Font = new System.Drawing.Font("KoPub돋움체 Medium", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BLIND.ForeColor = System.Drawing.Color.White;
            this.BLIND.Location = new System.Drawing.Point(86, 11);
            this.BLIND.Name = "BLIND";
            this.BLIND.Size = new System.Drawing.Size(164, 53);
            this.BLIND.TabIndex = 0;
            this.BLIND.Text = "BLIND";
            // 
            // panel_Connect
            // 
            this.panel_Connect.Controls.Add(this.panel_Login);
            this.panel_Connect.Controls.Add(this.pictureBox_ConnectingExit);
            this.panel_Connect.Controls.Add(this.pictureBox_Loading);
            this.panel_Connect.Controls.Add(this.VPNConnectingExitbutton);
            this.panel_Connect.Controls.Add(this.label2);
            this.panel_Connect.Location = new System.Drawing.Point(0, 78);
            this.panel_Connect.Name = "panel_Connect";
            this.panel_Connect.Size = new System.Drawing.Size(332, 238);
            this.panel_Connect.TabIndex = 10;
            // 
            // panel_Login
            // 
            this.panel_Login.BackColor = System.Drawing.Color.Transparent;
            this.panel_Login.Controls.Add(this.pictureBox_Login);
            this.panel_Login.Controls.Add(this.pictureBox_Exit);
            this.panel_Login.Controls.Add(this.label1);
            this.panel_Login.Controls.Add(this.Vpn_Login_Button);
            this.panel_Login.Controls.Add(this.EXIT_button);
            this.panel_Login.Controls.Add(this.VPN_PW);
            this.panel_Login.Controls.Add(this.VPN_ID);
            this.panel_Login.Controls.Add(this.panel3);
            this.panel_Login.Controls.Add(this.label4);
            this.panel_Login.Controls.Add(this.panel2);
            this.panel_Login.Location = new System.Drawing.Point(0, 3);
            this.panel_Login.Name = "panel_Login";
            this.panel_Login.Size = new System.Drawing.Size(332, 238);
            this.panel_Login.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("KoPub돋움체 Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(52, 140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 3);
            this.panel3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("KoPub돋움체 Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(47, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "PW";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(52, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 3);
            this.panel2.TabIndex = 10;
            // 
            // EXIT_button
            // 
            this.EXIT_button.BackColor = System.Drawing.Color.SkyBlue;
            this.EXIT_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EXIT_button.Font = new System.Drawing.Font("휴먼매직체", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EXIT_button.ForeColor = System.Drawing.SystemColors.Control;
            this.EXIT_button.Location = new System.Drawing.Point(189, 168);
            this.EXIT_button.Name = "EXIT_button";
            this.EXIT_button.Size = new System.Drawing.Size(48, 48);
            this.EXIT_button.TabIndex = 13;
            this.EXIT_button.Text = "EXIT";
            this.EXIT_button.UseVisualStyleBackColor = false;
            this.EXIT_button.Click += new System.EventHandler(this.EXIT_button_Click);
            // 
            // Vpn_Login_Button
            // 
            this.Vpn_Login_Button.BackColor = System.Drawing.Color.SkyBlue;
            this.Vpn_Login_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Vpn_Login_Button.Font = new System.Drawing.Font("휴먼매직체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Vpn_Login_Button.ForeColor = System.Drawing.SystemColors.Control;
            this.Vpn_Login_Button.Location = new System.Drawing.Point(83, 169);
            this.Vpn_Login_Button.Name = "Vpn_Login_Button";
            this.Vpn_Login_Button.Size = new System.Drawing.Size(46, 46);
            this.Vpn_Login_Button.TabIndex = 3;
            this.Vpn_Login_Button.Text = "LOGIN";
            this.Vpn_Login_Button.UseVisualStyleBackColor = false;
            this.Vpn_Login_Button.Click += new System.EventHandler(this.Vpn_Login_Button_Click);
            // 
            // pictureBox_Login
            // 
            this.pictureBox_Login.BackgroundImage = global::Blind_Client.Properties.Resources.icon_send;
            this.pictureBox_Login.Location = new System.Drawing.Point(83, 169);
            this.pictureBox_Login.Name = "pictureBox_Login";
            this.pictureBox_Login.Size = new System.Drawing.Size(48, 48);
            this.pictureBox_Login.TabIndex = 11;
            this.pictureBox_Login.TabStop = false;
            // 
            // pictureBox_Exit
            // 
            this.pictureBox_Exit.BackgroundImage = global::Blind_Client.Properties.Resources.icon_exit;
            this.pictureBox_Exit.Location = new System.Drawing.Point(189, 168);
            this.pictureBox_Exit.Name = "pictureBox_Exit";
            this.pictureBox_Exit.Size = new System.Drawing.Size(48, 48);
            this.pictureBox_Exit.TabIndex = 12;
            this.pictureBox_Exit.TabStop = false;
            // 
            // pictureBox_ConnectingExit
            // 
            this.pictureBox_ConnectingExit.BackgroundImage = global::Blind_Client.Properties.Resources.icon_exit;
            this.pictureBox_ConnectingExit.Location = new System.Drawing.Point(149, 156);
            this.pictureBox_ConnectingExit.Name = "pictureBox_ConnectingExit";
            this.pictureBox_ConnectingExit.Size = new System.Drawing.Size(48, 48);
            this.pictureBox_ConnectingExit.TabIndex = 13;
            this.pictureBox_ConnectingExit.TabStop = false;
            // 
            // pictureBox_Loading
            // 
            this.pictureBox_Loading.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Loading.Location = new System.Drawing.Point(39, 52);
            this.pictureBox_Loading.Name = "pictureBox_Loading";
            this.pictureBox_Loading.Size = new System.Drawing.Size(49, 50);
            this.pictureBox_Loading.TabIndex = 15;
            this.pictureBox_Loading.TabStop = false;
            // 
            // Vpn_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 322);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Vpn_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlindClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Connect.ResumeLayout(false);
            this.panel_Connect.PerformLayout();
            this.panel_Login.ResumeLayout(false);
            this.panel_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ConnectingExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox VPN_ID;
        private System.Windows.Forms.TextBox VPN_PW;
        private System.Windows.Forms.Timer Vpn_EventTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button VPNConnectingExitbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label BLIND;
        public System.Windows.Forms.Panel panel_Login;
        private System.Windows.Forms.Button EXIT_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Vpn_Login_Button;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel_Connect;
        private System.Windows.Forms.PictureBox pictureBox_ConnectingExit;
        private System.Windows.Forms.PictureBox pictureBox_Loading;
        private System.Windows.Forms.PictureBox pictureBox_Login;
        private System.Windows.Forms.PictureBox pictureBox_Exit;
    }
}