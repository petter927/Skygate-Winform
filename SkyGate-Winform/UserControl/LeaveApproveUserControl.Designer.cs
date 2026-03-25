namespace SkyGate_ADONET
{
    partial class LeaveApproveUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBoxAttachments = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.groupBoxDetail = new System.Windows.Forms.GroupBox();
            this.txtManagerRemark = new System.Windows.Forms.TextBox();
            this.labelRemark = new System.Windows.Forms.Label();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.txtLeaveReason = new System.Windows.Forms.TextBox();
            this.labelLeaveReason = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.labelHours = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.txtLeaveType = new System.Windows.Forms.TextBox();
            this.labelLeaveType = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.labelEmpName = new System.Windows.Forms.Label();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dgvLeaveList = new System.Windows.Forms.DataGridView();
            this.groupBoxAttachments.SuspendLayout();
            this.groupBoxDetail.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveList)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.Location = new System.Drawing.Point(10, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(117, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "請假審核單";
            // 
            // groupBoxAttachments
            // 
            this.groupBoxAttachments.Controls.Add(this.btnDownload);
            this.groupBoxAttachments.Controls.Add(this.lstAttachments);
            this.groupBoxAttachments.Location = new System.Drawing.Point(18, 529);
            this.groupBoxAttachments.Name = "groupBoxAttachments";
            this.groupBoxAttachments.Size = new System.Drawing.Size(660, 151);
            this.groupBoxAttachments.TabIndex = 1;
            this.groupBoxAttachments.TabStop = false;
            this.groupBoxAttachments.Text = "申請附件";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(310, 30);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 30);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "下載附件";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lstAttachments
            // 
            this.lstAttachments.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstAttachments.FormattingEnabled = true;
            this.lstAttachments.ItemHeight = 12;
            this.lstAttachments.Location = new System.Drawing.Point(3, 18);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(300, 130);
            this.lstAttachments.TabIndex = 0;
            // 
            // groupBoxDetail
            // 
            this.groupBoxDetail.Controls.Add(this.txtManagerRemark);
            this.groupBoxDetail.Controls.Add(this.labelRemark);
            this.groupBoxDetail.Controls.Add(this.btnReject);
            this.groupBoxDetail.Controls.Add(this.btnApprove);
            this.groupBoxDetail.Controls.Add(this.txtLeaveReason);
            this.groupBoxDetail.Controls.Add(this.labelLeaveReason);
            this.groupBoxDetail.Controls.Add(this.txtHours);
            this.groupBoxDetail.Controls.Add(this.labelHours);
            this.groupBoxDetail.Controls.Add(this.txtEndTime);
            this.groupBoxDetail.Controls.Add(this.labelEndTime);
            this.groupBoxDetail.Controls.Add(this.txtStartTime);
            this.groupBoxDetail.Controls.Add(this.labelStartTime);
            this.groupBoxDetail.Controls.Add(this.txtLeaveType);
            this.groupBoxDetail.Controls.Add(this.labelLeaveType);
            this.groupBoxDetail.Controls.Add(this.txtEmpName);
            this.groupBoxDetail.Controls.Add(this.labelEmpName);
            this.groupBoxDetail.Location = new System.Drawing.Point(18, 237);
            this.groupBoxDetail.Name = "groupBoxDetail";
            this.groupBoxDetail.Size = new System.Drawing.Size(660, 286);
            this.groupBoxDetail.TabIndex = 0;
            this.groupBoxDetail.TabStop = false;
            this.groupBoxDetail.Text = "請假詳細資訊";
            // 
            // txtManagerRemark
            // 
            this.txtManagerRemark.Location = new System.Drawing.Point(80, 180);
            this.txtManagerRemark.Multiline = true;
            this.txtManagerRemark.Name = "txtManagerRemark";
            this.txtManagerRemark.Size = new System.Drawing.Size(300, 50);
            this.txtManagerRemark.TabIndex = 15;
            // 
            // labelRemark
            // 
            this.labelRemark.AutoSize = true;
            this.labelRemark.Location = new System.Drawing.Point(20, 183);
            this.labelRemark.Name = "labelRemark";
            this.labelRemark.Size = new System.Drawing.Size(53, 12);
            this.labelRemark.TabIndex = 14;
            this.labelRemark.Text = "主管備註";
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.Red;
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(305, 240);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 30);
            this.btnReject.TabIndex = 13;
            this.btnReject.Text = "駁回";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.Green;
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(220, 240);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 30);
            this.btnApprove.TabIndex = 12;
            this.btnApprove.Text = "核准";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // txtLeaveReason
            // 
            this.txtLeaveReason.Location = new System.Drawing.Point(80, 140);
            this.txtLeaveReason.Multiline = true;
            this.txtLeaveReason.Name = "txtLeaveReason";
            this.txtLeaveReason.ReadOnly = true;
            this.txtLeaveReason.Size = new System.Drawing.Size(300, 30);
            this.txtLeaveReason.TabIndex = 11;
            // 
            // labelLeaveReason
            // 
            this.labelLeaveReason.AutoSize = true;
            this.labelLeaveReason.Location = new System.Drawing.Point(20, 143);
            this.labelLeaveReason.Name = "labelLeaveReason";
            this.labelLeaveReason.Size = new System.Drawing.Size(53, 12);
            this.labelLeaveReason.TabIndex = 10;
            this.labelLeaveReason.Text = "請假事由";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(80, 110);
            this.txtHours.Name = "txtHours";
            this.txtHours.ReadOnly = true;
            this.txtHours.Size = new System.Drawing.Size(100, 22);
            this.txtHours.TabIndex = 9;
            // 
            // labelHours
            // 
            this.labelHours.AutoSize = true;
            this.labelHours.Location = new System.Drawing.Point(20, 113);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(53, 12);
            this.labelHours.TabIndex = 8;
            this.labelHours.Text = "請假時數";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(280, 75);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(100, 22);
            this.txtEndTime.TabIndex = 7;
            // 
            // labelEndTime
            // 
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.Location = new System.Drawing.Point(220, 78);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(53, 12);
            this.labelEndTime.TabIndex = 6;
            this.labelEndTime.Text = "結束時間";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(80, 75);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(100, 22);
            this.txtStartTime.TabIndex = 5;
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Location = new System.Drawing.Point(20, 78);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(53, 12);
            this.labelStartTime.TabIndex = 4;
            this.labelStartTime.Text = "開始時間";
            // 
            // txtLeaveType
            // 
            this.txtLeaveType.Location = new System.Drawing.Point(280, 40);
            this.txtLeaveType.Name = "txtLeaveType";
            this.txtLeaveType.ReadOnly = true;
            this.txtLeaveType.Size = new System.Drawing.Size(100, 22);
            this.txtLeaveType.TabIndex = 3;
            // 
            // labelLeaveType
            // 
            this.labelLeaveType.AutoSize = true;
            this.labelLeaveType.Location = new System.Drawing.Point(220, 43);
            this.labelLeaveType.Name = "labelLeaveType";
            this.labelLeaveType.Size = new System.Drawing.Size(53, 12);
            this.labelLeaveType.TabIndex = 2;
            this.labelLeaveType.Text = "假別類型";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(80, 40);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            this.txtEmpName.Size = new System.Drawing.Size(100, 22);
            this.txtEmpName.TabIndex = 1;
            // 
            // labelEmpName
            // 
            this.labelEmpName.AutoSize = true;
            this.labelEmpName.Location = new System.Drawing.Point(20, 43);
            this.labelEmpName.Name = "labelEmpName";
            this.labelEmpName.Size = new System.Drawing.Size(53, 12);
            this.labelEmpName.TabIndex = 0;
            this.labelEmpName.Text = "申請人員";
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.dgvLeaveList);
            this.groupBoxList.Location = new System.Drawing.Point(15, 53);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(663, 178);
            this.groupBoxList.TabIndex = 0;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "待審核請假清單";
            // 
            // dgvLeaveList
            // 
            this.dgvLeaveList.AllowUserToAddRows = false;
            this.dgvLeaveList.AllowUserToDeleteRows = false;
            this.dgvLeaveList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeaveList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeaveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLeaveList.Location = new System.Drawing.Point(3, 18);
            this.dgvLeaveList.MultiSelect = false;
            this.dgvLeaveList.Name = "dgvLeaveList";
            this.dgvLeaveList.ReadOnly = true;
            this.dgvLeaveList.RowHeadersVisible = false;
            this.dgvLeaveList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeaveList.Size = new System.Drawing.Size(657, 157);
            this.dgvLeaveList.TabIndex = 0;
            this.dgvLeaveList.SelectionChanged += new System.EventHandler(this.dgvLeaveList_SelectionChanged);
            // 
            // LeaveApproveUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxAttachments);
            this.Controls.Add(this.groupBoxDetail);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.labelTitle);
            this.Name = "LeaveApproveUserControl";
            this.Size = new System.Drawing.Size(705, 751);
            this.Load += new System.EventHandler(this.LeaveApproveUserControl_Load);
            this.groupBoxAttachments.ResumeLayout(false);
            this.groupBoxDetail.ResumeLayout(false);
            this.groupBoxDetail.PerformLayout();
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.GroupBox groupBoxAttachments;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ListBox lstAttachments;
        private System.Windows.Forms.GroupBox groupBoxDetail;
        private System.Windows.Forms.TextBox txtManagerRemark;
        private System.Windows.Forms.Label labelRemark;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.TextBox txtLeaveReason;
        private System.Windows.Forms.Label labelLeaveReason;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label labelEndTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.TextBox txtLeaveType;
        private System.Windows.Forms.Label labelLeaveType;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label labelEmpName;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dgvLeaveList;
    }
}