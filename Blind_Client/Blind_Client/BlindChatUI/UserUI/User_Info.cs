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
    public partial class User_Info : UserControl
    {
        public User_Info()
        {
            InitializeComponent();
            
            this.BackColor = BlindColor.Gray;
            tableLayoutPanel1.BackColor = lbl_Name.BackColor = BlindColor.Primary;
            panel2.BackColor = BlindColor.Gray;
            lbl_Department.ForeColor = lbl_Birth.ForeColor = lbl_Email.ForeColor = lbl_Phone.ForeColor = lbl_Position.ForeColor = BlindColor.Primary;
            BlindNetUtil.SetEllipse(panel3, 20);

            panel9.Width = panel10.Width;
            panel14.Width = panel11.Width;
            panel15.Width = panel12.Width;
            panel16.Width = panel13.Width;
            panel19.Width = panel18.Width;

            panel9.BackColor = panel14.BackColor = panel15.BackColor = panel16.BackColor = panel19.BackColor = BlindColor.LightGreen;
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
