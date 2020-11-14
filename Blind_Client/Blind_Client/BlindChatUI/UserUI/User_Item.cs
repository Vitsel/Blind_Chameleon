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
            Lbl_UserPosition.Cursor = Cursors.Hand;
            Lbl_UserName.Cursor = Cursors.Hand;
            BlindNetUtil.SetEllipse(this, 10);
            
            this.BackColor = BlindColor.Light;
            Lbl_UserPosition.ForeColor = BlindColor.Primary;

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

        private void Lbl_UserName_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.BackColor = BlindColor.Gray;
        }

        private void Lbl_UserName_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = BlindColor.Light;
        }

        private void User_Item_Load(object sender, EventArgs e)
        {
            Lbl_UserName.Text = _user.Name;
            Lbl_UserPosition.Text = _user.Position;
        }
    }

}
