using BlindCryptography;
using BlindNet;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlindOpenner
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;

        static void Main(string[] args)
        {
#if !DEBUG
            var handl = GetConsoleWindow();
            ShowWindow(handl, SW_HIDE);
#endif

            if (args.Length != 1)
            {
                MessageBox.Show("잘못된 접근입니다.", "오류");
                return;
            }

            FileInfo file = new FileInfo(args[0]);
            if (!file.Exists)
            {
                MessageBox.Show("파일이 존재하지 않습니다.", "파일 열기");
                return;
            }
            FileStream fs = file.Open(FileMode.Open);
            byte[] buffer = new byte[fs.Length];
            Task<int> taskRead = fs.ReadAsync(buffer, 0, (int)file.Length);

            BlindSocket socket = new BlindSocket();
            Task<bool> taskCon = socket.ConnectWithECDHAsync(BlindNetConst.ServerIP, BlindNetConst.OPENNERPORT);
            taskCon.Wait();
            if (!taskCon.Result)
            {
                MessageBox.Show("서버와 연결에 실패했습니다.", "파일 열기");
                return;
            }
            Console.WriteLine("Connected with server.");

            taskRead.Wait();
            if (taskRead.Result == 0)
            {
                MessageBox.Show("파일 읽기에 실패했습니다.", "파일 열기");
                return;
            }
            fs.Close();

            uint id = BitConverter.ToUInt32(buffer, 0);
            string ext = GetSpecifyExt(id, socket);
            if (ext == null)
                return;

            Cryptography.AES256 aes256;
            if (!GetAES(ref buffer, socket, out aes256))
                return;

            Console.WriteLine("Start decrypted");
            byte[] decrypted = aes256.Decryption(buffer);
            Console.WriteLine("Decrypted");

            string tempFilePath = Path.GetTempPath() + Path.GetFileNameWithoutExtension(args[0]) + ext;
            MakeTempFile(tempFilePath, decrypted);
            Console.WriteLine("File maked");

            Process procFile = Process.Start(tempFilePath);

            Cryptography.AES256 latestAes;
            if (!GetLatestAES(socket, out latestAes))
            {
                MessageBox.Show("최신 키 받아오기를 실패했습니다.");
                return;
            }
            socket.Close();

            procFile.WaitForExit();
            Console.WriteLine("Canceled");

            FileInfo decFile = new FileInfo(tempFilePath);
            FileStream decFs = decFile.OpenRead();
            buffer = new byte[decFile.Length];
            decFs.Read(buffer, 0, (int)decFile.Length);
            decFs.Close();

            buffer = AddDataToFile(id, latestAes.Encryption(buffer));

            FileStream encFs = file.Open(FileMode.Open);
            encFs.Write(buffer, 0, buffer.Length);
            encFs.Close();
            decFile.Delete();
        }

        static void MakeTempFile(string path, byte[] data)
        {
            Console.WriteLine("Tempfile path : " + path);
            FileInfo decFile = new FileInfo(path);
            //if ((decFile.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
            //    decFile.Attributes |= FileAttributes.Hidden;
            //if ((decFile.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            //    decFile.Attributes &= ~FileAttributes.Hidden;
            FileStream fileStream = decFile.Open(FileMode.Create);
            Console.WriteLine("test");
            fileStream.Write(data, 0, data.Length);
            fileStream.Close();
            return;
        }

        static bool GetAES(ref byte[] data, BlindSocket socket, out Cryptography.AES256 aes256)
        {
            aes256 = null;

            uint encryptDate = BitConverter.ToUInt32(data, 4);
            byte[] realData = new byte[data.Length - 8];
            Array.Copy(data, 8, realData, 0, realData.Length);
            data = realData;

            Console.WriteLine("Encrypted date : " + encryptDate);
            socket.CryptoSend(BitConverter.GetBytes(encryptDate), PacketType.Info);

            byte[] key = socket.CryptoReceiveMsg();
            if (key == null)
            {
                MessageBox.Show("파일 복호화에 실패했습니다.", "파일 열기");
                return false;
            }
            Console.WriteLine("Received key {0} bytes", key.Length);

            byte[] iv = socket.CryptoReceiveMsg();
            if (iv == null)
            {
                MessageBox.Show("파일 복호화에 실패했습니다.", "파일 열기");
                return false;
            }
            Console.WriteLine("Received iv {0} bytes", iv.Length);

            aes256 = new Cryptography.AES256(key, iv);
            return true;
        }

        static string GetSpecifyExt(uint id, BlindSocket socket)
        {
            socket.CryptoSend(BitConverter.GetBytes(id), PacketType.Info);
            byte[] bExt = socket.CryptoReceiveMsg();
            if (bExt == null)
            {
                MessageBox.Show("파일 복호화에 실패했습니다.", "파일 열기");
                return null;
            }
            string ext = "." + Encoding.UTF8.GetString(bExt);
            Console.WriteLine("Ext : " + ext);
            return ext;
        }

        static bool GetLatestAES(BlindSocket socket, out Cryptography.AES256 aes256)
        {
            aes256 = null;
            byte[] key = socket.CryptoReceiveMsg();
            if (key == null)
            {
                MessageBox.Show("파일 복호화에 실패했습니다.", "파일 열기");
                return false;
            }
            Console.WriteLine("Received key {0} bytes", key.Length);

            byte[] iv = socket.CryptoReceiveMsg();
            if (iv == null)
            {
                MessageBox.Show("파일 복호화에 실패했습니다.", "파일 열기");
                return false;
            }
            Console.WriteLine("Received iv {0} bytes", iv.Length);

            aes256 = new Cryptography.AES256(key, iv);
            return true;
        }

        static byte[] AddDataToFile(uint id, byte[] data)
        {
            uint timestemp = uint.Parse(DateTime.Now.ToString("yyyyMMdd"));
            byte[] result = BlindNetUtil.MergeArray(BitConverter.GetBytes(timestemp), data);
            result = BlindNetUtil.MergeArray(BitConverter.GetBytes(id), result);
            return result;
        }
    }
}
