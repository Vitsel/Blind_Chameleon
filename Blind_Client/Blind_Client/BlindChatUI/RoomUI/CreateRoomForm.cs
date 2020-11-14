

using Blind_Client.BlindChatCode;
using BlindNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_Client.BlindChatUI.RoomUI
{
    public partial class CreateRoomForm : Form
    {
        private uint _UserID;
        private int _UserCount;
        private bool isMove;
        private Point fPt;
        public delegate void MyFunc(string text, uint[] array);
        public MyFunc CreateRoom;

        public CreateRoomForm(uint _UserID)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this._UserID = _UserID;
            _UserCount = 1;

            this.BackColor = Color.Black;
            lbl_UserCount.BackColor = button1.BackColor = lbl_FormName.BackColor = panel4.BackColor = BlindColor.DarkGreen;
            label1.BackColor = lbl_FormName.ForeColor = panel4.ForeColor = BlindColor.Light;

            btn_Cancel.BackColor = btn_Confirm.BackColor = BlindColor.DarkGreen;
            tableLayoutPanel1.BackColor = btn_Cancel.ForeColor = btn_Confirm.ForeColor = BlindColor.Light;

            CreateRoomIItem_LayoutPanel.BackColor = BlindColor.Gray;
            panel3.BackColor = BlindColor.Light;

            lbl_UserCount.ForeColor = BlindColor.Light;
            panel7.BackColor = tb_RoomName.BackColor = BlindColor.Light;
            
            BlindNetUtil.SetEllipse(this, 5);
            BlindNetUtil.SetEllipse(tableLayoutPanel1, 5);
            BlindNetUtil.SetEllipse(panel4, 10);
            BlindNetUtil.SetEllipse(btn_Confirm, 15);
            BlindNetUtil.SetEllipse(btn_Cancel, 15);
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (_UserCount < 2)
            {
                MessageBox.Show("1명 이상 선택해 주세요");
            }
            else
            {
                if (tb_RoomName.Text == "")
                {
                    MessageBox.Show("방 이름을 입력해 주세요");
                }
                else
                {
                    uint[] selectedUser = new uint[20];
                    selectedUser[0] = _UserID;


                    int i = 1;
                    foreach (CreateRoom_Item item in CreateRoomIItem_LayoutPanel.Controls)
                    {
                        if (item.isClicked)
                        {
                            selectedUser[i] = item.UserID;
                            i++;
                        }
                    }

                    if (CreateRoom != null)
                    {
                        CreateRoom(tb_RoomName.Text, selectedUser);
                    }
                    else
                    {
                        MessageBox.Show("실패...");
                    }

                    this.Close();
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddUserCount()
        {
            _UserCount += 1;
        }
        public void SubUserCount()
        {
            _UserCount -= 1;
        }
        public void LoadUserCount()
        {
            lbl_UserCount.Text = $"{_UserCount}/20";
        }

        private void CreateRoomForm_Load(object sender, EventArgs e)
        {
            foreach(User user in BlindChat.userList)
            {
                if(user.ID != _UserID)
                {
                    CreateRoom_Item item = new CreateRoom_Item(user);
                    item.AddUserCount = AddUserCount;
                    item.SubUserCount = SubUserCount;
                    item.LoadUserCount = LoadUserCount;
                    item.Width = CreateRoomIItem_LayoutPanel.Width-40;

                    CreateRoomIItem_LayoutPanel.Controls.Add(item);

                }
            }
            LoadUserCount();
        }

        private void lbl_FormName_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fPt = new Point(e.X, e.Y);
        }

        private void lbl_FormName_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMove && (e.Button&MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (fPt.X - e.X), this.Top - (fPt.Y - e.Y));
            }
        }

        private void lbl_FormName_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
