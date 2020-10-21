using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlindNet;
using Org.BouncyCastle.Crypto.Signers;
using MySql.Data.MySqlClient;

namespace Blind_Server
{
    public static class global
    {
        public static List<BlindChat> ListBlindChat = new List<BlindChat>();
    }
    public partial class BlindChat
    {
        private BlindSocket chatSock;
        private int UserID;

        MySqlConnection hDB;
        //private Queue<ChatPacket> ChatMessageQueue;

        public void SetOnline(int online)
        {
            string sql = $"update User set isOnline = {online} where ID={UserID};";
            ExecuteQuery(sql);
        }

        public void Run()
        {
            this.hDB = new MySqlConnection("Server=localhost;Database=BlindChat;Uid=root;Pwd=sungsu430;");
            this.hDB.Open();

            chatSock = GetChatPortSocket();

            while (true)
            {
                byte[] data = chatSock.CryptoReceiveMsg();
                if (data == null)
                {
                    chatSock.Close();
                    SetOnline((int)UserStat.Offline);
                    global.ListBlindChat.Remove(this);
                    Console.WriteLine("disconnected");
                    return;
                }

                ChatPacket chatPacket = BlindNetUtil.ByteToStruct<ChatPacket>(data);
                if(chatPacket.Type == ChatType.User)
                {
                    //클라이언트에서 서버에 user구조체를 보내는것은 자신의 userID를 등록할 때 뿐
                    SetClientUserID(chatPacket);
                }
                else if(chatPacket.Type == ChatType.Time)
                {
                    ClientUpdateData(chatPacket);
                }
                else if(chatPacket.Type == ChatType.NewRoom)
                {
                    ExecuteNewRoom(chatPacket);
                }
                else if(chatPacket.Type == ChatType.Message)
                {
                    MessageToParticipants(chatPacket);
                }
                else if(chatPacket.Type == ChatType.RoomJoined)
                {
                    ExecuteInvitation(chatPacket);
                }

            }
        }




        public BlindChat()
        {
            global.ListBlindChat.Add(this);
        }
        public BlindChat(MySqlConnection hDB)
        {
            global.ListBlindChat.Add(this);
            this.hDB = hDB;
        }
        ~BlindChat()
        {
        }

    }
}
