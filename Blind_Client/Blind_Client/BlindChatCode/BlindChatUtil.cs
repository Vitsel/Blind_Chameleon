using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blind_Client.BlindChatUI;
using BlindNet;

namespace Blind_Client.BlindChatCode
{
    static public class BlindColor
    {
        public static Color Primary = Color.FromArgb(94,170, 168);
        public static Color Info = Color.FromArgb(54, 185, 204);
        public static Color Light = Color.FromArgb(244, 243, 242);
        public static Color Secondary = Color.FromArgb(133, 135, 150);

        public static Color Gray = Color.FromArgb(244, 243, 242);
        public static Color DarkGray = Color.FromArgb(234, 233, 232);

        public static Color BrightGreen = Color.FromArgb(183, 230, 222);
        public static Color LightGreen = Color.FromArgb(163, 210, 202);
        public static Color DarkGreen = Color.FromArgb(5, 102, 118);
        public static Color LightBlue = Color.FromArgb(99, 116, 223);
        public static Color BrightBlue = Color.FromArgb(119, 136, 223);
        public static Color SkyBlue = Color.FromArgb(200, 205, 250);
        public static Color Black = Color.FromArgb(20, 20, 20);
    }

    static public class BlindChatUtil
    {
        public static Form GetFormWithName(string formName)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == formName)
                    return openForm;
            }
            return null;
        }

        public static T ChatPacketToStruct<T>(ChatPacket chatPack) where T : struct
        {
            byte[] chatPackByte = new byte[Marshal.SizeOf(typeof(T))];
            Array.Copy(chatPack.Data, chatPackByte, chatPackByte.Length);

            T data = BlindNetUtil.ByteToStruct<T>(chatPackByte);
            return data;
        }

        public static ChatPacket StructToChatPacket(Invitation inv)
        {
            byte[] data = BlindNetUtil.StructToByte(inv);
            return BlindChatUtil.ByteToChatPacket(data, ChatType.Invitation);
        }
        public static ChatPacket StructToChatPacket(NewRoomStruct newRoom)
        {
            byte[] data = BlindNetUtil.StructToByte(newRoom);
            return BlindChatUtil.ByteToChatPacket(data, ChatType.NewRoom);
        }
        public static ChatPacket StructToChatPacket(User user)
        {
            byte[] data = BlindNetUtil.StructToByte(user);
            return BlindChatUtil.ByteToChatPacket(data, ChatType.User);
        }
        public static ChatPacket StructToChatPacket(ChatRoom room)
        {
            byte[] data = BlindNetUtil.StructToByte(room);
            return BlindChatUtil.ByteToChatPacket(data, ChatType.Room);
        }
        public static ChatPacket StructToChatPacket(ChatRoomJoined roomJoined, ChatType type = ChatType.RoomJoined)
        {
            byte[] data = BlindNetUtil.StructToByte(roomJoined);
            return BlindChatUtil.ByteToChatPacket(data, type);
        }
        public static ChatPacket StructToChatPacket(ChatMessage message)
        {
            byte[] data = BlindNetUtil.StructToByte(message);
            return BlindChatUtil.ByteToChatPacket(data, ChatType.Message);
        }
        public static ChatPacket StructToChatPacket(ChatTimeStamp time)
        {
            byte[] data = BlindNetUtil.StructToByte(time);
            return BlindChatUtil.ByteToChatPacket(data, ChatType.Time);
        }



        public static ChatPacket ByteToChatPacket(byte[] data, ChatType type)
        {
            ChatPacket chatPack = new ChatPacket();
            if (data.Length > BlindChatConst.CHATDATASIZE)
            {
                //MessageBox.Show("Data Size Must be smaller than 2048 bytes");
                chatPack.Data = null;
                return chatPack;
            }
            else
            {
                byte[] packData = new byte[BlindChatConst.CHATDATASIZE];
                Array.Copy(data, packData, data.Length);
                chatPack.Type = type;
                chatPack.Data = packData;
            }
            return chatPack;
        }
    }

    public static class BlindChatConst
    {
        public const int CHATDATASIZE = 1023;
        public const int MESSAGESIZE = 512;
        public const int SMALLSIZE = 32;
        public const string ZERO_TIME = "0000-00-00 00:00:00";
    }
    public enum ChatType
    {
        Time = 1,

        User = 2,
        Room = 3,
        Message = 4,
        RoomJoined = 5,

        Reset = 6,

        //chat functions.. ex) quit chat, create chat
        NewRoom = 7,
        Invitation = 8,
        Exit = 9
    }

    public enum UserStat
    {
        Offline = 0,
        Online = 1
    }
    //채팅 패킷 구조체
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChatPacket
    {
        public ChatType Type;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = BlindChatConst.CHATDATASIZE)]
        public byte[] Data;
    }

    //db 테이블 구조체
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct User
    {
        public uint ID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Time;

        public int Online;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Position;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Department;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Phone;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Email;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Birth;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChatRoom
    {
        public int ID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Time;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string LastMessageTime;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChatRoomJoined
    {
        public int ID;
        public int RoomID;
        public uint UserID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Time;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChatMessage
    {
        public int ID;
        public uint UserID;
        public int RoomID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.MESSAGESIZE)]
        public string Message;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Time;
    }



    //기능 구조체
    //시간 동기화 구조체
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChatTimeStamp
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string timeUser;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string timeChatRoom;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string timeChatRoomJoined;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string timeMessage;
    }
    //방 생성 정보 구조체
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NewRoomStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public uint[] UserID;
    }

    //방 초대 구조체
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Invitation
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BlindChatConst.SMALLSIZE)]
        public string Name;

        //초대한 사람의 id
        public int UserID;
        public int RoomID;
    }

    static class ChatSize
    {
        public static int User = Marshal.SizeOf(typeof(User));
        public static int ChatRoom = Marshal.SizeOf(typeof(ChatRoom));
        public static int ChatRoomJoined = Marshal.SizeOf(typeof(ChatRoomJoined));
        public static int ChatMessage = Marshal.SizeOf(typeof(ChatMessage));
        public static int Time = Marshal.SizeOf(typeof(ChatTimeStamp));
        public static int NewRoom = Marshal.SizeOf(typeof(NewRoomStruct));
        public static int Invitation = Marshal.SizeOf(typeof(Invitation));
    }
}
