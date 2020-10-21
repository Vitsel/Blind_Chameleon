using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_Client.BlindChatUI
{
    public partial class Control_More : UserControl
    {
        private int _UserID;
        public Control_More(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
    }
}
