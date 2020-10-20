using System;
using System.Text;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using BlindNet;
using System.Data;
using System.IO;
using BlindCryptography;
using System.IO.Compression;
using System.Collections.Generic;
using Org.BouncyCastle.Crypto.Agreement.JPake;

namespace Blind_Server
{
    class Doc_Center
    {
        BlindSocket socket;
        MySqlConnection connection;
        uint uid;
        uint[] gids;
        uint[] accessibleDirs;
        bool isInner;

        public Doc_Center(uint uid, params uint[] gids)
        {
            this.uid = uid;
            this.gids = gids;
            accessibleDirs = null;
            isInner = false;
        }

        public void Run()
        {
            socket = _Main.socket_docCenter.AcceptWithECDH();
            isInner = BitConverter.ToBoolean(socket.CryptoReceiveMsg(), 0);

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
                //try
                //{
                BlindPacket packet = socket.CryptoReceive();
                if (packet.header != PacketType.Disconnect)
                    packet.data = BlindNetUtil.ByteTrimEndNull(packet.data);

                switch (packet.header)
                {
                    case PacketType.DocRefresh:
                        UpdateRoot();
                        break;
                    case PacketType.DocDirInfo:
                        {
                            byte[] data = BlindNetUtil.ByteTrimEndNull(packet.data);
                            byte[] tmp = new byte[4];
                            Array.Copy(data, 0, tmp, 0, data.Length);
                            UpdateDir(BitConverter.ToUInt32(tmp, 0));
                            break;
                        }
                    case PacketType.DocAddDir:
                        AddDir(BlindNetUtil.ByteToStruct<Directory_Info>(packet.data));
                        break;
                    case PacketType.DocRemoveDir:
                        {
                            byte[] data = BlindNetUtil.ByteTrimEndNull(packet.data);
                            byte[] tmp = new byte[4];
                            Array.Copy(data, 0, tmp, 0, data.Length);
                            RemoveDir(BitConverter.ToUInt32(tmp, 0));
                            break;
                        }
                    case PacketType.DocChngNameDir:
                        ChangeNameDir(BlindNetUtil.ByteToStruct<Directory_Info>(packet.data));
                        break;
                    case PacketType.DocFileUpload:
                        FileUpload(BlindNetUtil.ByteToStruct<Directory_Info>(packet.data));
                        break;
                    case PacketType.DocFileDownload:
                        {
                            byte[] data = BlindNetUtil.ByteTrimEndNull(packet.data);
                            byte[] tmp = new byte[4];
                            Array.Copy(data, 0, tmp, 0, data.Length);
                            FileDownload(BitConverter.ToUInt32(tmp, 0));
                            break;
                        }
                    case PacketType.DocDirDownload:
                        {
                            byte[] data = BlindNetUtil.ByteTrimEndNull(packet.data);
                            byte[] tmp = new byte[4];
                            Array.Copy(data, 0, tmp, 0, data.Length);
                            DirDownload(BitConverter.ToUInt32(tmp, 0));
                            break;
                        }
                    case PacketType.Disconnect:
                        return;
                }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("ERROR : [UID : " + uid + "] " + ex.Message);
                //    return;
                //}
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
            string command = "SELECT id, parent_id, name, modified_date FROM directorys_info WHERE parent_id = " + dirID.ToString() + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            MySqlDataReader reader = commander.ExecuteReader();
            while (reader.Read())
            {
                Directory_Info dir = new Directory_Info();
                dir.id = (uint)reader["id"];
                dir.parent_id = (uint)reader["parent_id"];
                dir.name = (string)reader["name"];
                dir.modDate = ((DateTime)reader["modified_date"]).ToString();
                socket.CryptoSend(BlindNetUtil.StructToByte(dir), PacketType.Sending);
            }
            reader.Close();
            socket.CryptoSend(null, PacketType.EOF);

            command = "SELECT id, name, modified_date, UPPER(type), size FROM files_info WHERE dir_id = " + dirID.ToString() + ";";
            commander = new MySqlCommand(command, connection);
            reader = commander.ExecuteReader();
            while (reader.Read())
            {
                File_Info file = new File_Info();
                file.id = (uint)reader["id"];
                file.name = (string)reader["name"];
                file.modDate = reader["modified_date"].ToString();
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
                string command = "INSERT INTO directorys_info values(0, '" + dir.name + "', " + dir.parent_id + ", DEFAULT, NULL);";
                MySqlCommand commander = new MySqlCommand(command, connection);
                if (commander.ExecuteNonQuery() != 1)
                    socket.CryptoSend(null, PacketType.Fail);

                commander.CommandText = "SELECT MAX(id) FROM directorys_info;";
                MySqlDataReader reader = commander.ExecuteReader();
                reader.Read();
                dir.id = (uint)reader["MAX(id)"];
                reader.Close();

                commander.CommandText = "SELECT path FROM directorys_info WHERE id = " + dir.parent_id + ";";
                reader = commander.ExecuteReader();
                reader.Read();
                string path = (string)reader["path"] + dir.id;
                reader.Close();

                commander.CommandText = "UPDATE directorys_info SET path = '" + RemakePath(path, true) + "' WHERE id = " + dir.id + ";";
                if (commander.ExecuteNonQuery() != 1)
                    socket.CryptoSend(null, PacketType.Fail);

                DirectoryInfo di = new DirectoryInfo(path);
                if (di.Exists)
                {
                    socket.CryptoSend(null, PacketType.Fail);
                    return;
                }
                UpdateModDate(dir.parent_id);

                di.Create();
                socket.CryptoSend(BlindNetUtil.StructToByte(dir), PacketType.OK);
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
                string command = "SELECT path, parent_id FROM directorys_info WHERE id = " + id + ";";
                MySqlCommand commander = new MySqlCommand(command, connection);
                MySqlDataReader reader = commander.ExecuteReader();
                string path = null;
                uint pid = 0;
                if (reader.Read())
                {
                    path = (string)reader["path"];
                    pid = (uint)reader["parent_id"];
                }
                reader.Close();

                if (path == null)
                    throw new Exception();

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
                    throw new Exception();

                RemoveDirTree(id);
                UpdateModDate(pid);
                socket.CryptoSend(null, PacketType.OK);
            }
            catch (Exception ex)
            {
                socket.CryptoSend(null, PacketType.Fail);
            }
        }

