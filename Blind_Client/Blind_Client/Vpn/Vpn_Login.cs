using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_Client
{
    public delegate void VpnUserDataEventHandler(string ID, string PW);//자식 ->클라
    public delegate void VpnClientExitEventHandler(bool result); // 자식->클라
    public delegate void VpnConnectionEventHandler(bool result);//클라 -> 자식
    public partial class Vpn_Login : Form
    {
        public VpnUserDataEventHandler VpnSendEvent; //자식 -> 클라
        public VpnClientExitEventHandler VpnClientExitEvent; //자식 -> 클라\
        bool VpnLoginCheck=false;
        bool ConnectionResult = false;

        public Vpn_Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar_VPNState.Style = ProgressBarStyle.Marquee;
            progressBar_VPNState.Maximum = 0;
            progressBar_VPNState.Maximum = 100;
            progressBar_VPNState.Step = 1;
            progressBar_VPNState.Value = 0;
            panel_Connection.Hide();
            this.FormClosed += Vpn_Login_FormClosing;
        }

        private void Vpn_Login_FormClosing(object sender, FormClosedEventArgs e)
        {
            if (VpnLoginCheck == false)
            {
                if (MessageBox.Show("종료하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    VpnClientExitEvent(true);
                    Close();
                }
            }
        }

        private void Vpn_Login_Button_Click(object sender, EventArgs e)
        {
            if (VPN_ID.Text != "" && VPN_PW.Text != "")
            {
                VpnLoginCheck = true;
                this.DialogResult = DialogResult.OK;
                VpnSendEvent(VPN_ID.Text, VPN_PW.Text);
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호를 입력하지 않았습니다.");
                return;
            }
            panel_Login.Hide();
            this.Close();
        }

        public void ConnectionEventChecking(bool result)
        {
            ConnectionResult = result;
        }

        private void VPN_EVENT_Tick(object sender, EventArgs e)
        {

        }
    }
}
