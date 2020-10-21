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

namespace Blind_Client.BlindChatUI.UserUI
{
    public partial class User_Item : UserControl
    {
        private User _user;

        public delegate void MyFunc(User user);
        public MyFunc UserClickEvent, UserDoubleClickEvent;


        public User_Item(User user)
        {
            InitializeComponent();
            Lbl_UserDepartment.Cursor = Cursors.Hand;
            Lbl_UserName.Cursor = Cursors.Hand;

            _user = user;
        }

        private void Lbl_UserName_Click(object sender, EventArgs e)
        {
            if(UserClickEvent != null)
            {
                UserClickEvent(_user);
            }
        }

        private void Lbl_UserName_DoubleClick(object sender, EventArgs e)
        {
            if(UserDoubleClickEvent != null)
            {
                UserDoubleClickEvent(_user);
            }
        }

        private void User_Item_Load(object sender, EventArgs e)
        {
            Lbl_UserName.Text = _user.Name;
            Lbl_UserDepartment.Text = _user.Department;
        }
    }

}