        private void RemoveDirTree(uint id)
        {
            string command = "SELECT id FROM directorys_info WHERE parent_id = " + id + ";";
            MySqlDataAdapter adaper = new MySqlDataAdapter(command, connection);
            DataSet data = new DataSet();
            adaper.Fill(data);

            foreach (DataRow row in data.Tables[0].Rows)
                RemoveDirTree((uint)row["id"]);

            command = "DELETE FROM files_info WHERE dir_id = " + id + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            commander.ExecuteNonQuery();

            commander.CommandText = "DELETE FROM directorys_info WHERE id = " + id + ";";
            commander.ExecuteNonQuery();
        }

        private void ChangeNameDir(Directory_Info dir)
        {
            string command = "UPDATE directorys_info SET name = '" + dir.name + "' WHERE id = " + dir.id + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            UpdateModDate(dir.parent_id);

            if (commander.ExecuteNonQuery() == 1)
                socket.CryptoSend(null, PacketType.OK);
            else
                socket.CryptoSend(null, PacketType.Fail);
        }

        private void FileUpload(Directory_Info dir)
        {
            File_Info file = BlindNetUtil.ByteToStruct<File_Info>(socket.CryptoReceiveMsg());

            try
            {
                string command = "SELECT path FROM files_info WHERE dir_id = " + dir.id + " AND name = '" + file.name + "';";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                string path = null;

                if (dataset.Tables[0].Rows.Count != 0)
                {
                    command = "UPDATE files_info SET modified_date = NOW() WHERE dir_id = " + dir.id + " AND name = '" + file.name + "';";
                    MySqlCommand commander = new MySqlCommand(command, connection);
                    if (commander.ExecuteNonQuery() != 1)
                        throw new Exception();

                    path = (string)dataset.Tables[0].Rows[0]["path"];
                    File.Delete(path);
                }
                else
                {
                    command = "INSERT INTO files_info VALUES (" + 0 + ", " + dir.id + ", '" + file.name + "', DEFAULT, UPPER('" + file.type + "'), " +
                        file.size + ", NULL);";
                    MySqlCommand commander = new MySqlCommand(command, connection);
                    if (commander.ExecuteNonQuery() != 1)
                        throw new Exception();
                }

                byte[] data = socket.CryptoReceiveMsg();

                if (path == null)
                {
                    command = "SELECT path FROM directorys_info WHERE id = " + dir.id + ";";
                    adapter = new MySqlDataAdapter(command, connection);
                    adapter.Fill(dataset);
                    if (dataset.Tables[0].Rows.Count != 1)
                        throw new Exception();

                    command = "SELECT MAX(id) FROM files_info;";
                    MySqlCommand commander = new MySqlCommand(command, connection);
                    MySqlDataReader reader = commander.ExecuteReader();
                    reader.Read();
                    file.id = (uint)reader["MAX(id)"];
                    reader.Close();

                    path = (string)dataset.Tables[0].Rows[0]["path"] + file.id + ".blind";
                    command = "UPDATE files_info SET path = '" + RemakePath(path, false) + "' WHERE dir_id = " + dir.id + " AND name = '" + file.name + "';";
                    commander = new MySqlCommand(command, connection);
                    if (commander.ExecuteNonQuery() != 1)
                        throw new Exception();
                }

                data = EncryptFile(data);
                if (data == null)
                    throw new Exception();

                FileInfo fi = new FileInfo(path);
                FileStream fs = fi.OpenWrite();
                fs.Write(data, 0, data.Length);
                fs.Close();

                UpdateModDate(dir.id);
                socket.CryptoSend(null, PacketType.OK);
            }
            catch (Exception ex)
            {
                socket.CryptoSend(null, PacketType.Fail);
            }
        }

