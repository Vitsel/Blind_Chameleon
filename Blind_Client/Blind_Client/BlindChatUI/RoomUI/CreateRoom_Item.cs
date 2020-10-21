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
    public partial class CreateRoom_Item : UserControl
    {
        private User _User;
        private bool _isClicked;
        public delegate void MyFunc();
        public MyFunc AddUserCount, SubUserCount, LoadUserCount;

        public int UserID { get { return _User.ID; } }
        public bool isClicked { get { return _isClicked; } }

        private void CreateRoom_Item_Load(object sender, EventArgs e)
        {
            this.lbl_UserName.Text = _User.Name;
        }

        public CreateRoom_Item(User user)
        {
            InitializeComponent();
            _User = user;
            _isClicked = false;
        }

        private void lbl_UserName_Click(object sender, EventArgs e)
        {
            if (!_isClicked)
            {
                btn_Check.Text = "V";
                AddUserCount();
            }
            else
            {
                btn_Check.Text = "X";
                SubUserCount();
            }
            _isClicked = !_isClicked;
            if (LoadUserCount != null)
                LoadUserCount();
        }
    }
}
