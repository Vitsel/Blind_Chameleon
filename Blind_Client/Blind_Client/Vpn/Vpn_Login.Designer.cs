﻿namespace Blind_Client
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
            this.Vpn_Login_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VPN_ID = new System.Windows.Forms.TextBox();
            this.VPN_PW = new System.Windows.Forms.TextBox();
            this.GroupBox_VPN_LOGIN = new System.Windows.Forms.GroupBox();
            this.GroupBox_VPN_State = new System.Windows.Forms.GroupBox();
            this.progressBar_VPNState = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.VPN_EVENT = new System.Windows.Forms.Timer(this.components);
            this.panel_Connection = new System.Windows.Forms.Panel();
            this.panel_Login = new System.Windows.Forms.Panel();
            this.panel_Connection.SuspendLayout();
            this.panel_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vpn_Login_Button
            // 
            this.Vpn_Login_Button.Location = new System.Drawing.Point(250, 10);
            this.Vpn_Login_Button.Name = "Vpn_Login_Button";
            this.Vpn_Login_Button.Size = new System.Drawing.Size(73, 70);
            this.Vpn_Login_Button.TabIndex = 0;
            this.Vpn_Login_Button.Text = "Login";
            this.Vpn_Login_Button.UseVisualStyleBackColor = true;
            this.Vpn_Login_Button.Click += new System.EventHandler(this.Vpn_Login_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // VPN_ID
            // 
            this.VPN_ID.Location = new System.Drawing.Point(82, 16);
            this.VPN_ID.Name = "VPN_ID";
            this.VPN_ID.Size = new System.Drawing.Size(160, 21);
            this.VPN_ID.TabIndex = 3;
            // 
            // VPN_PW
            // 
            this.VPN_PW.Location = new System.Drawing.Point(82, 49);
            this.VPN_PW.Name = "VPN_PW";
            this.VPN_PW.Size = new System.Drawing.Size(160, 21);
            this.VPN_PW.TabIndex = 4;
            // 
            // GroupBox_VPN_LOGIN
            // 
            this.GroupBox_VPN_LOGIN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.GroupBox_VPN_LOGIN.CausesValidation = false;
            this.GroupBox_VPN_LOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox_VPN_LOGIN.Location = new System.Drawing.Point(558, 323);
            this.GroupBox_VPN_LOGIN.Name = "GroupBox_VPN_LOGIN";
            this.GroupBox_VPN_LOGIN.Size = new System.Drawing.Size(329, 112);
            this.GroupBox_VPN_LOGIN.TabIndex = 5;
            this.GroupBox_VPN_LOGIN.TabStop = false;
            this.GroupBox_VPN_LOGIN.Text = "Login";
            // 
            // GroupBox_VPN_State
            // 
            this.GroupBox_VPN_State.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupBox_VPN_State.CausesValidation = false;
            this.GroupBox_VPN_State.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GroupBox_VPN_State.Location = new System.Drawing.Point(558, 29);
            this.GroupBox_VPN_State.Name = "GroupBox_VPN_State";
            this.GroupBox_VPN_State.Size = new System.Drawing.Size(359, 127);
            this.GroupBox_VPN_State.TabIndex = 6;
            this.GroupBox_VPN_State.TabStop = false;
            this.GroupBox_VPN_State.Text = "VPN 연결 현황";
            this.GroupBox_VPN_State.UseCompatibleTextRendering = true;
            // 
            // progressBar_VPNState
            // 
            this.progressBar_VPNState.Location = new System.Drawing.Point(16, 52);
            this.progressBar_VPNState.Name = "progressBar_VPNState";
            this.progressBar_VPNState.Size = new System.Drawing.Size(294, 34);
            this.progressBar_VPNState.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "연결 시도중(최대 30초)";
            // 
            // VPN_EVENT
            // 
            this.VPN_EVENT.Interval = 1000;
            this.VPN_EVENT.Tick += new System.EventHandler(this.VPN_EVENT_Tick);
            // 
            // panel_Connection
            // 
            this.panel_Connection.Controls.Add(this.progressBar_VPNState);
            this.panel_Connection.Controls.Add(this.label3);
            this.panel_Connection.Location = new System.Drawing.Point(12, 12);
            this.panel_Connection.Name = "panel_Connection";
            this.panel_Connection.Size = new System.Drawing.Size(332, 106);
            this.panel_Connection.TabIndex = 7;
            // 
            // panel_Login
            // 
            this.panel_Login.Controls.Add(this.label2);
            this.panel_Login.Controls.Add(this.VPN_ID);
            this.panel_Login.Controls.Add(this.VPN_PW);
            this.panel_Login.Controls.Add(this.label1);
            this.panel_Login.Controls.Add(this.Vpn_Login_Button);
            this.panel_Login.Location = new System.Drawing.Point(3, 12);
            this.panel_Login.Name = "panel_Login";
            this.panel_Login.Size = new System.Drawing.Size(352, 120);
            this.panel_Login.TabIndex = 8;
            // 
            // Vpn_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 507);
            this.Controls.Add(this.panel_Login);
            this.Controls.Add(this.GroupBox_VPN_LOGIN);
            this.Controls.Add(this.GroupBox_VPN_State);
            this.Controls.Add(this.panel_Connection);
            this.Name = "Vpn_Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Connection.ResumeLayout(false);
            this.panel_Connection.PerformLayout();
            this.panel_Login.ResumeLayout(false);
            this.panel_Login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Vpn_Login_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox VPN_ID;
        private System.Windows.Forms.TextBox VPN_PW;
        private System.Windows.Forms.ProgressBar progressBar_VPNState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer VPN_EVENT;
        public System.Windows.Forms.GroupBox GroupBox_VPN_LOGIN;
        public System.Windows.Forms.GroupBox GroupBox_VPN_State;
        public System.Windows.Forms.Panel panel_Connection;
        public System.Windows.Forms.Panel panel_Login;
    }
}