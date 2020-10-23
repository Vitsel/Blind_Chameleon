﻿

using Blind_Client.BlindChatCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int _UserID;
        private int _UserCount;
        public delegate void MyFunc(string text, int[] array);
        public MyFunc CreateRoom;

        public CreateRoomForm(int _UserID)
        {
            InitializeComponent();
            this._UserID = _UserID;
            _UserCount = 1;
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
                    int[] selectedUser = new int[20];
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
            lbl_UserCount.Text = $"인원 수({_UserCount}/20)";
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

                    CreateRoomIItem_LayoutPanel.Controls.Add(item);

                }
            }
            LoadUserCount();
        }

    }
}
