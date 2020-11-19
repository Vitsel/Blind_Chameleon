//#define PROGRAMMING

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

/*
   제작           : 최찬희
   최종 수정일 : 2020-10-30 오후 4:08
   돌아가는 방식 
    VPN_Start                  : 메인에서 시작. 그리고 아래 내용진행
     -VPN_First_Check      : 내부/외부 사용자를 판가름한다. 내부 : 바로 클라이언트 접속  | 외부 : VPN로그인 및 연결 시도
     -VPN_RegCheck         : VPN연결 프로토콜 L2TP에 필요한 레지 확인
     -VPN_Create             : VPN 연결 네트워크 생성
     -VPN_Connection       : VPN 연결 네트워크 연결 시도
*/

namespace Blind_Client
{
    class VPN_Class
    {
        private Vpn_Login VpnLogin_Dialog;
        public VpnConnectionEventHandler VpnConnectionEvent;//vpn_Login폼에 연결 결과 보냄
        private RasDialer dialer = new RasDialer(); // vpn 연결 생성. 연결실패한 후에 바로 연결캔슬 할 수 있도록.

        public bool ClientExitChecking = false; //Vpn 폼에서 종료버튼 누른지 확인
        private bool VpnConnectionChecking=false; // 연결 비동기 이벤트에서 결과에따라 값변동 성공시 true 실패시 false
        private string VPN_Name = "Blind_VPN"; // 만들 이름
        public string  IsInnerClient_Id = ""; // 내/외부에 따라 가져올 아이디
        private string IsInnerClientVPN_Pw = "";//외부일 시 VPN 사용자 입력 비밀번호값 들어옴.
        private string VPN_Connection_IP = ""; // 인터넷 위치에따라 아이피 설정 (공인ip (Public))
        private string VPN_Create_VirtualIP = "10.0.1.7"; // dns 서버를 vpn서버로 설정.(설정안하면 속도 씹창남) (사설ip (Private))


        public bool Network_Position = true; //true = 내부 false = 외부       

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
                //string instruction_DisConnect = "rasdial \"Blind_VPN\" /disconnect";
                string instruction_Remove = "rasphone -r Blind_VPN";
                pro.StandardInput.Write(instruction_DisConnect + Environment.NewLine); //지정한 명령어 + \r\n
                Thread.Sleep(1000); //바로삭제하면 완전히 제거가안됨 일정간격 줘야함.
                pro.StandardInput.Write(instruction_Remove + Environment.NewLine); //지정한 명령어 + \r\n
            }
            else if(Type == "VPNREG")
                pro.StandardInput.Write("shutdown -r -t 1" + Environment.NewLine); //지정한 명령어 + \r\n
            
            pro.StandardInput.Close(); //종료

