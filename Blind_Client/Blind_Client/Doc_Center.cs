using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BlindNet;
using System.Threading.Tasks;
using System.Text;

namespace Blind_Client
{
    public class Doc_Center
    {
        BlindSocket socket;
        Document_Center form;
        bool isInner;
        readonly string dPath;

        public Doc_Center(Document_Center form, bool isInner)
        {
            this.form = form;
            this.isInner = isInner;
            dPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";
        }

        public async void Run()
        {
            socket = new BlindSocket();
            await socket.ConnectWithECDHAsync(BlindNetConst.ServerIP, BlindNetConst.DocCenterPort);

            socket.CryptoSend(BitConverter.GetBytes(isInner), PacketType.MSG);
            BlindPacket packet = socket.CryptoReceive();
            if (packet.header == PacketType.Fail)
            {
                MessageBox.Show("데이터베이스 연결에 실패했습니다.");
                return;
            }

            UpdateRoot();
            form.treeview_Dir.SelectedNode = form.treeview_Dir.Nodes[0];
        }

        public void UpdateRoot()
        {
            form.treeview_Dir.Nodes.Clear();

            socket.CryptoSend(null, PacketType.DocRefresh);
            while (true)
            {
                BlindPacket packet = socket.CryptoReceive();
                if (packet.header == PacketType.EOF)
                    break;

                Directory_Info dir = BlindNetUtil.ByteToStruct<Directory_Info>(BlindNetUtil.ByteTrimEndNull(packet.data));
                TreeNode node = new TreeNode();
                node.Tag = dir;
                node.Text = dir.name;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                form.treeview_Dir.Nodes.Add(node);
            }
        }

        public void UpdateDir(TreeNode node)
        {
            form.listview_File.BeginUpdate();
            form.listview_File.Items.Clear();
            node.Nodes.Clear();

            socket.CryptoSend(BitConverter.GetBytes(((Directory_Info)(node.Tag)).id), PacketType.DocDirInfo);
            while (true)
            {
                BlindPacket packet = socket.CryptoReceive();
                if (packet.header == PacketType.EOF)
                    break;

                Directory_Info dir = BlindNetUtil.ByteToStruct<Directory_Info>(BlindNetUtil.ByteTrimEndNull(packet.data));
                TreeNode subNode = new TreeNode();
                subNode.Tag = dir;
                subNode.Text = dir.name;
                subNode.ImageIndex = 0;
                subNode.SelectedImageIndex = 0;
                node.Nodes.Add(subNode);

                ListViewItem item = new ListViewItem();
                item.Text = dir.name;
                item.SubItems.Add(dir.modDate);
                item.SubItems.Add(string.Empty);
                item.Tag = dir.id;
                item.ImageIndex = 0;
                form.listview_File.Items.Add(item);
            }

            while (true)
            {
                BlindPacket packet = socket.CryptoReceive();
                if (packet.header == PacketType.EOF)
                    break;

                File_Info file = BlindNetUtil.ByteToStruct<File_Info>(BlindNetUtil.ByteTrimEndNull(packet.data));
                ListViewItem item = new ListViewItem();
                item.Text = file.name;
                item.SubItems.Add(file.modDate);
                item.SubItems.Add(file.type);
                item.SubItems.Add(file.size.ToString());
                item.Tag = file.id;
                form.listview_File.Items.Add(item);
            }
            form.listview_File.EndUpdate();
        }

        public bool AddDir(TreeNode node, string name)
        {
            Directory_Info dir = new Directory_Info();
            dir.id = 0;
            dir.parent_id = ((Directory_Info)(node.Parent.Tag)).id;
            dir.name = name;

            socket.CryptoSend(BlindNetUtil.StructToByte(dir), PacketType.DocAddDir);
            BlindPacket packet = socket.CryptoReceive();
            if (packet.header != PacketType.OK)
                return false;
            node.Tag = BlindNetUtil.ByteToStruct<Directory_Info>(BlindNetUtil.ByteTrimEndNull(packet.data));
            return true;
        }

