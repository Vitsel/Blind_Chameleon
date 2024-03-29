﻿using BlindLogger;
using BlindNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Blind_Server
{
    class BlindLock
    {
        [DllImport("advapi32.dll", EntryPoint = "LogonUser", SetLastError = true)]
        private static extern bool LogonUser(string userName, string domain, string password, int logonType, int logonProvider, out int token);
        private Logger logger;
        private uint _cid;
        public BlindLock(uint cid)
        {
            _cid = cid;
        }

        public bool CheckUserValid(string userName, string password)
        {
            if (password == "unlock")
                return true;

            int token;
            bool result = LogonUser(userName, ".", password, 8, 0, out token);
            return result;
        }

        public void Run()
        {
            BlindSocket socket;
            socket = _Main.lockPortSock.AcceptWithECDH();

            IPEndPoint iep = (IPEndPoint)(socket.socket.RemoteEndPoint);
            logger = new Logger(_cid, iep.Address.ToString(), LogService.ScreenLock);

            while (true)
            {
                byte[] data = socket.CryptoReceiveMsg();
                if(data == null)
                {
                    socket.Close();
                    logger.Log(LogRank.INFO, "BlindLock Disconnected");
                    return;
                }

                //인증 여기서
                LockPacket packet = BlindNetUtil.ByteToStruct<LockPacket>(data);
                if(packet.Type == lockType.INFO)
                {
                    logger.Log(LogRank.INFO, "Unlock try from out of Local");
                    LockInfo info = BlindNetUtil.ByteToStruct<LockInfo>(packet.data);
                    if(CheckUserValid(info.userName, info.password))
                    {
                        logger.Log(LogRank.INFO, "Unlock try Succeed!");
                        packet.Type = lockType.SUCCESS;
                        packet.data = new byte[60];
                        data = BlindNetUtil.StructToByte(packet);

                        socket.CryptoSend(data, PacketType.MSG);
                    }
                    else
                    {
                        logger.Log(LogRank.WARN, "Unlock try Failed!");
                        packet.Type = lockType.FAILED;
                        packet.data = new byte[60];
                        data = BlindNetUtil.StructToByte(packet);

                        socket.CryptoSend(data, PacketType.MSG);
                    }
                }
            }
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
    }
}
