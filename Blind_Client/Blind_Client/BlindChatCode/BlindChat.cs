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
        private uint _UserID;
        public uint UserID { get { return _UserID; } }
        static private BlindChatDB DB;
        private static BlindSocket recvSock, sendSock;
        private MainForm form;
        private ChatMain UI;
        public static List<User> userList = new List<User>();
        public static List<ChatRoom> roomList = new List<ChatRoom>();

        //=========================================

        public BlindChat(uint _UserID, ref ChatMain UI, MainForm form)
        {
            this.form = form;

            this._UserID = _UserID;
            UI.BlindChat = this;
            UI.UserID = _UserID;
            UI._RoomControl.SetBlindChat(this);

            this.UI = UI;
            DB = new BlindChatDB(this._UserID);
        }
        ~BlindChat()
        {
            recvSock.Close();
            sendSock.Close();
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

            sendSock = new BlindSocket();
            sendSock.ConnectWithECDH(BlindNetConst.ServerIP, BlindNetConst.CHATPORT);

            recvSock = new BlindSocket();
            recvSock.ConnectWithECDH(BlindNetConst.ServerIP, BlindNetConst.CHATPORT+1);


            syncTime = DB.GetAllTime();
            packet = BlindChatUtil.StructToChatPacket(syncTime);
            ChatPacketSend(packet);


            //string sql;
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
#if DEBUG
                        MessageBox.Show("데이터 로드 완료");
#endif 
                    }
                    Start = true;
                }
                else if(packet.Type == ChatType.Exit)
                {
                    ExecuteExit(packet);
                }
                else
                {

                }
            }
        }

    }
}
