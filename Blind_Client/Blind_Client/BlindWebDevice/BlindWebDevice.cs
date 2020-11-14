using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using BlindNet;
using System.Windows.Forms;

/*
   제작           : 최찬희
   최종 수정일 : 2020-11-12 오전 10:14
   돌아가는 방식 (SqlLookup)
     -클라에서 접속한 아이디를 서버로 보낸다 (ClientMsg)
     -데이터를 받으면 받은 데이터를 조회해 cid값을 알아낸다 (CidGenderAdapt)
     -알아내고 난 후 그 값을 통해 cusb 값과 cUsbCam값을 알아내서 클라로 보낸다.
     -클라는 그 값을 통해 디바이스 제어를 한다. 
*/

namespace Blind_Client.BlindWebDeviceClass
{
    class BlindWebDevice
    {
        BlindSocket BS = new BlindSocket();
        BlindPacket BP = new BlindPacket();
        DeviceDriverHelper DDH;

        public void Run()
        {
            BS.ConnectWithECDH(BlindNetConst.ServerIP, BlindNetConst.WebDevicePort);
            DDH = new DeviceDriverHelper();
            SqlLookup();
        }

        ~BlindWebDevice() { BS.Close(); }

        private void SqlLookup()
        {
            while (true)
            {
                BP=BS.CryptoReceive();// 아이디에 따른 장치제어 결과 받아옴
                BP.data = BlindNetUtil.ByteTrimEndNull(BP.data);
                string ReceiveByteToStringGender = Encoding.Default.GetString(BP.data);// 변환 바이트 -> string = default,GetString | string -> 바이트 = utf8,GetBytes

                //11 : USB,CAM 차단 | 10: USB만 차단 | 01: 웹캠만 차단 | 00 : 모두허용
                DDH.DeviceToggle(ReceiveByteToStringGender);

                Thread.Sleep(1000);
            }
        }

    }
}
