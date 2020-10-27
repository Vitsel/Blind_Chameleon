using Blind_Client.BlindChatCode;
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
        private ChatRoom _room;
        private List<User> _userList = new List<User>();
        private Invitation_Form invForm;
        public Room_Menu(ChatRoom room)
        {
            InitializeComponent();
            this._room = room;
            this.lbl_RoomName.Text = room.Name;
            this.StartPosition = FormStartPosition.CenterParent;
            _userList = BlindChat.GetUserList(_room.ID);
        }

        private void btn_Invite_Click(object sender, EventArgs e)
        {
            invForm = new Invitation_Form(_room.ID);
            invForm.Show();
            Close();
        }

        private void Room_Menu_Load(object sender, EventArgs e)
        {
            foreach(User user in _userList)
            {
                lb_UserListBox.Items.Add(user.Name);
            }
        }
    }
}