        private async void FileDownload(uint id)
        {
            string command = "SELECT name, path FROM files_info WHERE id = " + id + ";";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            if (dataset.Tables[0].Rows.Count != 1)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }
            string fileName = (string)dataset.Tables[0].Rows[0]["name"];
            if (!isInner)
                fileName = Path.GetFileNameWithoutExtension(fileName) + ".blind";
            socket.CryptoSend(Encoding.UTF8.GetBytes(fileName), PacketType.MSG);

            FileInfo file = new FileInfo((string)dataset.Tables[0].Rows[0]["path"]);
            if (!file.Exists)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }
            FileStream fs = file.OpenRead();
            byte[] buffer = new byte[fs.Length];
            await fs.ReadAsync(buffer, 0, (int)fs.Length);
            fs.Close();

            if (isInner)
            {
                buffer = DecryptFile(buffer);
                if (buffer == null)
                {
                    socket.CryptoSend(null, PacketType.Fail);
                    return;
                }
            }
            socket.CryptoSend(buffer, PacketType.MSG);
        }

        private async void DirDownload(uint id)
        {
            List<Dictionary<string, string>> fileList = new List<Dictionary<string, string>>();
            GetArchiveFileList(id, fileList);

            foreach (var file in fileList)
            {
                if (!File.Exists(file["PATH"]))
                {
                    socket.CryptoSend(null, PacketType.Fail);
                    return;
                }
            }
            socket.CryptoSend(null, PacketType.OK);

            string dirName = GetDirPath(id);
            for (int i = 0; i < fileList.Count; i++)
                fileList[i]["NAME"] = fileList[i]["NAME"].Replace(dirName + "\\", string.Empty);

            using (var ms = new MemoryStream())
            {
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create))
                {
                    foreach (var file in fileList)
                    {
                        if (isInner)
                        {
                            using (var entryStream = archive.CreateEntry(file["NAME"]).Open())
                            using (var fileStream = File.OpenRead(file["PATH"]))
                            {
                                byte[] data = new byte[fileStream.Length];
                                await fileStream.ReadAsync(data, 0, data.Length);
                                data = DecryptFile(data);
                                await entryStream.WriteAsync(data, 0, data.Length);
                            }
                        }
                        else
                            archive.CreateEntryFromFile(file["PATH"], file["NAME"]);
                    }
                }
                socket.CryptoSend(ms.ToArray(), PacketType.MSG);
            }
        }

        private void GetArchiveFileList(uint id, List<Dictionary<string, string>> list)
        {
            string command = "SELECT id, name, path FROM files_info WHERE dir_id = " + id + ";";
            MySqlDataAdapter adaper = new MySqlDataAdapter(command, connection);
            DataSet data = new DataSet();
            adaper.Fill(data);

            foreach (DataRow row in data.Tables[0].Rows)
            {
                if (!isInner)
                    row["name"] = Path.GetFileNameWithoutExtension((string)row["name"]) + ".blind";
                string name = GetFilePath((uint)row["id"]);
                name = Path.GetDirectoryName(name) + "\\" + row["name"];
                list.Add(new Dictionary<string, string>() {
                    { "NAME", name },
                    { "PATH", (string)row["path"] }
                });
            }

            command = "SELECT id FROM directorys_info WHERE parent_id = " + id + ";";
            adaper = new MySqlDataAdapter(command, connection);
            data = new DataSet();
            adaper.Fill(data);
            if ((uint)data.Tables[0].Rows.Count == 0)
                return;
            foreach (DataRow row in data.Tables[0].Rows)
                GetArchiveFileList((uint)row["id"], list);
        }

        private string GetFilePath(uint id)
        {
            string path = null;
            string command = "SELECT name, dir_id FROM files_info WHERE id = " + id + ";";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            if (dataset.Tables[0].Rows.Count != 1)
                return null;

            string dirPath = GetDirPath((uint)dataset.Tables[0].Rows[0]["dir_id"]);
            if (dirPath == null)
                return null;

            path = dirPath + "\\" + dataset.Tables[0].Rows[0]["name"];
            return path;
        }

        private string GetDirPath(uint id)
        {
            string command = "SELECT name, parent_id FROM directorys_info WHERE id = " + id + ";";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            if (dataset.Tables[0].Rows.Count != 1)
                return null;
            else if ((uint)dataset.Tables[0].Rows[0]["parent_id"] == 0)
                return (string)dataset.Tables[0].Rows[0]["name"];

            string parentPath = GetDirPath((uint)dataset.Tables[0].Rows[0]["parent_id"]);
            if (parentPath == null)
                return null;

            return parentPath + "\\" + (string)dataset.Tables[0].Rows[0]["name"];
        }

        private byte[] DecryptFile(byte[] data)
        {
            string command = "SELECT _key, iv FROM crypto_key WHERE apply_date <= '" + DateTime.Now.ToString("yyyy-MM-dd") +
                "' AND expire_date > '" + DateTime.Now.ToString("yyyy-MM-dd") + "'; ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables[0].Rows.Count != 1)
                return null;
            Cryptography.AES256 aes256 = new Cryptography.AES256((byte[])(dataset.Tables[0].Rows[0]["_key"]), (byte[])(dataset.Tables[0].Rows[0]["iv"]));
            try
            {
                return aes256.Decryption(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private byte[] EncryptFile(byte[] data)
        {
            string command = "SELECT _key, iv FROM crypto_key WHERE apply_date <= NOW() AND expire_date > NOW();";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables[0].Rows.Count != 1)
                return null;

            Cryptography.AES256 aes256 = new Cryptography.AES256((byte[])(dataset.Tables[0].Rows[0]["_key"]), (byte[])(dataset.Tables[0].Rows[0]["iv"]));
            try
            {
                return aes256.Encryption(data);
            }
            catch (Exception ex)
            {
                return null;
            }
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

        void UpdateModDate(uint id)
        {
            string command = "UPDATE directorys_info SET modified_date = NOW() WHERE id = " + id + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            commander.ExecuteNonQuery();

            command = "SELECT parent_id FROM directorys_info WHERE id = " + id + ";";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if ((uint)(dataset.Tables[0].Rows[0]["parent_id"]) != 0)
                UpdateModDate((uint)(dataset.Tables[0].Rows[0]["parent_id"]));
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct Directory_Info
    {
        public uint id;
        public uint parent_id;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string modDate;
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
