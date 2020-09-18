namespace Blind_Client
{
    partial class Document_Center
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeview_Dir = new System.Windows.Forms.TreeView();
            this.listview_File = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.botton_Upload = new System.Windows.Forms.Button();
            this.button_Download = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.treeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeview_Dir
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.treeview_Dir, 2);
            this.treeview_Dir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeview_Dir.Location = new System.Drawing.Point(3, 43);
            this.treeview_Dir.Name = "treeview_Dir";
            this.treeview_Dir.Size = new System.Drawing.Size(215, 366);
            this.treeview_Dir.TabIndex = 2;
            this.treeview_Dir.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeview_Dir_AfterLabelEdit);
            this.treeview_Dir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeview_Dir_AfterSelect);
            this.treeview_Dir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeview_Dir_MouseDown);
            // 
            // listview_File
            // 
            this.listview_File.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.modDate,
            this.type,
            this.size});
            this.tableLayoutPanel1.SetColumnSpan(this.listview_File, 4);
            this.listview_File.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listview_File.HideSelection = false;
            this.listview_File.Location = new System.Drawing.Point(224, 43);
            this.listview_File.Name = "listview_File";
            this.listview_File.Size = new System.Drawing.Size(466, 366);
            this.listview_File.TabIndex = 3;
            this.listview_File.UseCompatibleStateImageBehavior = false;
            this.listview_File.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "이름";
            this.name.Width = 183;
            // 
            // modDate
            // 
            this.modDate.Text = "수정한 날짜";
            this.modDate.Width = 106;
            // 
            // type
            // 
            this.type.Text = "유형";
            this.type.Width = 87;
            // 
            // size
            // 
            this.size.Text = "크기";
            this.size.Width = 92;
            // 
            // botton_Upload
            // 
            this.botton_Upload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.botton_Upload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botton_Upload.Location = new System.Drawing.Point(504, 3);
            this.botton_Upload.Name = "botton_Upload";
            this.botton_Upload.Size = new System.Drawing.Size(89, 34);
            this.botton_Upload.TabIndex = 4;
            this.botton_Upload.Text = "Upload";
            this.botton_Upload.UseVisualStyleBackColor = true;
            // 
            // button_Download
            // 
            this.button_Download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Download.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Download.Location = new System.Drawing.Point(599, 3);
            this.button_Download.Name = "button_Download";
            this.button_Download.Size = new System.Drawing.Size(91, 34);
            this.button_Download.TabIndex = 5;
            this.button_Download.Text = "Download";
            this.button_Download.UseVisualStyleBackColor = true;
            this.button_Download.Click += new System.EventHandler(this.button_Download_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.12469F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.87531F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.Controls.Add(this.listview_File, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.treeview_Dir, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Download, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.botton_Upload, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(693, 412);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // treeMenu
            // 
            this.treeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.treeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.treeMenu.Name = "contextMenuStrip1";
            this.treeMenu.Size = new System.Drawing.Size(215, 28);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(214, 24);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // Document_Center
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Document_Center";
            this.Size = new System.Drawing.Size(693, 412);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.treeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader modDate;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.Button button_Download;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ColumnHeader size;
        public System.Windows.Forms.TreeView treeview_Dir;
        public System.Windows.Forms.ListView listview_File;
        public System.Windows.Forms.Button botton_Upload;
        private System.Windows.Forms.ContextMenuStrip treeMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
