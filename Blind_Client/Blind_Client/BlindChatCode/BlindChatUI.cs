using Blind_Client.BlindChatUI;
using Blind_Client.BlindChatUI.RoomUI;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_Client.BlindChatCode
{
    public partial class BlindChat
    {

        public delegate void VoidFunction();
        public void ExecuteWithInvoke(Form form, VoidFunction function)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(new MethodInvoker(function));
            }
            else
            {
                function();
            }
        }

        //넘겨받은 UI 수정 함수를 사용해 값들을 추가해준다.
        public void LoadUI()
        {
            ExecuteWithInvoke(form, delegate
            {
                UI._UserControl.LoadUsers();
                UI._RoomControl.LoadRooms();
            });
            //LoadRoomJoined();
        }


        public void LoadRoomJoined()
        {

        }
        public void LoadMessage()
        {

        }

        public void AddUser(User user)
        {
            string sql = $"INSERT INTO User (ID, Name, Time, Position, Department, Phone, Email, Birth) VALUES ({user.ID}, \'{user.Name}\', \'{user.Time}\',\'{user.Position}\',\'{user.Department}\',\'{user.Phone}\',\'{user.Email}\',\'{user.Birth}\');";
            DB.ExecuteNonQuery(sql);
            userList.Add(user);

            if (Start)
            {
                ExecuteWithInvoke(form, delegate
                {
                    UI._UserControl.AddUser(user);
                });
            }
        }
        public void AddRoom(ChatRoom room)
        {
            string sql = $"INSERT INTO ChatRoom (ID, Name, Time, LastMessageTime) VALUES ({room.ID},\'{room.Name}\',\'{room.Time}\', \'{room.LastMessageTime}\')";
            DB.ExecuteNonQuery(sql);
            roomList.Add(room);

            if (Start)
            {
                ExecuteWithInvoke(form, delegate
                {
                    UI._RoomControl.AddRoom(room);
                    //수정
                    //UI._RoomControl.LoadRooms();                

                    UI._RoomControl.Invalidate();
                });
            }
        }
        public void AddMember(ChatRoomJoined roomJoined)
        {
            string sql = $"insert into ChatRoomJoined (ID, roomID, userID, time) values ({roomJoined.ID}, {roomJoined.RoomID}, {roomJoined.UserID}, \'{roomJoined.Time}\');";
            DB.ExecuteNonQuery(sql);


            ExecuteWithInvoke(form, delegate
            {
                //수정
                //UI._RoomControl.LoadRooms();
                foreach (Room_Item item in UI._RoomControl.RoomItem_LayoutPanel.Controls)
                {
                    if (item.ID == roomJoined.RoomID)
                    {
                        item.UserCount = BlindChat.GetUserList(roomJoined.RoomID).Count().ToString()+"    |";
                        UI._RoomControl.RoomItem_LayoutPanel.Controls.SetChildIndex((Control)item, 0);
                        UI._RoomControl.RoomItem_LayoutPanel.Invalidate();
                    }
                }


            });


        }
        public void AddMessage(ChatMessage message)
        {
            string sql = $"insert into ChatMessage (message, userID, roomID, time) values (\'{message.Message}\', {message.UserID}, {message.RoomID}, \'{message.Time}\');";
            DB.ExecuteNonQuery(sql);

            sql = $"update ChatRoom set LastMessageTime = \'{message.Time}\' where ID={message.RoomID}";
            DB.ExecuteNonQuery(sql);

            foreach (ChatRoom a in BlindChat.roomList)
            {
                if (a.ID == message.RoomID)
                {
                    ChatRoom tmpRoom = a;
                    tmpRoom.LastMessageTime = message.Time;
                    BlindChat.roomList[roomList.IndexOf(a)] = tmpRoom;
                    break;
                }
            }
            ExecuteWithInvoke(this.form, delegate
            {
                //UI._RoomControl.LoadRooms();

                foreach (Room_Item item in UI._RoomControl.RoomItem_LayoutPanel.Controls)
                {
                    if (item.ID == message.RoomID)
                    {
                        DateTime time = DateTime.Parse(message.Time);

                        item.Time = time.ToString("tt hh:mm");

                        UI._RoomControl.RoomItem_LayoutPanel.Controls.SetChildIndex((Control)item, 0);
                        UI._RoomControl.RoomItem_LayoutPanel.Invalidate();
                    }
                }

            });



            MessageRoom form = BlindChatUtil.GetFormWithName(message.RoomID.ToString()) as MessageRoom;
            if(form != null)
            {
                ExecuteWithInvoke(form, delegate
                {
                    form.AddMessage(message);
                });
            }
        }
        public void ExecuteExit(ChatPacket packet)
        {
            ChatRoomJoined roomJoined = BlindChatUtil.ChatPacketToStruct<ChatRoomJoined>(packet);
            if(roomJoined.UserID == _UserID)
            {
                string sql = $"delete from ChatRoomJoined where RoomID = {roomJoined.RoomID};";
                DB.ExecuteNonQuery(sql);
                sql = $"delete from ChatRoom where ID = {roomJoined.RoomID};";
                DB.ExecuteNonQuery(sql);

                roomList.RemoveAt(roomList.FindIndex(x => x.ID == roomJoined.RoomID));


            }
            else
            {
                string sql = $"delete from ChatRoomJoined where UserID = {roomJoined.UserID} and RoomID = {roomJoined.RoomID}";
                DB.ExecuteNonQuery(sql);

                //ChatMessage message = new ChatMessage();
                //message.RoomID = roomJoined.RoomID;
                //message.UserID = 0;
                //message.Time = roomJoined.Time;

                //User user = BlindChat.userList.Find(x => x.ID == roomJoined.UserID);
                //message.Message = $"{user.Name}님이 나갔습니다.";

                //AddMessage(message);
            }


            ExecuteWithInvoke(form, delegate
            {
                UI._RoomControl.LoadRooms();
            }); 
        }

        public void OpenMessageRoom(ChatRoom room)
        {
            Form openForm = BlindChatUtil.GetFormWithName(room.ID.ToString());
            if(openForm != null)
            {
                ExecuteWithInvoke(openForm, delegate
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Location = new Point(openForm.Location.X + openForm.Width, openForm.Location.Y);
                    }
                    openForm.Activate();
                });
            }
            else
            {
                Task tMessageRoom = new Task(() =>
                {
                    MessageRoom messageRoom = new MessageRoom(_UserID,room, GetMessageList(room.ID));
                    messageRoom.SendChatMessage = ChatMessageSend;
                    messageRoom.Location = new Point(form.Location.X + form.Width, form.Location.Y);
                    Application.Run(messageRoom);
                });
                tMessageRoom.Start();
            }
        }
        public void OpenMessageMenu()
        {

        }

    }
}