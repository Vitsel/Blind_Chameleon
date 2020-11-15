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
using BlindNet;

namespace Blind_Client.BlindChatUI.RoomUI
{
    public partial class Room_Item : UserControl
    {
        private ChatRoom _Room;
        public delegate void MyFunc(ChatRoom Room);
        public MyFunc RoomClickEvent, RoomDoubleClickEvent;
        public int ID { get{ return _Room.ID; } }
        public string Time { set { lbl_Time.Text = value; } }
        public string UserCount { set { lbl_userCount.Text = value; } }


        public Room_Item(ChatRoom Room)
        {
            InitializeComponent();
            lbl_Name.Cursor = Cursors.Hand;

            this.BackColor = BlindColor.Primary;
            lbl_Time.ForeColor = lbl_Name.ForeColor = BlindColor.Light;
            BlindNetUtil.SetEllipse(this, 15);
            
            _Room = Room;
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

            DateTime currentTime = DateTime.Now;
            DateTime messageTime = Convert.ToDateTime(_Room.LastMessageTime);

            TimeSpan gapTime = currentTime - messageTime;

            if(gapTime.Days < 1)
            {
                this.lbl_Time.Text = messageTime.ToString("tt hh:mm");
            }
            else if(gapTime.Days < 2)
            {
                this.lbl_Time.Text = "어제";
            }
            else
            {
                this.lbl_Time.Text = messageTime.ToString("MM:dd");
            }
            lbl_userCount.Text = BlindChat.GetUserList(_Room.ID).Count().ToString() + "    |";
        }

        private void lbl_Name_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = BlindColor.LightGreen;
        }

        private void lbl_Name_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = BlindColor.Primary;
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
