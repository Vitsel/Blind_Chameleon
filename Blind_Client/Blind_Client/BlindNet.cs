﻿using Blind_Client;
using BlindCryptography;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlindNet
{
    class BlindSocket
    {
        public Socket socket;
        private Cryptography.AES256 aes { get; set; }

        public BlindSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            aes = null;
        }

        public BlindSocket(Cryptography.AES256 aes)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.aes = aes;
        }

        public BlindSocket(Socket socket, Cryptography.AES256 aes)
        {
            this.socket = socket;
            this.aes = aes;
        }

        public BlindSocket(ref BlindSocket blindSocket)
        {
            socket = blindSocket.socket;
            aes = blindSocket.aes;
        }

        ~BlindSocket()
        {
            socket.Close();
            socket.Dispose();
        }

        public int CryptoSend(byte[] data, PacketType header)
        {
            int realSendBytes = 0;
            BlindPacket pack = new BlindPacket();
            byte[] encrypted;
            if (data == null)
                data = new byte[BlindNetConst.DATASIZE];
            try
            {
                if (header == PacketType.MSG)
                    for (int i = 0; i < data.Length; i += BlindNetConst.DATASIZE)
                    {
                        int len = (i + BlindNetConst.DATASIZE < data.Length) ? BlindNetConst.DATASIZE : data.Length - i;
                        pack.header = (len == data.Length) ? (byte)PacketType.EOF : (byte)PacketType.Sending;
                        pack.data = new byte[BlindNetConst.DATASIZE];
                        Array.Copy(data, i, pack.data, 0, len);
                        encrypted = aes.Encryption(BlindNetUtil.StructToByte(pack));
                        realSendBytes += socket.Send(encrypted, BlindNetConst.PACKSIZE, SocketFlags.None);
                    }
                else
                {
                    pack.header = (byte)header;
                    pack.data = new byte[BlindNetConst.DATASIZE];
                    Array.Copy(data, 0, pack.data, 0, data.Length);
                    encrypted = aes.Encryption(BlindNetUtil.StructToByte(pack));
                    realSendBytes = socket.Send(encrypted, BlindNetConst.PACKSIZE, SocketFlags.None);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return realSendBytes;
        }

        public BlindPacket CryptoReceive()
        {
            byte[] data = new byte[BlindNetConst.PACKSIZE];
            socket.Receive(data, BlindNetConst.PACKSIZE, SocketFlags.None);
            byte[] decrypted = aes.Decryption(data);
            return BlindNetUtil.ByteToStruct<BlindPacket>(decrypted);
        }

        public byte[] CryptoReceiveMsg()
        {
            BlindPacket packet = new BlindPacket();
            packet.header = (byte)PacketType.Sending;
            byte[] result = null;
            while (packet.header == (byte)PacketType.Sending)
            {
                packet = CryptoReceive();
                result = BlindNetUtil.MergeArray<byte>(result, packet.data);
                result = BlindNetUtil.ByteTrimEndNull(result);
            }
            return result;
        }

        private void Connect(string ip = BlindNetConst.ServerIP, int port = BlindNetConst.MAINPORT)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), port);
            while (true)
            {
                try
                {
                    socket.Connect(iep);
                }
                catch (SocketException ex)
                {
                    continue;
                }
                break;
            }
        }

        public bool ConnectWithECDH(string ip = BlindNetConst.ServerIP, int port = BlindNetConst.MAINPORT)
        {
            Connect(ip, port);
            aes = BlindNetUtil.ECDH_Client(socket);
            if (aes == null)
                return false;
            return true;
        }

        public async Task<bool> ConnectWithECDHAsync(string ip = BlindNetConst.ServerIP, int port = BlindNetConst.MAINPORT)
        {
            await Task.Run(() => Connect(ip, port));
            aes = BlindNetUtil.ECDH_Client(socket);
            if (aes == null)
                return false;
            return true;
        }
    }

    class BlindServerScoket : BlindSocket
    {
        private readonly IPEndPoint iep;

        public BlindServerScoket(string ip = BlindNetConst.ServerIP, int port = BlindNetConst.MAINPORT) : base()
        {
            iep = new IPEndPoint(IPAddress.Parse(ip), port);
        }

        public void BindListen()
        {
            socket.Bind(iep);
            socket.Listen(BlindNetConst.MAXQ);
        }

        public BlindSocket AcceptWithECDH()
        {
            Socket sock = socket.Accept();
            return BlindNetUtil.ECDH_Server(sock);
        }

        public async Task<BlindSocket> AcceptWithECDHAsync()
        {
            Socket sock = await Task<Socket>.Run(socket.Accept);
            return BlindNetUtil.ECDH_Server(sock);
        }
    }

    static class BlindNetUtil
    {
        static public bool IsConnectedInternet()
        {
            const string NCSI_TEST_URL = "http://www.msftncsi.com/ncsi.txt";
            const string NCSI_TEST_RESULT = "Microsoft NCSI";
            const string NCSI_DNS = "dns.msftncsi.com";
            const string NCSI_DNS_IP_ADDRESS = "131.107.255.255";

            try
            {
                var webClient = new WebClient();
                string result = webClient.DownloadString(NCSI_TEST_URL);
                if (result != NCSI_TEST_RESULT)
                {
                    return false;
                }
                var dnsHost = Dns.GetHostEntry(NCSI_DNS);
                if (dnsHost.AddressList.Count() < 0 || dnsHost.AddressList[0].ToString() != NCSI_DNS_IP_ADDRESS)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        static public string GetPublicIP()
        {
            string publicIP;
            try
            {
                publicIP = new WebClient().DownloadString("http://ipinfo.io/ip").Trim();
            }
            catch
            {
                publicIP = null;
            }
            return publicIP;
        }

        static public (string ip, string mac) GetLocalIP()
        {
            string ip = null;
            string mac = null;
            NetworkInterface[] net = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface n in net)
            {
                for (int i = 0; ; i++)
                {
                    try
                    {
                        if (n.GetIPProperties().GatewayAddresses[i].Address != null)
                        {
                            mac = n.GetPhysicalAddress().ToString();
                            for (int j = 2; j <= 15; j += 3)
                                mac = mac.Insert(j, "-");
                            ip = n.GetIPProperties().UnicastAddresses[1].Address.ToString();
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
                break;
            }
            return (ip, mac);
        }

        public static byte[] StructToByte(object st)
        {
            int size = Marshal.SizeOf(st);
            byte[] arr = new byte[size];
            IntPtr buff = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(st, buff, false);
            Marshal.Copy(buff, arr, 0, size);
            Marshal.FreeHGlobal(buff);
            return arr;
        }

        public static T ByteToStruct<T>(byte[] arr) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            if (size > arr.Length)
                throw new Exception("Array's length is too long");

            IntPtr buff = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, buff, size);
            T st = Marshal.PtrToStructure<T>(buff);

            return st;
        }

        public static T[] MergeArray<T>(T[] arrA, T[] arrB)
        {
            if (arrA == null)
                arrA = new T[0];

            T[] result = new T[arrA.Length + arrB.Length];
            Array.Copy(arrA, 0, result, 0, arrA.Length);
            Array.Copy(arrB, 0, result, arrA.Length, arrB.Length);
            return result;
        }

        public static byte[] ByteTrimEndNull(byte[] arr)
        {
            string tmp = Encoding.UTF8.GetString(arr);
            tmp = tmp.TrimEnd('\0');
            return Encoding.UTF8.GetBytes(tmp);
        }

        public static string GetRandomString(int min, int max)
        {
            Random rand = new Random();
            int len = rand.Next(min, max);
            string input = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            var chars = Enumerable.Range(0, len).Select(x => input[rand.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }

        static public Cryptography.AES256 ECDH_Client(Socket socket)
        {
            Cryptography.AES256 aes;
            using (ECDiffieHellmanCng dh = new ECDiffieHellmanCng())
            {
                dh.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                dh.HashAlgorithm = CngAlgorithm.Sha256;
                byte[] publicKey = dh.PublicKey.ToByteArray();
                byte[] sharekey = new byte[publicKey.Length];
                socket.Receive(sharekey, publicKey.Length, SocketFlags.None);
                socket.Send(publicKey, publicKey.Length, SocketFlags.None);
                byte[] key = dh.DeriveKeyMaterial(CngKey.Import(sharekey, CngKeyBlobFormat.EccPublicBlob));
                aes = new Cryptography.AES256(key);
            }

            BlindSocket blindSocket = new BlindSocket(socket, aes);
            while (true)
            {
                byte[] testTxt = blindSocket.CryptoReceiveMsg();
                blindSocket.CryptoSend(testTxt, PacketType.Response);
                var pack = blindSocket.CryptoReceive();
                if (pack.header == (byte)PacketType.Retry)
                    continue;
                else if (pack.header == (byte)PacketType.Fail)
                {
                    MessageBox.Show("Connection test with text is failed");
                    return null;
                }
                else if (pack.header == (byte)PacketType.OK)
                    break;
            }
            return aes;
        }

        static public BlindSocket ECDH_Server(Socket socket)
        {
            if (socket == null)
                return null;

            Cryptography.AES256 aes;
            BlindSocket clientSock;
            using (ECDiffieHellmanCng dh = new ECDiffieHellmanCng())
            {
                dh.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                dh.HashAlgorithm = CngAlgorithm.Sha256;
                byte[] publicKey = dh.PublicKey.ToByteArray();
                socket.Send(publicKey, publicKey.Length, SocketFlags.None);
                byte[] sharekey = new byte[publicKey.Length];
                socket.Receive(sharekey, publicKey.Length, SocketFlags.None);
                byte[] key = dh.DeriveKeyMaterial(CngKey.Import(sharekey, CngKeyBlobFormat.EccPublicBlob));
                aes = new Cryptography.AES256(key);
                clientSock = new BlindSocket(socket, aes);
            }

            for (int i = 1; ; i++)
            {
                string testTxt = BlindNetUtil.GetRandomString(BlindNetConst.MINRNDTXT, BlindNetConst.MAXRNDTXT);
                clientSock.CryptoSend(Encoding.UTF8.GetBytes(testTxt), PacketType.MSG);
                var pack = clientSock.CryptoReceive();
                string recvTxt = Encoding.UTF8.GetString(pack.data).TrimEnd('\0');
                if (recvTxt != testTxt)
                {
                    if (i < BlindNetConst.MAXRETRY)
                        clientSock.CryptoSend(null, PacketType.Retry);
                    else
                    {
                        clientSock.CryptoSend(null, PacketType.Fail);
                        return null;
                    }
                }
                else
                    break;
            }
            clientSock.CryptoSend(null, PacketType.OK);
            return clientSock;
        }
    }

    class BlindClient
    {
        public BlindSocket socket;
        public CancellationTokenSource token;
        public FileCenter fileCenter; //기능 객체
        public Task tFileCenter; //기능 객체 작동 Task
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct BlindPacket
    {
        public byte header;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = BlindNetConst.DATASIZE)]
        public byte[] data;
    }

    public enum PacketType
    {
        Response = 1,           //단순 응답
        OK = 2,                 //긍정적인 응답
        Fail = 3,               //부정적인 응답
        Retry = 4,              //재전송 요청
        MSG = 5,                //Packet에 사용되지는 않으나 송수신 메소드에서 MSG일 경우 Sending, EOD를 유동적으로 적용
        EOF = 6,                //메시지의 마지막 패킷
        Sending = 7             //마지막이 아닌 패킷
    }

    static class BlindNetConst
    {
        public const string ServerIP = "127.0.0.1";
        public const int MAINPORT = 55555;
        public const int MAXQ = 100;
        public const int PACKSIZE = 1040;
        public const int DATASIZE = 1024;
        public const int MAXRNDTXT = 100;
        public const int MINRNDTXT = 50;
        public const int MAXRETRY = 3;
    }
}