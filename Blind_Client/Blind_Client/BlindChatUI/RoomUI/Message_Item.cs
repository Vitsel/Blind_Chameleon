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
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using BlindNet;

namespace Blind_Client.BlindChatUI.RoomUI
{
    public enum MessageDirection { left, right, middle };
    public partial class Message_Item : UserControl
    {
        private int BubbleIndent;
        private ChatMessage _message;
        private MessageDirection direction;
        public string UserName { set { this.lbl_userName.Text = value; } }
        
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public Message_Item(ChatMessage message, MessageDirection direct)
        {
            InitializeComponent();

            BubbleIndent = 100;
            _message = message;
            label1.Text = message.Message;
            label1.Dock = DockStyle.Fill;
            panel1.Dock = DockStyle.None;
            this.BackColor = Color.Transparent;
            label1.Enabled = true;
            label1.ForeColor = Color.Black;
            direction = direct;

            if(direction == MessageDirection.right)
            {
                panel1.BackColor = label1.BackColor = BlindColor.SkyBlue;
                lbl_userName.Text = "";
            }
            else if(direction == MessageDirection.middle)
            {
                panel1.BackColor = Color.Transparent;
                label1.BackColor = BlindColor.DarkGray;
                label1.ForeColor = BlindColor.Secondary;
                
                lbl_userName.Text = "";
            }
            else
            {
                label1.BackColor = panel1.BackColor = BlindColor.DarkGray;
                lbl_userName.Dock = DockStyle.Left;
                panel1.Location = new Point(0, lbl_userName.Height);
            }
            lbl_userName.ForeColor = BlindColor.Black;
            BlindNetUtil.SetEllipse(panel1, 10);
            
        }

        public void ReSizeMessage(int Width)
        {
            if (direction != MessageDirection.middle)
            {
                this.Width = Width - 42;
                //Size TextSize = TextRenderer.MeasureText(_message.Message, textBox1.Font, new Size(this.Width - 100, this.Height-12), TextFormatFlags.WordBreak|TextFormatFlags.WordEllipsis);

                Graphics g = this.CreateGraphics();
                SizeF TextSize = g.MeasureString(_message.Message, label1.Font, this.Width - BubbleIndent - 12); // indent 뺀거

                this.Height = (int)TextSize.Height + 12;     //패딩
                lbl_userName.Height = panel2.Height = 17;

                panel1.Width = (int)TextSize.Width + 12;    //패딩
                panel1.Height = (int)TextSize.Height + 12;   //패딩

                if (direction == MessageDirection.right)
                {
                    //this.Height = panel1.Height + 12;
                    panel1.Location = new Point(this.Width - panel1.Width, 0);
                    lbl_userName.Text = "";
                    lbl_userName.Height = panel2.Height = 0;
                }

                this.Height = panel1.Height + panel2.Height;
            }
            else
            {
                lbl_userName.Height = panel2.Height = 0;
                panel1.Width = this.Width = Width - 36;

                Graphics g = this.CreateGraphics();
                SizeF TextSize = g.MeasureString(_message.Message, label1.Font, panel1.Width - 12); // indent 뺀거

                label1.Height = panel1.Height = (int)TextSize.Height + 12;
                label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;

                this.Height = panel1.Height + panel2.Height+4;
                panel1.Location = new Point(0, 0);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
