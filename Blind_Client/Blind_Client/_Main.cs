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


            while (true)
            {
                VPN.CMD_VPN_Instruction("VPN");

                if (!VPN.VPN_Start())
                {
                    if (MessageBox.Show("VPN 연결에 실패하였습니다. 다시시도 하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        VPN.CMD_VPN_Instruction("VPN");
                        Application.ExitThread();
                        Environment.Exit(0); //완전종료
                    }
                }
                else
                    break;
            }
            

            isInner = VPN.Network_Position;
            Application.Run(new MainForm(isInner,VPN.IsInnerClient_Id));
            //인자값 | 첫번째 : 내부/외부 판단. (디버그했을때 실질적인 값 : true -> "True" | false -> "False") | 두번째 : 시도한 아이디

        }
    }
}
