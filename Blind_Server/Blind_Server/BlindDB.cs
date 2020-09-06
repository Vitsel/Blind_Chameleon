using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Blind_Server
{
    class BlindDB
    {
        private string ip;
        private string port;
        private string dbName;
        private string uid;
        private string pwd;
        private MySqlConnection connection;

        BlindDB(string dbName, string uid, string pwd, string ip = BlindDBConst.serverIP, string port = BlindDBConst.serverPort)
        {
            this.ip = ip;
            this.port = port;
            this.dbName = dbName;
            this.uid = uid;
            this.pwd = pwd;
        }

        ~BlindDB()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Dispose();
        }

        public bool Connect()
        {
            connection = new MySqlConnection("Server=" + ip + ";Port=" + port + ";Database=" + dbName + ";Uid=" + uid + ";Pwd=" + pwd);
            if (!connection.Ping())
            {
                return false;
            }
            connection.Open();
            return true;
        }

        public void disconnect()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public int Querry(string querry)
        {
            MySqlCommand command = new MySqlCommand(querry, connection);
            return command.ExecuteNonQuery();
        }

        public MySqlDataReader QuerryWithResult(string querry)
        {
            MySqlCommand command = new MySqlCommand(querry, connection);
            return command.ExecuteReader();
        }
    }

    static class BlindDBConst
    {
        public const string serverIP = "192.168.35.149";
        public const string serverPort = "3306";
    }
}
