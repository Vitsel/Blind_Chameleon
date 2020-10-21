namespace Blind_Client
{
    partial class Vpn_Connection_State
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
            this.GroupBox_VPN_State = new System.Windows.Forms.GroupBox();
            this.progressBar_VPNState = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GroupBox_VPN_State.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox_VPN_State
            // 
            this.GroupBox_VPN_State.Controls.Add(this.progressBar_VPNState);
            this.GroupBox_VPN_State.Controls.Add(this.label2);
            this.GroupBox_VPN_State.Location = new System.Drawing.Point(137, 75);
            this.GroupBox_VPN_State.Name = "GroupBox_VPN_State";
            this.GroupBox_VPN_State.Size = new System.Drawing.Size(278, 81);
            this.GroupBox_VPN_State.TabIndex = 5;
            this.GroupBox_VPN_State.TabStop = false;
            this.GroupBox_VPN_State.Text = "VPN 연결 현황";
            // 
            // progressBar_VPNState
            // 
            this.progressBar_VPNState.Location = new System.Drawing.Point(9, 41);
            this.progressBar_VPNState.Name = "progressBar_VPNState";
            this.progressBar_VPNState.Size = new System.Drawing.Size(263, 34);
            this.progressBar_VPNState.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "연결 시도중(최대 30초)";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Vpn_Connection_State
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 272);
            this.Controls.Add(this.GroupBox_VPN_State);
            this.Name = "Vpn_Connection_State";
            this.Text = "Vpn_Connection_State";
            this.Load += new System.EventHandler(this.Vpn_Connection_State_Load);
            this.GroupBox_VPN_State.ResumeLayout(false);
            this.GroupBox_VPN_State.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox_VPN_State;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar_VPNState;
        private System.Windows.Forms.Timer timer1;
    }
}