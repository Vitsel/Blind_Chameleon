using BlindNet;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_Client
{
    public partial class MainForm : Form
    {
        BlindSocket mainSocket = new BlindSocket();
        CancellationTokenSource token;
        FileCenter fileCenter;
        Task tFileCenter;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
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
            fileCenter = new FileCenter();
            tFileCenter = Task.Factory.StartNew(() => fileCenter.Run(), token.Token, TaskCreationOptions.LongRunning, scheduler); //기능 객체의 최초 함수 실행
        }

        private void Button_DocCenter_Click(object sender, EventArgs e)
        {
            document_Center.BringToFront();
        }
    }
}
