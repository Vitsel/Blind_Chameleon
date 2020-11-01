namespace Blind_Client.BlindChatUI.UserUI
{
    partial class User_Info
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_PositionText = new System.Windows.Forms.Label();
            this.lbl_DepartmentText = new System.Windows.Forms.Label();
            this.lbl_PhoneText = new System.Windows.Forms.Label();
            this.lbl_EmailText = new System.Windows.Forms.Label();
            this.lbl_BirthText = new System.Windows.Forms.Label();
            this.lbl_Position = new System.Windows.Forms.Label();
            this.lbl_Birth = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Department = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Name);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 50);
            this.panel1.TabIndex = 0;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Name.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(0, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(200, 50);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "-";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_PositionText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_DepartmentText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_PhoneText, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_EmailText, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_BirthText, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Position, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Birth, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Email, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Phone, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Department, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 350);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lbl_PositionText
            // 
            this.lbl_PositionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_PositionText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PositionText.Location = new System.Drawing.Point(103, 0);
            this.lbl_PositionText.Name = "lbl_PositionText";
            this.lbl_PositionText.Size = new System.Drawing.Size(94, 50);
            this.lbl_PositionText.TabIndex = 5;
            this.lbl_PositionText.Text = "-";
            this.lbl_PositionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DepartmentText
            // 
            this.lbl_DepartmentText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DepartmentText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DepartmentText.Location = new System.Drawing.Point(103, 50);
            this.lbl_DepartmentText.Name = "lbl_DepartmentText";
            this.lbl_DepartmentText.Size = new System.Drawing.Size(94, 50);
            this.lbl_DepartmentText.TabIndex = 9;
            this.lbl_DepartmentText.Text = "-";
            this.lbl_DepartmentText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PhoneText
            // 
            this.lbl_PhoneText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_PhoneText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PhoneText.Location = new System.Drawing.Point(103, 100);
            this.lbl_PhoneText.Name = "lbl_PhoneText";
            this.lbl_PhoneText.Size = new System.Drawing.Size(94, 50);
            this.lbl_PhoneText.TabIndex = 8;
            this.lbl_PhoneText.Text = "-";
            this.lbl_PhoneText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_EmailText
            // 
            this.lbl_EmailText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_EmailText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EmailText.Location = new System.Drawing.Point(103, 150);
            this.lbl_EmailText.Name = "lbl_EmailText";
            this.lbl_EmailText.Size = new System.Drawing.Size(94, 50);
            this.lbl_EmailText.TabIndex = 7;
            this.lbl_EmailText.Text = "-";
            this.lbl_EmailText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_BirthText
            // 
            this.lbl_BirthText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BirthText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BirthText.Location = new System.Drawing.Point(103, 200);
            this.lbl_BirthText.Name = "lbl_BirthText";
            this.lbl_BirthText.Size = new System.Drawing.Size(94, 50);
            this.lbl_BirthText.TabIndex = 6;
            this.lbl_BirthText.Text = "-";
            this.lbl_BirthText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Position
            // 
            this.lbl_Position.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Position.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Position.Location = new System.Drawing.Point(3, 0);
            this.lbl_Position.Name = "lbl_Position";
            this.lbl_Position.Size = new System.Drawing.Size(94, 50);
            this.lbl_Position.TabIndex = 0;
            this.lbl_Position.Text = "직급";
            this.lbl_Position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Birth
            // 
            this.lbl_Birth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Birth.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Birth.Location = new System.Drawing.Point(3, 200);
            this.lbl_Birth.Name = "lbl_Birth";
            this.lbl_Birth.Size = new System.Drawing.Size(94, 50);
            this.lbl_Birth.TabIndex = 4;
            this.lbl_Birth.Text = "생년월일";
            this.lbl_Birth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Email
            // 
            this.lbl_Email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Email.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.Location = new System.Drawing.Point(3, 150);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(94, 50);
            this.lbl_Email.TabIndex = 3;
            this.lbl_Email.Text = "이메일";
            this.lbl_Email.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Phone.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Phone.Location = new System.Drawing.Point(3, 100);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(94, 50);
            this.lbl_Phone.TabIndex = 2;
            this.lbl_Phone.Text = "전화";
            this.lbl_Phone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Department
            // 
            this.lbl_Department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Department.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Department.Location = new System.Drawing.Point(3, 50);
            this.lbl_Department.Name = "lbl_Department";
            this.lbl_Department.Size = new System.Drawing.Size(94, 50);
            this.lbl_Department.TabIndex = 1;
            this.lbl_Department.Text = "부서";
            this.lbl_Department.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // User_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "User_Info";
            this.Size = new System.Drawing.Size(200, 400);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Department;
        private System.Windows.Forms.Label lbl_Position;
        private System.Windows.Forms.Label lbl_Birth;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_PositionText;
        private System.Windows.Forms.Label lbl_DepartmentText;
        private System.Windows.Forms.Label lbl_PhoneText;
        private System.Windows.Forms.Label lbl_EmailText;
        private System.Windows.Forms.Label lbl_BirthText;
        private System.Windows.Forms.Label lbl_Name;
    }
}
