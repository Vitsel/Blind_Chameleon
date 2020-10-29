using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using BlindNet;
using System.Windows.Forms;

namespace Blind_Client.BlindChatCode
{
    public partial class BlindChat
    {
        public void LoadUserList()
        {
            userList.Clear();
            string sql = $"select * from User order by Department asc;" ;
            SQLiteDataReader rdr = DB.ExecuteSelect(sql);

            while (rdr.Read())
            {
                User user = DB.GetUser(rdr);
                userList.Add(user);
            }
        }
        public void LoadRoomList()
        {
            roomList.Clear();
            string sql = $"select * from ChatRoom;";
            SQLiteDataReader rdr = DB.ExecuteSelect(sql);

            while (rdr.Read())
            {
                ChatRoom room = DB.GetRoom(rdr);
                roomList.Add(room);
            }
        }
        public List<ChatMessage> GetMessageList(int roomID)
        {
            List<ChatMessage> messageList = new List<ChatMessage>();
            string sql = $"select * from ChatMessage where RoomID = {roomID};";
            SQLiteDataReader rdr = DB.ExecuteSelect(sql);

            while (rdr.Read())
            {
                ChatMessage message = DB.GetMessage(rdr);
                messageList.Add(message);
            }
            return messageList;
        }
        static public List<User> GetUserList(int roomID)
        {
            List<User> userList = new List<User>();
            string sql = $"select * from User where ID in (select userID from ChatRoomJoined where RoomID = {roomID})";
            SQLiteDataReader rdr = DB.ExecuteSelect(sql);

            while (rdr.Read())
            {
                User user = DB.GetUser(rdr);
                userList.Add(user);
            }
            return userList;
        }

        public void LoadList()
        {
            LoadUserList();
            LoadRoomList();
        }



        public static void InviteUser(int userID, int roomID)
        {
            ChatRoomJoined roomJoined = new ChatRoomJoined();
            roomJoined.UserID = userID;
            roomJoined.RoomID = roomID;
            
            ChatPacketSend(BlindChatUtil.StructToChatPacket(roomJoined));

            //Invitation inv = new Invitation();
            //inv.Name = roomName;
            //inv.RoomID = roomID;
            //inv.UserID = userID;

            //ChatPacketSend(BlindChatUtil.StructToChatPacket(inv));
        }
        public void CreateRoom(string text, int[] users)
        {
            //한 방에는 최대 20명
            NewRoomStruct newRoom = new NewRoomStruct();
            newRoom.Name = text;
            newRoom.UserID = users;

            ChatPacketSend(BlindChatUtil.StructToChatPacket(newRoom));
            
        }
        public void ChatMessageSend(string text, int userID, int roomID)
        {
            ChatMessage message = new ChatMessage();
            message.Message = text;
            message.UserID = userID;
            message.RoomID = roomID;

            ChatPacketSend(BlindChatUtil.StructToChatPacket(message));
        }




        public static void ChatPacketSend(ChatPacket chatPack)
        {
            if (chatPack.Data.Length > BlindChatConst.CHATDATASIZE)
            {
                Console.WriteLine("data size must be 2048 bytes!");
                return;
            }
            else
            {
                byte[] packData = BlindNetUtil.StructToByte(chatPack);
                chatSock.CryptoSend(packData, PacketType.MSG);
            }
        }
        public ChatPacket ChatPacketReceive()
        {
            byte[] data = chatSock.CryptoReceiveMsg();
            if (data == null)
            {
                chatSock.Close();
                MessageBox.Show("disconnected");
            }
            ChatPacket chatPack = BlindNetUtil.ByteToStruct<ChatPacket>(data);

            return chatPack;
        }
    }
}
