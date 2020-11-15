using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlindNet;
using System.IO;
namespace WebSocketClass
{
    class WebSocket
    {
        static BlindSocket SUBBS;
        static BlindPacket SUBBP;
        static TcpListener TListener;
        static TcpClient TClient;
        static NetworkStream ClientStream;
        static byte[] ReadBuffer;

        public string ServerIP;
        public int ServerPort;

        public WebSocket(string ServerIP, int ServerPort, BlindSocket BS, BlindPacket BP)
        {
            this.ServerIP = ServerIP;
            this.ServerPort = ServerPort;
            SUBBS = BS;
            SUBBP = BP;
            TListener = null;
            TClient = null;
            ClientStream = null;
            ReadBuffer = new byte[10240];

            
            TListener = new TcpListener(IPAddress.Parse(this.ServerIP), this.ServerPort);
            TListener.Start();
            Console.WriteLine("WebServer Open\r\n");

            TListener.BeginAcceptTcpClient(OnServerConnect, null); // 클라이언트 접속 대기
        }

        public void Close()  { TListener.Stop();  }

        static void OnServerConnect(IAsyncResult ar) // 서버접속 들어왔을때 처리
        {
            TClient = TListener.EndAcceptTcpClient(ar); // 클라접속
            Console.WriteLine("(WebSocket)Connection\r\n");
            TListener.BeginAcceptTcpClient(OnServerConnect, null);


            //접속 url 정보 받아옴
            ClientStream = TClient.GetStream();
            ClientStream.BeginRead(ReadBuffer, 0, ReadBuffer.Length, onAcceptReader, null);
        }

        static void onAcceptReader(IAsyncResult ar) // 클라이언트 데이터 읽어오기
        {
            int ReceiveLength = ClientStream.EndRead(ar); // 받은 데이터 길이 확인
            if (ReceiveLength <= 0) // 0보다 같거나 작은경우 접속 사망
            {
                Console.WriteLine("(WebSocket)Connection Close");
                ClientStream.Close();
                return;
            }

            string ClientMSG = Encoding.UTF8.GetString(ReadBuffer, 0, ReceiveLength);

            if (!Regex.IsMatch(ClientMSG, "GET")) //웹페이지로 받은 것이 아닌경우 종료
            {
                Console.WriteLine("(WebSocket)Connection Close");
                ClientStream.Close();
                return;
            }

            const string eol = "\r\n";
            string resMessage = "HTTP/1.1 101 Switching Protocols" + eol
             + "Connection: Upgrade" + eol
             + "Upgrade: websocket" + eol
             + "Sec-WebSocket-Accept: " + Convert.ToBase64String(
                 System.Security.Cryptography.SHA1.Create().ComputeHash(
                     Encoding.UTF8.GetBytes(
                         new Regex("Sec-WebSocket-Key: (.*)").Match(ClientMSG).Groups[1].Value.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
                     )
                 )
             ) + eol
             + eol
             ;

            Byte[] response = Encoding.UTF8.GetBytes(resMessage);
            ClientStream.Write(response, 0, response.Length); //웹에 서버 정보 전송

            ClientStream.BeginRead(ReadBuffer, 0, ReadBuffer.Length, onEchoReader, null);
        }

