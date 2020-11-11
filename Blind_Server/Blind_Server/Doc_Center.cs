//#define PROGRAMMING

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
using System.Diagnostics;

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

        ~Doc_Center()
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

        public void Run()
        {
            socket = _Main.socket_docCenter.AcceptWithECDH();
            socket.socket.NoDelay = true;
            isInner = BitConverter.ToBoolean(socket.CryptoReceiveMsg(), 0);

            connection = new MySqlConnection("Server = " + BlindNetConst.DatabaseIP + "; Port = 3306; Database = document_center; Uid = root; Pwd = kit2020");
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : [UID : " + uid + "] " + ex.Message);
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }
            socket.CryptoSend(null, PacketType.OK);

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
                    case PacketType.DocRemoveFile:
                        {
                            byte[] data = BlindNetUtil.ByteTrimEndNull(packet.data);
                            byte[] tmp = new byte[4];
                            Array.Copy(data, 0, tmp, 0, data.Length);
                            RemoveFile(BitConverter.ToUInt32(tmp, 0));
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
                    case PacketType.DocGetFileSize:
                        {
                            byte[] data = BlindNetUtil.ByteTrimEndNull(packet.data);
                            byte[] tmp = new byte[4];
                            Array.Copy(data, 0, tmp, 0, data.Length);
                            GetFileSize(BitConverter.ToUInt32(tmp, 0));
                            break;
                        }
                    case PacketType.DocGetDirSize:
                        {
                            byte[] data = BlindNetUtil.ByteTrimEndNull(packet.data);
                            byte[] tmp = new byte[4];
                            Array.Copy(data, 0, tmp, 0, data.Length);
                            GetDirSize(BitConverter.ToUInt32(tmp, 0));
                            break;
                        }
                    case PacketType.DocRenameFile:
                        {
                            byte[] data = BlindNetUtil.ByteTrimEndNull(packet.data);
                            byte[] tmp = new byte[4];
                            Array.Copy(data, 0, tmp, 0, data.Length);
                            RenameFile(BitConverter.ToUInt32(tmp, 0));
                            break;
                        }
                    case PacketType.DocMoveFile:
                        MoveFile(BlindNetUtil.ByteToStruct<SrcDstInfo>(packet.data));
                        break;
                    case PacketType.DocMoveDir:
                        MoveDir(BlindNetUtil.ByteToStruct<SrcDstInfo>(packet.data));
                        break;
                    case PacketType.DocCopyFile:
                        CopyFile(BlindNetUtil.ByteToStruct<SrcDstInfo>(packet.data));
                        break;
                    case PacketType.DocCopyDir:
                        CopyDir(BlindNetUtil.ByteToStruct<SrcDstInfo>(packet.data));
                        break;
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
            if (accessibleDirs.Length < 1)
            {
                socket.CryptoSend(null, PacketType.EOF);
                return;
            }

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
                //else
                //    throw new Exception();

                RemoveDirTree(id);
                UpdateModDate(pid);
                socket.CryptoSend(null, PacketType.OK);
            }
            catch (Exception ex)
            {
                socket.CryptoSend(null, PacketType.Fail);
            }
        }

        private void RemoveFile(uint id)
        {
            try
            {
                string command = "SELECT path, dir_id FROM files_info WHERE id = " + id + ";";
                MySqlCommand commander = new MySqlCommand(command, connection);
                MySqlDataReader reader = commander.ExecuteReader();
                string path = null;
                uint? dir_id = 0;
                if (reader.Read())
                {
                    path = reader["path"].ToString();
                    dir_id = (uint)reader["dir_id"];
                }
                reader.Close();

                commander.CommandText = "DELETE FROM files_info WHERE id = " + id + ";";
                commander.ExecuteNonQuery();

                FileInfo file = new FileInfo(path);
                if (file.Exists)
                    file.Delete();

                if (dir_id == 0)
                    throw new Exception();

                UpdateModDate(dir_id.Value);
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
            Debug.WriteLine("Start FileUpload \"{0}\"", file.name);
            MySqlCommand commander = null;
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
                    commander = new MySqlCommand(command, connection);
                    if (commander.ExecuteNonQuery() != 1)
                        throw new Exception();

                    path = (string)dataset.Tables[0].Rows[0]["path"];
                    File.Delete(path);
                }
                else
                {
                    command = "INSERT INTO files_info VALUES (" + 0 + ", " + dir.id + ", '" + file.name + "', DEFAULT, UPPER('" + file.type + "'), " +
                        file.size + ", NULL);";
                    commander = new MySqlCommand(command, connection);
                    if (commander.ExecuteNonQuery() != 1)
                        throw new Exception();
                }

                Debug.WriteLine("[FileUpload] Start leceiving");
                byte[] data = socket.CryptoReceiveMsg();
                Debug.WriteLine("[FileUpload] End leceiving {0} bytes", data.Length);

                command = "SELECT MAX(id) FROM files_info;";
                commander = new MySqlCommand(command, connection);
                MySqlDataReader reader = commander.ExecuteReader();
                reader.Read();
                file.id = (uint)reader["MAX(id)"];
                reader.Close();

                if (path == null)
                {
                    command = "SELECT path FROM directorys_info WHERE id = " + dir.id + ";";
                    adapter = new MySqlDataAdapter(command, connection);
                    adapter.Fill(dataset);
                    if (dataset.Tables[0].Rows.Count != 1)
                        throw new Exception();

                    path = (string)dataset.Tables[0].Rows[0]["path"] + file.id + ".blind";
                    command = "UPDATE files_info SET path = '" + RemakePath(path, false) + "' WHERE dir_id = " + dir.id + " AND name = '" + file.name + "';";
                    commander = new MySqlCommand(command, connection);
                    if (commander.ExecuteNonQuery() != 1)
                        throw new Exception();
                }

                data = EncryptFile(data);
                if (data == null)
                    throw new Exception();
                data = BlindNetUtil.MergeArray(BitConverter.GetBytes(file.id), data);

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

        private void FileDownload(uint id)
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

#if !PROGRAMMING
            fileName = Path.GetFileNameWithoutExtension(fileName) + ".blind";
#endif
            socket.CryptoSend(Encoding.UTF8.GetBytes(fileName), PacketType.Info);

            FileInfo file = new FileInfo((string)dataset.Tables[0].Rows[0]["path"]);
            if (!file.Exists)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }
            FileStream fs = file.OpenRead();
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, (int)fs.Length);
            fs.Close();