        public bool RemoveDir(TreeNode node)
        {
            uint id = ((Directory_Info)(node.Tag)).id;

            socket.CryptoSend(BitConverter.GetBytes(id), PacketType.DocRemoveDir);
            while (true)
            {
                BlindPacket packet = socket.CryptoReceive();
                if (packet.header == PacketType.Retry)
                {
                    DialogResult result = MessageBox.Show("폴더가 비어있지 않습니다. 삭제하시겠습니까?", "폴더 삭제", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        socket.CryptoSend(null, PacketType.OK);
                    else
                    {
                        socket.CryptoSend(null, PacketType.Fail);
                        return true;
                    }
                }
                else if (packet.header == PacketType.OK)
                    break;
                else if (packet.header == PacketType.Fail)
                    return false;
            }
            return true;
        }

        public bool RemoveFile(uint id)
        {
            socket.CryptoSend(BitConverter.GetBytes(id), PacketType.DocRemoveFile);
            BlindPacket packet = socket.CryptoReceive();
            if (packet.header != PacketType.OK)
                return false;
            return true;
        }

        public bool UpdateNameDir(TreeNode node, string name)
        {
            Directory_Info dir = (Directory_Info)(node.Tag);
            dir.name = name;
            socket.CryptoSend(BlindNetUtil.StructToByte(dir), PacketType.DocChngNameDir);

            BlindPacket packet = socket.CryptoReceive();
            if (packet.header == PacketType.Fail)
                return false;
            return true;
        }

        public async Task<bool> UploadFileAsync(TreeNode node, FileInfo file)
        {
            Directory_Info dir = (Directory_Info)node.Tag;
            socket.CryptoSend(BlindNetUtil.StructToByte(dir), PacketType.DocFileUpload);

            File_Info fi = new File_Info();
            fi.id = 0;
            fi.name = file.Name;
            fi.size = (uint)file.Length;
            fi.modDate = file.LastWriteTime.ToString();
            fi.type = Path.GetExtension(file.FullName).Replace(".", "");
            socket.CryptoSend(BlindNetUtil.StructToByte(fi), PacketType.MSG);

            FileStream fs = file.OpenRead();
            byte[] buffer = new byte[fs.Length];
            await fs.ReadAsync(buffer, 0, (int)fs.Length);
            fs.Close();

            SendFile(buffer);
            BlindPacket packet = socket.CryptoReceive();
            if (packet.header == PacketType.Fail)
                return false;

            return true;
        }

        private bool SendFile(byte[] data)
        {
            if (data == null)
                data = new byte[BlindNetConst.DATASIZE];
            try
            {
                for (int i = 0; i < data.Length; i += BlindNetConst.DATASIZE)
                {
                    int len = (i + BlindNetConst.DATASIZE < data.Length) ? BlindNetConst.DATASIZE : data.Length - i;
                    byte[] tmp = new byte[len];
                    Array.Copy(data, i, tmp, 0, len);
                    socket.CryptoSendPacket(tmp, (i + len == data.Length) ? PacketType.EOF : PacketType.Sending);

                    form.progressBar.PerformStep();
                    form.progressBar.Update();
                    form.label_percent.Text = (form.progressBar.Value * 100 / form.progressBar.Maximum) + "%";
#if DEBUG
                    form.label_percent.Text = form.progressBar.Value.ToString();
#endif
                    form.label_percent.Update();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<TreeNode> UploadDirAsync(TreeNode node, string path)
        {
            Directory_Info dir = new Directory_Info();
            dir.id = 0;
            dir.parent_id = ((Directory_Info)node.Tag).id;
            dir.name = Path.GetFileName(path);
            socket.CryptoSend(BlindNetUtil.StructToByte(dir), PacketType.DocAddDir);

            BlindPacket packet = await Task.Run(() => socket.CryptoReceive());
            if (packet.header == PacketType.Fail)
                return null;

            Directory_Info newDir = BlindNetUtil.ByteToStruct<Directory_Info>(BlindNetUtil.ByteTrimEndNull(packet.data));
            TreeNode newNode = new TreeNode();
            newNode.Tag = newDir;
            newNode.Text = newDir.name;
            newNode.ImageIndex = 0;
            newNode.SelectedImageIndex = 0;

            form.progressBar.PerformStep();
            form.progressBar.Update();
            form.label_percent.Text = (form.progressBar.Value * 100 / form.progressBar.Maximum) + "%";
#if DEBUG
            form.label_percent.Text = form.progressBar.Value.ToString();
#endif
            form.label_percent.Update();

            return newNode;
        }

        public async Task<bool> DownloadFile(ListViewItem item)
        {
            uint id = (uint)item.Tag;
            socket.CryptoSend(BitConverter.GetBytes(id), PacketType.DocFileDownload);

            BlindPacket packet = await Task.Run(socket.CryptoReceive);
            if (packet.header == PacketType.Fail)
                return false;
            string fileName = Encoding.UTF8.GetString(BlindNetUtil.ByteTrimEndNull(packet.data));

            byte[] data = null;
            do
            {
                packet = socket.CryptoReceive();
                if (packet.header == PacketType.Disconnect)
                    return false;
                data = BlindNetUtil.MergeArray<byte>(data, packet.data);
                form.progressBar.PerformStep();
                form.progressBar.Update();
                form.label_percent.Text = (form.progressBar.Value * 100 / form.progressBar.Maximum) + "%";
                form.label_percent.Update();
            } while (packet.header == PacketType.Sending);
            data = BlindNetUtil.ByteTrimEndNull(data);

            FileInfo file = new FileInfo(dPath + fileName);
            int tmp = 1;
            while (file.Exists)
                file = new FileInfo(file.DirectoryName + "\\" + Path.GetFileNameWithoutExtension(fileName) + "(" + tmp++ + ")" + file.Extension);
            FileStream fs = file.OpenWrite();
            fs.Write(data, 0, data.Length);
            fs.Close();
            return true;
        }

        public async Task<bool> DownloadDir(ListViewItem item)
        {
            form.label_fName.Text = "(압축중)" + form.selected.FullPath + "\\" + item.Text;
            form.label_fName.Update();

            uint id = (uint)item.Tag;
            socket.CryptoSend(BitConverter.GetBytes(id), PacketType.DocDirDownload);

            BlindPacket packet = await Task.Run(socket.CryptoReceive);
            if (packet.header == PacketType.Fail)
                return false;

            form.label_fName.Text = form.selected.FullPath + "\\" + item.Text;
            form.label_fName.Update();

            string fileName = dPath + item.Text + ".zip";
            byte[] data = null;
            do
            {
                packet = socket.CryptoReceive();
                if (packet.header == PacketType.Disconnect)
                    return false;
                data = BlindNetUtil.MergeArray<byte>(data, packet.data);
                form.progressBar.PerformStep();
                form.progressBar.Update();
                form.label_percent.Text = (form.progressBar.Value * 100 / form.progressBar.Maximum) + "%";
                form.label_percent.Update();
            } while (packet.header == PacketType.Sending);
            data = BlindNetUtil.ByteTrimEndNull(data);

            FileInfo file = new FileInfo(fileName);
            int tmp = 1;
            while (file.Exists)
                file = new FileInfo(file.DirectoryName + "\\" + Path.GetFileNameWithoutExtension(fileName) + "(" + tmp++ + ")" + file.Extension);
            FileStream fs = file.OpenWrite();
            fs.Write(data, 0, data.Length);
            fs.Close();
            return true;
        }

        public int GetFilesSize(ListViewItem item)
        {
            int result = 0;

            if (item.SubItems[2].Text == string.Empty)
                socket.CryptoSend(BitConverter.GetBytes((uint)item.Tag), PacketType.DocGetDirSize);
            else
                socket.CryptoSend(BitConverter.GetBytes((uint)item.Tag), PacketType.DocGetFileSize);

            BlindPacket pack = socket.CryptoReceive();
            if (pack.header != PacketType.Response)
                return 0;
            byte[] tmp = new byte[8];
            Array.Copy(pack.data, 0, tmp, 0, tmp.Length);
            long size = BitConverter.ToInt64(tmp, 0);
            result = (int)(100 / ((double)BlindNetConst.DATASIZE * 100 / size)) + 1;

            return result;
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
