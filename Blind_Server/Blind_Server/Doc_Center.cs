using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BlindNet;
using System.Data;
using System.IO;

namespace Blind_Server
{
    class Doc_Center
    {
        BlindSocket socket;
        MySqlConnection connection;
        uint uid;
        uint[] gids;
        uint[] accessibleDirs;

        public Doc_Center(uint uid, params uint[] gids)
        {
            this.uid = uid;
            this.gids = gids;
            accessibleDirs = null;
        }

        public void Run()
        {
            socket = _Main.socket_docCenter.AcceptWithECDH();

            connection = new MySqlConnection("Server = 192.168.35.149; Port = 3306; Database = document_center; Uid = root; Pwd = kit2020");
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : [UID : " + uid + "] " + ex.Message);
                return;
            }

            while (true)
            {
                try
                {
                    BlindPacket packet = socket.CryptoReceive();

                    switch (packet.header)
                    {
                        case PacketType.DocRefresh:
                            UpdateRoot();
                            break;
                        case PacketType.DocDirInfo:
                            byte[] data = BlindNetUtil.ByteTrimEndNull(packet.data);
                            byte[] tmp = new byte[4];
                            Array.Copy(data, 0, tmp, 0, data.Length);
                            uint dirID = BitConverter.ToUInt32(tmp, 0);
                            UpdateDir(dirID);
                            break;
                        case PacketType.DocAddDir:
                            AddDir(BlindNetUtil.ByteToStruct<Directory_Info>(packet.data));
                            break;
                        case PacketType.DocRemoveDir:
                            byte[] data2 = BlindNetUtil.ByteTrimEndNull(packet.data);
                            byte[] tmp2 = new byte[4];
                            Array.Copy(data2, 0, tmp2, 0, data2.Length);
                            uint dirID2 = BitConverter.ToUInt32(tmp2, 0);
                            RemoveDir(dirID2);
                            break;
                        case PacketType.DocChngNameDir:
                            ChangeNameDir(BlindNetUtil.ByteToStruct<Directory_Info>(packet.data));
                            break;
                        case PacketType.Disconnect:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR : [UID : " + uid + "] " + ex.Message);
                    return;
                }
            }
        }

        void UpdateRoot()
        {
            if (!connection.Ping())
            {
                Console.WriteLine("ERROR : [UID : " + uid + "] Database connection is terminate");
                return;
            }

            SetAccessibleDirs();

            string command = "SELECT id, parent_id, name FROM directorys_info WHERE id IN (" + UintArrToString(accessibleDirs) + ");";
            MySqlCommand commander = new MySqlCommand(command, connection);
            MySqlDataReader reader = commander.ExecuteReader();
            while (reader.Read())
            {
                Directory_Info dir = new Directory_Info();
                dir.id = (uint)reader["id"];
                dir.parent_id = (uint)reader["parent_id"];
                dir.name = (string)reader["name"];
                socket.CryptoSend(BlindNetUtil.StructToByte(dir), PacketType.Sending);
            }
            reader.Close();
            socket.CryptoSend(null, PacketType.EOF);
        }

        void UpdateDir(uint dirID)
        {
            string command = "SELECT id, parent_id, name FROM directorys_info WHERE parent_id = " + dirID.ToString() + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            MySqlDataReader reader = commander.ExecuteReader();
            while (reader.Read())
            {
                Directory_Info dir = new Directory_Info();
                dir.id = (uint)reader["id"];
                dir.parent_id = (uint)reader["parent_id"];
                dir.name = (string)reader["name"];
                socket.CryptoSend(BlindNetUtil.StructToByte(dir), PacketType.Sending);
            }
            reader.Close();
            socket.CryptoSend(null, PacketType.EOF);

            command = "SELECT id, name, modified_day, UPPER(type), size FROM files_info WHERE dir_id = " + dirID.ToString() + ";";
            commander = new MySqlCommand(command, connection);
            reader = commander.ExecuteReader();
            while (reader.Read())
            {
                File_Info file = new File_Info();
                file.id = (uint)reader["id"];
                file.name = (string)reader["name"];
                file.modDate = reader["modified_day"].ToString();
                file.type = (string)reader["UPPER(type)"];
                file.size = (uint)reader["size"];
                socket.CryptoSend(BlindNetUtil.StructToByte(file), PacketType.Sending);
            }
            reader.Close();
            socket.CryptoSend(null, PacketType.EOF);
        }

