using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blind_Client.BlindChatCode;
using Blind_Client.BlindChatUI.RoomUI;

namespace Blind_Client.BlindChatUI
{
    public partial class Control_Room : UserControl
    {
        private uint _UserID; 
        private CreateRoomForm createRoomForm;
        public delegate void MyFunc(string text, int[] array);
        public MyFunc CreateRoom;
        private BlindChat _BlindChat;

        public Control_Room(uint UserID, BlindChat BlindChat)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        public void SetBlindChat(BlindChat chat)
        {
            _BlindChat = chat;
        }

        public void LoadRooms()
        {
            while (RoomItem_LayoutPanel.Controls.Count > 0)
            {
                RoomItem_LayoutPanel.Controls[0].Dispose();
            }
            RoomItem_LayoutPanel.Controls.Clear();
            List<ChatRoom> roomListOrder = BlindChat.roomList.OrderByDescending(x => x.LastMessageTime).ToList();

            foreach(ChatRoom room in roomListOrder)
            {
                AddRoom(room);
            }
        }
        public void AddRoom(ChatRoom room)
        {
            Room_Item roomItem = new Room_Item(room);
            roomItem.Anchor = AnchorStyles.Left|AnchorStyles.Right;
            roomItem.RoomDoubleClickEvent = _BlindChat.OpenMessageRoom;

            //userItem.UserClickEvent = DisplayUserInfo;

            RoomItem_LayoutPanel.Controls.Add(roomItem);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach (Room_Item item in RoomItem_LayoutPanel.Controls)
            {
                item.Width = this.Width;
            }
        }
        public void SendCreateRoom(string text, uint[] array)
        {
            _BlindChat.CreateRoom(text, array);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            createRoomForm = new CreateRoomForm(_UserID);
            createRoomForm.CreateRoom = SendCreateRoom;
            createRoomForm.ShowDialog();
        }
    }
}
