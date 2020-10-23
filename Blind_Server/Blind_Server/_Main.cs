using BlindNet;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using BlindLogger;

namespace Blind_Server
{
    class _Main
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;

        public static List<BlindClient> Clients = new List<BlindClient>();
        public static BlindServerScoket mainSocket;
        public static BlindServerScoket socket_docCenter;

        public static BlindServerScoket chatPortSock;
        //public static MySqlConnection hDB = new MySqlConnection("Server=localhost;Database=BlindChat;Uid=root;Pwd=sungsu430;");

        static void Main(string[] args)
        {
            var handl = GetConsoleWindow();

            //hDB.Open();

            //ShowWindow(handl, SW_HIDE); //Console 창 숨기기
            socket_docCenter = new BlindServerScoket(BlindNetConst.ServerIP, BlindNetConst.DocCenterPort);
            socket_docCenter.BindListen();

            chatPortSock = new BlindServerScoket(BlindNetConst.ServerIP, BlindNetConst.CHATPORT);
            chatPortSock.BindListen();

            mainSocket = new BlindServerScoket();
            mainSocket.BindListen();
            while (true)
            {
                BlindSocket client = mainSocket.AcceptWithECDH();
                AddConnectedUser(client);
            }
        }

        static async void AddConnectedUser(BlindSocket socket)
        {
            if (socket == null)
                return;

            IPEndPoint iep = (IPEndPoint)(socket.socket.RemoteEndPoint);
            Console.WriteLine("Accepted {0} : {1}", iep.Address, iep.Port);

            //로그인 인증 추가

            //Client 구조체 초기화 및 추가
            TaskScheduler scheduler = TaskScheduler.Default;
            BlindClient client = new BlindClient();
            client.socket = socket;
            client.token = new CancellationTokenSource();

            client.documentCenter = new Doc_Center(1, 3, 4); //기능 객체 생성
            client.tDocumentCenter = Task.Factory.StartNew(() => client.documentCenter.Run(), client.token.Token, TaskCreationOptions.LongRunning, scheduler); //기능 객체의 최초 함수 실행

            //client.chat = new BlindChat(hDB);
            //client.chat = new BlindChat();
            //client.tChat = Task.Factory.StartNew(() => client.chat.Run(), client.token.Token, TaskCreationOptions.LongRunning, scheduler);

            Clients.Add(client);
        }
    }

    class BlindClient
    {
        public uint id;
        public BlindSocket socket;
        public CancellationTokenSource token;
        public Doc_Center documentCenter; //기능 객체
        public Task tDocumentCenter; //기능 객체 작동 Task

        public BlindChat chat;
        public Task tChat;
    }
}
