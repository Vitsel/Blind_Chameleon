using BlindNet;
using System;
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
        public SynchronizationContext _uiSyncContext;

        BlindSocket mainSocket;
        CancellationTokenSource token;
        Doc_Center documentCenter;
        
        ChatMain _ChatMain;
        BlindChat chat;
        Task tChat;

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

            //로그인 확인 추가

            //각 기능 객체 및 Task 생성
            TaskScheduler scheduler = TaskScheduler.Default;
            token = new CancellationTokenSource();
            //documentCenter = new Doc_Center(document_Center);
            //documentCenter.Run();
            //document_Center.docCenter = documentCenter;

            int _userID = 2;
            _ChatMain = new ChatMain(_userID);
            ChatControlPanel.Controls.Add(_ChatMain);
            chat = new BlindChat(_userID, ref _ChatMain, this);
            tChat = Task.Factory.StartNew(() => chat.Run(), token.Token, TaskCreationOptions.LongRunning, scheduler);
        }

        private void Button_DocCenter_Click(object sender, EventArgs e)
        {
            document_Center.BringToFront();
        }

        private void btn_ActivateChat_Click(object sender, EventArgs e)
        {
            _ChatMain.BringToFront();
        }
    }
}
