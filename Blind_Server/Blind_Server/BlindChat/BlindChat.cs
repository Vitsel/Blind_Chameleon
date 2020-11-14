using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlindNet;
using Org.BouncyCastle.Crypto.Signers;
using MySql.Data.MySqlClient;
using BlindLogger;
using System.Windows.Forms;
using System.Net;

namespace Blind_Server
{
    public static class global
    {
        public static List<BlindChat> ListBlindChat = new List<BlindChat>();
    }
    public partial class BlindChat
    {
        private BlindSocket recvSock, sendSock;
        private uint UserID;
        private Logger logger;

        MySqlConnection hDB;
        //private Queue<ChatPacket> ChatMessageQueue;

        public void SetOnline(int online)
        {
            string sql = $"update User set isOnline = {online} where ID={UserID};";
            ExecuteQuery(sql);
        }

        public void Run()
        {
            this.hDB = new MySqlConnection("Server=" + BlindNetConst.DatabaseIP + ";Database=BlindChat;Uid=root;Pwd=kit2020;");
            this.hDB.Open();

            recvSock = GetChatRecvSocket();
            sendSock = GetChatSendSocket();

            IPEndPoint iep = (IPEndPoint)(recvSock.socket.RemoteEndPoint);
            logger = new Logger(UserID, iep.Address.ToString(), LogService.Chat);


            SetOnline((int)UserStat.Online);
            while (true)
            {
                byte[] data = recvSock.CryptoReceiveMsg();
                if (data == null)
                {
                    recvSock.Close();
                    sendSock.Close();
                    SetOnline((int)UserStat.Offline);
                    global.ListBlindChat.Remove(this);
                    logger.Log(LogRank.INFO, "BlindChat Disconnected");
                    return;
                }

                ChatPacket chatPacket = BlindNetUtil.ByteToStruct<ChatPacket>(data);
                if(chatPacket.Type == ChatType.Time)
                {
                    ClientUpdateData(chatPacket);
                    logger.Log(LogRank.INFO, "Chat Data Synchronized");
                }
                else if(chatPacket.Type == ChatType.NewRoom)
                {
                    ExecuteNewRoom(chatPacket);
                    logger.Log(LogRank.INFO, "Created New Chat Room");
                }
                else if(chatPacket.Type == ChatType.Message)
                {
                    MessageToParticipants(chatPacket);
                }
                else if(chatPacket.Type == ChatType.RoomJoined)
                {
                    ExecuteInvitation(chatPacket);
                }
                else if(chatPacket.Type == ChatType.Exit)
                {
                    ExecuteExit(chatPacket);
                }

            }
        }




        public BlindChat(uint cid)
        {
            global.ListBlindChat.Add(this);
            UserID = cid;
        }
        public BlindChat(MySqlConnection hDB, uint cid)
        {
            global.ListBlindChat.Add(this);
            this.hDB = hDB;
        }
        ~BlindChat()
        {
        }

    }
}
