using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Blind_Client
{
    static class _Main
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        static string ext = ".blind";
        static string fileTypeDesc = "The extension of the file encrypted by 'Blind'";
        static string extType = "Blind" + ext + ".v1";
        static string assocExeFileName = "BlindOpenner.exe";
        static string assocExeFilePath = @"C:\BlindOpenner.exe";

        [STAThread]
        static void Main()
         {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ProcessFileExtReg(true);

            VPN_Class VPN = new VPN_Class();

            while (true)
            {
                VPN.CMD_VPN_Instruction("VPN");

                if (!VPN.VPN_Start())
                {
                    if (MessageBox.Show("VPN 연결에 실패하였습니다. 다시시도 하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        VPN.CMD_VPN_Instruction("VPN");
                        Application.ExitThread();
                        Environment.Exit(0); //완전종료
                    }
                }
                else
                    break;
            }

            bool isInner = VPN.Network_Position;
            isInner = true;
            Application.Run(new MainForm(isInner,VPN.IsInnerClient_Id));//인자값 | 첫번째 : 내부 | 두번째 : 내부(사용자계정명) 외부(VPN 사용자 입력값)
        }
        
        private static void ProcessFileExtReg(bool register)
        {
            using (RegistryKey classesKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true))
            {
                if (register)
                {
                    using (RegistryKey extKey = classesKey.CreateSubKey(ext))
                    {
                        extKey.SetValue(null, extType);
                    }

                    using (RegistryKey typeKey = classesKey.CreateSubKey(extType))
                    {
                        typeKey.SetValue(null, fileTypeDesc);
                        using (RegistryKey shellKey = typeKey.CreateSubKey("shell"))
                        {
                            using (RegistryKey openKey = shellKey.CreateSubKey("open"))
                            {
                                using (RegistryKey commandKey = openKey.CreateSubKey("command"))
                                {
                                    string assocCommand = string.Format("\"{0}\" \"%1\"", assocExeFilePath);
                                    commandKey.SetValue(null, assocCommand);
                                }
                            }
                        }
                    }
                }
                else
                {
                    DeleteRegistryKey(classesKey, ext, false);
                    DeleteRegistryKey(classesKey, extType, true);
                }

                RegistApplication(classesKey, register);
            }
        }

        private static void RegistApplication(RegistryKey classesKey, bool register)
        {
            using (RegistryKey appKey = classesKey.CreateSubKey("Applications"))
            {
                if (register)
                {
                    using (RegistryKey exeKey = appKey.CreateSubKey(assocExeFileName))
                    {
                        using (RegistryKey shellKey = exeKey.CreateSubKey("shell"))
                        {
                            using (RegistryKey openKey = shellKey.CreateSubKey("open"))
                            {
                                using (RegistryKey commandKey = openKey.CreateSubKey("command"))
                                {
                                    string assocCommand = string.Format("\"{0}\" \"%1\"", assocExeFilePath);
                                    commandKey.SetValue(null, assocCommand);
                                }
                            }
                        }
                    }
                }
                else
                    DeleteRegistryKey(appKey, assocExeFileName, true);
            }
        }

        private static void DeleteRegistryKey(RegistryKey classesKey, string subKeyName, bool deleteAllSubKey)
        {
            if (CheckRegistryKeyExists(classesKey, subKeyName) == false)
            {
                return;
            }

            if (deleteAllSubKey)
            {
                classesKey.DeleteSubKeyTree(subKeyName);
            }
            else
            {
                classesKey.DeleteSubKey(subKeyName);
            }
        }

        private static bool CheckRegistryKeyExists(RegistryKey classesKey, string subKeyName)
        {
            RegistryKey regKey = null;

            try
            {
                regKey = classesKey.OpenSubKey(subKeyName);
                return regKey != null;
            }
            finally
            {
                if (regKey != null)
                {
                    regKey.Close();
                }
            }
        }
    }
}
