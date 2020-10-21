using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32; // 레지관련
using DotRas;//vpn관련

namespace Blind_Client
{

    class VPN_Class
    {
        private Vpn_Login VpnLogin_Dialog = new Vpn_Login(); // 자식폼 생성
        public VpnConnectionEventHandler VpnConnectionEvent;
        private bool VpnConnectionEventResult=false;

        private string VPN_Name = "Blind_VPN"; // 만들 이름
        private string Child_VPN_ID = ""; // 자식폼에서 받아올 아이디
        private string Child_VPN_PW = "";// 자식폼에서 받아올 비밀번호
        private string VPN_Connection_IP = ""; // 인터넷 위치에따라 아이피 설정
        public bool Network_Position = true; //true = 내부 false = 외부
        public bool ClientExitChecking = false;
        
       

        public void CMD_VPN_Instruction(string Type)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            psi.FileName = @"cmd";
            psi.CreateNoWindow = true; //화면출력 비활성화 =true
            psi.UseShellExecute = false; //

            psi.RedirectStandardInput = true; //데이터 받기
            psi.RedirectStandardOutput = true; //데이터 보내기
            psi.RedirectStandardError = false; // 오류내용 받기

            pro.StartInfo = psi;
            pro.Start();// cmd 실행

            if (Type == "VPN")
            {
                string instruction_DisConnect = "rasphone -h Blind_VPN";
                string instruction_Remove = "rasphone -r Blind_VPN";
                pro.StandardInput.Write(instruction_DisConnect + Environment.NewLine); //지정한 명령어 + \r\n
                Thread.Sleep(2000); //바로삭제하면 완전히 제거가안됨 일정간격 줘야함.
                pro.StandardInput.Write(instruction_Remove + Environment.NewLine); //지정한 명령어 + \r\n
            }
            else if(Type == "VPNREG")
            {
                string instruction_Shutdown = "shutdown -s -t 1";
                pro.StandardInput.Write(instruction_Shutdown + Environment.NewLine); //지정한 명령어 + \r\n
            }
            pro.StandardInput.Close(); //종료

            pro.WaitForExit();
            pro.Close();
        }

        private bool VPN_Create()
        {
            //https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/aa377274(v=vs.85)
            string preSharedKey = "kit2020";//l2tp 공유기
            RasVpnStrategy strategy = RasVpnStrategy.L2tpOnly;

            RasEntry vpnEntry = RasEntry.CreateVpnEntry(VPN_Name, VPN_Connection_IP, strategy, RasDevice.Create(VPN_Name, RasDeviceType.Vpn), false); //create
            vpnEntry.Options.RequireDataEncryption = true; //데이터 암호화
            vpnEntry.Options.UsePreSharedKey = true; //l2tp/ipsec
            vpnEntry.Options.UseLogOnCredentials = false; // 로그인 기록 저장
            vpnEntry.Options.RequireMSChap= false; //Microsoft CHAP Version
            vpnEntry.Options.RequireMSChap2 = true; //Microsoft CHAP Version 2 (MS-CHAP v2)
            vpnEntry.Options.RemoteDefaultGateway = false; //게이트웨이 0.0.0.0으로
            RasPhoneBook phoneBook = new RasPhoneBook();
            try
            {
                phoneBook.Open();
                phoneBook.Entries.Add(vpnEntry);//vpn 생성
                vpnEntry.UpdateCredentials(RasPreSharedKey.Client, preSharedKey);//l2tp 공유키 설정
                return true;
            }
            catch (Exception ex)
            {
                Exception FailText = ex;
                MessageBox.Show(string.Concat(ex.ToString(), "\n"));
                return false;
            }
        }

        private void Dialer_StateChanged(object sender, StateChangedEventArgs e)
        {
            //이벤트 자동생성됨
        }

        private void Dialer_DialCompleted(object sender, DialCompletedEventArgs e)
        {
            VpnConnectionEventResult = false;
            this.VpnConnectionEvent += new VpnConnectionEventHandler(VpnLogin_Dialog.ConnectionEventChecking);

            if (e.Connected)
            {
                VpnConnectionEventResult = true;
                VpnConnectionEvent(VpnConnectionEventResult);//(보내면 Connection State에서 값을 확인후 폼 꺼짐.)
                return;
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Connection Attempt Cancel");
            }
            else if (e.TimedOut)
            {
                MessageBox.Show("Connection Attempt Time out");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("UnKnown Error");
                MessageBox.Show(e.Error.ToString());
            }
            VpnConnectionEvent(VpnConnectionEventResult);
        }

