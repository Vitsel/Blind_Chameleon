using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BlindNet;

namespace Blind_Client
{
    public class Doc_Center
    {
        BlindSocket socket;
        Document_Center form;

        public Doc_Center(Document_Center form)
        {
            this.form = form;
        }

        public async void Run()
        {
            socket = new BlindSocket();
            await socket.ConnectWithECDHAsync(BlindNetConst.ServerIP, BlindNetConst.DocCenterPort);

            UpdateRoot();
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
            while(true)
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