#if PROGRAMMING
            if (isInner)
            {
                buffer = DecryptFile(buffer);
                if (buffer == null)
                {
                    socket.CryptoSend(null, PacketType.Fail);
                    return;
                }
            }
#endif
            socket.CryptoSend(buffer, PacketType.MSG);
        }

        private void DirDownload(uint id)
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

            string dirName = GetDirPath(id);
            for (int i = 0; i < fileList.Count; i++)
                fileList[i]["NAME"] = fileList[i]["NAME"].Replace(dirName + "\\", string.Empty);

            using (var ms = new MemoryStream())
            {
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create))
                {
                    foreach (var file in fileList)
                    {
#if PROGRAMMING
                        if (isInner)
                        {
                            using (var entryStream = archive.CreateEntry(file["NAME"]).Open())
                            using (var fileStream = File.OpenRead(file["PATH"]))
                            {
                                byte[] data = new byte[fileStream.Length];
                                fileStream.Read(data, 0, data.Length);
                                data = DecryptFile(data);
                                entryStream.Write(data, 0, data.Length);
                            }
                        }
                        else
#endif
                        archive.CreateEntryFromFile(file["PATH"], file["NAME"]);
                    }
                }
                socket.CryptoSend(null, PacketType.OK);
                socket.CryptoSend(ms.ToArray(), PacketType.MSG);
            }
        }

        private void GetFileSize(uint id)
        {
            try
            {
                string command = "SELECT path FROM files_info WHERE id = " + id;
                MySqlCommand commander = new MySqlCommand(command, connection);
                MySqlDataReader reader = commander.ExecuteReader();
                string path = null;
                if (reader.Read())
                    path = (string)reader["path"];
                else
                    throw new Exception();
                reader.Close();

                FileInfo file = new FileInfo(path);
                if (!file.Exists)
                    throw new Exception();

                socket.CryptoSend(BitConverter.GetBytes(file.Length), PacketType.Response);
            }
            catch (Exception ex)
            {
                socket.CryptoSend(null, PacketType.Fail);
            }
        }

        private void GetDirSize(uint id)
        {
            try
            {
                string command = "SELECT path FROM directorys_info WHERE id = " + id;
                MySqlCommand commander = new MySqlCommand(command, connection);
                MySqlDataReader reader = commander.ExecuteReader();
                string path = null;
                if (reader.Read())
                    path = (string)reader["path"];
                else
                    throw new Exception();
                reader.Close();

                long size = 0;
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (FileInfo fi in dir.GetFiles("*", SearchOption.AllDirectories))
                    size += fi.Length;
                socket.CryptoSend(BitConverter.GetBytes(size), PacketType.Response);
            }
            catch (Exception ex)
            {
                socket.CryptoSend(null, PacketType.Fail);
            }
        }

        private void RenameFile(uint id)
        {
            string name = Encoding.UTF8.GetString(socket.CryptoReceiveMsg());

            string command = "UPDATE files_info SET name = '" + name + "', type = '" +
                Path.GetExtension(name).Replace(".", "") + "' WHERE id = " + id + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            if (commander.ExecuteNonQuery() != 1)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }
            socket.CryptoSend(null, PacketType.OK);
        }

        private void GetArchiveFileList(uint id, List<Dictionary<string, string>> list)
        {
            string command = "SELECT id, name, path FROM files_info WHERE dir_id = " + id + ";";
            MySqlDataAdapter adaper = new MySqlDataAdapter(command, connection);
            DataSet data = new DataSet();
            adaper.Fill(data);

            foreach (DataRow row in data.Tables[0].Rows)
            {
#if !PROGRAMMING
                row["name"] = Path.GetFileNameWithoutExtension((string)row["name"]) + ".blind";
#endif
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
            byte[] fileData = new byte[data.Length - 8];
            Array.Copy(data, 8, fileData, 0, fileData.Length);
            uint encryptDate = BitConverter.ToUInt32(data, 4);
            string command = "SELECT _key, iv FROM crypto_key WHERE apply_date <= '" + encryptDate +
                "' AND expire_date > '" + encryptDate + "'; ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables[0].Rows.Count != 1)
                return null;
            Cryptography.AES256 aes256 = new Cryptography.AES256((byte[])(dataset.Tables[0].Rows[0]["_key"]), (byte[])(dataset.Tables[0].Rows[0]["iv"]));
            try
            {
                return aes256.Decryption(fileData);
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
                uint timestemp = uint.Parse(DateTime.Now.ToString("yyyyMMdd"));
                return BlindNetUtil.MergeArray(BitConverter.GetBytes(timestemp), aes256.Encryption(data));
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

        void MoveFile(SrcDstInfo info)
        {
            string command = "SELECT name, path FROM files_info WHERE id = " + info.id + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            MySqlDataReader reader = commander.ExecuteReader();
            if (!reader.Read())
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            string fileName = reader["name"].ToString();
            FileInfo file = new FileInfo(reader["path"].ToString());
            reader.Close();
            if (!file.Exists)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            command = "SELECT path FROM directorys_info WHERE id = " + info.dstDir + ";";
            commander = new MySqlCommand(command, connection);
            var result = commander.ExecuteScalar();
            if (result == null)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            string newFile = result.ToString() + file.Name;
            file.MoveTo(newFile);
            newFile = RemakePath(newFile, false);

            int count = 1;
            string newFileName = fileName;
            while (IsInSameName(newFileName, info.dstDir, false))
                newFileName = fileName + "(" + count++ + ")";

            command = "UPDATE files_info SET name = '" + newFileName + "', dir_id = " + info.dstDir + ", path = '" + newFile + "' WHERE id = " + info.id + ";";
            commander = new MySqlCommand(command, connection);
            if (commander.ExecuteNonQuery() != 1)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }
            socket.CryptoSend(null, PacketType.OK);

            UpdateModDate(info.srcDir);
            UpdateModDate(info.dstDir);
            return;
        }

        void MoveDir(SrcDstInfo info)
        {
            string command = "SELECT name, path FROM directorys_info WHERE id = " + info.id + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            MySqlDataReader reader = commander.ExecuteReader();
            if (!reader.Read())
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            string dirName = reader["name"].ToString();
            DirectoryInfo dir = new DirectoryInfo(reader["path"].ToString());
            reader.Close();
            if (!dir.Exists)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            command = "SELECT path FROM directorys_info WHERE id = " + info.dstDir + ";";
            commander = new MySqlCommand(command, connection);
            var dstDir = commander.ExecuteScalar();
            if (dstDir == null)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            string newDir = dstDir.ToString() + dir.Name;
            dir.MoveTo(newDir);

            newDir = RemakePath(newDir, true);
            RefreshPath(info.id, newDir);

            int count = 1;
            string newDirName = dirName;
            while (IsInSameName(newDirName, info.dstDir, true))
                newDirName = dirName + "(" + count++ + ")";
            command = "UPDATE directorys_info SET name = '" + newDirName + "', parent_id = " + info.dstDir + ", path = '" + newDir + "' WHERE id = " + info.id + ";";
            commander = new MySqlCommand(command, connection);
            if (commander.ExecuteNonQuery() != 1)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }
            socket.CryptoSend(null, PacketType.OK);

            UpdateModDate(info.srcDir);
            UpdateModDate(info.dstDir);
            return;
        }

        bool IsInSameName(string name, uint dirID, bool isDir)
        {
            string command = string.Empty;
            if (isDir)
                command = "SELECT COUNT(*) FROM directorys_info WHERE parent_id = " + dirID + " AND name = '" + name + "';";
            else
                command = "SELECT COUNT(*) FROM files_info WHERE dir_id = " + dirID + " AND name = '" + name + "';";
            MySqlCommand commander = new MySqlCommand(command, connection);
            if (uint.Parse(commander.ExecuteScalar().ToString()) > 0)
                return true;
            return false;
        }

        void RefreshPath(uint dir, string newPath)
        {
            string command = "SELECT id, name FROM files_info WHERE dir_id = " + dir + ";";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                command = "UPDATE files_info SET path = '" + newPath + Path.GetFileName(row["name"].ToString()) + "' WHERE id = " + row["id"].ToString() + ";";
                MySqlCommand commander = new MySqlCommand(command, connection);
                commander.ExecuteNonQuery();
            }

            command = "SELECT id FROM directorys_info WHERE parent_id = " + dir + ";";
            adapter = new MySqlDataAdapter(command, connection);
            dataset = new DataSet();
            adapter.Fill(dataset);

            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                command = "UPDATE directorys_info SET path = '" + newPath + Path.GetFileName(row["id"].ToString()) + "' WHERE id = " + row["id"].ToString() + ";";
                MySqlCommand commander = new MySqlCommand(command, connection);
                commander.ExecuteNonQuery();
                RefreshPath((uint)row["id"], newPath + RemakePath(Path.GetFileName(row["id"].ToString()), true));
            }
        }

        void CopyFile(SrcDstInfo info)
        {
            string command = "SELECT name, path FROM files_info WHERE id = " + info.id + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            MySqlDataReader reader = commander.ExecuteReader();
            if (!reader.Read())
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            string fileName = reader["name"].ToString();
            FileInfo file = new FileInfo(reader["path"].ToString());
            reader.Close();
            if (!file.Exists)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            uint newFileID = MakeNewFile(fileName, info.dstDir, (uint)file.Length);
            if (newFileID == 0)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            command = "SELECT path FROM directorys_info WHERE id = " + info.dstDir + ";";
            commander = new MySqlCommand(command, connection);
            var dstDir = commander.ExecuteScalar();
            if (dstDir == null)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            string newFile = dstDir.ToString() + newFileID + ".blind";
            file.CopyTo(newFile);

            socket.CryptoSend(null, PacketType.OK);

            UpdateModDate(info.dstDir);
            return;
        }

        uint MakeNewFile(string name, uint did, uint size)
        {
            string command = "SELECT path FROM directorys_info WHERE id = " + did + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            string dirPath = commander.ExecuteScalar().ToString();

            int count = 1;
            string newFileName = name;
            while (IsInSameName(newFileName, did, false))
                newFileName = name + "(" + count++ + ")";

            command = "INSERT INTO files_info VALUES(0, @dir_id, '" + newFileName + "', now(), '" +
                Path.GetExtension(name).Replace(".", "") + "', @size, null)";
            commander = new MySqlCommand(command, connection);
            commander.Parameters.AddWithValue("dir_id", did);
            commander.Parameters.AddWithValue("size", size);
            if (commander.ExecuteNonQuery() != 1)
            {
                return 0;
            }

            uint newFileID = GetLastID();
            string newFile = dirPath + newFileID + ".blind";
            newFile = RemakePath(newFile, false);
            command = "UPDATE files_info SET path = '" + newFile + "' WHERE id = " + newFileID + ";";
            commander = new MySqlCommand(command, connection);
            commander.ExecuteNonQuery();

            return newFileID;
        }

        uint GetLastID(bool isDir = false)
        {
            string command;
            if (isDir)
                command = "SELECT MAX(id) FROM directorys_info;";
            else
                command = "SELECT MAX(id) FROM files_info;";

            MySqlCommand commander = new MySqlCommand(command, connection);
            uint id = (uint)(commander.ExecuteScalar());
            return id;
        }

        void CopyDir(SrcDstInfo info)
        {
            string command = "SELECT name, path FROM directorys_info WHERE id = " + info.id + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            MySqlDataReader reader = commander.ExecuteReader();
            if (!reader.Read())
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            string dirName = reader["name"].ToString();
            DirectoryInfo dir = new DirectoryInfo(reader["path"].ToString());
            reader.Close();
            if (!dir.Exists)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            command = "SELECT path FROM directorys_info WHERE id = " + info.dstDir + ";";
            commander = new MySqlCommand(command, connection);
            var dstDir = commander.ExecuteScalar();
            if (dstDir == null)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            uint newDirID = MakeNewDir(dirName, info.dstDir);
            if (newDirID == 0)
            {
                socket.CryptoSend(null, PacketType.Fail);
                return;
            }

            string newDirPath = dstDir.ToString() + newDirID;
            DirectoryInfo newDir = new DirectoryInfo(newDirPath);
            newDir.Create();
            DirCopyTo(info.id, newDirID);

            //RefreshPath(info.id, newDir);


            socket.CryptoSend(null, PacketType.OK);

            UpdateModDate(info.dstDir);
            return;
        }

        uint MakeNewDir(string name, uint pid)
        {
            int count = 1;
            string newDirName = name;
            while (IsInSameName(newDirName, pid, true))
                newDirName = name + "(" + count++ + ")";

            string command = "INSERT INTO directorys_info VALUES(0, '" + newDirName + "', @parent_id,  now(), null)";
            MySqlCommand commander = new MySqlCommand(command, connection);
            commander.Parameters.AddWithValue("parent_id", pid);
            if (commander.ExecuteNonQuery() != 1)
            {
                return 0;
            }

            command = "SELECT path FROM directorys_info WHERE id = " + pid + ";";
            commander = new MySqlCommand(command, connection);
            string dstPath = commander.ExecuteScalar().ToString();

            uint newDirID = GetLastID(true);
            string newDirPath = dstPath + newDirID;
            newDirPath = RemakePath(newDirPath, true);

            command = "UPDATE directorys_info SET path = '" + newDirPath + "' WHERE id = " + newDirID + ";";
            commander = new MySqlCommand(command, connection);
            if (commander.ExecuteNonQuery() != 1)
            {
                return 0;
            }

            return newDirID;
        }

        void DirCopyTo(uint srcID, uint dstID)
        {
            string command = "SELECT name, path FROM files_info WHERE dir_id = " + srcID + ";";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            command = "SELECT path FROM directorys_info WHERE id = " + dstID + ";";
            MySqlCommand commander = new MySqlCommand(command, connection);
            string dstPath = commander.ExecuteScalar().ToString();

            foreach(DataRow row in dataset.Tables[0].Rows)
            {
                FileInfo file = new FileInfo(row["path"].ToString());
                uint newFileID = MakeNewFile(row["name"].ToString(), dstID, (uint)file.Length);
                file.CopyTo(dstPath + newFileID + ".blind");
            }

            command = "SELECT name, id FROM directorys_info WHERE parent_id = " + srcID + ";";
            adapter = new MySqlDataAdapter(command, connection);
            dataset = new DataSet();
            adapter.Fill(dataset);

            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                uint newDirID = MakeNewDir(row["name"].ToString(), dstID);
                DirectoryInfo dir = new DirectoryInfo(dstPath + newDirID);
                dir.Create();
                DirCopyTo((uint)row["id"], newDirID);
            }
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

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct SrcDstInfo
    {
        public uint srcDir;
        public uint id;
        public uint dstDir;

        public SrcDstInfo(uint src, uint id, uint dst)
        {
            srcDir = src;
            this.id = id;
            dstDir = dst;
        }
    }
}
