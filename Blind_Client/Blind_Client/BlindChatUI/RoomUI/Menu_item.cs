using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlindNet;
using Blind_Client.BlindChatCode;

namespace Blind_Client.BlindChatUI.RoomUI
{
    public partial class Menu_item : UserControl
    {
        private string userName;
        public Menu_item(string name)
        {
            InitializeComponent();

            BlindNetUtil.SetEllipse(this, 5);
            this.BackColor = BlindColor.Primary;
            lbl_name.ForeColor = BlindColor.Light;
            lbl_name.BackColor = BlindColor.Primary;

            userName = name;
            lbl_name.Text = userName;
        }
    }
}
