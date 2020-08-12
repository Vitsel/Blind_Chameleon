using BlindNet;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

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

        static void Main(string[] args)
        {
            var handl = GetConsoleWindow();
            //ShowWindow(handl, SW_HIDE); //Console 창 숨기기

            BlindServerScoket socket = new BlindServerScoket();
            socket.BindListen();
            while (true)
            {
                Socket sock = socket.socket.Accept();
                CertificateAsync(sock);
            }
        }

        static async void CertificateAsync(Socket socket)
        {
            if (socket == null)
                return;
            BlindSocket clientSock = await Task<BlindSocket>.Run(() => BlindNetUtil.ECDH_Server(socket));
            if (clientSock == null)
                return;
            IPEndPoint iep = (IPEndPoint)socket.RemoteEndPoint;
            Console.WriteLine("Accepted {0} : {1}", iep.Address, iep.Port);

            //로그인 인증 추가

            //Client 구조체 초기화 및 추가
            TaskScheduler scheduler = TaskScheduler.Default;
            BlindClient client = new BlindClient();
            client.socket = clientSock;
            client.token = new CancellationTokenSource();
            client.fileCenter = new FileCenter(); //기능 객체 생성
            client.tFileCenter = Task.Factory.StartNew(() => client.fileCenter.Run(), client.token.Token, TaskCreationOptions.LongRunning, scheduler); //기능 객체의 최초 함수 실행
            Clients.Add(client);
        }
    }
}