        void AddDir(Directory_Info dir)
        {
            try
            {
                string command = "SELECT MAX(id) FROM directorys_info;";
                MySqlCommand commander = new MySqlCommand(command, connection);
                MySqlDataReader reader = commander.ExecuteReader();
                reader.Read();
                dir.id = (uint)reader["MAX(id)"] + 1;
                reader.Close();

                commander.CommandText = "SELECT path FROM directorys_info WHERE id = " + dir.parent_id + ";";
                reader = commander.ExecuteReader();
                reader.Read();
                string path = RemakePath((string)reader["path"] + dir.id, true);
                reader.Close();

                DirectoryInfo di = new DirectoryInfo(path);
                if (!di.Exists)
                    di.Create();
                else
                {
                    socket.CryptoSend(null, PacketType.Fail);
                    return;
                }

                commander.CommandText = "INSERT INTO directorys_info values(0, '" + dir.name + "', " + dir.parent_id + ", '" + path + "');";
                if (commander.ExecuteNonQuery() == 1)
                    socket.CryptoSend(BlindNetUtil.StructToByte(dir), PacketType.OK);
                else
                    socket.CryptoSend(null, PacketType.Fail);
            }
            catch
            {
                socket.CryptoSend(null, PacketType.Fail);
            }
        }

        private void RemoveDir(uint id)
        {
            try
            {
                string command = "SELECT path FROM directorys_info WHERE id = " + id + ";";
                MySqlCommand commander = new MySqlCommand(command, connection);
                MySqlDataReader reader = commander.ExecuteReader();
                string path = null;
                if (reader.Read())
                    path = (string)reader["path"];
                reader.Close();

                if (path == null)
                    throw new System.Exception();

                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    try
                    {
                        dir.Delete();
                    }
                    catch (IOException ex)
                    {
                        socket.CryptoSend(null, PacketType.Retry);
                        BlindPacket packet = socket.CryptoReceive();
                        if (packet.header == PacketType.OK)
                            dir.Delete(true);
                        else
                            return;
                    }
                }
                else
                    throw new System.Exception();

                commander.CommandText = "DELETE FROM files_info WHERE dir_id = " + id + ";";
                commander.ExecuteNonQuery();

                commander.CommandText = "DELETE FROM directorys_info WHERE id = " + id + ";";
                if (commander.ExecuteNonQuery() == 1)
                    socket.CryptoSend(null, PacketType.OK);
                else
                    throw new System.Exception();
            }
            catch
            {
                socket.CryptoSend(null, PacketType.Fail);
            }
        }

        private void ChangeNameDir(Directory_Info dir)
        {
            string command = "UPDATE directorys_info SET name = '" + dir.name + "' WHERE id = " + dir.id + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);

            if (commander.ExecuteNonQuery() == 1)
                socket.CryptoSend(null, PacketType.OK);
            else
                socket.CryptoSend(null, PacketType.Fail);
        }

        private void SetAccessibleDirs()
        {
            string command = "SELECT dir_id FROM root_dirs WHERE gid IN (" + UintArrToString(gids) + ");";

            DataSet dataset = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            adapter.Fill(dataset);

            accessibleDirs = new uint[dataset.Tables[0].Rows.Count];
            for (int i = 0; i < accessibleDirs.Length; i++)
            {
                accessibleDirs[i] = (uint)dataset.Tables[0].Rows[i]["dir_id"];
            }
        }

        public string UintArrToString(uint[] arr)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                    result.Append(arr[i]);
                else
                    result.Append(arr[i] + ",");
            }

            return result.ToString();
        }

        string RemakePath(string path, bool isDir)
        {
            int i = path.Length - 1;
            while (true)
            {
                int j = path.LastIndexOf("\\", i);
                if (j == -1)
                    break;
                path = path.Insert(j, "\\");
                if (j - 1 < 0)
                    break;
                i = j - 1;
            }

            if (isDir)
                path = path + "\\\\";
            return path;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct Directory_Info
    {
        public uint id;
        public uint parent_id;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string name;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct File_Info
    {
        public uint id;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string modDate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string type;
        public uint size;
    }
}
