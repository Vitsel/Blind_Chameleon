using BlindNet;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blind_Client.BlindChatCode;
using Blind_Client.BlindChatUI;

namespace Blind_Client
{
    public partial class MainForm : Form
    {
        bool isInner;
        private Socket socket;
        private Thread receiveThread;

        public SynchronizationContext _uiSyncContext;

        BlindSocket mainSocket;
        CancellationTokenSource token;
        Doc_Center documentCenter;
        
        ChatMain _ChatMain;
        BlindChat chat;
        Task tChat;

        DeviceDriverHelper DDH;

        public MainForm(bool isInner)
        {
            InitializeComponent();
            this.isInner = isInner;
            mainSocket = new BlindSocket();
            _uiSyncContext = SynchronizationContext.Current;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!BlindNetUtil.IsConnectedInternet())
            {
                MessageBox.Show("There is no internet connection", "확인", MessageBoxButtons.OK);
                Close();
            }

            bool result = mainSocket.ConnectWithECDH();
            if (!result)
            {
                MessageBox.Show("Main socket connection failed.", "확인", MessageBoxButtons.OK);
                Close();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //각 기능 객체 및 Task 생성
            TaskScheduler scheduler = TaskScheduler.Default;
            token = new CancellationTokenSource();
            DDH = new DeviceDriverHelper();
            //documentCenter = new Doc_Center(document_Center, isInner);
            //documentCenter.Run();
            //document_Center.docCenter = documentCenter;

            int _userID = 2;
            _ChatMain = new ChatMain(_userID);
            MainControlPanel.Controls.Add(_ChatMain);
            //chat = new BlindChat(_userID, ref _ChatMain, this);
            //tChat = Task.Factory.StartNew(() => chat.Run(), token.Token, TaskCreationOptions.LongRunning, scheduler);


            //--------웹통신하면서 반환된 값에따라 usb,캠 차단하고 허용하고.-------------------
            /*IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ipaddress, 4444);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);

            receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.IsBackground = true;
            receiveThread.Start();
            */
        }

        private void Receive_HWMessage()
        {
            while (true)
            {
                byte[] recevieBuffer = new byte[512];
                int length = socket.Receive(recevieBuffer, recevieBuffer.Length, SocketFlags.None);
                string msg = Encoding.UTF8.GetString(recevieBuffer, 0, length);

                if (msg == "UsbDeny")
                    DDH.DeviceToggle("USB", true);
                else if (msg == "UsbAllow")
                    DDH.DeviceToggle("USB", false);

                if (msg == "WebCamDeny")
                    DDH.DeviceToggle("WebCam", true);
                else if (msg == "WebCamAllow")
                    DDH.DeviceToggle("WebCam", false);
            }
        }

        private void Button_DocCenter_Click(object sender, EventArgs e)
        {
            //document_Center.BringToFront();
        }

        private void btn_ActivateChat_Click(object sender, EventArgs e)
        {
            _ChatMain.BringToFront();
        }

    }
}
