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

namespace Blind_Client.BlindChatUI.RoomUI
{
    public partial class Room_Item : UserControl
    {
        private ChatRoom _Room;
        public delegate void MyFunc(ChatRoom Room);
        public MyFunc RoomClickEvent, RoomDoubleClickEvent;
        public int ID { get{ return _Room.ID; } }

        public Room_Item(ChatRoom Room)
        {
            InitializeComponent();
            lbl_Name.Cursor = Cursors.Hand;
            lbl_Info.Cursor = Cursors.Hand;
            
            _Room = Room;
        }

        public void NewMessage()
        {
            btn_NewMessage.BackColor = Color.Red;
        }
        public void OpenedMessage()
        {
            btn_NewMessage.BackColor = Color.Transparent;
        }
        private void lbl_Name_Click(object sender, EventArgs e)
        {
            if(RoomClickEvent != null)
            {
                RoomClickEvent(_Room);
            }
        }

        private void Room_Item_Load(object sender, EventArgs e)
        {
            this.lbl_Name.Text = _Room.Name;
            this.lbl_Info.Text = "#" + _Room.ID;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.lbl_Name.Width = this.Width;
            this.lbl_Info.Width = this.Width;
        }

        private void lbl_Name_DoubleClick(object sender, EventArgs e)
        {
            if (RoomDoubleClickEvent != null)
            {
                RoomDoubleClickEvent(_Room);
            }
        }
    }
}