            pro.WaitForExit();
            pro.Close();
        }

        private bool VPN_First_Check()
        {
            string DomainCheck = (System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[0];//0으로하면 도메인 1로하면 사용자명
            VpnLogin_Dialog.VpnIDPWSendEvent += new VpnUserDataEventHandler(this.VpnLogin_Data);//VpnLogin에서 적은 사용자 아이디 비번 델리게이트
            VpnLogin_Dialog.VpnClientExitEvent += new VpnClientExitEventHandler(this.VpnLogin_ClientExitCheck); // 클라를 수동으로 껐는지 델리게이트

            if (DomainCheck.Equals("BLIND2A")) //내부일때
            {
                Network_Position = true;
                VPN_Connection_IP = "127.0.0.1"; // 내부 vpn 없애서 일반 루트백으로.
                IsInnerClient_Id= (System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]; //사용자계정 가져와서 저장. 성윤이꺼 화면보호기에 필요함.
            }
            else //외부일때
            {
                Network_Position = false;
                VPN_Connection_IP = "54.235.49.150"; //vpn 서버 아이피

                VpnLogin_Dialog.ShowDialog();
                if (ClientExitChecking == true) //창닫기 버튼 눌렀을때
                {
                    VpnLogin_Dialog.Close();
                    if (dialer.IsBusy)// 연결이 되어있다면
                        dialer.DialAsyncCancel();//연결 끝내기
                    CMD_VPN_Instruction("VPN");
                    Application.ExitThread();
                    Environment.Exit(0); //완전종료
                }
            }
            return true;
        }

        private bool VPN_Create()
        {
            //https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/aa377274(v=vs.85)
            string preSharedKey = "kit2020!^)!$)%^";//l2tp 공유기 키
            RasVpnStrategy strategy = RasVpnStrategy.L2tpOnly;

            RasEntry vpnEntry = RasEntry.CreateVpnEntry(VPN_Name, VPN_Connection_IP, strategy, RasDevice.Create(VPN_Name, RasDeviceType.Vpn), false); //
            vpnEntry.Options.RequireDataEncryption = true; //데이터 암호화
            vpnEntry.Options.UsePreSharedKey = true; //l2tp/ipsec
            vpnEntry.Options.UseLogOnCredentials = false; // 로그인 기록 저장
            vpnEntry.Options.RequireMSChap= false; //Microsoft CHAP Version
            vpnEntry.Options.RequireMSChap2 = true; //Microsoft CHAP Version 2 (MS-CHAP v2)
            vpnEntry.DnsAddress = System.Net.IPAddress.Parse(VPN_Create_VirtualIP);
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

        private bool VPN_Connection()
        {
            dialer.EntryName = VPN_Name; // 연결할 vpn명
            dialer.AllowUseStoredCredentials = true; //자격증명
            dialer.Timeout = 30000;//연결시간
            dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
            dialer.StateChanged += Dialer_StateChanged; // 이벤트 함수
            dialer.DialCompleted += Dialer_DialCompleted; // 이벤트 함수

            if (Network_Position == true)//내부
                dialer.Credentials = new System.Net.NetworkCredential("vpnuser", "cksgml!34");
            else if (Network_Position == false)//외부
                dialer.Credentials = new System.Net.NetworkCredential(IsInnerClient_Id, IsInnerClientVPN_Pw);//로그인창에서 입력한 것으로
            try
            {
                if (dialer.IsBusy)// 연결이 되어있다면
                    dialer.DialAsyncCancel();//연결 끝내기

                dialer.DialAsync(); //비동기로 연결시도

                VpnLogin_Dialog.panel_Connect.Show();//로딩창 표시
                VpnLogin_Dialog.ShowDialog();
                if (ClientExitChecking == true) //사용자가 나가기를 눌렀거나 연결에 실패한경우
                {
                    VpnLogin_Dialog.Close();
                    if (dialer.IsBusy)// 연결이 되어있다면
                        dialer.DialAsyncCancel();//연결 끝내기
                    CMD_VPN_Instruction("VPN");//vpn 제거
                    Application.ExitThread();
                    Environment.Exit(0); //완전종료
                }
                return VpnConnectionChecking;// 이벤트에따라 성공하면 true로 바뀜
            }
            catch
            {
                return VpnConnectionChecking;
            }
        }

        private void Dialer_StateChanged(object sender, StateChangedEventArgs e)
        {
            //이벤트 자동생성됨
        }

        private void Dialer_DialCompleted(object sender, DialCompletedEventArgs e)
        {
            this.VpnConnectionEvent += new VpnConnectionEventHandler(VpnLogin_Dialog.ConnectionEventChecking);//Vpn_Login에 보낼 것 델리게이트

            if (e.Connected)
            {
                VpnConnectionChecking = true;
                VpnConnectionEvent(true);//(보내면 Vpn_Login 폼꺼짐)
                return;
            }
            /*else if (e.Cancelled) //연결실패하면 자동적으로 캔슬함
            {
                //MessageBox.Show("Connection Attempt Cancel");
            }
            */
            else if (e.TimedOut)
            {
                MessageBox.Show("Connection Attempt Time out");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Vpn Connection Error");
                MessageBox.Show(e.Error.ToString());
            }
            VpnConnectionEvent(true);
        }

        private void VpnLogin_Data(string ID, string PW) //로그인 폼에서 메인폼으로 전송함
        {
            IsInnerClient_Id = ID;
            IsInnerClientVPN_Pw = PW;
        }

        private void VpnLogin_ClientExitCheck(bool result) //로그인 폼에서 메인폼으로 전송함
        {
            ClientExitChecking = result;
        }

        private bool VPN_RegCheck()
        {
            string L2tpRegLocation = "SYSTEM\\CurrentControlSet\\services\\PolicyAgent";
            string L2tpRegName = "AssumeUDPEncapsulationContextOnSendRule";
            string L2tpRegValue = "2";
            string L2tpRegGetValue = "-1";

            RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(L2tpRegLocation, true);
            if (RegKey != null)
            {
                L2tpRegGetValue = Convert.ToString(RegKey.GetValue(L2tpRegName));//레지 지정 값 가져옴.

                if (L2tpRegGetValue != "2")//레지값이 2가 아닐때
                {
                    if (MessageBox.Show("VPN 연결에 필요한 레지스트리가 발견되지 않아 재부팅을 해야합니다." + Environment.NewLine+"\t\t지금 재부팅 하시겠습니까?", "BlindClient", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        RegKey.SetValue(L2tpRegName, L2tpRegValue, RegistryValueKind.DWord);
                        Application.ExitThread();
                        CMD_VPN_Instruction("VPNREG");
                        Environment.Exit(0); //완전종료
                    }
                    else
                    {
                        Application.ExitThread();
                        Environment.Exit(0); //완전종료
                    }
                }
            }
            else//레지 못열었을때
            {
                MessageBox.Show("Registry Not Open. Plase Administrator Checking");
                Application.ExitThread();
                Environment.Exit(0); //완전종료
            }
            return true;
        }

        public bool VPN_Start()
        {
            VpnLogin_Dialog = new Vpn_Login();
            VpnLogin_Dialog.VpnIDPWSendEvent += new VpnUserDataEventHandler(this.VpnLogin_Data);
            VpnLogin_Dialog.VpnClientExitEvent += new VpnClientExitEventHandler(this.VpnLogin_ClientExitCheck);
            this.VpnConnectionEvent+= new VpnConnectionEventHandler(VpnLogin_Dialog.ConnectionEventChecking);
            bool result = false;

#if PROGRAMMING
            return VPN_First_Check();
#endif
            if (VPN_First_Check())
            {
                if (Network_Position == true && VPN_Connection_IP == "127.0.0.1") //내부일때
                    result = true;
                else
                {
                    if (VPN_RegCheck()) //l2tp 연결에 필요한 레지가 있는지 확인
                    {
                        if (VPN_Create() == true)
                        {
                            if (VPN_Connection() == true)
                                result = true;
                        }
                    }
                    else
                        result = false;
                }
            }
            return result;
        }
    }
}
