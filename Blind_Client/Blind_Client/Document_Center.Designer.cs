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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_funcType = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_fName = new System.Windows.Forms.Label();
            this.button_Download = new System.Windows.Forms.Button();
            this.botton_Upload = new System.Windows.Forms.Button();
            this.label_percent = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.text_rename = new System.Windows.Forms.TextBox();
            this.treeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.treeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeview_Dir
            // 
            this.treeview_Dir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(242)))));
            this.treeview_Dir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeview_Dir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeview_Dir.Font = new System.Drawing.Font("KoPub돋움체 Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeview_Dir.Location = new System.Drawing.Point(3, 32);
            this.treeview_Dir.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.treeview_Dir.Name = "treeview_Dir";
            this.treeview_Dir.Size = new System.Drawing.Size(178, 296);
            this.treeview_Dir.TabIndex = 2;
            this.treeview_Dir.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeview_Dir_AfterLabelEdit);
            this.treeview_Dir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeview_Dir_AfterSelect);
            this.treeview_Dir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeview_Dir_MouseDown);
            // 
            // listview_File
            // 
            this.listview_File.AllowColumnReorder = true;
            this.listview_File.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(242)))));
            this.listview_File.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview_File.CheckBoxes = true;
            this.listview_File.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.modDate,
            this.type,
            this.size});
            this.listview_File.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listview_File.Font = new System.Drawing.Font("KoPub돋움체 Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listview_File.HideSelection = false;
            this.listview_File.Location = new System.Drawing.Point(0, 0);
            this.listview_File.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.listview_File.Name = "listview_File";
            this.listview_File.OwnerDraw = true;
            this.listview_File.Size = new System.Drawing.Size(422, 294);
            this.listview_File.TabIndex = 3;
            this.listview_File.UseCompatibleStateImageBehavior = false;
            this.listview_File.View = System.Windows.Forms.View.Details;
            this.listview_File.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listview_File_DrawColumnHeader);
            this.listview_File.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listview_File_DrawItem);
            this.listview_File.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listview_File_DrawSubItem);
            this.listview_File.DoubleClick += new System.EventHandler(this.listview_File_DoubleClick);
            this.listview_File.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listview_File_MouseDown);
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
            this.size.Width = 107;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.treeview_Dir, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 330);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(118)))));
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.Controls.Add(this.label_funcType, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.progressBar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_fName, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Download, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.botton_Upload, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_percent, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(606, 32);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // label_funcType
            // 
            this.label_funcType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_funcType.AutoSize = true;
            this.label_funcType.Font = new System.Drawing.Font("KoPub돋움체 Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_funcType.ForeColor = System.Drawing.SystemColors.Control;
            this.label_funcType.Location = new System.Drawing.Point(5, 8);
            this.label_funcType.Name = "label_funcType";
            this.label_funcType.Size = new System.Drawing.Size(68, 16);
            this.label_funcType.TabIndex = 7;
            this.label_funcType.Text = "다운로드 : ";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar.Location = new System.Drawing.Point(78, 7);
            this.progressBar.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(131, 18);
            this.progressBar.TabIndex = 6;
            // 
            // label_fName
            // 
            this.label_fName.AutoSize = true;
            this.label_fName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_fName.Font = new System.Drawing.Font("KoPub돋움체 Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_fName.ForeColor = System.Drawing.SystemColors.Control;
            this.label_fName.Location = new System.Drawing.Point(256, 0);
            this.label_fName.Name = "label_fName";
            this.label_fName.Size = new System.Drawing.Size(233, 32);
            this.label_fName.TabIndex = 8;
            this.label_fName.Text = "Path";
            this.label_fName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_Download
            // 
            this.button_Download.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(118)))));
            this.button_Download.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_Download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Download.FlatAppearance.BorderSize = 0;
            this.button_Download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Download.Font = new System.Drawing.Font("KoPub돋움체 Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Download.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Download.Image = global::Blind_Client.Properties.Resources.download;
            this.button_Download.Location = new System.Drawing.Point(565, 2);
            this.button_Download.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Download.Name = "button_Download";
            this.button_Download.Size = new System.Drawing.Size(38, 28);
            this.button_Download.TabIndex = 5;
            this.button_Download.UseVisualStyleBackColor = false;
            this.button_Download.Click += new System.EventHandler(this.button_Download_Click);
            // 
            // botton_Upload
            // 
            this.botton_Upload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(118)))));
            this.botton_Upload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.botton_Upload.FlatAppearance.BorderSize = 0;
            this.botton_Upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botton_Upload.Font = new System.Drawing.Font("KoPub돋움체 Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.botton_Upload.ForeColor = System.Drawing.SystemColors.Control;
            this.botton_Upload.Image = global::Blind_Client.Properties.Resources.upload;
            this.botton_Upload.Location = new System.Drawing.Point(521, 2);
            this.botton_Upload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botton_Upload.Name = "botton_Upload";
            this.botton_Upload.Size = new System.Drawing.Size(38, 28);
            this.botton_Upload.TabIndex = 4;
            this.botton_Upload.UseVisualStyleBackColor = false;
            this.botton_Upload.Click += new System.EventHandler(this.botton_Upload_Click);
            // 
            // label_percent
            // 
            this.label_percent.AutoSize = true;
            this.label_percent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_percent.Font = new System.Drawing.Font("KoPub돋움체 Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_percent.ForeColor = System.Drawing.SystemColors.Control;
            this.label_percent.Location = new System.Drawing.Point(212, 0);
            this.label_percent.Name = "label_percent";
            this.label_percent.Size = new System.Drawing.Size(38, 32);
            this.label_percent.TabIndex = 9;
            this.label_percent.Text = "0%";
            this.label_percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.text_rename);
            this.panel1.Controls.Add(this.listview_File);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(184, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 294);
            this.panel1.TabIndex = 9;
            // 
            // text_rename
            // 
            this.text_rename.Location = new System.Drawing.Point(77, 2);
            this.text_rename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_rename.Name = "text_rename";
            this.text_rename.Size = new System.Drawing.Size(88, 21);
            this.text_rename.TabIndex = 4;
            this.text_rename.Visible = false;
            this.text_rename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_rename_KeyDown);
            this.text_rename.Leave += new System.EventHandler(this.text_rename_Leave);
            // 
            // treeMenu
            // 
            this.treeMenu.Font = new System.Drawing.Font("KoPub돋움체 Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.treeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.treeMenu.Name = "contextMenuStrip1";
            this.treeMenu.Size = new System.Drawing.Size(184, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // uploadMenu
            // 
            this.uploadMenu.Font = new System.Drawing.Font("KoPub돋움체 Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uploadMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uploadMenu.Name = "uploadMenu";
            this.uploadMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // listMenu
            // 
            this.listMenu.Font = new System.Drawing.Font("KoPub돋움체 Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.listMenu.Name = "listMenu";
            this.listMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // Document_Center
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Document_Center";
            this.Size = new System.Drawing.Size(606, 330);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ContextMenuStrip uploadMenu;
        private System.Windows.Forms.ContextMenuStrip listMenu;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label_funcType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Label label_fName;
        public System.Windows.Forms.Label label_percent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox text_rename;
    }
}