        static void onEchoReader(IAsyncResult ar)
        {  //웹에서 보낸 데이터 처리

            // 받은 데이터의 길이를 확인합니다.
            int receiveLength = ClientStream.EndRead(ar);

            // 데이터 6 = close() 데이터 0보다 작거나 같은것 = 홈페이지 끈경우
            if (receiveLength <= 0 || receiveLength == 6)
            {
                Console.WriteLine("(WebSocket)Connection Close");
                ClientStream.Close();
                return;
            }

            BitArray maskingCheck = new BitArray(new byte[] { ReadBuffer[1] });//마스킹 관련
            int receivedSize = (int)ReadBuffer[1];

            byte[] mask = new byte[] { ReadBuffer[2], ReadBuffer[3], ReadBuffer[4], ReadBuffer[5] };

            receivedSize -= 128;
            //if (maskingCheck.Get(0))
            //{
            //    Console.WriteLine("마스킹 되어 있습니다.");
            //    receivedSize -= 128;            // 마스킹으로 인해 추가된 값을 빼 줍니다.
            //}
            //else
            //{
            //    Console.WriteLine("마스킹 되어 있지 않습니다.");
            //}

            //데이터 길이 비트 : receivedSize | 데이터 길이 : receivedLength

            // 받은 메시지를 디코딩해 줍니다.
            byte[] decodedByte = new byte[receivedSize];
            for (int _i = 0; _i < receivedSize; _i++)
            {
                int curIndex = _i + 6;
                decodedByte[_i] = (byte)(ReadBuffer[curIndex] ^ mask[_i % 4]);
            }

            // 받은 메시지를 출력합니다.
            //string newMessage = Encoding.UTF8.GetString( ReadBuffer, 6, receiveLength - 6 );
            string newMessage = Encoding.UTF8.GetString(decodedByte, 0, receivedSize);

            string value = "\u0003�"; //페이지이동할때 발생
            if (newMessage.ToString() == value.ToString())
            {
                ClientStream.Close(); //페이지 이동하면 뒤지게끔
                Console.WriteLine("(WebSocket)Connection Close");
                return;
            }
            Console.WriteLine(string.Format("(WebSocket)Receive Message : {0}", newMessage));

            string SendMsg = "false";
            byte[] sendMessage;
            string Instruction = "";
            bool InstructionResult = false;
            string[] MessageSort = new string[10]; // 받아온 것 분류하기 위한 스트링 배열
            Enumerable.Repeat("NULL", 10);
            /* 메시지 "," 순서 
            계정 생성 : 방식, cid, 아이디, 비밀번호, 이름, 직급, 휴대폰 번호, 이메일, 부서, 성별
            계정 생성,삭제 : 방식,아이디            
            */
            for (int count = 0; count <= 9; count++) // 스트링 배열에 순차적으로 ,을 구분하여 0~9까지 결과를 배열에 넣음
            {
                try
                {
                    if (newMessage.Split(',')[count].ToString() != "")
                        MessageSort[count] = newMessage.Split(',')[count].ToString();
                }
                catch
                {
                    MessageSort[3] = "1234";
                    break;
                }
            }

            Instruction = MessageSort[0] + " " + MessageSort[2] + " " + MessageSort[3];

            InstructionResult = CMD_Instruction(Instruction);
            SUBBS.CryptoSend(Encoding.UTF8.GetBytes(Instruction), PacketType.Response); //타입 + 아이디 + 비번 정보 보냄
            Console.WriteLine("(VpnSocket)Send Instruction");
            SUBBP=SUBBS.CryptoReceive(); // VPN 서버에서 실행된 결과 메시지 받음 ( true / false)
            string VpnServerReceiveMsg = Encoding.Default.GetString(BlindNetUtil.ByteTrimEndNull(SUBBP.data)); // 결과 메시지 변환후 저장
            Console.WriteLine("(VpnSocket)Receive Message : " + VpnServerReceiveMsg);

            if (InstructionResult == true && VpnServerReceiveMsg == "true")
            {
                if (MessageSort[0] == "Create")
                    SendMsg = "CreateSuccess," + MessageSort[1];
                if (MessageSort[0] == "Modify")
                    SendMsg = "ModifySuccess," + MessageSort[1];
                if (MessageSort[0] == "Delete")
                    SendMsg = "DeleteSuccess," + MessageSort[1];
            }
            else
                SendMsg = "Fail," + MessageSort[1];

            // 보낼 메시지 만들기
            sendMessage = Encoding.UTF8.GetBytes(SendMsg);

            List<byte> sendByteList = new List<byte>();

            // 첫 데이터의 정보를 만들어 추가합니다.
            BitArray firstInfor = new BitArray(
                new bool[]{

                    true                // FIN
                    , false             // RSV1
                    , false             // RSV2
                    , false             // RSV3

                    // opcode (0x01: 텍스트)
                    , false
                    , false
                    , false
                    , true

                }
            );
            byte[] inforByte = new byte[1];
            firstInfor.CopyTo(inforByte, 0);
            sendByteList.Add(inforByte[0]);

            // 문자열의 길이를 추가합니다.
            sendByteList.Add((byte)sendMessage.Length);

            // 실제 데이터를 추가합니다.
            sendByteList.AddRange(sendMessage);

            // 만든 메시지 보내기
            ClientStream.Write(sendByteList.ToArray(), 0, sendByteList.Count);
            Console.WriteLine("(WebSocket)Web Send Message : " + SendMsg + "\r\n");

            // 또 다음 메시지를 받을 수 있도록 대기 합니다.
            //ClientStream.BeginRead(ReadBuffer, 0, ReadBuffer.Length, onEchoReader, null);
            ClientStream.Close(); //페이지 이동하면 뒤지게끔
            Console.WriteLine("(WebSocket)Connection Close");

            //TClient.Close(); // 페이지이동하면 뒤지게끔

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
