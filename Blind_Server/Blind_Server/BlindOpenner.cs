using BlindNet;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Blind_Server
{
    class BlindOpenner
    {
        MySqlConnection connection;
        BlindServerScoket mainSocket;

        public void Run()
        {
            connection = new MySqlConnection("Server = " + BlindNetConst.DatabaseIP + "; Port = 3306; Database = document_center; Uid = root; Pwd = kit2020");
            mainSocket = new BlindServerScoket(BlindNetConst.ServerIP, BlindNetConst.OPENNERPORT);
            mainSocket.BindListen();
            while (true)
            {
                BlindSocket client = mainSocket.AcceptWithECDH();
                IPEndPoint iep = (IPEndPoint)(client.socket.RemoteEndPoint);
                Console.WriteLine("Accepted {0} : {1}", iep.Address, iep.Port);
                if (client == null)
                    continue;

                byte[] data = BlindNetUtil.ByteTrimEndNull(client.CryptoReceiveMsg());
                byte[] tmp = new byte[4];
                Array.Copy(data, 0, tmp, 0, data.Length);
                string ext = GetExt(BitConverter.ToUInt32(tmp, 0));
                if (ext == null)
                {
                    client.CryptoSend(null, PacketType.Disconnect);
                    continue;
                }
                client.CryptoSend(Encoding.UTF8.GetBytes(ext), PacketType.Info);

                data = BlindNetUtil.ByteTrimEndNull(client.CryptoReceiveMsg());
                tmp = new byte[4];
                Array.Copy(data, 0, tmp, 0, data.Length);
                int encryptDate = BitConverter.ToInt32(tmp, 0);
                byte[] key, iv;
                if (!GetSpecifyKeyPair(out key, out iv, encryptDate))
                {
                    client.CryptoSend(null, PacketType.Disconnect);
                    continue;
                }
                client.CryptoSend(key, PacketType.Info);
                client.CryptoSend(iv, PacketType.Info);

                byte[] latestKey, latestIv;
                if (!GetLatestKeyPair(out latestKey, out latestIv))
                {
                    client.CryptoSend(null, PacketType.Disconnect);
                    continue;
                }
                client.CryptoSend(latestKey, PacketType.Info);
                client.CryptoSend(latestIv, PacketType.Info);

                client.Close();
            }
        }

        string GetExt(uint id)
        {
            string command = "SELECT LOWER(type) FROM files_info WHERE id = " + id + ";";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables[0].Rows[0]["LOWER(type)"] == null)
                return null;

            string ext = dataset.Tables[0].Rows[0]["LOWER(type)"].ToString();
            return ext;
        }

        bool GetSpecifyKeyPair(out byte[] key, out byte[] iv, int encryptDate)
        {
            key = null;
            iv = null;
            string command = "SELECT _key, iv FROM crypto_key WHERE apply_date <= " + encryptDate +
                " AND expire_date > " + encryptDate + ";";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables[0].Rows[0]["_key"] == null || (byte[])dataset.Tables[0].Rows[0]["iv"] == null)
                return false;

            key = (byte[])dataset.Tables[0].Rows[0]["_key"];
            iv = (byte[])dataset.Tables[0].Rows[0]["iv"];
            return true;
        }

        bool GetLatestKeyPair(out byte[] key, out byte[] iv)
        {
            key = null;
            iv = null;
            string command = "SELECT _key, iv FROM crypto_key WHERE apply_date <= NOW() AND expire_date > NOW();";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables[0].Rows[0]["_key"] == null || (byte[])dataset.Tables[0].Rows[0]["iv"] == null)
                return false;

            key = (byte[])dataset.Tables[0].Rows[0]["_key"];
            iv = (byte[])dataset.Tables[0].Rows[0]["iv"];
            return true;
        }
    }
}