        private bool VPN_Connection()
        {
            RasDialer dialer = new RasDialer(); // vpn 연결 생성
            dialer.EntryName = VPN_Name; // 연결할 vpn명
            dialer.AllowUseStoredCredentials = true; //자격증명
            dialer.Timeout = 30000;//연결시간
            dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
            dialer.StateChanged += Dialer_StateChanged; // 이벤트 함수 실행
            dialer.DialCompleted += Dialer_DialCompleted; // 이벤트 함수 실행

            if (Network_Position == true)//내부
                dialer.Credentials = new System.Net.NetworkCredential("vpnuser", "cksgml!34");
            else if (Network_Position == false)//외부
                dialer.Credentials = new System.Net.NetworkCredential(Child_VPN_ID, Child_VPN_PW);//로그인창에서 입력한 것으로
            try
            {
                if (dialer.IsBusy)// 연결이 되어있다면
                    dialer.DialAsyncCancel();//연결 끝내기

                dialer.DialAsync(); //비동기로 연결시도

                VpnLogin_Dialog.panel_Connection.Show();
                VpnLogin_Dialog.ShowDialog();
                if (ClientExitChecking == true)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool VPN_First_Check()
        {
            string currentUser = (System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[0];//0으로하면 도메인 1로하면 사용자명
            VpnLogin_Dialog.VpnSendEvent += new VpnUserDataEventHandler(this.VpnLogin_Data);
            VpnLogin_Dialog.VpnClientExitEvent += new VpnClientExitEventHandler(this.VpnLogin_ClientExitCheck);

            if (currentUser.Equals("BLIND2A")) //내부일때
            {
                Network_Position = true;
                VPN_Connection_IP = "127.0.0.1"; // 내부 vpn 없애서 일반 루트백으로.
            }
            else //외부일때
            {
                Network_Position = false;
                VPN_Connection_IP = "54.235.49.150";

                VpnLogin_Dialog.ShowDialog();
                if (ClientExitChecking == true)
                    return false;
            }

            return true;
        }

        private void VpnLogin_Data(string ID, string PW) //로그인 폼에서 델리게이트로 전송받음
        {
            Child_VPN_ID = ID;
            Child_VPN_PW = PW;
        }

        private void VpnLogin_ClientExitCheck(bool result)
        {
            ClientExitChecking = result;
        }
        
        private bool VPN_RegCheck()
        {
            string[] L2tpRegLocation = new string[] { "SYSTEM\\CurrentControlSet\\services\\PolicyAgent", "SYSTEM\\CurrentControlSet\\services\\RasMan\\Parameters" };
            string[] L2tpRegName = new string[] { "AssumeUDPEncapsulationContextOnSendRule", "ProhibitIpSec" };
            object[] L2tpRegValue = new object[] { 2, 1 };
            bool RegExistenceCheck = true;
            object RegValueResult;
            
            for (int i = 0; i <= 1; i++) //레지 확인후 없으면 추가 있으면 패스
            {
                RegValueResult = "-1";
                RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(L2tpRegLocation[i], true);//값 오픈
                if (RegKey != null)
                {
                    RegValueResult = RegKey.GetValue(L2tpRegName[i].ToString()); //값 가져오기
                    if (RegValueResult == (object)"-1")//값을 못받아왔을때
                    {
                        RegExistenceCheck = false;
                        RegKey.SetValue(L2tpRegName[i], L2tpRegValue[i], RegistryValueKind.DWord);
                    }
                }
                else
                {
                    MessageBox.Show("Registry Not Open. Plase Administrator Checking");
                    return false;
                }
            }

            if (RegExistenceCheck == false) // 레지 확인이 1개라도 안됐으면
            {
                if (MessageBox.Show("레지스트리 추가가 안되어 있어 반드시 재부팅을 해야합니다. 재부팅 하시겠습니까?", "VPN 레지스트리 발견 안됨!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    CMD_VPN_Instruction("VPNREG");

                return false;
            }

          return true;
     }

        public bool VPN_Start()
        {
            VpnLogin_Dialog.VpnSendEvent += new VpnUserDataEventHandler(this.VpnLogin_Data);
            VpnLogin_Dialog.VpnClientExitEvent += new VpnClientExitEventHandler(this.VpnLogin_ClientExitCheck);
            this.VpnConnectionEvent+= new VpnConnectionEventHandler(this.ConnectionEventChecking);
            bool result = false;
            if (!VPN_RegCheck())
                return result;

            CMD_VPN_Instruction("VPN");

            if (VPN_First_Check())
           {
                if (Network_Position == true && VPN_Connection_IP == "127.0.0.1")
                    result = true;

                if (result == false)
                {
                    if (VPN_Create() == true)
                    {
                        if (VPN_Connection() == true)
                            result = true;
                    }
                }
           }
            return result;
        }

    }
}
