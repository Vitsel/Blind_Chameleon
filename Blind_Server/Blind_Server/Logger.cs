using System;
using MySql.Data.MySqlClient;
using BlindNet;

namespace BlindLogger
{
    class Logger
    {
        uint cid;
        string cip;
        string sip;
        string service;
        uint port;
        MySqlConnection connection;

        public Logger(uint cid, string cip, LogService service)
        {
            this.cid = cid;
            this.cip = cip;
            this.sip = BlindNetConst.ServerIP;
            switch(service)
            {
                case LogService.Listner:
                    this.service = "Listner";
                    port = BlindNetConst.MAINPORT;
                    break;
                case LogService.DocumentCenter:
                    this.service = "Document Center";
                    port = BlindNetConst.DocCenterPort;
                    break;
                case LogService.Chat:
                    this.service = "Chat";
                    port = BlindNetConst.CHATPORT;
                    break;
                case LogService.DeviceControl:
                    this.service = "Device Control";
                    port = BlindNetConst.WebDevicePort;
                    break;
                case LogService.ScreenLock:
                    this.service = "ScreenLock";
                    port = BlindNetConst.LOCKPORT;
                    break;
                case LogService.Login:
                    this.service = "Login";
                    port = BlindNetConst.MAINPORT;
                    break;
            }
            connection = new MySqlConnection("Server = " + BlindNetConst.DatabaseIP + "; Port = 3306; Database = BlindWeb; Uid = logger; Pwd = kit2020");
            connection.Open();
        }

        public void Log(LogRank rank, string contents)
        {
            string strRank = null;
            switch(rank)
            {
                case LogRank.INFO:
                    strRank = "INFORMATION";
                    break;
                case LogRank.WARN:
                    strRank = "WARNNING";
                    break;
                case LogRank.ERROR:
                    strRank = "ERROR";
                    break;
                case LogRank.FATAL:
                    strRank = "FATAL";
                    break;
            }
            string command = "INSERT INTO logtable values (0, now(), now(), @rank, @cid, @cip, @sip, @service, @port, @contents);";
            MySqlCommand commander = new MySqlCommand(command, connection);
            commander.Parameters.AddWithValue("rank", strRank);
            commander.Parameters.AddWithValue("cid", cid);
            commander.Parameters.AddWithValue("cip", cip);
            commander.Parameters.AddWithValue("sip", sip);
            commander.Parameters.AddWithValue("service", service);
            commander.Parameters.AddWithValue("port", port);
            commander.Parameters.AddWithValue("contents", contents);
            //commander.ExecuteNonQuery();
        }
    }

    public enum LogService
    {
        Listner,
        DocumentCenter,
        Chat,
        DeviceControl,
        ScreenLock,
        Login
    }

    public enum LogRank
    {
        INFO,
        WARN,
        ERROR,
        FATAL
    }
}
