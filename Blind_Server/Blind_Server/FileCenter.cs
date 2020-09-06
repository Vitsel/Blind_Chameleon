using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BlindNet;

namespace Blind_Server
{
    class FileCenter
    {
        BlindSocket socket;
        uint uid;
        uint[] gids;

        FileCenter(uint uid, uint[] gids)
        {
            this.uid = uid;
            this.gids = gids;
        }

        public void Run()
        {
            BlindServerScoket srvSock = new BlindServerScoket(BlindNetConst.ServerIP, BlindNetConst.DocCenterPort);
            socket = srvSock.AcceptWithECDH();

            while(true)
            {
                BlindPacket pack = socket.CryptoReceive();
                switch(pack.header)
                {
                    case PacketType.DocRefresh:
                        break;
                }
            }
        }
    }
}
