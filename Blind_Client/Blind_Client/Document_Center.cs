using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Blind_Client
{
    public partial class Document_Center : UserControl
    {
        public Doc_Center docCenter;
        TreeNode selected;
        ListViewItem selectItem;
        bool isAddDir;
        string prevLabel;

        public Document_Center()
        {
            InitializeComponent();

            selected = null;
            selectItem = null;
            isAddDir = false;
            prevLabel = null;

            ImageList imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.opened_folder);
            treeview_Dir.ImageList = imageList;
            listview_File.LargeImageList = imageList;
            listview_File.SmallImageList = imageList;

            uploadMenu.Items.Add("파일", null, new EventHandler(UploadFile));
            uploadMenu.Items.Add("폴더", null, new EventHandler(UploadDir));
        }

        private async void button_Download_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection items = listview_File.CheckedItems;
            foreach (ListViewItem item in items)
            {
                bool result = false;
                if (item.SubItems[2].Text == string.Empty)
                    result = await docCenter.DownloadDir(item);
                else
                    result = await docCenter.DownloadFile(item);
                if (!result)
                    MessageBox.Show("'" + item.Text + "' 다운로드에 실패했습니다.");
            }
        }

        private TreeNode FindSameNode(uint id)
        {
            foreach (TreeNode node in treeview_Dir.Nodes)
                if (((Directory_Info)node.Tag).id == id)
                    return node;
            return null;
        }

        private void treeview_Dir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeview_Dir.SelectedNode = selected;

            if (treeview_Dir.SelectedNode != null)
            {
                treeview_Dir.SelectedNode.Nodes.Clear();
                docCenter.UpdateDir(treeview_Dir.SelectedNode);
                treeview_Dir.SelectedNode.Expand();
            }
        }

        private void treeview_Dir_MouseDown(object sender, MouseEventArgs e)
        {
            selected = treeview_Dir.GetNodeAt(e.Location) ?? selected;

            if (e.Button == MouseButtons.Right)
            {
                treeMenu.Items.Clear();
                if (selected != null)
                {
                    treeview_Dir.SelectedNode = selected;
                    treeMenu.Items.Add("폴더 추가", null, new EventHandler(treeMenu_AddDir));
                    if (selected.Parent != null)
                    {
                        treeMenu.Items.Add("폴더 삭제", null, new EventHandler(treeMenu_RemoveDir));
                        treeMenu.Items.Add("이름 변경", null, new EventHandler(treeMenu_ChangeName));
                    }
                    treeMenu.Items.Add("새로고침", null, new EventHandler(treeMenu_RefreshDir));
                }
                else
                {
                    treeMenu.Items.Add("새로고침", null, new EventHandler(treeMenu_RefreshDir));
                }
                treeMenu.Show(treeview_Dir, e.Location);
            }
        }

        private void treeMenu_AddDir(object sender, EventArgs e)
        {
            isAddDir = true;

            TreeNode subDir = new TreeNode();
            subDir.Text = "";
            subDir.ImageIndex = 0;
            subDir.SelectedImageIndex = 0;

            selected.Nodes.Add(subDir);
            selected.Expand();
            treeview_Dir.LabelEdit = true;
            subDir.BeginEdit();
        }

        private void treeMenu_RemoveDir(object sender, EventArgs e)
        {
            if (docCenter.RemoveDir(selected))
            {
                TreeNode tmp = selected.Parent;
                selected.Remove();
                selected = treeview_Dir.SelectedNode = tmp;
                docCenter.UpdateDir(tmp);
            }
            else
                MessageBox.Show("폴더 삭제에 실패했습니다.");
        }

        private void treeMenu_RefreshDir(object sender, EventArgs e)
        {
            if (selected != null)
            {
                selected.Nodes.Clear();
                docCenter.UpdateDir(selected);
                selected.Expand();
            }
            else
            {
                docCenter.UpdateRoot();
            }
        }

        private void treeMenu_ChangeName(object sender, EventArgs e)
        {
            if (!selected.IsEditing)
            {
                prevLabel = selected.Text;
                treeview_Dir.LabelEdit = true;
                selected.BeginEdit();
            }
        }

        private void treeview_Dir_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            char[] invalidChars = new char[] {
                ':', '\\', '/', '\'', '\"', ' ',
                '@', '.', ',', '!', '?', '*'
            };

            if (e.Label == null || e.Label.Length == 0)
            {
                e.CancelEdit = true;
                if (isAddDir)
                {
                    e.Node.Remove();
                    isAddDir = false;
                }
                else
                    e.Node.Text = prevLabel;
                treeview_Dir.LabelEdit = false;
                return;
            }

            if (e.Label.IndexOfAny(invalidChars) != -1)
            {
                e.CancelEdit = true;
                MessageBox.Show("잘못된 이름입니다.");
                e.Node.BeginEdit();
                return;
            }

            TreeNode sameDir = IsInSameDir(e.Node.Parent, e.Label);
            if (sameDir != null)
            {
                if (MessageBox.Show("이미 같은 이름의 폴더가 존재합니다.존재합니다. 덮어 쓰시겠습니까?", "폴더 이름 변경", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Node.EndEdit(false);
                    if (docCenter.RemoveDir(sameDir))
                        sameDir.Remove();
                    else
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("덮어쓰기에 실패했습니다.");
                        e.Node.BeginEdit();
                        return;
                    }
                }
                else
                {
                    e.CancelEdit = true;
                    e.Node.BeginEdit();
                    return;
                }
            }

            e.Node.EndEdit(false);
            if (isAddDir)
            {
                if (docCenter.AddDir(e.Node, e.Label))
                    docCenter.UpdateDir(e.Node.Parent);
                else
                {
                    MessageBox.Show("폴더 생성에 실패했습니다.");
                    e.Node.Remove();
                }
            }
            else
            {
                if (docCenter.UpdateNameDir(e.Node, e.Label))
                    docCenter.UpdateDir(selected);
                else
                {
                    MessageBox.Show("이름 변경에 실패했습니다.");
                    e.Node.Text = prevLabel;
                }
            }

            isAddDir = false;
            treeview_Dir.LabelEdit = false;
            prevLabel = null;
        }

        TreeNode IsInSameDir(TreeNode parent, string name)
        {
            foreach (TreeNode node in parent.Nodes)
            {
                if (name == node.Text)
                    return node;
            }
            return null;
        }

        ListViewItem IsInSameFile(string name)
        {
            foreach (ListViewItem item in listview_File.Items)
            {
                if (item.Text == name)
                    return item;
            }
            return null;
        }

        private void botton_Upload_Click(object sender, EventArgs e)
        {
            Control button = (Control)sender;
            uploadMenu.Show(botton_Upload, 0, button.Height);
        }

        private async void UploadFile(object sender, EventArgs e)
        {
            if (treeview_Dir.SelectedNode == null)
            {
                MessageBox.Show("폴더를 선택하세요.");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "파일 선택";
            ofd.FileName = "파일명";
            ofd.Filter = "모든 파일 (*.*) | *.*";
            ofd.SupportMultiDottedExtensions = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            string[] selectFiles = ofd.FileNames;

            for (int i = 0; i < selectFiles.Length; i++)
            {
                if (IsInSameFile(Path.GetFileName(selectFiles[i])) != null)
                    if (MessageBox.Show("이미 " + Path.GetFileName(selectFiles[i]) + " 파일이 존재합니다.\n덮어 쓰시겠습니까?", "파일 업로드", MessageBoxButtons.YesNo) == DialogResult.No)
                        selectFiles[i] = null;
            }

            foreach (string path in selectFiles)
            {
                if (path == null)
                    continue;
                FileInfo fi = new FileInfo(path);
                await docCenter.UploadFileAsync(treeview_Dir.SelectedNode, fi);
            }
            docCenter.UpdateDir(treeview_Dir.SelectedNode);
        }

        private async void UploadDir(object sender, EventArgs e)
        {
            CommonOpenFileDialog dlg = new CommonOpenFileDialog();
            dlg.IsFolderPicker = true;
            dlg.Title = "폴더 선택";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == CommonFileDialogResult.Cancel)
                return;

            if (treeview_Dir.SelectedNode == null)
            {
                MessageBox.Show("폴더를 선택하세요.");
                return;
            }

            string[] selectDirs = dlg.FileNames.ToArray();

            for (int i = 0; i < selectDirs.Length; i++)
            {
                TreeNode sameDir = IsInSameDir(treeview_Dir.SelectedNode, Path.GetFileName(selectDirs[i]));
                if (sameDir != null)
                {
                    if (MessageBox.Show("이미 같은 이름의 폴더가 존재합니다.존재합니다. 덮어 쓰시겠습니까?", "폴더 이름 변경", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (docCenter.RemoveDir(sameDir))
                            sameDir.Remove();
                        else
                        {
                            MessageBox.Show(Path.GetFileName(selectDirs[i]) + " 폴더 삭제를 실패했습니다.");
                            return;
                        }
                    }
                    else
                        selectDirs[i] = null;
                }
            }

            foreach (string path in selectDirs)
            {
                TreeNode newNode = await docCenter.UploadDirAsync(treeview_Dir.SelectedNode, path);
                if (newNode == null)
                {
                    MessageBox.Show("폴더 생성에 실패했습니다.");
                    return;
                }

                treeview_Dir.SelectedNode.Nodes.Add(newNode);
                DirectoryInfo dir = new DirectoryInfo(path);
                await UploadSubFiles(newNode, dir);
            }

            docCenter.UpdateDir(treeview_Dir.SelectedNode);
        }

        private async Task UploadSubFiles(TreeNode node, DirectoryInfo dir)
        {
            foreach (FileInfo f in dir.GetFiles())
                await docCenter.UploadFileAsync(node, f);

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                TreeNode n = await docCenter.UploadDirAsync(node, d.FullName);
                await UploadSubFiles(n, d);
            }
        }

        ///
        ///listview_file 
        ///
        private void listview_File_MouseDown(object sender, MouseEventArgs e)
        {
            selectItem = listview_File.GetItemAt(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
            {
                listMenu.Items.Clear();
                if (selectItem != null)
                {
                    if (!selectItem.Checked)
                    {
                        foreach (ListViewItem item in listview_File.Items)
                            item.Checked = false;
                        selectItem.Checked = true;
                    }
                    listMenu.Items.Add("삭제", null, new EventHandler(listMenu_Remove));
                    //listMenu.Items.Add("이동", null, new EventHandler(treeMenu_ChangeName));

                    if (listview_File.CheckedItems.Count == 1)
                        listMenu.Items.Add("이름 변경", null, new EventHandler(treeMenu_ChangeName));
                }
                else
                {
                    listview_File.SelectedItems.Clear();
                    listMenu.Items.Add("폴더 추가", null, new EventHandler(treeMenu_AddDir));
                    listMenu.Items.Add("파일 업로드", null, new EventHandler(UploadFile));
                    listMenu.Items.Add("폴더 업로드", null, new EventHandler(UploadDir));
                    listMenu.Items.Add("새로고침", null, new EventHandler(treeMenu_RefreshDir));
                }
                listMenu.Show(treeview_Dir, e.Location);
            }
        }

        private void listMenu_Remove(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listview_File.CheckedItems)
            {
                bool result = false;
                if (item.SubItems[2].Text == string.Empty)
                {
                    foreach (TreeNode node in selected.Nodes)
                        if (node.Text == item.Text)
                            result = docCenter.RemoveDir(node);
                }
                else
                    result = docCenter.RemoveFile((uint)item.Tag);
                item.Remove();
                if (!result)
                    MessageBox.Show("오류가 발생했습니다.");
            }
            docCenter.UpdateDir(selected);
        }

        private void listview_File_DoubleClick(object sender, EventArgs e)
        {
            string text = listview_File.FocusedItem.Text;
            foreach (TreeNode node in selected.Nodes)
            {
                if (node.Text == text)
                {
                    selected = node;
                    treeview_Dir.SelectedNode = node;
                    return;
                }
            }
        }
    }
}
