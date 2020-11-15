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
    public partial class Room_Menu : Form
    {
        private uint UserID;
        private ChatRoom _room;
        private List<User> _userList = new List<User>();
        private Invitation_Form invForm;
        private bool isMove;
        private Point fPt;

        public Room_Menu(uint userID, ChatRoom room)
        {
            InitializeComponent();

            this.isMove = false;
            this._room = room;
            this.UserID = userID;
            this.lbl_RoomName.Text = room.Name;
            this.StartPosition = FormStartPosition.Manual;
            _userList = BlindChat.GetUserList(_room.ID);

            btn_Invite.BackColor = btn_close.BackColor = panel1.BackColor = lbl_RoomName.BackColor = BlindColor.DarkGreen;

            lbl_RoomName.ForeColor = BlindColor.Light;
            btn_exit.BackColor = BlindColor.DarkGreen;
            btn_close.ForeColor = BlindColor.Light;
            panel2.BackColor = BlindColor.Light;
            label1.ForeColor = BlindColor.Secondary;

            BlindNetUtil.SetEllipse(this, 5);
            BlindNetUtil.SetEllipse(panel5, 5);
            BlindNetUtil.SetEllipse(btn_Invite, 20);
        }

        private void btn_Invite_Click(object sender, EventArgs e)
        {
            invForm = new Invitation_Form(_room.ID);
            invForm.Location = new Point(this.Location.X, this.Location.Y);
            invForm.Show();
            Close();
        }

        private void Room_Menu_Load(object sender, EventArgs e)
        {
            foreach(User user in _userList)
            {
                Menu_item item = new Menu_item(user.Name);
                item.Width = flowLayoutPanel1.Width - 54;
                if (user.ID == UserID)
                {
                    flowLayoutPanel1.Controls.Add(item);
                    flowLayoutPanel1.Controls.SetChildIndex((Control)item, 0);
                    //lb_UserListBox.Items.Insert(0, user.Name);
                    continue;
                }
                flowLayoutPanel1.Controls.Add(item);
                //lb_UserListBox.Items.Add(user.Name);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            BlindChat.ExitRoom(UserID, _room.ID);
            Close();
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
