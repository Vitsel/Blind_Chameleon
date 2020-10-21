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
    public delegate void ConnectEventCheckingHandler(bool EventSend);
    public partial class Vpn_Connection_State : Form
    {
        public bool EventChecking= false;
        
        public Vpn_Connection_State()
        {
            InitializeComponent();
        }

        private void Vpn_Connection_State_Load(object sender, EventArgs e)
        {
            //VPN 상태 프로그래스바
            progressBar_VPNState.Style = ProgressBarStyle.Marquee;
            progressBar_VPNState.Maximum = 0;
            progressBar_VPNState.Maximum = 100;
            progressBar_VPNState.Step = 1;
            progressBar_VPNState.Value = 0;

            timer1.Start();
        }

        private void FormClosed(object sender,FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
                MessageBox.Show("종료");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (EventChecking == true)
                this.Close();
        }

        public void EventValue(bool EventSend)
        {
            EventChecking = EventSend;
        }
    }
}
