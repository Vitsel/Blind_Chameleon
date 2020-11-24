using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketClass;
using BlindNet;
namespace WebMainServer
{
    class _Main
    {
        static BlindServerScoket MainWebSocket;
        public static BlindSocket BS;
        public static BlindPacket BP;
        public static WebSocket WS;
        static _Main()
        {
            MainWebSocket = new BlindServerScoket(BlindNetConst.ServerIP, BlindNetConst.WebInterlockPort);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Well Come to Console \r\n");
            Console.WriteLine("All Press KeyDown -> Program Exit");
            MainWebSocket.BindListen();
            Console.WriteLine("VpnServer Connection Listening");
            BS = MainWebSocket.AcceptWithECDH(); //따로 받는이유 : 브로드캐스트로 인해서 여러개의 클라를 받으려면 따로 받아줘야함.
            IPEndPoint iep = (IPEndPoint)(BS.socket.RemoteEndPoint);
            Console.WriteLine("VpnServer Connection Start. (Connection IP : " + iep.Address.ToString() + ")\r\n");
            Console.WriteLine("----------------------------------------------------");

            WS = new WebSocket(BlindNetConst.ServerIP, BlindNetConst.WebTcpPort, BS, BP);

            Console.ReadLine();
        }
    }
}
