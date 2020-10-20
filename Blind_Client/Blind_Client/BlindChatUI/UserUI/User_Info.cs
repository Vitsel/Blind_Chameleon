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
    public partial class User_Info : UserControl
    {
        public User_Info()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void SetUserInfo(User user)
        {
            this.lbl_Name.Text = user.Name;
            this.lbl_PositionText.Text = user.Position;
            this.lbl_DepartmentText.Text = user.Department;
            this.lbl_EmailText.Text = user.Email;
            this.lbl_PhoneText.Text = user.Phone;
            this.lbl_BirthText.Text = user.Birth;
        }
    }
}
