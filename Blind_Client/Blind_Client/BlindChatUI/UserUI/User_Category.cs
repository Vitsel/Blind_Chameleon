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
    public partial class User_Category : UserControl
    {
        public User_Category(string department)
        {
            InitializeComponent();
            Lbl_Category.Text = department;
            Lbl_Category.ForeColor = BlindColor.Light;
            //Lbl_Category.BackColor = BlindColor.Info;
            
            BlindNetUtil.SetEllipse(this, 3);
        }
    }
}
