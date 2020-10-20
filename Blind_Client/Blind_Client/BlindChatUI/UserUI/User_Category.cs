using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_Client.BlindChatUI.UserUI
{
    public partial class User_Category : UserControl
    {
        public User_Category(string department)
        {
            InitializeComponent();
            Lbl_Category.Text = department;
        }
    }
}
