using Blind_Client.BlindChatUI.RoomUI;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
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
            string sql = $"INSERT INTO ChatRoom (ID, Name, Time) VALUES ({room.ID},\'{room.Name}\',\'{room.Time}\')";
            DB.ExecuteNonQuery(sql);
            roomList.Add(room);

            if (Start)
            {
                ExecuteWithInvoke(form, delegate
                {
                    UI._RoomControl.AddRoom(room);
                    UI._RoomControl.LoadRooms();
                });
            }
        }
        public void AddMember(ChatRoomJoined roomJoined)
        {
            string sql = $"insert into ChatRoomJoined (ID, roomID, userID, time) values ({roomJoined.ID}, {roomJoined.RoomID}, {roomJoined.UserID}, \'{roomJoined.Time}\');";
            DB.ExecuteNonQuery(sql);

            //UI.AddMember(roomJoined);
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
                UI._RoomControl.LoadRooms();
            });



            MessageRoom form = GetFormWithName(message.RoomID.ToString()) as MessageRoom;
            if(form != null)
            {
                ExecuteWithInvoke(form, delegate
                {
                    form.AddMessage(message);
                });
            }
        }

        public void OpenMessageRoom(ChatRoom room)
        {
            Form openForm = GetFormWithName(room.ID.ToString());
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
                    Application.Run(messageRoom);
                });
                tMessageRoom.Start();
            }
        }
        public Form GetFormWithName(string formName)
        {
            foreach(Form openForm in Application.OpenForms)
            {
                if (openForm.Name == formName)
                    return openForm;
            }
            return null;
        }
    }
}
