using System;
using System.Text; // Encoding
using System.Threading;
using System.Data; // 
using System.Net; // network 관련
using System.Net.Sockets; // 소켓
using System.Collections.Generic;
using MySql.Data.MySqlClient; // Mysql
using System.Windows.Forms;
using BlindNet;
using BlindLogger;
/*
   제작           : 최찬희
   최종 수정일 : 2020-10-28
   *돌아가는 방식 (SqlLookup)
     -1초마다 클라의 cid값을 조회해서 클라에게 보내준다.
     -클라는 그 값을 통해 디바이스 제어를 한다. 
*/
namespace Blind_Server
{
    class BlindWebDevice
    {
        public BlindSocket BS;
        public Logger logger;
        public MySqlConnection connection;
        public MySqlCommand Command;
        private uint cid = 0;

        public BlindWebDevice(uint Cid)
        {
            cid = Cid;
        }

        public void Run()
        {
            BS = _Main.WebDeviceSocket.AcceptWithECDH();
            connection = new MySqlConnection(@"server=54.84.228.2; database=BlindWeb; user=root; password=kit2020");
            connection.Open();
            IPEndPoint iep = (IPEndPoint)(BS.socket.RemoteEndPoint);
            logger = new Logger(cid, iep.Address.ToString(), LogService.DeviceControl);

            string ClientSendResultValue = "NULL";
            string QueryResultBackupValue = "";
            string UsbValue = "";
            string CamValue = "";
            while (true)
            {
                string DeviceUsbQuery = "SELECT cusb from blindDevice where cid=" + cid + ";"; //USB
                Command = new MySqlCommand(DeviceUsbQuery, connection);//검색할 쿼리, 연결된 쿼리
                UsbValue = Command.ExecuteScalar().ToString();
                string DeviceCamQuery = "SELECT ccamera from blindDevice where cid=" + cid + ";"; //CAM
                Command = new MySqlCommand(DeviceCamQuery, connection);//검색할 쿼리, 연결된 쿼리
                CamValue = Command.ExecuteScalar().ToString();


                /* USB가 1번째 CAM이 2번째라고 했을때 10진수로 값을 정해서 보냄 (0은 차단 1은 허용)
                 * USB 1 CAM 1 = 11 (USB는 허용 CAM도 허용인 경우) -> 값 11 클라 전송
                 * USB 1 CAM 0 = 10 (USB는 허용 CAM은 차단인 경우) -> 값 10 클라 전송
                 * USB 0 CAM 1 = 01 (USB는 차단 CAM은 허용인 경우) -> 값 01 클라 전송
                 * USB 0 CAM 0 = 00 (USB는 허용 CAM도 허용인 경우) -> 값 00 클라 전송
                */

                ClientSendResultValue = "";
                if (UsbValue == "True" && CamValue == "True")
                    ClientSendResultValue = "11";
                else if (UsbValue == "True" && CamValue == "False")
                    ClientSendResultValue = "10";
                else if (UsbValue == "False" && CamValue == "True")
                    ClientSendResultValue = "01";
                else if (UsbValue == "False" && CamValue == "False")
                    ClientSendResultValue = "00";

                if (QueryResultBackupValue != ClientSendResultValue)
                {
                    QueryResultBackupValue = ClientSendResultValue;
                    if (ClientSendResultValue == "11")
                        logger.Log(LogRank.INFO, "DeviceControl(USB:Allow | CAM:Allow) cid: " + cid);
                    else if (ClientSendResultValue == "10")
                        logger.Log(LogRank.INFO, "DeviceControl(USB:Allow | CAM:Deny) cid: " + cid);
                    else if (ClientSendResultValue == "01")
                        logger.Log(LogRank.INFO, "DeviceControl(USB:Deny | CAM:Allow) cid: " + cid);
                    else if (ClientSendResultValue == "00")
                        logger.Log(LogRank.INFO, "DeviceControl(USB:Deny | CAM:Deny) cid: " + cid);
                   }

                byte[] SendStringToByteGender = Encoding.UTF8.GetBytes(ClientSendResultValue);// 변환 바이트 -> string = default,GetString | string -> 바이트 = utf8,GetBytes

                if (BS.CryptoSend(SendStringToByteGender, PacketType.Response) == 0)
                    break;
            }
        }


    }
}
