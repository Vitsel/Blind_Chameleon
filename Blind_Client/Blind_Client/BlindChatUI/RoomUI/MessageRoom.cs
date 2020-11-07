using Blind_Client.BlindChatCode;
using BlindNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_Client.BlindChatUI.RoomUI
{
    public partial class MessageRoom : Form
    {
        private uint _userID;
        private ChatRoom _room;
        private List<ChatMessage> _messageList;
        public delegate void MyFunc(string text, uint userID, int roomID);
        public MyFunc SendChatMessage;
        private bool isMove;
        private Point fPt;

        public MessageRoom(uint userID, ChatRoom room, List<ChatMessage> messageList)
        {
            InitializeComponent();

            isMove = false;
            _userID = userID;
            _room = room;
            _messageList = messageList;
            this.Name = room.ID.ToString();
            this.lbl_ID.Text = "#" + room.ID.ToString();
            this.Text = this.lbl_Title.Text = _room.Name;
            this.StartPosition = FormStartPosition.Manual;

            panel1.BackColor = lbl_Title.BackColor = lbl_ID.BackColor = btn_menu.BackColor = button1.BackColor = BlindColor.Primary;
            lbl_Title.ForeColor = lbl_ID.ForeColor = button1.ForeColor = BlindColor.Light;
            panel4.BackColor = btn_Send.ForeColor = BlindColor.Light;
            btn_Send.BackColor = BlindColor.BrightBlue;
            panel5.BackColor = tb_Message.BackColor = BlindColor.Light;
            message_LayoutPanel.BackColor = BlindColor.Gray;
            
            BlindNetUtil.SetEllipse(this, 5);
            BlindNetUtil.SetEllipse(panel2, 5);
            //BlindNetUtil.SetEllipse(btn_Send, 5);
            BlindNetUtil.SetEllipse(panel4, 5);
            BlindNetUtil.SetEllipse(btn_menu, 20);
        }
        public void AddMessage(ChatMessage message)
        {
            Message_Item msgItem;
            if (message.UserID == _userID)
            {
                msgItem = new Message_Item(message, MessageDirection.right);
            }
            else if (message.UserID == 0)
            {
                msgItem = new Message_Item(message, MessageDirection.middle);
            }
            else
            {
                msgItem = new Message_Item(message, MessageDirection.left);
            }
            foreach(var a in BlindChat.userList)
            {
                if (a.ID == message.UserID) msgItem.UserName = a.Name;
            }
            msgItem.ReSizeMessage(this.Width);

            message_LayoutPanel.Controls.Add(msgItem);
            if (message_LayoutPanel.AutoScrollPosition.Y < message_LayoutPanel.VerticalScroll.Maximum)
                message_LayoutPanel.AutoScrollPosition = new Point(message_LayoutPanel.AutoScrollPosition.X, message_LayoutPanel.VerticalScroll.Maximum);
            //message_LayoutPanel.ScrollControlIntoView(msgItem);
        }
        public void LoadMessage()
        {
            message_LayoutPanel.Controls.Clear();
            foreach(ChatMessage message in _messageList)
            {
                AddMessage(message);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            foreach(Message_Item msgItem in message_LayoutPanel.Controls)
            {
                msgItem.ReSizeMessage(this.Width);
            }
        }


        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (tb_Message.Text == "" || tb_Message.Text == "\r\n")
            {
                MessageBox.Show("메시지를 입력하세요.");
                return;
            }

            string message = tb_Message.Text;
            if (SendChatMessage != null)
            {
                SendChatMessage(message, _userID, _room.ID);
            }
            tb_Message.Clear();
        }

        private void MessageRoom_Load(object sender, EventArgs e)
        {
            LoadMessage();
        }

        private void tb_Message_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Send_Click(sender, e);
            }
            if(tb_Message.Text == "\r\n")
            {
                tb_Message.Text = "";
            }
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            Room_Menu menu = new Room_Menu(_userID, _room);
            //menu.Parent = this;
            menu.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            menu.Show();
        }

        private void lbl_FormName_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fPt = new Point(e.X, e.Y);
        }

        private void lbl_FormName_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (fPt.X - e.X), this.Top - (fPt.Y - e.Y));
            }
        }

        private void lbl_FormName_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
