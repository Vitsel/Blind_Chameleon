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
        public enum MainChatControl { User, Room }

        private int _UserID;
        private BlindChat _BlindChat;

        public Control_User _UserControl;
        public Control_Room _RoomControl;
        private Panel buttonPanel;
        private Button _selectedButton;

        public int UserID { get { return _UserID; } set { _UserID = value; } }
        public BlindChat BlindChat { set { _BlindChat = value; } }
        //public Control_User UserControl { get{ return _UserControl; } }
        //public Control_Room RoomControl { get { return _RoomControl; } }


        public ChatMain(int UserID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;


            this.UserID = UserID;

            buttonPanel = new Panel();
            buttonPanel.Width = 6;
            buttonPanel.Height = btn_Chat.Height;
            buttonPanel.BackColor = BlindColor.UIColor;

            _UserControl = new Control_User(UserID);
            _UserControl.Dock = DockStyle.Fill;
            
            _RoomControl = new Control_Room(UserID, _BlindChat);
            _RoomControl.Dock = DockStyle.Fill;

            Function_LayoutPanel.Controls.Add(_UserControl);
            Function_LayoutPanel.Controls.Add(_RoomControl);
            Button_LayoutPanel.Controls.Add(buttonPanel);


            this.btn_Chat.Cursor = this.btn_Member.Cursor = Cursors.Hand;

            this.Function_LayoutPanel.BackColor = BlindColor.BackColor;
            this.BackColor = BlindColor.ButtonColor;
            this.btn_Chat.ForeColor = this.btn_Member.ForeColor = BlindColor.UIColor;
            this.btn_Chat.BackColor = this.btn_Member.BackColor = BlindColor.ButtonColor;

            BlindChatUtil.SetEllipse(btn_Member, 20);
            BlindChatUtil.SetEllipse(btn_Chat, 20);

            //EllipseControl funcEllipse = new EllipseControl();
            //funcEllipse.TargetControl = Function_LayoutPanel;
            //funcEllipse.CorenerRadius = 10;

        }

        public void ActivateControl(MainChatControl controlType)
        {
            switch (controlType)
            {
                case MainChatControl.User:
                    {
                        _UserControl.BringToFront();
                        SetButton(btn_Member);
                        //SetControl(_UserControl);
                    }
                    break;
                case MainChatControl.Room:
                    {
                        _RoomControl.BringToFront();
                        SetButton(btn_Chat);
                        //SetControl(_RoomControl);
                    }
                    break;

            }
        }
        private void SetButton(Button btn)
        {
            if(_selectedButton != null)
            {
                _selectedButton.BackColor = BlindColor.ButtonColor;
            }

            buttonPanel.Parent = btn;
            buttonPanel.Dock = DockStyle.Left;
            //buttonPanel.Location = new Point(0, btn.Location.Y);
            //buttonPanel.BringToFront();

            btn.BackColor = BlindColor.PressedColor;
            _selectedButton = btn;
        }
        private void ChatMain_Load(object sender, EventArgs e)
        {
            ActivateControl(MainChatControl.User);
        }

        private void btn_Member_Click(object sender, EventArgs e)
        {
            ActivateControl(MainChatControl.User);
        }

        private void btn_Chat_Click(object sender, EventArgs e)
        {
            ActivateControl(MainChatControl.Room);
            _RoomControl.LoadRooms();
        }


    }
}
