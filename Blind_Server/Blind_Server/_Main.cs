using BlindNet;
using System;
using System.Data;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlindLogger;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;

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
        public static BlindServerScoket WebDeviceSocket;
        public static BlindServerScoket chatPortSock;
        public static BlindServerScoket lockPortSock;
        public static MySqlConnection connection;

        static void Main(string[] args)
        {
            var handl = GetConsoleWindow();

            BlindOpenner openner = new BlindOpenner();
            Task.Run(() => openner.Run());

            //DataBase MySql Connection
            connection = DataBaseConnection();

            //ShowWindow(handl, SW_HIDE); //Console 창 숨기기
            socket_docCenter = new BlindServerScoket(BlindNetConst.ServerIP, BlindNetConst.DocCenterPort);
            socket_docCenter.BindListen();

            chatPortSock = new BlindServerScoket(BlindNetConst.ServerIP, BlindNetConst.CHATPORT);
            chatPortSock.BindListen();

            lockPortSock = new BlindServerScoket(BlindNetConst.ServerIP, BlindNetConst.LOCKPORT);
            lockPortSock.BindListen();

            mainSocket = new BlindServerScoket();
            mainSocket.BindListen();

            WebDeviceSocket = new BlindServerScoket(BlindNetConst.ServerIP, BlindNetConst.WebDevicePort);
            WebDeviceSocket.BindListen();

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

            //로그인 인증
            uint cid;
            byte[] cName = socket.CryptoReceiveMsg();// 아이디 받음
            if (Encoding.UTF8.GetString(cName) != "\0")
                cid = GetClientID(Encoding.UTF8.GetString(cName)); // 바이트 -> 스트링
            else
                cid = 0;
            socket.CryptoSend(BitConverter.GetBytes(cid), PacketType.Response);//cid 보냄
            if (cid == 0)
            {
                socket.Close();
                return;
            }
            uint[] gids = GetGids(cid);


            Console.WriteLine("Accepted {0} : {1}" + $"({cid})", iep.Address, iep.Port);

            //Client 구조체 초기화 및 추가
            TaskScheduler scheduler = TaskScheduler.Default;
            BlindClient client = new BlindClient();
            client.socket = socket;
            client.token = new CancellationTokenSource();

            client.documentCenter = new Doc_Center(cid, gids); //기능 객체 생성
            client.tDocumentCenter = Task.Factory.StartNew(() => client.documentCenter.Run(), client.token.Token, TaskCreationOptions.LongRunning, scheduler); //기능 객체의 최초 함수 실행

            client.chat = new BlindChat(cid);
            client.tChat = Task.Factory.StartNew(() => client.chat.Run(), client.token.Token, TaskCreationOptions.LongRunning, scheduler);

            client.blindLock = new BlindLock(cid);
            client.tBlindLock = Task.Factory.StartNew(() => client.blindLock.Run(), client.token.Token, TaskCreationOptions.LongRunning, scheduler);

            client.blindWebDevice = new BlindWebDevice();
            client.tBlindWebDevice = Task.Factory.StartNew(() => client.blindWebDevice.Run(cid, connection), client.token.Token, TaskCreationOptions.LongRunning, scheduler);

            Clients.Add(client);
        }

        static MySqlConnection DataBaseConnection()
        {
            string MysqlStr = string.Format(@"server=54.84.228.2; database=BlindWeb; user=root; password=kit2020");
            MySqlConnection MysqlCon; //쿼리연결

            MysqlCon = new MySqlConnection(MysqlStr); // 쿼리 접속
            MysqlCon.Open();

            return MysqlCon;
        }

        static uint GetClientID(string cName)
        {
            uint result;
            string command = "SELECT cid FROM blindEmployee WHERE id =" + "'" + cName + "';";
            MySqlCommand commander = new MySqlCommand(command, connection);
            var cid = commander.ExecuteScalar();
            if (cid == null)
                return 0;
            result = UInt32.Parse(cid.ToString());

            return result;
        }

        static uint[] GetGids(uint cid)
        {
            string command = "SELECT gid FROM blindGroupMatchEmp WHERE cid = " + cid + ";";
            MySqlDataAdapter reader = new MySqlDataAdapter(command, connection);
            DataSet dataSet = new DataSet();
            reader.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count == 0)
                return null;

            uint[] gids = new uint[dataSet.Tables[0].Rows.Count];
            for (int i = 0; i < gids.Length; i++)
                gids[i] = UInt32.Parse(dataSet.Tables[0].Rows[i]["gid"].ToString());
            return gids;
        }

    }

    class BlindClient
    {
        public BlindSocket socket;
        public CancellationTokenSource token;
        public Doc_Center documentCenter; //기능 객체
        public Task tDocumentCenter; //기능 객체 작동 Task

        public BlindChat chat;
        public Task tChat;
        public BlindLock blindLock;
        public Task tBlindLock;

        public BlindWebDevice blindWebDevice;
        public Task tBlindWebDevice;
    }
}
