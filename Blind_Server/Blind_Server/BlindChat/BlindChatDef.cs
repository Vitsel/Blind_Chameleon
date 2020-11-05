using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlindNet;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System.Reflection;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Crmf;
using MySql.Data.MySqlClient;
using System.Data;
using Org.BouncyCastle.Tsp;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace Blind_Server
{
    public partial class BlindChat
    {
        public MySqlDataReader ExecuteSelect(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, hDB);
            return cmd.ExecuteReader();
        }
        public void ExecuteQuery(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, hDB);
            cmd.ExecuteNonQuery();
        }

        public void SetClientUserID(ChatPacket chatPack)
        {
            User user = BlindChatUtil.ChatPacketToStruct<User>(chatPack);
            this.UserID = user.ID;
            SetOnline((int)UserStat.Online);

            
            ChatPacketSend(chatPack);
        }


        public void ExecuteExit(ChatPacket chatPack)
        {
            string timeNow = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            ChatRoomJoined roomJoined = BlindChatUtil.ChatPacketToStruct<ChatRoomJoined>(chatPack);

            SendChatPacketToParticipants(chatPack, roomJoined.RoomID);

            string sql = $"delete from ChatRoomJoined where UserID = {roomJoined.UserID} and RoomID = {roomJoined.RoomID};";
            ExecuteQuery(sql);

            ChatMessage message = new ChatMessage();
            message.RoomID = roomJoined.RoomID;
            message.UserID = 0;
            message.Time = timeNow;

            sql = $"select * from User where ID = {roomJoined.UserID}";

            ChatMessage _message = new ChatMessage();
            message.RoomID = roomJoined.RoomID;
            message.UserID = 0;
            message.Time = timeNow;

            sql = $"select * from User where ID = {roomJoined.UserID}";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, hDB);
            DataSet ds = new DataSet();
            adpt.Fill(ds); 
            DataRow r = ds.Tables[0].Rows[0];

            User userInfo = (User)GetStructFromDB<User>(r);
            message.Message = $"{userInfo.Name}님이 나갔습니다.";

            byte[] _data = BlindNetUtil.StructToByte(message);
            ChatPacket _packet = BlindChatUtil.ByteToChatPacket(_data, ChatType.Message);
            SendChatPacketToParticipants(_packet, message.RoomID);

            //시간을 수정한 메시지를 DB에 등록
            AddToDBTimeNow<ChatMessage>(_packet);
        }

        public void ExecuteInvitation(ChatPacket chatPack)
        {
            ChatRoomJoined roomJoined = BlindChatUtil.ChatPacketToStruct<ChatRoomJoined>(chatPack);

            string timeNow = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string sql = $"insert into ChatRoomJoined (UserID, RoomID, Time) values ({roomJoined.UserID},{roomJoined.RoomID},\'{timeNow}\');";
            ExecuteQuery(sql);

            sql = $"select * from ChatRoomJoined where Time = \'{timeNow}\' and UserID={ roomJoined.UserID }";
            MySqlDataReader rdr = ExecuteSelect(sql);
            
            if (rdr.Read())
            {
                roomJoined = (ChatRoomJoined)GetStructFromDB<ChatRoomJoined>(rdr);
                rdr.Close();
                byte[] data = BlindNetUtil.StructToByte(roomJoined);

                ChatPacket packet = BlindChatUtil.ByteToChatPacket(data, ChatType.RoomJoined);
                SendChatPacketToParticipants(packet, roomJoined.RoomID);

                ChatMessage message = new ChatMessage();
                message.RoomID = roomJoined.RoomID;
                message.UserID = 0;
                message.Time = timeNow;

                sql = $"select * from User where ID = {roomJoined.UserID}";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, hDB);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                DataRow r = ds.Tables[0].Rows[0];
                User userInfo = (User)GetStructFromDB<User>(r);

                message.Message = $"{userInfo.Name}님이 접속하셨습니다.";
                byte[] _data = BlindNetUtil.StructToByte(message);
                ChatPacket _packet = BlindChatUtil.ByteToChatPacket(_data, ChatType.Message);
                SendChatPacketToParticipants(_packet, message.RoomID);

                //시간을 수정한 메시지를 DB에 등록
                AddToDBTimeNow<ChatMessage>(_packet);
            }
            
        }

        public void MessageToParticipants(ChatPacket chatPack)
        {
            //메시지의 시간을 수정한다.
            string timeNow = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            ChatMessage message = BlindChatUtil.ChatPacketToStruct<ChatMessage>(chatPack);
            message.Time = timeNow;

            byte[] data = BlindNetUtil.StructToByte(message);
            ChatPacket pack = BlindChatUtil.ByteToChatPacket(data, ChatType.Message);

            //시간을 수정한 메시지를 DB에 등록
            AddToDBTimeNow<ChatMessage>(pack);

            //방데이터에 최신 메시지 시간 수정
            string sql = $"update ChatRoom set LastMessageTime = \'{message.Time}\' where ID = {message.RoomID}";
            ExecuteQuery(sql);

            //방에 속한 사용자들에게 메시지 전송
            SendChatPacketToParticipants(pack, message.RoomID);
        }


        public void AddToDBTimeNow<T>(ChatPacket chatPack)
        {
            string sql;
            string Time = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            if (typeof(T) == typeof(User))
            {
                User user = BlindChatUtil.ChatPacketToStruct<User>(chatPack);
                sql = $"insert into User (ID, Name, Time, isOnline) values ({user.ID}, {user.Name}, \'{Time}\', {user.Online});";
            }
            else if(typeof(T) == typeof(ChatRoom))
            {
                ChatRoom room = new ChatRoom();
                sql = $"insert into ChatRoom (ID, Name, Time) values ({room.ID},\'{room.Name}\',\'{Time}\');";
            }
            else if(typeof(T) == typeof(ChatRoomJoined))
            {
                ChatRoomJoined roomjoined = new ChatRoomJoined();
                sql = $"insert into ChatRoomJoined (ID, UserID, RoomID, Time) values ({roomjoined.ID},{roomjoined.UserID},{roomjoined.RoomID},\'{Time}\');";
            }
            else if (typeof(T) == typeof(ChatMessage))
            {
                ChatMessage msg = BlindChatUtil.ChatPacketToStruct<ChatMessage>(chatPack);
                sql = $"insert into ChatMessage (UserID, RoomID, Message, Time) values ({msg.UserID},{msg.RoomID},\'{msg.Message}\',\'{msg.Time}\');";
            }
            else return;

            ExecuteQuery(sql);
        }






        public void SendChatPacketToParticipants(ChatPacket chatPack, int RoomID)
        {
            string sql = $"select ID from User where ID in" +
                       $"(select UserID from ChatRoomJoined where RoomID = {RoomID})" +
                       $"and isOnline = true;";
            MySqlDataReader rdr = ExecuteSelect(sql);
            
            while (rdr.Read())
            {
                int userID_DB = int.Parse(rdr["ID"].ToString());
                foreach (BlindChat chat in global.ListBlindChat)
                {
                    if (chat.UserID == userID_DB)
                    {
                        chat.ChatPacketSend(chatPack);
                        chat.SendReset();
                        
                    }
                }
            }
            rdr.Close();
        }













        public void ExecuteNewRoom(ChatPacket chatPack)
        {
            string timeNow = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            NewRoomStruct newroom = BlindChatUtil.ChatPacketToStruct<NewRoomStruct>(chatPack);
            
            //DB에 방 정보 추가
            string sql = $"insert into ChatRoom (Name, Time, LastMessageTime) values (\'{newroom.Name}\',\'{timeNow}\', \'{timeNow}\');";
            ExecuteQuery(sql);

            //방금 생성한 방 정보 불러오기(roomid를 알아오기 위해)
            sql = $"select * from ChatRoom where Time = \'{timeNow}\';";
            MySqlDataReader rdr = ExecuteSelect(sql);

            if (rdr.Read())
            {
                int RoomID = int.Parse(rdr["ID"].ToString());
                rdr.Close();
                //방에 속한 사용자를 등록한다.
                for(int i =0; newroom.UserID[i] != 0; i++)
                {
                    sql = $"insert into ChatRoomJoined (UserID, RoomID, Time) values ({newroom.UserID[i]}, {RoomID}, \'{timeNow}\');";
                    ExecuteQuery(sql); 
                    
                    ChatMessage message = new ChatMessage();
                    message.RoomID = RoomID;
                    message.UserID = 0;
                    message.Time = timeNow;

                    sql = $"select * from User where ID = {newroom.UserID[i]}";
                    MySqlDataAdapter adpt = new MySqlDataAdapter(sql, hDB);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        User userInfo = (User)GetStructFromDB<User>(row);
                        message.Message = $"{userInfo.Name}님이 접속하셨습니다.";
                    }
                    byte[] _data = BlindNetUtil.StructToByte(message);
                    ChatPacket _packet = BlindChatUtil.ByteToChatPacket(_data, ChatType.Message);
                    SendChatPacketToParticipants(_packet, message.RoomID);

                    //시간을 수정한 메시지를 DB에 등록
                    AddToDBTimeNow<ChatMessage>(_packet);
                }

                //방에 속한 사용자들에게 전송
                ClientUpdateNewRoom(RoomID);
            }
        }

        public void ClientUpdateNewRoom(int RoomID)
        {
            ClientRoomsWithRoomID<ChatRoom>(RoomID);
            ClientRoomsWithRoomID<ChatRoomJoined>(RoomID);
            SendReset();
        }
        public void ClientRoomsWithRoomID<T>(int RoomID)
        {
            string sql;
            ChatType Type;
            if (typeof(T) == typeof(ChatRoom)) {
                sql = $"select * from ChatRoom where ID = {RoomID};";
                Type = ChatType.Room;
            }
            else if (typeof(T) == typeof(ChatRoomJoined)) {
                sql = $"select * from ChatRoomJoined where RoomID ={RoomID}";
                Type = ChatType.RoomJoined;
            }
            else return;

            //MySqlDataReader rdr = ExecuteSelect(sql);

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, hDB);
            DataSet ds = new DataSet();
            adpt.Fill(ds);

            foreach(DataRow row in ds.Tables[0].Rows)
            {
                T st = (T)GetStructFromDB<T>(row);

                byte[] data = BlindNetUtil.StructToByte(st);

                ChatPacket chatPacket = BlindChatUtil.ByteToChatPacket(data, Type);
                SendChatPacketToParticipants(chatPacket, RoomID);
            }

            //각 정보들을 방에 속한 사용자들에게 전송
            //while (rdr.Read())
            //{
            //    T st = (T)GetStructFromDB<T>(rdr);

            //    byte[] data = BlindNetUtil.StructToByte(st);

            //    ChatPacket chatPacket = BlindChatUtil.ByteToChatPacket(data, Type);
            //    SendChatPacketToParticipants(chatPacket, RoomID);
            //}
            //rdr.Close();
        }







        public void ChatPacketSend(ChatPacket chatPacket)
        {
            if (chatPacket.Data.Length > BlindChatConst.CHATDATASIZE)
            {
                Console.WriteLine("data size must be 2048 bytes!");
                return;
            }
            else
            {
                byte[] packData = BlindNetUtil.StructToByte(chatPacket);
                chatSock.CryptoSend(packData, PacketType.MSG);
            }
        }













        public void SendReset()
        {
            byte[] data = new byte[BlindChatConst.CHATDATASIZE];
            ChatPacket chatPacket = BlindChatUtil.ByteToChatPacket(data, ChatType.Reset);
            ChatPacketSend(chatPacket);
        }
        public void ClientUpdateData(ChatPacket chatPack)
        {
            ChatTimeStamp syncTime = BlindChatUtil.ChatPacketToStruct<ChatTimeStamp>(chatPack);

            ClientUpdateUser(syncTime.timeUser);
            ClientUpdateChatRoom(syncTime.timeChatRoom);
            ClientUpdateChatRoomJoined(syncTime.timeChatRoomJoined);
            ClientUpdateMessage(syncTime.timeMessage);

            SendReset();
        }
        public object GetStructFromDB<T>(DataRow row)
        {
            
            object st;
            try
            {
                if (typeof(T) == typeof(User))
                {
                    User user = new User();
                    user.ID = int.Parse(row["ID"].ToString());
                    user.Online = int.Parse(row["isOnline"].ToString());
                    user.Name = row["Name"].ToString();
                    user.Time = row["Time"].ToString();
                    user.Position = row["Position"].ToString();
                    user.Department = row["Department"].ToString();
                    user.Phone = row["Phone"].ToString();
                    user.Email = row["Email"].ToString();
                    user.Birth = row["Birth"].ToString();
                    user.Online = 0;

                    st = user;
                }
                else if (typeof(T) == typeof(ChatRoom))
                {
                    ChatRoom room = new ChatRoom();
                    room.ID = int.Parse(row["ID"].ToString());
                    room.Name = row["Name"].ToString();
                    room.Time = row["Time"].ToString();
                    room.LastMessageTime = row["LastMessageTime"].ToString();

                    st = room;
                }
                else if (typeof(T) == typeof(ChatRoomJoined))
                {
                    ChatRoomJoined roomjoined = new ChatRoomJoined();
                    roomjoined.ID = int.Parse(row["ID"].ToString());
                    roomjoined.UserID = int.Parse(row["UserID"].ToString());
                    roomjoined.RoomID = int.Parse(row["RoomID"].ToString());
                    roomjoined.Time = row["Time"].ToString();

                    st = roomjoined;
                }
                else if (typeof(T) == typeof(ChatMessage))
                {
                    ChatMessage message = new ChatMessage();
                    message.UserID = int.Parse(row["UserID"].ToString());
                    message.RoomID = int.Parse(row["RoomID"].ToString());
                    message.Time = row["Time"].ToString();
                    message.Message = row["Message"].ToString();
                    message.ID = int.Parse(row["ID"].ToString());

                    st = message;
                }
                else
                {
                    return null;
                }
                return st;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public object GetStructFromDB<T>(MySqlDataReader rdr)
        {
            object st;
            try
            {
                if (typeof(T) == typeof(User))
                {
                    User user = new User();
                    user.ID = int.Parse(rdr["ID"].ToString());
                    user.Online = int.Parse(rdr["isOnline"].ToString());
                    user.Name = rdr["Name"].ToString();
                    user.Time = rdr["Time"].ToString();
                    user.Position = rdr["Position"].ToString();
                    user.Department = rdr["Department"].ToString();
                    user.Phone = rdr["Phone"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Birth = rdr["Birth"].ToString();
                    user.Online = 0;

                    st = user;
                }
                else if (typeof(T) == typeof(ChatRoom))
                {
                    ChatRoom room = new ChatRoom();
                    room.ID = int.Parse(rdr["ID"].ToString());
                    room.Name = rdr["Name"].ToString();
                    room.Time = rdr["Time"].ToString();
                    room.LastMessageTime = rdr["LastMessageTime"].ToString();

                    st = room;
                }
                else if (typeof(T) == typeof(ChatRoomJoined))
                {
                    ChatRoomJoined roomjoined = new ChatRoomJoined();
                    roomjoined.ID = int.Parse(rdr["ID"].ToString());
                    roomjoined.UserID = int.Parse(rdr["UserID"].ToString());
                    roomjoined.RoomID = int.Parse(rdr["RoomID"].ToString());
                    roomjoined.Time = rdr["Time"].ToString();

                    st = roomjoined;
                }
                else if (typeof(T) == typeof(ChatMessage))
                {
                    ChatMessage message = new ChatMessage();
                    message.UserID = int.Parse(rdr["UserID"].ToString());
                    message.RoomID = int.Parse(rdr["RoomID"].ToString());
                    message.Time = rdr["Time"].ToString();
                    message.Message = rdr["Message"].ToString();
                    message.ID = int.Parse(rdr["ID"].ToString());

                    st = message;
                }
                else
                {
                    return null;
                }
                return st;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void ClientUpdateUser(string Time)//새로 추가된 사용자가 있을 경우 전송
        {
            string sql = $"select * from User where time > \'{Time}\' order by time asc";
            MySqlDataReader rdr = ExecuteSelect(sql);

            while (rdr.Read())
            {
                User user = (User)GetStructFromDB<User>(rdr);

                byte[] data = BlindNetUtil.StructToByte(user);

                ChatPacket chatPacket = BlindChatUtil.ByteToChatPacket(data, ChatType.User);
                ChatPacketSend(chatPacket);
            }
            rdr.Close();
        }
        public void ClientUpdateChatRoom(string Time)
        {
            string sql =
                $"select * from ChatRoom " +
                $"where ID in " +
                $"(select RoomID from ChatRoomJoined where UserID={this.UserID}) " +
                $"and Time > \'{Time}\' order by Time asc";
            MySqlDataReader rdr = ExecuteSelect(sql);

            while (rdr.Read())
            {
                ChatRoom room = (ChatRoom)GetStructFromDB<ChatRoom>(rdr);

                byte[] data = BlindNetUtil.StructToByte(room);

                ChatPacket chatPacket = BlindChatUtil.ByteToChatPacket(data, ChatType.Room);
                ChatPacketSend(chatPacket);
            }
            rdr.Close();
        }

        public void ClientUpdateChatRoomJoined(string Time)
        {
            string sql =
                $"select * from ChatRoomJoined " +
                $"where RoomID in " +
                $"(select roomID from ChatRoomJoined where UserID={UserID}) " +
                $"and Time > \'{Time}\' order by Time asc";
            MySqlDataReader rdr = ExecuteSelect(sql);

            while (rdr.Read())
            {
                ChatRoomJoined chatRoomJoined = (ChatRoomJoined)GetStructFromDB<ChatRoomJoined>(rdr);

                byte[] data = BlindNetUtil.StructToByte(chatRoomJoined);

                ChatPacket chatPacket = BlindChatUtil.ByteToChatPacket(data, ChatType.RoomJoined);
                ChatPacketSend(chatPacket);
            }
            rdr.Close();
        }
        
        public void ClientUpdateMessage(string Time)
        {
            string sql =
                $"select * from ChatMessage " +
                $"where RoomID in (select roomID from ChatRoomJoined where userID = {UserID}) " +
                $"and Time > \'{Time}\' order by Time asc";

            MySqlDataReader rdr = ExecuteSelect(sql);

            while (rdr.Read())
            {
                ChatMessage message = (ChatMessage)GetStructFromDB<ChatMessage>(rdr);

                byte[] data = BlindNetUtil.StructToByte(message);

                ChatPacket chatPacket = BlindChatUtil.ByteToChatPacket(data, ChatType.Message);
                ChatPacketSend(chatPacket);
            }
            rdr.Close();
        }





        BlindSocket GetChatPortSocket()
        {
            BlindSocket socket;
            socket = _Main.chatPortSock.AcceptWithECDH();

            return socket;
        }
    }
    


    static class BlindChatUtil
    {
        public static T ChatPacketToStruct<T>(ChatPacket chatPack) where T : struct
        {
            byte[] chatPackByte = new byte[Marshal.SizeOf(typeof(T))];
            Array.Copy(chatPack.Data, chatPackByte, chatPackByte.Length);

            T data = BlindNetUtil.ByteToStruct<T>(chatPackByte);
            return data;
        }
        public static ChatPacket ByteToChatPacket(byte[] data, ChatType type)
        {
            ChatPacket chatPack = new ChatPacket();
            if (data.Length > BlindChatConst.CHATDATASIZE)
            {
                //MessageBox.Show("Data Size Must be smaller than 2048 bytes");
                chatPack.Data = null;
                return chatPack;
            }
            else
            {
                byte[] packData = new byte[BlindChatConst.CHATDATASIZE];
                Array.Copy(data, packData, data.Length);
                chatPack.Type = type;
                chatPack.Data = packData;
            }
            return chatPack;
        }
    }


    public static class BlindChatConst
    {
        public const int CHATDATASIZE = 2048;
        public const int MESSAGESIZE = 512;
        public const int SMALLSIZE = 32;
        public const string ZERO_TIME = "0000-00-00 00:00:00";
    }
    public enum ChatType
    {
        Time = 1,

        User = 2,
        Room = 3,
        Message = 4,
        RoomJoined = 5,

        Reset = 6,

        //chat functions.. ex) quit chat, create chat
        NewRoom = 7,
        Invitation = 8,
        Exit = 9
    }

    public enum UserStat
    {
        Offline = 0,
        Online = 1
    }

    //채팅 패킷 구조체
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChatPacket
    {
        public ChatType Type;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = BlindChatConst.CHATDATASIZE)]
        public byte[] Data;
    }//2048 byte packet



    //db 테이블 구조체
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct User
    {
        public int ID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Time;

        public int Online;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Position;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Department;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Phone;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Email;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Birth;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChatRoom
    {
        public int ID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Time;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string LastMessageTime;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChatRoomJoined
    {
        public int ID;
        public int RoomID;
        public int UserID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Time;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChatMessage
    {
        public int ID;
        public int UserID;
        public int RoomID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.MESSAGESIZE)]
        public string Message;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Time;
    }



    //기능 구조체
    //시간 동기화 구조체
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChatTimeStamp
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string timeUser;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string timeChatRoom;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string timeChatRoomJoined;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string timeMessage;
    }
    //방 생성 정보 구조체
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NewRoomStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public int[] UserID;
    }

    //방 초대 구조체
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Invitation
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Name;

        //초대한 사람의 id
        public int UserID;
        public int RoomID;
    }
    static class ChatSize
    {
        public static int User = Marshal.SizeOf(typeof(User));
        public static int ChatRoom = Marshal.SizeOf(typeof(ChatRoom));
        public static int ChatRoomJoined = Marshal.SizeOf(typeof(ChatRoomJoined));
        public static int ChatMessage = Marshal.SizeOf(typeof(ChatMessage));
        public static int Time = Marshal.SizeOf(typeof(ChatTimeStamp));
        public static int NewRoom = Marshal.SizeOf(typeof(NewRoomStruct));
        public static int Invitation = Marshal.SizeOf(typeof(Invitation));
    }
}
