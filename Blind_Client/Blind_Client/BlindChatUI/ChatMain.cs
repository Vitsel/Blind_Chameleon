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
using System.Diagnostics;

namespace Blind_Client.BlindChatUI
{
    public partial class ChatMain : UserControl
    {
        public enum MainChatControl { User, Room, More }

        private int _UserID;
        private BlindChat _BlindChat;

        public Control_User _UserControl;
        public Control_Room _RoomControl;
        private Control_More _MoreControl;

        public int UserID { get { return _UserID; } set { _UserID = value; } }
        public BlindChat BlindChat { set { _BlindChat = value; } }
        //public Control_User UserControl { get{ return _UserControl; } }
        //public Control_Room RoomControl { get { return _RoomControl; } }

        public ChatMain(int UserID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.UserID = UserID;

            _UserControl = new Control_User(UserID);
            _UserControl.Dock = DockStyle.Fill;
            
            _RoomControl = new Control_Room(UserID, _BlindChat);
            _RoomControl.Dock = DockStyle.Fill;

            _MoreControl = new Control_More(UserID);
            _MoreControl.Dock = DockStyle.Fill;

            Function_LayoutPanel.Controls.Add(_UserControl);
            Function_LayoutPanel.Controls.Add(_RoomControl);
            Function_LayoutPanel.Controls.Add(_MoreControl);
        }

        public void ActivateControl(MainChatControl controlType)
        {
            switch (controlType)
            {
                case MainChatControl.User:
                    _UserControl.BringToFront();
                    //SetControl(_UserControl);
                    break;
                case MainChatControl.Room:
                    _RoomControl.BringToFront();
                    //SetControl(_RoomControl);
                    break;
                case MainChatControl.More:
                    //SetControl(_MoreControl);
                    break;
            }
        }

        private void ChatMain_Load(object sender, EventArgs e)
        {

        }

        private void btn_Member_Click(object sender, EventArgs e)
        {
            ActivateControl(MainChatControl.User);
        }

        private void btn_Chat_Click(object sender, EventArgs e)
        {
            ActivateControl(MainChatControl.Room);
        }

        private void btn_More_Click(object sender, EventArgs e)
        {
            ActivateControl(MainChatControl.More);
        }
    }
}
