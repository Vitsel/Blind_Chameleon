﻿namespace Blind_Client.BlindChatUI
{
    partial class Control_Room
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
            while(RoomItem_LayoutPanel.Controls.Count > 0)
            {
                RoomItem_LayoutPanel.Controls[0].Dispose();
            }

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RoomItem_LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_room = new System.Windows.Forms.Label();
            this.btn_Create = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12, 7, 22, 10);
            this.panel1.Size = new System.Drawing.Size(457, 70);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btn_Create);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(385, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(50, 53);
            this.panel2.TabIndex = 1;
            // 
            // RoomItem_LayoutPanel
            // 
            this.RoomItem_LayoutPanel.AutoScroll = true;
            this.RoomItem_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoomItem_LayoutPanel.Location = new System.Drawing.Point(0, 70);
            this.RoomItem_LayoutPanel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.RoomItem_LayoutPanel.Name = "RoomItem_LayoutPanel";
            this.RoomItem_LayoutPanel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.RoomItem_LayoutPanel.Size = new System.Drawing.Size(457, 430);
            this.RoomItem_LayoutPanel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Blind_Client.Properties.Resources.titleBack;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.lbl_room);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(12, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(137, 53);
            this.panel3.TabIndex = 2;
            // 
            // lbl_room
            // 
            this.lbl_room.BackColor = System.Drawing.Color.Transparent;
            this.lbl_room.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_room.Font = new System.Drawing.Font("KoPub돋움체 Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_room.Location = new System.Drawing.Point(0, 0);
            this.lbl_room.Name = "lbl_room";
            this.lbl_room.Size = new System.Drawing.Size(137, 53);
            this.lbl_room.TabIndex = 0;
            this.lbl_room.Text = "채팅";
            this.lbl_room.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Create
            // 
            this.btn_Create.BackColor = System.Drawing.Color.Transparent;
            this.btn_Create.BackgroundImage = global::Blind_Client.Properties.Resources.icon_add;
            this.btn_Create.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Create.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Create.FlatAppearance.BorderSize = 0;
            this.btn_Create.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Create.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create.Font = new System.Drawing.Font("KoPub돋움체 Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Create.ForeColor = System.Drawing.Color.White;
            this.btn_Create.Location = new System.Drawing.Point(0, 0);
            this.btn_Create.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(50, 53);
            this.btn_Create.TabIndex = 0;
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.button1_Click);
            // 
            // Control_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RoomItem_LayoutPanel);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Control_Room";
            this.Size = new System.Drawing.Size(457, 500);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_room;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Create;
        public System.Windows.Forms.FlowLayoutPanel RoomItem_LayoutPanel;
        private System.Windows.Forms.Panel panel3;
    }
}
