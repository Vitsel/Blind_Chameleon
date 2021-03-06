﻿using System;
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

namespace Blind_Client.BlindChatUI.RoomUI
{
    public partial class CreateRoom_Item : UserControl
    {
        private User _User;
        private bool _isClicked;
        public delegate void MyFunc();
        public MyFunc AddUserCount, SubUserCount, LoadUserCount;

        public uint UserID { get { return _User.ID; } }
        public bool isClicked { get { return _isClicked; } }

        private void CreateRoom_Item_Load(object sender, EventArgs e)
        {
            this.lbl_UserName.Text = _User.Name;
        }

        private void lbl_UserName_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = BlindColor.Primary;
        }

        private void lbl_UserName_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = BlindColor.LightGreen;
        }

        private void btn_Check_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btn_Check_MouseLeave(object sender, EventArgs e)
        {

        }

        public CreateRoom_Item(User user)
        {
            InitializeComponent();
            _User = user;
            _isClicked = false;

            this.BackColor = BlindColor.LightGreen;
            panel1.BackColor = BlindColor.Primary;
            panel2.BackColor = btn_Check.BackColor = BlindColor.Light;

            
            BlindNetUtil.SetEllipse(this, 10);
            BlindNetUtil.SetEllipse(panel1, 30);
            BlindNetUtil.SetEllipse(panel2, 40);
            BlindNetUtil.SetEllipse(btn_Check, 40);
        }

        private void lbl_UserName_Click(object sender, EventArgs e)
        {
            if (!_isClicked)
            {
                AddUserCount();
                btn_Check.BackColor = BlindColor.DarkGreen;
            }
            else
            {
                SubUserCount();
                btn_Check.BackColor = BlindColor.Light;
            }
            _isClicked = !_isClicked;
            if (LoadUserCount != null)
                LoadUserCount();
        }
    }
}
