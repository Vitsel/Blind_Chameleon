using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlindNet;

namespace Blind_Client
{
    class FileCenter
    {
        BlindSocket socket;

        public void Run()
        {
            socket = new BlindSocket();
            socket.ConnectWithECDH(BlindNetConst.ServerIP, BlindNetConst.DocCenterPort);

            UpdateView();
        }

        public void UpdateView()
        {
            socket.CryptoSend(null, PacketType.DocRefresh);
            
        }
    }
}
