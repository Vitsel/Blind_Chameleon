﻿using System;
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

        public Room_Item(ChatRoom Room)
        {
            InitializeComponent();
            lbl_Name.Cursor = Cursors.Hand;
            lbl_Info.Cursor = Cursors.Hand;

            this.BackColor = BlindColor.Light;
            BlindNetUtil.SetEllipse(this, 10);
            
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
            this.lbl_Time.Text = _Room.LastMessageTime;
        }

        private void lbl_Name_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = BlindColor.Gray;
        }

        private void lbl_Name_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = BlindColor.Light;
        }

        private void lbl_Name_DoubleClick(object sender, EventArgs e)
        {
            if (RoomDoubleClickEvent != null)
            {
                OpenedMessage();
                RoomDoubleClickEvent(_Room);
            }
        }
    }
}
