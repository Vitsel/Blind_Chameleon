using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_Client.BlindChatCode
{
    class BlindChatDB
    {
        private uint userID;
        private SQLiteConnection hDB;

        public bool Exists { get { FileInfo fileInfo = new FileInfo($"./{userID}.bc"); return fileInfo.Exists; } }


        public BlindChatDB(uint userID)
        {
            this.userID = userID;
        }
        ~BlindChatDB()
        {

        }
        public ChatTimeStamp GetAllTime()
        {
            ChatTimeStamp chatTimeStamp = new ChatTimeStamp();
            chatTimeStamp.timeUser = GetClientTime(ChatType.User);
            chatTimeStamp.timeChatRoom = GetClientTime(ChatType.Room);
            chatTimeStamp.timeChatRoomJoined = GetClientTime(ChatType.RoomJoined);
            chatTimeStamp.timeMessage = GetClientTime(ChatType.Message);

            return chatTimeStamp;
        }

        public string GetClientTime(ChatType type)
        {
            string tableName;
            if (type == ChatType.User) tableName = "User";
            else if (type == ChatType.Room) tableName = "ChatRoom";
            else if (type == ChatType.RoomJoined) tableName = "ChatRoomJoined";
            else tableName = "ChatMessage";

            string sql = $"select time from {tableName} order by time desc;";
            SQLiteDataReader rdr = ExecuteSelect(sql);

            string time;
            if (rdr.Read())
            {
                time = rdr["time"].ToString();
            }
            else
            {
                time = BlindChatConst.ZERO_TIME;
            }
            rdr.Close();
            return time;
        }
        public User GetUser(SQLiteDataReader rdr)
        {
            User user = new User();

            user.ID = uint.Parse(rdr["ID"].ToString());
            user.Online = int.Parse(rdr["Online"].ToString());
            user.Name = rdr["Name"].ToString();
            user.Time = rdr["Time"].ToString();
            user.Position = rdr["Position"].ToString();
            user.Department = rdr["Department"].ToString();
            user.Phone = rdr["Phone"].ToString();
            user.Email= rdr["Email"].ToString();
            user.Birth = rdr["Birth"].ToString();

            return user;
        }
        public ChatRoom GetRoom(SQLiteDataReader rdr)
        {
            ChatRoom room = new ChatRoom();

            room.ID = int.Parse(rdr["ID"].ToString());
            room.Name = rdr["Name"].ToString();
            room.Time = rdr["Time"].ToString();
            room.LastMessageTime = rdr["LastMessageTime"].ToString();

            return room;
        }
        public ChatRoomJoined GetRoomJoined(SQLiteDataReader rdr)
        {
            ChatRoomJoined roomJoined = new ChatRoomJoined();

            roomJoined.ID = int.Parse(rdr["ID"].ToString());
            roomJoined.UserID = uint.Parse(rdr["UserID"].ToString());
            roomJoined.RoomID = int.Parse(rdr["RoomID"].ToString());
            roomJoined.Time = rdr["Time"].ToString();

            return roomJoined;
        }
        public ChatMessage GetMessage(SQLiteDataReader rdr)
        {
            ChatMessage message = new ChatMessage();

            message.ID = int.Parse(rdr["ID"].ToString());
            message.UserID = uint.Parse(rdr["UserID"].ToString());
            message.RoomID = int.Parse(rdr["RoomID"].ToString());
            message.Message = rdr["Message"].ToString();
            message.Time = rdr["Time"].ToString();

            return message;
        }

        public SQLiteDataReader ExecuteSelect(string sql)
        {
            if (hDB != null)
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, hDB);
                return cmd.ExecuteReader();
            }
            else
                return null;
        }
        public void ExecuteNonQuery(string sql)
        {
            if(hDB != null)
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, hDB);
                cmd.ExecuteNonQuery();
            }
        }
        public void Open()
        {
            if (!Exists)
            {
                string sql;
                SQLiteConnection.CreateFile($"./{userID}.bc");
                hDB = new SQLiteConnection($"Data Source=./{userID}.bc;Version=3;");
                hDB.Open();

                sql = "CREATE TABLE \'User\'("+
                    "\'ID\'    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"+
                    "\'Name\'  TEXT NOT NULL,"+
                    "\'Time\'  TEXT NOT NULL," +
                    "\'Online\'    INTEGER NOT NULL DEFAULT 0,"+
                    "\'Position\'  TEXT NOT NULL,"+
                    "\'Department\'    TEXT NOT NULL,"+
                    "\'Phone\' TEXT NOT NULL,"+
                    "\'Email\' TEXT NOT NULL,"+
                    "\'Birth\' TEXT NOT NULL"+
                    ");";

                ExecuteNonQuery(sql);

                sql = "CREATE TABLE \'ChatRoom\' (" +
                    "\'ID\'	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "\'Name\'	TEXT NOT NULL," +
                    "\'Time\'	TEXT NOT NULL," +
                    "\'LastMessageTime\'    TEXT"+
                    ");";
                ExecuteNonQuery(sql);

                sql = "CREATE TABLE \'ChatMessage\' (" +
                    "\'ID\'	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "\'UserID\'	INTEGER NOT NULL," +
                    "\'RoomID\'	INTEGER NOT NULL," +
                    "\'Message\'TEXT NOT NULL," +
                    "\'Time\'	TEXT NOT NULL," +
                    "FOREIGN KEY(\'RoomID\') REFERENCES \'ChatRoom\'(\'ID\')," +
                    "FOREIGN KEY(\'UserID\') REFERENCES \'User\'" +
                    ");";
                ExecuteNonQuery(sql);

                sql = "CREATE TABLE \'ChatRoomJoined\' (" +
                    "\'ID\'    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "\'UserID\'    INTEGER NOT NULL," +
                    "\'RoomID\'    INTEGER NOT NULL," +
                    "\'Time\'  TEXT NOT NULL," +
                    "FOREIGN KEY(\'RoomID\') REFERENCES \'ChatRoom\'(\'ID\')," +
                    "FOREIGN KEY(\'UserID\') REFERENCES \'User\'(\'ID\')" +
                    "); ";
                ExecuteNonQuery(sql);
#if DEBUG
                MessageBox.Show("DB가 새로 생성되었습니다.");
#endif
            }
            else
            {
                hDB = new SQLiteConnection($"Data Source=./{userID}.bc;Version=3;");
                hDB.Open();
            }
        }


    }
}
