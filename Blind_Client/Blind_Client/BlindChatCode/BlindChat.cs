using BlindNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blind_Client.BlindChatCode;
using System.Data.SqlTypes;
using System.Windows.Forms;
using Blind_Client.BlindChatUI;

namespace Blind_Client.BlindChatCode
{
    public partial class BlindChat
    {
        private int _UserID;
        public int UserID { get { return _UserID; } }
        private BlindChatDB DB;
        private BlindSocket chatSock;
        private MainForm form;
        private ChatMain UI;
        public static List<User> userList = new List<User>();
        public static List<ChatRoom> roomList = new List<ChatRoom>();

        //=========================================

        public BlindChat(int _UserID, ref ChatMain UI, MainForm form)
        {
            this.form = form;

            this._UserID = _UserID;
            UI.BlindChat = this;
            UI.UserID = _UserID;
            UI._RoomControl.SetBlindChat(this);

            this.UI = UI;
            DB = new BlindChatDB(this._UserID);
        }

        private bool Start = false;
        public void Run()
        {
            ChatPacket packet;
            ChatTimeStamp syncTime;

            User user;
            ChatRoom room;
            ChatRoomJoined roomJoined;
            ChatMessage message;

            DB.Open();

            chatSock = new BlindSocket();
            chatSock.ConnectWithECDH(BlindNetConst.ServerIP, BlindNetConst.CHATPORT);

            {
                user = new User();
                user.ID = _UserID;
                packet = BlindChatUtil.StructToChatPacket(user);
                ChatPacketSend(packet);
            }

            packet = ChatPacketReceive();
            user = BlindChatUtil.ChatPacketToStruct<User>(packet);
            _UserID = user.ID;

            syncTime = DB.GetAllTime();
            packet = BlindChatUtil.StructToChatPacket(syncTime);
            ChatPacketSend(packet);


            string sql;
            while (true)
            {
                packet = ChatPacketReceive();

                if(packet.Type == ChatType.User)
                {
                    //사용자 UI에 표시
                    user = BlindChatUtil.ChatPacketToStruct<User>(packet);
                    AddUser(user);
                }
                else if(packet.Type == ChatType.Room)
                {
                    //방추가 UI에 표시
                    room = BlindChatUtil.ChatPacketToStruct<ChatRoom>(packet);
                    AddRoom(room);
                }
                else if(packet.Type == ChatType.RoomJoined)
                {
                    //방인원 UI에 표시
                    roomJoined = BlindChatUtil.ChatPacketToStruct<ChatRoomJoined>(packet);
                    AddMember(roomJoined);
                }
                else if(packet.Type == ChatType.Message)
                {
                    //메시지 UI에 표시
                    message = BlindChatUtil.ChatPacketToStruct<ChatMessage>(packet);
                    AddMessage(message);




                }
                else if(packet.Type == ChatType.Reset)
                {
                    if (!Start)
                    {
                        LoadList();
                        LoadUI();
                    }
                    Start = true;
                }
                else if(packet.Type == ChatType.Invitation)
                {

                }
                else
                {

                }
            }
        }

    }
}
