using System;
using System.Windows.Forms;

namespace Blind_Client
{
    public partial class Document_Center : UserControl
    {
        public Doc_Center docCenter;
        TreeNode selected;
        bool isAddDir;
        string prevLabel;

        public Document_Center()
        {
            InitializeComponent();

            selected = null;
            isAddDir = false; 
            prevLabel = null;

            ImageList imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.opened_folder);
            treeview_Dir.ImageList = imageList;
            listview_File.LargeImageList = imageList;
            listview_File.SmallImageList = imageList;
        }

        private void button_Download_Click(object sender, EventArgs e)
        {
            
        }

        private void treeview_Dir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeview_Dir.SelectedNode = selected;

            if (selected != null)
            {
                selected.Nodes.Clear();
                docCenter.UpdateDir(selected);
                selected.Expand();
            }
        }

        private void treeview_Dir_MouseDown(object sender, MouseEventArgs e)
        {
            selected = treeview_Dir.GetNodeAt(e.Location);
            treeview_Dir.SelectedNode = selected;

            if (e.Button == MouseButtons.Right)
            {
                treeMenu.Items.Clear();
                if (selected != null)
                {
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
                selected.Remove();
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
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(invalidChars) == -1)
                    {
                        if (!IsInSameDir(e.Node.Parent, e.Label))
                        {
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
                                if (!docCenter.UpdateNameDir(e.Node, e.Label))
                                {
                                    MessageBox.Show("이름 변경에 실패했습니다.");
                                    e.Node.Text = prevLabel;
                                }
                                else if(selected != null)
                                    docCenter.UpdateDir(selected);
                            }
                        }
                        else
                        {
                            e.CancelEdit = true;
                            MessageBox.Show("이미 같은 이름의 폴더가 존재합니다.");
                            e.Node.BeginEdit();
                        }
                    }
                    else
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("잘못된 이름입니다.");
                        e.Node.BeginEdit();
                        return;
                    }
                }
                else
                {
                    e.CancelEdit = true;
                    MessageBox.Show("잘못된 이름입니다.");
                    e.Node.BeginEdit();
                }
            }
            else if(prevLabel == null)
            {
                e.Node.Remove();
            }
            else
            {
                e.Node.Text = prevLabel;
            }

            isAddDir = false;
            treeview_Dir.LabelEdit = false;
            prevLabel = null;
        }

        bool IsInSameDir(TreeNode parent, string name)
        {
            foreach (TreeNode node in parent.Nodes)
            {
                if (name == node.Text)
                    return true;
            }
            return false;
        }
    }
}
