using System;
using System.Windows.Forms;

namespace Blind_Client
{
    static class _Main
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool isInner = true;

            VPN_Class VPN = new VPN_Class();
            
            while(!VPN.VPN_Start())
            {
                if (VPN.ClientExitChecking == true)
                    return;

                if (MessageBox.Show("VPN 연결에 실패하였습니다. 다시시도 하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    VPN.CMD_VPN_Instruction("VPN");
                    Application.ExitThread();
                }
            }

            isInner = VPN.Network_Position;
            Application.Run(new MainForm(isInner));
        }
    }
}
