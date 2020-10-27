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
    public partial class Invitation_Form : Form
    {
        private int _roomID;
        private int _UserCount;
        private List<User> _userList;

        public Invitation_Form(int _roomID)
        {
            InitializeComponent();
            this._roomID = _roomID;
            _UserCount = 0;
            _userList = BlindChat.GetUserList(this._roomID);
        }

        private void btn_Invite_Click(object sender, EventArgs e)
        {
            if (_UserCount < 1)
            {
                MessageBox.Show("1명 이상 선택해 주세요");
            }
            else
            {
                foreach (CreateRoom_Item item in InvitationItem_LayoutPanel.Controls)
                {
                    if (item.isClicked)
                    {
                        BlindChat.InviteUser(item.UserID, _roomID);
                    }
                }

                this.Close();
            }
        }
        public void AddUserCount()
        {
            _UserCount += 1;
        }
        public void SubUserCount()
        {
            _UserCount -= 1;
        }
        public void LoadUserCount()
        {
            lbl_UserCount.Text = $"인원 수({_UserCount + _userList.Count}/20)";
        }
        private void Invitation_Form_Load(object sender, EventArgs e)
        {

            foreach (User user in BlindChat.userList)
            {
                if (!this._userList.Contains(user))
                {
                    //방 멤버에 없는 사용자 UI출력
                    CreateRoom_Item item = new CreateRoom_Item(user);
                    item.AddUserCount = AddUserCount;
                    item.SubUserCount = SubUserCount;
                    item.LoadUserCount = LoadUserCount;

                    InvitationItem_LayoutPanel.Controls.Add(item);

                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
