using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_Client.BlindChatUI.RoomUI
{
    class TextBoxNoCaret:TextBox
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public TextBoxNoCaret()
        {
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.None;
            this.GotFocus += TextBoxGotFocus;

            this.ReadOnly = true;
            this.Enabled = false;
            this.Cursor = Cursors.IBeam; // mouse cursor like in other controls
        }

        private void TextBoxGotFocus(object sender, EventArgs args)
        {
            HideCaret(this.Handle);
        }
    }
}
