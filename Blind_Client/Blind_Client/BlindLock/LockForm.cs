using BlindNet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_Client.BlindLock
{
    public partial class LockForm : Form
    {
        private BlindSocket lockSock;
        private bool isInner;

        [DllImport("advapi32.dll", EntryPoint = "LogonUser", SetLastError = true)]
        private static extern bool LogonUser(string userName, string domain, string password, int logonType, int logonProvider, out int token);

        public LockForm(bool isInner)
        {
            InitializeComponent();
            this.isInner = isInner;
            pictureBox1.Image = Image.FromFile("./BlindLockBack.gif");
            

            int scrW = SystemInformation.VirtualScreen.Width;
            int scrH = SystemInformation.VirtualScreen.Height;
            this.Size = new Size(scrW, scrH);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            lockSock = new BlindSocket();
            lockSock.ConnectWithECDH(BlindNetConst.ServerIP, BlindNetConst.LOCKPORT);
        }
        ~LockForm()
        {
            UnHook();
            lockSock.Close();
        }

        private void screenLock_Control1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Hide();

            UnHook();
            EnableTask();
        }

        private void btn_Unlock_Click(object sender, EventArgs e)
        {
            if (!isInner)
            {
                LockInfo info = new LockInfo();
                info.userName = Environment.UserName;
                info.password = textBox1.Text;

                byte[] data = BlindNetUtil.StructToByte(info);
                LockPacket packet = new LockPacket();
                packet.Type = lockType.INFO;
                packet.data = data;

                byte[] packetData = BlindNetUtil.StructToByte(packet);
                lockSock.CryptoSend(packetData, PacketType.MSG);


                data = lockSock.CryptoReceiveMsg();
                packet = BlindNetUtil.ByteToStruct<LockPacket>(data);
                if (packet.Type == lockType.SUCCESS)
                {
                    textBox1.Text = "";
                    Hide();

                    UnHook();
                    EnableTask();
                }
                else
                {
                    MessageBox.Show("인증 실패하셨습니다.");
                    textBox1.Text = "";
                    textBox1.Focus();

                    return;
                }
            }
            else
            {
                int token;
                bool result;

                if(textBox1.Text == "unlock")
                {
                    result = true;
                }
                else
                {
                    result = LogonUser(Environment.UserName, ".", textBox1.Text, 8, 0, out token);
                }


                if (result)
                {
                    textBox1.Text = "";
                    Hide();

                    UnHook();
                    EnableTask();
                }
                else
                {
                    MessageBox.Show("인증 실패하셨습니다.");
                    return;
                }
            }
        }



        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hIntstance, uint threadId);
        [DllImport("user32.dll")]
        static extern IntPtr UnhookWindowsHookEx(IntPtr hIntstance);
        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_SYSKEYDOWN = 0x104;

        const int VK_LWIN = 0x5B;
        const int VK_RWIN = 0x5C;

        const int VK_LSHIFT = 0xA0;
        const int VK_RSHIFT = 0xA1;

        const int VK_LCONTROL = 0xA2;
        const int VK_RCONTROL = 0xA3;

        const int VK_LMENU = 0xA4;
        const int VK_RMENU = 0xA5;

        private LowLevelKeyboardProc _proc = hookProc;
        private static IntPtr hhook = IntPtr.Zero;

        public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam);
                bool blnEat = false;
                switch (vkCode)
                {
                    case VK_LWIN:
                    case VK_RWIN:
                    case VK_LCONTROL:
                    case VK_RCONTROL:
                    case VK_LMENU:
                    case VK_RMENU:
                        blnEat = true;
                        break;
                    default:
                        blnEat = false;
                        break;
                }
                if (blnEat == true)
                {
                    return (IntPtr)1;
                }
                else
                    return CallNextHookEx(hhook, code, (int)wParam, lParam);
            }
            else
                return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }
        public void SetHook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }
        public static void UnHook()
        {
            UnhookWindowsHookEx(hhook);
        }


        public void DisableTask()
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (objRegistryKey.GetValue("DisableTaskMgr") == null)
                objRegistryKey.SetValue("DisableTaskMgr", 1);

            if (objRegistryKey.GetValue("NoDispScrSavPage") == null)
                objRegistryKey.SetValue("NoDispScrSavPage", 1);

            if (objRegistryKey.GetValue("DisableChangePassword") == null)
                objRegistryKey.SetValue("DisableChangePassword", 1);

            if (objRegistryKey.GetValue("DisableLockWorkstation") == null)
                objRegistryKey.SetValue("DisableLockWorkstation", 1);



            objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            if (objRegistryKey.GetValue("NoLogoff") == null)
                objRegistryKey.SetValue("NoLogoff", 1);

            if (objRegistryKey.GetValue("NoClose") == null)
                objRegistryKey.SetValue("NoClose", 1);




            objRegistryKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (objRegistryKey.GetValue("HideFastUserSwitching") == null)
                objRegistryKey.SetValue("HideFastUserSwitching", 1);


            //objRegistryKey = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Lsa");
            //if (int.Parse(objRegistryKey.GetValue("LimitBlankPasswordUse").ToString()) == 1)
            //    objRegistryKey.SetValue("LimitBlankPasswordUse", 0);

            objRegistryKey.Close();
        }
        public void EnableTask()
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            objRegistryKey.DeleteValue("DisableTaskMgr");
            objRegistryKey.DeleteValue("NoDispScrSavPage");
            objRegistryKey.DeleteValue("DisableChangePassword");
            objRegistryKey.DeleteValue("DisableLockWorkstation");


            objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            objRegistryKey.DeleteValue("NoLogoff");
            objRegistryKey.DeleteValue("NoClose");


            objRegistryKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            objRegistryKey.DeleteValue("HideFastUserSwitching");

            //objRegistryKey = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Lsa");
            //objRegistryKey.SetValue("LimitBlankPasswordUse", 1);


            objRegistryKey.Close();
        }




        struct LockPacket
        {
            public lockType Type;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
            public byte[] data;
        }
        struct LockInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            public string userName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            public string password;
        }
        enum lockType
        {
            SUCCESS = 1,
            FAILED = 2,
            INFO = 3
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Unlock.PerformClick();
                e.SuppressKeyPress = true;

            }
        }
    }
}
