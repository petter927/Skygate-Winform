namespace SkyGate_ADONET
{
    partial class HRManagementUserControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.cmbSupervisor = new System.Windows.Forms.ComboBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.lblEDept = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lblEID = new System.Windows.Forms.Label();
            this.txtEID = new System.Windows.Forms.TextBox();
            this.lblEName = new System.Windows.Forms.Label();
            this.txtEName = new System.Windows.Forms.TextBox();
            this.lblETitle = new System.Windows.Forms.Label();
            this.lblEStatus = new System.Windows.Forms.Label();
            this.lblEHireDate = new System.Windows.Forms.Label();
            this.txtEHireDate = new System.Windows.Forms.TextBox();
            this.lblELeaveDate = new System.Windows.Forms.Label();
            this.txtELeaveDate = new System.Windows.Forms.TextBox();
            this.lblEEmail = new System.Windows.Forms.Label();
            this.txtEEmail = new System.Windows.Forms.TextBox();
            this.lblEphone = new System.Windows.Forms.Label();
            this.txtEphone = new System.Windows.Forms.TextBox();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.lblERole = new System.Windows.Forms.Label();
            this.txtETitle = new System.Windows.Forms.TextBox();
            this.cmbEStatus = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblHRMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDept
            // 
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(179, 176);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(121, 20);
            this.cmbDept.TabIndex = 0;
            // 
            // cmbSupervisor
            // 
            this.cmbSupervisor.FormattingEnabled = true;
            this.cmbSupervisor.Location = new System.Drawing.Point(179, 228);
            this.cmbSupervisor.Name = "cmbSupervisor";
            this.cmbSupervisor.Size = new System.Drawing.Size(121, 20);
            this.cmbSupervisor.TabIndex = 1;
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(179, 394);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(121, 20);
            this.cmbRole.TabIndex = 2;
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(3, 450);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.RowTemplate.Height = 24;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(664, 192);
            this.dataGridViewEmployees.TabIndex = 3;
            // 
            // lblEDept
            // 
            this.lblEDept.AutoSize = true;
            this.lblEDept.Location = new System.Drawing.Point(120, 176);
            this.lblEDept.Name = "lblEDept";
            this.lblEDept.Size = new System.Drawing.Size(53, 12);
            this.lblEDept.TabIndex = 11;
            this.lblEDept.Text = "部　　門";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(114, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 50);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "新增員工";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(326, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 50);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "修改員工";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(220, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(100, 50);
            this.btnFind.TabIndex = 21;
            this.btnFind.Text = "查詢員工";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(432, 10);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 50);
            this.btnDel.TabIndex = 22;
            this.btnDel.Text = "刪除員工";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lblEID
            // 
            this.lblEID.AutoSize = true;
            this.lblEID.Location = new System.Drawing.Point(120, 120);
            this.lblEID.Name = "lblEID";
            this.lblEID.Size = new System.Drawing.Size(53, 12);
            this.lblEID.TabIndex = 24;
            this.lblEID.Text = "員工編號";
            // 
            // txtEID
            // 
            this.txtEID.Location = new System.Drawing.Point(179, 114);
            this.txtEID.Name = "txtEID";
            this.txtEID.Size = new System.Drawing.Size(121, 22);
            this.txtEID.TabIndex = 23;
            // 
            // lblEName
            // 
            this.lblEName.AutoSize = true;
            this.lblEName.Location = new System.Drawing.Point(120, 150);
            this.lblEName.Name = "lblEName";
            this.lblEName.Size = new System.Drawing.Size(53, 12);
            this.lblEName.TabIndex = 26;
            this.lblEName.Text = "姓　　名";
            // 
            // txtEName
            // 
            this.txtEName.Location = new System.Drawing.Point(179, 144);
            this.txtEName.Name = "txtEName";
            this.txtEName.Size = new System.Drawing.Size(121, 22);
            this.txtEName.TabIndex = 25;
            // 
            // lblETitle
            // 
            this.lblETitle.AutoSize = true;
            this.lblETitle.Location = new System.Drawing.Point(120, 202);
            this.lblETitle.Name = "lblETitle";
            this.lblETitle.Size = new System.Drawing.Size(53, 12);
            this.lblETitle.TabIndex = 30;
            this.lblETitle.Text = "職　　務";
            // 
            // lblEStatus
            // 
            this.lblEStatus.AutoSize = true;
            this.lblEStatus.Location = new System.Drawing.Point(120, 260);
            this.lblEStatus.Name = "lblEStatus";
            this.lblEStatus.Size = new System.Drawing.Size(53, 12);
            this.lblEStatus.TabIndex = 34;
            this.lblEStatus.Text = "在職狀態";
            // 
            // lblEHireDate
            // 
            this.lblEHireDate.AutoSize = true;
            this.lblEHireDate.Location = new System.Drawing.Point(120, 288);
            this.lblEHireDate.Name = "lblEHireDate";
            this.lblEHireDate.Size = new System.Drawing.Size(53, 12);
            this.lblEHireDate.TabIndex = 36;
            this.lblEHireDate.Text = "入  職  日";
            // 
            // txtEHireDate
            // 
            this.txtEHireDate.Location = new System.Drawing.Point(179, 282);
            this.txtEHireDate.Name = "txtEHireDate";
            this.txtEHireDate.Size = new System.Drawing.Size(121, 22);
            this.txtEHireDate.TabIndex = 35;
            // 
            // lblELeaveDate
            // 
            this.lblELeaveDate.AutoSize = true;
            this.lblELeaveDate.Location = new System.Drawing.Point(120, 316);
            this.lblELeaveDate.Name = "lblELeaveDate";
            this.lblELeaveDate.Size = new System.Drawing.Size(53, 12);
            this.lblELeaveDate.TabIndex = 38;
            this.lblELeaveDate.Text = "離  職  日";
            // 
            // txtELeaveDate
            // 
            this.txtELeaveDate.Location = new System.Drawing.Point(179, 310);
            this.txtELeaveDate.Name = "txtELeaveDate";
            this.txtELeaveDate.Size = new System.Drawing.Size(121, 22);
            this.txtELeaveDate.TabIndex = 37;
            // 
            // lblEEmail
            // 
            this.lblEEmail.AutoSize = true;
            this.lblEEmail.Location = new System.Drawing.Point(120, 344);
            this.lblEEmail.Name = "lblEEmail";
            this.lblEEmail.Size = new System.Drawing.Size(53, 12);
            this.lblEEmail.TabIndex = 40;
            this.lblEEmail.Text = "電子信箱";
            // 
            // txtEEmail
            // 
            this.txtEEmail.Location = new System.Drawing.Point(179, 338);
            this.txtEEmail.Name = "txtEEmail";
            this.txtEEmail.Size = new System.Drawing.Size(121, 22);
            this.txtEEmail.TabIndex = 39;
            // 
            // lblEphone
            // 
            this.lblEphone.AutoSize = true;
            this.lblEphone.Location = new System.Drawing.Point(120, 372);
            this.lblEphone.Name = "lblEphone";
            this.lblEphone.Size = new System.Drawing.Size(53, 12);
            this.lblEphone.TabIndex = 42;
            this.lblEphone.Text = "行動電話";
            // 
            // txtEphone
            // 
            this.txtEphone.Location = new System.Drawing.Point(179, 366);
            this.txtEphone.Name = "txtEphone";
            this.txtEphone.Size = new System.Drawing.Size(121, 22);
            this.txtEphone.TabIndex = 41;
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.AutoSize = true;
            this.lblSupervisor.Location = new System.Drawing.Point(120, 234);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(53, 12);
            this.lblSupervisor.TabIndex = 43;
            this.lblSupervisor.Text = "主　　管";
            // 
            // lblERole
            // 
            this.lblERole.AutoSize = true;
            this.lblERole.Location = new System.Drawing.Point(120, 397);
            this.lblERole.Name = "lblERole";
            this.lblERole.Size = new System.Drawing.Size(53, 12);
            this.lblERole.TabIndex = 44;
            this.lblERole.Text = "權　　限";
            // 
            // txtETitle
            // 
            this.txtETitle.Location = new System.Drawing.Point(179, 196);
            this.txtETitle.Name = "txtETitle";
            this.txtETitle.Size = new System.Drawing.Size(121, 22);
            this.txtETitle.TabIndex = 45;
            // 
            // cmbEStatus
            // 
            this.cmbEStatus.FormattingEnabled = true;
            this.cmbEStatus.Location = new System.Drawing.Point(179, 255);
            this.cmbEStatus.Name = "cmbEStatus";
            this.cmbEStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbEStatus.TabIndex = 48;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSubmit.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(326, 365);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(138, 76);
            this.btnSubmit.TabIndex = 51;
            this.btnSubmit.Text = "送出";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblHRMessage
            // 
            this.lblHRMessage.AutoSize = true;
            this.lblHRMessage.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblHRMessage.Location = new System.Drawing.Point(10, 69);
            this.lblHRMessage.Name = "lblHRMessage";
            this.lblHRMessage.Size = new System.Drawing.Size(0, 25);
            this.lblHRMessage.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 53;
            this.label2.Text = "人事管理";
            // 
            // HRManagementUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHRMessage);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cmbEStatus);
            this.Controls.Add(this.txtETitle);
            this.Controls.Add(this.lblERole);
            this.Controls.Add(this.lblSupervisor);
            this.Controls.Add(this.lblEphone);
            this.Controls.Add(this.txtEphone);
            this.Controls.Add(this.lblEEmail);
            this.Controls.Add(this.txtEEmail);
            this.Controls.Add(this.lblELeaveDate);
            this.Controls.Add(this.txtELeaveDate);
            this.Controls.Add(this.lblEHireDate);
            this.Controls.Add(this.txtEHireDate);
            this.Controls.Add(this.lblEStatus);
            this.Controls.Add(this.lblETitle);
            this.Controls.Add(this.lblEName);
            this.Controls.Add(this.txtEName);
            this.Controls.Add(this.lblEID);
            this.Controls.Add(this.txtEID);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblEDept);
            this.Controls.Add(this.dataGridViewEmployees);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.cmbSupervisor);
            this.Controls.Add(this.cmbDept);
            this.Name = "HRManagementUserControl";
            this.Size = new System.Drawing.Size(670, 750);
            this.Load += new System.EventHandler(this.HRManagementUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.ComboBox cmbSupervisor;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label lblEID;
        private System.Windows.Forms.TextBox txtEID;
        private System.Windows.Forms.Label lblEName;
        private System.Windows.Forms.TextBox txtEName;
        private System.Windows.Forms.Label lblEDept;
        private System.Windows.Forms.Label lblETitle;
        private System.Windows.Forms.Label lblEStatus;
        private System.Windows.Forms.Label lblEHireDate;
        private System.Windows.Forms.TextBox txtEHireDate;
        private System.Windows.Forms.Label lblELeaveDate;
        private System.Windows.Forms.TextBox txtELeaveDate;
        private System.Windows.Forms.Label lblEEmail;
        private System.Windows.Forms.TextBox txtEEmail;
        private System.Windows.Forms.Label lblEphone;
        private System.Windows.Forms.TextBox txtEphone;
        private System.Windows.Forms.Label lblERole;
        private System.Windows.Forms.TextBox txtETitle;
        private System.Windows.Forms.ComboBox cmbEStatus;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblHRMessage;
        private System.Windows.Forms.Label label2;
    }
}
