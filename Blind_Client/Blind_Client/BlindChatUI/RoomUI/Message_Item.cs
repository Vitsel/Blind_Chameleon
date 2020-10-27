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

            BubbleIndent = 40;
            _message = message;
            textBox1.Text = message.Message;
            textBox1.Dock = DockStyle.Fill;
            panel1.Dock = DockStyle.None;
            this.BackColor = Color.Transparent;

            direction = direct;


            if(direction == MessageDirection.right)
            {
                panel1.BackColor = Color.FromArgb(255, 255, 204);
                textBox1.BackColor = Color.FromArgb(255, 255, 204);
                lbl_userName.Text = "";
            }
            else if(direction == MessageDirection.middle)
            {
                panel1.BackColor = Color.Transparent;
                textBox1.BackColor = Color.LightGray;
                
                lbl_userName.Text = "";
            }
            else
            {
                panel1.BackColor = Color.FromArgb(204, 255, 204);
                textBox1.BackColor = Color.FromArgb(204, 255, 204);
                lbl_userName.Dock = DockStyle.Left;
                panel1.Location = new Point(0, lbl_userName.Height);
            }
        }

        public void ReSizeMessage(int Width)
        {
            if (direction != MessageDirection.middle)
            {
                this.Width = Width - 48;
                //Size TextSize = TextRenderer.MeasureText(_message.Message, textBox1.Font, new Size(this.Width - 100, this.Height-12), TextFormatFlags.WordBreak|TextFormatFlags.WordEllipsis);

                Graphics g = this.CreateGraphics();
                SizeF TextSize = g.MeasureString(_message.Message, textBox1.Font, this.Width - 100);

                this.Height = (int)TextSize.Height + 12 + 24;

                panel1.Width = (int)TextSize.Width + 12;
                panel1.Height = (int)TextSize.Height + 12;

                if (direction == MessageDirection.right)
                {
                    this.Height = panel1.Height + 12;
                    panel1.Location = new Point(this.Width - panel1.Width, 0);
                    lbl_userName.Text = "";
                }
            }
            else
            {
                this.Width = Width-48;
                this.Width =
                panel1.Width = this.Width - 6;
                textBox1.TextAlign = HorizontalAlignment.Center;
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
