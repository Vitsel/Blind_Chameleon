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
using Blind_Client.BlindChatUI.UserUI;

namespace Blind_Client.BlindChatUI
{
    public partial class Control_User : UserControl
    {
        private int _UserID;
        private User_Info _UserInfo;

        public Control_User(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;

        }

        private void Control_User_Load(object sender, EventArgs e)
        {
            //LoadUsers();

            _UserInfo = new User_Info();
            _UserInfo.Dock = DockStyle.Fill;
            UserInfo_LayoutPanel.Controls.Add(_UserInfo);
        }
        public void LoadUsers()
        {
            UserItem_LayoutPanel.Controls.Clear();
            string depart = BlindChat.userList[0].Department;
            AddCategory(depart);
            foreach (User user in BlindChat.userList)
            {
                if(user.Department != depart)
                {
                    depart = user.Department;
                    AddCategory(depart);
                }
                AddUser(user);
            }
        }
        public void AddCategory(string department)
        {
            User_Category category = new User_Category(department);
            UserItem_LayoutPanel.Controls.Add(category);
        }
        public void AddUser(User user)
        {
            User_Item userItem = new User_Item(user);
            userItem.UserClickEvent = DisplayUserInfo;

            UserItem_LayoutPanel.Controls.Add(userItem);
        }
        public void DisplayUserInfo(User user)
        {
            _UserInfo.SetUserInfo(user);
        }
    }
}