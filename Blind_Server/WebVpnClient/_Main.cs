using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlindNet;
namespace WebVpnClient
{
    class _Main
    {
        public static BlindSocket MainSocket;
        public static BlindPacket MainPacket;
        static string ReceiveByteToStringGenderText;
        static string Result;

        static _Main()
        {
            MainSocket = new BlindSocket();
            MainPacket = new BlindPacket();
            ReceiveByteToStringGenderText = "";
            Result = "";
        }
        ~_Main() { MainSocket.Close(); }

        static void Main(string[] args)
        {
            Console.WriteLine("Well Come to Console \r\n\r\n");
            if (!BlindNetUtil.IsConnectedInternet())
            {
                Console.WriteLine("There is no internet connection");
                Environment.Exit(0);
            }

            bool result = MainSocket.ConnectWithECDH(BlindNetConst.ServerIP,BlindNetConst.WebInterlockPort);
            if (!result)
            {
                Console.WriteLine("Main socket connection failed.");
                Environment.Exit(0);
            }
            Console.WriteLine("Main Server Connection. (Server IP : " + BlindNetConst.ServerIP+")\r\n");
            

            while (true)
            {  //받기 -> 명령문 실행 -> 결과(Result) 스트링 전송)
                MainPacket = MainSocket.CryptoReceive(); //타입 + 아이디 + 비번 정보 받음
                Console.Write("Server Message Receive Waiting");
                //MainPacket.data = BlindNetUtil.ByteTrimEndNull(MainPacket.data); //
                ReceiveByteToStringGenderText = Encoding.Default.GetString(BlindNetUtil.ByteTrimEndNull(MainPacket.data)); //변환해서 ㅓㄶ음
                Console.WriteLine("Receive Message : " + ReceiveByteToStringGenderText);
                if (CMD_Instruction(ReceiveByteToStringGenderText)) // 명령문 전달해서 실행
                    Result = "true";
                else
                    Result = "false";

                MainSocket.CryptoSend(Encoding.UTF8.GetBytes(Result), PacketType.Response); // 결과 전송
                Console.WriteLine("Send Message | Instruction Result = " + Result + "\r\n");
            }
        }
        static bool CMD_Instruction(string Instruction)
        {
            System.Diagnostics.Process ps = new System.Diagnostics.Process();
            //ps.StartInfo.WorkingDirectory = "C:\\BlindWeb\\AccountCMD";
            ps.StartInfo.FileName = "C:\\BlindWeb\\AccountCMD\\Account.bat";
            ps.StartInfo.Arguments = Instruction;
            ps.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;

            try
            {
                ps.Start();
                ps.WaitForExit(10000);

                if (ps.ExitCode.ToString() == "0")
                    return true;
                else
                    return false;
            }
            catch 
            {
                return false;
            }
        }
    }
}
