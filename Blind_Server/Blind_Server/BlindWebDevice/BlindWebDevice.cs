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
/*
   제작           : 최찬희
   최종 수정일 : 2020-10-28
   *돌아가는 방식 (SqlLookup)
     -클라에서 접속한 아이디를 서버로 보낸다 (ClientMsg)
     -데이터를 받으면 받은 데이터를 조회해 cid값을 알아낸다 (CidGenderAdapt)
     -알아내고 난 후 그 값을 통해 cusb 값과 cUsbCam값을 알아내서 클라로 보낸다.
     -클라는 그 값을 통해 디바이스 제어를 한다. 
*/
namespace Blind_Server
{
    class BlindWebDevice
    {
        private BlindSocket BS;
        private BlindPacket BP;

        public void Run(uint ClientCID,MySqlConnection connection)
        {
            BS = _Main.WebDeviceSocket.AcceptWithECDH();
            BP = new BlindPacket();
            SqlLookup(ClientCID,connection);
        }


        private void SqlLookup(uint ClientCID, MySqlConnection connection)
        {
            string ClientSendResultValue = "NULL";
            while (true)
            {
                string DeviceUsbQuery = "SELECT cusb from blindDevice where cid=" + ClientCID+";"; //USB
                string DeviceCamQuery = "SELECT ccamera from blindDevice where cid=" +ClientCID + ";"; //CAM
                MySqlCommand CidUsbCommand = new MySqlCommand(DeviceUsbQuery, connection);//검색할 쿼리, 연결된 쿼리
                MySqlCommand CidCamCommand = new MySqlCommand(DeviceCamQuery, connection);//검색할 쿼리, 연결된 쿼리

                /* USB가 1번째 CAM이 2번째라고 했을때 10진수로 값을 정해서 보냄 (1은 차단 0은 허용)
                 * USB 1 CAM 1 = 11 (USB는 차단 CAM도 차단인 경우) -> 값 11 클라 전송
                 * USB 1 CAM 0 = 10 (USB는 차단 CAM은 허용인 경우) -> 값 10 클라 전송
                 * USB 0 CAM 1 = 01 (USB는 허용 CAM은 차단인 경우) -> 값 01  클라 전송
                 * USB 0 CAM 1 = 01 (USB는 허용 CAM도 허용인 경우) -> 값 00  클라 전송
                */

                ClientSendResultValue = "";
                if (CidUsbCommand.ExecuteScalar().ToString() == "True" && CidCamCommand.ExecuteScalar().ToString() == "True")
                    ClientSendResultValue = "11";
                else if (CidUsbCommand.ExecuteScalar().ToString() == "True" && CidCamCommand.ExecuteScalar().ToString() == "False")
                    ClientSendResultValue = "10";
                else if (CidUsbCommand.ExecuteScalar().ToString() == "False" && CidCamCommand.ExecuteScalar().ToString() == "True")
                    ClientSendResultValue = "01";
                else if (CidUsbCommand.ExecuteScalar().ToString() == "False" && CidCamCommand.ExecuteScalar().ToString() == "False")
                    ClientSendResultValue = "00";

                byte[] SendStringToByteGender = Encoding.UTF8.GetBytes(ClientSendResultValue);// 변환 바이트 -> string = default,GetString | string -> 바이트 = utf8,GetBytes
                BS.CryptoSend(SendStringToByteGender, PacketType.Sending);

                Thread.Sleep(1000);
            }
        }

    }
}
