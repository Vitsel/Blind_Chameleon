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
        public VpnUserDataEventHandler VpnIDPWSendEvent; //자식 -> 클라
        public VpnClientExitEventHandler VpnClientExitEvent; //자식 -> 클라
        bool VpnLoginCheck =false;
        bool ConnectionEventCheck= false;
        public Vpn_Login()
        {
            InitializeComponent();
            //this.LoadingBitmap = Image.FromFile("Vpn\\UI\\loading.gif");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox_Loading.Image = Properties.Resources.Loading;
            //this.pictureBox_Loading.Image = LoadingBitmap;
            panel1.BackColor = Color.FromArgb(5, 102, 118);
            panel_Login.BackColor = Color.FromArgb(5, 102, 118);
            panel_Connect.BackColor = Color.FromArgb(5, 102, 118);
            panel_Connect.BackColor = Color.FromArgb(5, 102, 118);
            VPN_ID.BackColor = Color.FromArgb(5, 102, 118);
            VPN_PW.BackColor = Color.FromArgb(5, 102, 118);
            VPN_Class VPN = new VPN_Class();
            VPN_ID.Focus();
            this.FormClosed += Vpn_Login_FormClosed; //폼 종료되는 것 연결
            pictureBox_Login.Click += Vpn_Login_Button_Click;
            pictureBox_Exit.Click += EXIT_button_Click;
            pictureBox_ConnectingExit.Click += VPNConnectingExitbutton_Click;
            if (VpnLoginCheck == true)//로그인 성공시 폼을 숨기고 다시 show 하는것이기때문에 로그인 성공했으면 결과값 남아있음.
                Vpn_EventTimer.Start();
        }

        private void Vpn_Login_FormClosed(object sender, FormClosedEventArgs e)
        { //closed = 폼닫고나서 수행 closing 폼닫기전
            
            if (e.CloseReason == CloseReason.None) //hide 명령어 사용하면 여기로
            {
                return;
            }
                if (e.CloseReason == CloseReason.UserClosing)//close 명령어 포함 사용자 창닫기까지 여기로
            {
                Vpn_EventTimer.Stop();
                VpnClientExitEvent(true);
                Close();
            }
        }

        public void ConnectionEventChecking(bool result)
        {
            ConnectionEventCheck = result;//연결시도시 비동기로 연결을 시도하고 연결에 관한 결과 이벤트 발생시 true를 보냄.
        }

        private void Vpn_EventTimer_Tick(object sender, EventArgs e)
        { //연결중일때 스타트
            if (ConnectionEventCheck == true)
            {
                Vpn_EventTimer.Stop();
                this.Hide();
            }
        }

        private void EXIT_button_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0); //완전종료
        }
        
        private void VPNConnectingExitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Vpn_Login_Button_Click(object sender, EventArgs e)
        {
            if (VPN_ID.Text != "" && VPN_PW.Text != "")
            {
                VpnLoginCheck = true;
                this.DialogResult = DialogResult.OK;
                VpnIDPWSendEvent(VPN_ID.Text, VPN_PW.Text);//메인에 아이디 비번 보냄.
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호를 입력하지 않았습니다.");
                VPN_ID.Text = "";
                VPN_PW.Text = "";
                return;
            }
            panel_Login.Hide();//로그인성공시 로그인폼 숨기고
            this.Hide();//폼 하이드
        }

        private void VPN_PW_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Vpn_Login_Button_Click(sender, e);
        }
    }
}
