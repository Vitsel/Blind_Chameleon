using BlindNet;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blind_Client.BlindChatCode;
using Blind_Client.BlindChatUI;
using Blind_Client.BlindLock;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Blind_Client
{
    public partial class MainForm : Form
    {
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        [DllImport("kernel32.dll")]
        private static extern uint GetLastError();
        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(IntPtr hwnd, int id, KeyModifiers fsModifiers, Keys vk);
        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(IntPtr hwnd, int id);
        const int WM_HOTKEY = 0x0312;
        const uint WAITTIMESEC = 10;

        private bool isMove;
        private Point fPt;


        bool isInner;
        public SynchronizationContext _uiSyncContext;

        BlindSocket mainSocket;
        CancellationTokenSource token;
        Doc_Center documentCenter;
        
        ChatMain _ChatMain;
        BlindChat chat;
        Task tChat; 
        LockForm lockForm;

        public MainForm(bool isInner)
        {
            InitializeComponent();

            this.isInner = isInner;
            mainSocket = new BlindSocket();
            _uiSyncContext = SynchronizationContext.Current;

            //UI
            Button_DocCenter.ForeColor = btn_ActivateChat.ForeColor = BlindColor.UIColor;
            Button_DocCenter.BackColor = btn_ActivateChat.BackColor = BlindColor.PressedColor;



            this.isMove = false;
            this.panel_Fore.BackColor = Color.LightGray;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
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

            //단축키&타이머 등록
            //BlindLockTimer.Enabled = true;
            //RegisterHotKey(this.Handle, 0, KeyModifiers.Windows, Keys.L);
            //RegisterHotKey(this.Handle, 1, KeyModifiers.Alt, Keys.L);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //각 기능 객체 및 Task 생성
            TaskScheduler scheduler = TaskScheduler.Default;
            token = new CancellationTokenSource();

            //documentCenter = new Doc_Center(document_Center, isInner);
            //documentCenter.Run();
            //document_Center.docCenter = documentCenter;

            int _userID = 3;
            //UI
            _ChatMain = new ChatMain(_userID);
            _ChatMain.Dock = DockStyle.Fill;
            MainControlPanel.Controls.Add(_ChatMain);
            EllipseControl blindchatEllipse = new EllipseControl();
            blindchatEllipse.TargetControl = _ChatMain;
            blindchatEllipse.CorenerRadius = 5;
            //Func
            chat = new BlindChat(_userID, ref _ChatMain, this);
            tChat = Task.Factory.StartNew(() => chat.Run(), token.Token, TaskCreationOptions.LongRunning, scheduler);

            //ScreenLocking
            //lockForm = new LockForm(isInner);
        }

        private void Button_DocCenter_Click(object sender, EventArgs e)
        {
            document_Center.BringToFront();
        }

        private void btn_ActivateChat_Click(object sender, EventArgs e)
        {
            _ChatMain.BringToFront();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //프로그램 종료시 단축키&타이머 해제
            //BlindLockTimer.Enabled = false;
            //UnregisterHotKey(this.Handle, 0);
            //UnregisterHotKey(this.Handle, 1);
        }





        private void BlindChatTimer_Tick(object sender, EventArgs e)
        {
            //if (GetIdleTime() > WAITTIMESEC * 1000) // 10초
            //{
            //    BlindLockTimer.Enabled = false;
            //    lockForm.SetHook();
            //    lockForm.DisableTask();

            //    lockForm.ShowDialog();

            //    BlindLockTimer.Enabled = true;
            //}
        }

        private const int cGrip = 20;
        private const int cCaption = 40;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    {
                        Point pos = new Point(m.LParam.ToInt32());
                        pos = this.PointToClient(pos);
                        if (pos.Y < cCaption)
                        {
                            m.Result = (IntPtr)2;
                            return;
                        }
                        if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                        {
                            m.Result = (IntPtr)17;
                            return;
                        }
                        if(pos.X <= cGrip && pos.Y>=this.ClientSize.Height - cGrip)
                        {
                            m.Result = (IntPtr)16;
                            return;
                        }
                        if (pos.X <= cGrip)
                        {
                            m.Result = (IntPtr)10;
                            return;
                        }
                        if(pos.X>=ClientSize.Width - cGrip)
                        {
                            m.Result = (IntPtr)11;
                            return;
                        }
                        if(pos.Y <= cGrip)
                        {
                            m.Result = (IntPtr)12;
                            return;
                        }
                        if(pos.Y >= this.ClientSize.Height - cGrip)
                        {
                            m.Result = (IntPtr)15;
                            return;
                        }
                    }
                    break;
                    //    case WM_HOTKEY:
                    //        {
                    //            if (m.WParam == (IntPtr)0x0)
                    //            {
                    //                BlindLockTimer.Enabled = false;
                    //                lockForm.SetHook();
                    //                lockForm.DisableTask();

                    //                lockForm.ShowDialog();

                    //                BlindLockTimer.Enabled = true;
                    //            }
                    //            else if (m.WParam == (IntPtr)0x1)
                    //            {

                    //                BlindLockTimer.Enabled = false;
                    //                lockForm.SetHook();
                    //                lockForm.DisableTask();

                    //                lockForm.ShowDialog();

                    //                BlindLockTimer.Enabled = true;
                    //            }
                    //        }
                    //        break;
            }
            base.WndProc(ref m);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(ClientSize.Width - cGrip, ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, BackColor, rc);

            base.OnPaint(e);
        }

        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        };
        public static uint GetIdleTime()
        {
            LASTINPUTINFO LastInPut = new LASTINPUTINFO();
            LastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(LastInPut);
            GetLastInputInfo(ref LastInPut);

            return ((uint)Environment.TickCount - LastInPut.dwTime);
        }

        public static long GetTickCount()
        {
            return Environment.TickCount;
        }

        public static long GetLastInputTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            if (!GetLastInputInfo(ref lastInPut))
            {
                throw new Exception(GetLastError().ToString());
            }
            return lastInPut.dwTime;
        }




        //UI
        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }


        private void panel_Fore_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fPt = new Point(e.X, e.Y);
        }

        private void panel_Fore_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (fPt.X - e.X), this.Top - (fPt.Y - e.Y));
            }
        }

        private void panel_Fore_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void btn_close_MouseMove(object sender, MouseEventArgs e)
        {
            btn_close.ForeColor = Color.Black;
        }

        private void btn_close_MouseLeave(object sender, EventArgs e)
        {
            btn_close.ForeColor = Color.Gray;
        }

        private void btn_maximize_MouseMove(object sender, MouseEventArgs e)
        {
            btn_maximize.ForeColor = Color.Black;
        }

        private void btn_maximize_MouseLeave(object sender, EventArgs e)
        {
            btn_maximize.ForeColor = Color.Gray;
        }

        private void btn_minimize_MouseMove(object sender, MouseEventArgs e)
        {
            btn_minimize.ForeColor = Color.Black;
        }

        private void btn_minimize_MouseLeave(object sender, EventArgs e)
        {
            btn_minimize.ForeColor = Color.Gray;
        }



    }
}
