namespace SkyGate_ADONET
{
    partial class OTApproveUserControl
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
            this.groupBoxDetail = new System.Windows.Forms.GroupBox();
            this.txtOTID = new System.Windows.Forms.TextBox();
            this.lblOTID = new System.Windows.Forms.Label();
            this.txtManagerRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.txtOTReason = new System.Windows.Forms.TextBox();
            this.lblOTReason = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtOTDate = new System.Windows.Forms.TextBox();
            this.lblOTDate = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dgvOTList = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBoxDetail.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOTList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxDetail
            // 
            this.groupBoxDetail.Controls.Add(this.txtOTID);
            this.groupBoxDetail.Controls.Add(this.lblOTID);
            this.groupBoxDetail.Controls.Add(this.txtManagerRemark);
            this.groupBoxDetail.Controls.Add(this.lblRemark);
            this.groupBoxDetail.Controls.Add(this.btnReject);
            this.groupBoxDetail.Controls.Add(this.btnApprove);
            this.groupBoxDetail.Controls.Add(this.txtOTReason);
            this.groupBoxDetail.Controls.Add(this.lblOTReason);
            this.groupBoxDetail.Controls.Add(this.txtHours);
            this.groupBoxDetail.Controls.Add(this.lblHours);
            this.groupBoxDetail.Controls.Add(this.txtEndTime);
            this.groupBoxDetail.Controls.Add(this.lblEndTime);
            this.groupBoxDetail.Controls.Add(this.txtStartTime);
            this.groupBoxDetail.Controls.Add(this.lblStartTime);
            this.groupBoxDetail.Controls.Add(this.txtOTDate);
            this.groupBoxDetail.Controls.Add(this.lblOTDate);
            this.groupBoxDetail.Controls.Add(this.txtEmpName);
            this.groupBoxDetail.Controls.Add(this.lblEmpName);
            this.groupBoxDetail.Location = new System.Drawing.Point(7, 235);
            this.groupBoxDetail.Name = "groupBoxDetail";
            this.groupBoxDetail.Size = new System.Drawing.Size(660, 286);
            this.groupBoxDetail.TabIndex = 1;
            this.groupBoxDetail.TabStop = false;
            this.groupBoxDetail.Text = "加班詳細資訊";
            // 
            // txtOTID
            // 
            this.txtOTID.Location = new System.Drawing.Point(80, 40);
            this.txtOTID.Name = "txtOTID";
            this.txtOTID.ReadOnly = true;
            this.txtOTID.Size = new System.Drawing.Size(100, 22);
            this.txtOTID.TabIndex = 17;
            // 
            // lblOTID
            // 
            this.lblOTID.AutoSize = true;
            this.lblOTID.Location = new System.Drawing.Point(20, 43);
            this.lblOTID.Name = "lblOTID";
            this.lblOTID.Size = new System.Drawing.Size(53, 12);
            this.lblOTID.TabIndex = 16;
            this.lblOTID.Text = "加班單號";
            // 
            // txtManagerRemark
            // 
            this.txtManagerRemark.Location = new System.Drawing.Point(80, 180);
            this.txtManagerRemark.Multiline = true;
            this.txtManagerRemark.Name = "txtManagerRemark";
            this.txtManagerRemark.Size = new System.Drawing.Size(300, 50);
            this.txtManagerRemark.TabIndex = 15;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(20, 183);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(53, 12);
            this.lblRemark.TabIndex = 14;
            this.lblRemark.Text = "主管備註";
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
            // txtOTReason
            // 
            this.txtOTReason.Location = new System.Drawing.Point(80, 140);
            this.txtOTReason.Multiline = true;
            this.txtOTReason.Name = "txtOTReason";
            this.txtOTReason.ReadOnly = true;
            this.txtOTReason.Size = new System.Drawing.Size(300, 30);
            this.txtOTReason.TabIndex = 11;
            // 
            // lblOTReason
            // 
            this.lblOTReason.AutoSize = true;
            this.lblOTReason.Location = new System.Drawing.Point(20, 143);
            this.lblOTReason.Name = "lblOTReason";
            this.lblOTReason.Size = new System.Drawing.Size(53, 12);
            this.lblOTReason.TabIndex = 10;
            this.lblOTReason.Text = "加班事由";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(280, 75);
            this.txtHours.Name = "txtHours";
            this.txtHours.ReadOnly = true;
            this.txtHours.Size = new System.Drawing.Size(100, 22);
            this.txtHours.TabIndex = 9;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(220, 78);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(53, 12);
            this.lblHours.TabIndex = 8;
            this.lblHours.Text = "加班時數";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(280, 110);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(100, 22);
            this.txtEndTime.TabIndex = 7;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(220, 113);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(53, 12);
            this.lblEndTime.TabIndex = 6;
            this.lblEndTime.Text = "結束時間";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(80, 110);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(100, 22);
            this.txtStartTime.TabIndex = 5;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(20, 113);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(53, 12);
            this.lblStartTime.TabIndex = 4;
            this.lblStartTime.Text = "開始時間";
            // 
            // txtOTDate
            // 
            this.txtOTDate.Location = new System.Drawing.Point(80, 75);
            this.txtOTDate.Name = "txtOTDate";
            this.txtOTDate.ReadOnly = true;
            this.txtOTDate.Size = new System.Drawing.Size(100, 22);
            this.txtOTDate.TabIndex = 3;
            // 
            // lblOTDate
            // 
            this.lblOTDate.AutoSize = true;
            this.lblOTDate.Location = new System.Drawing.Point(20, 78);
            this.lblOTDate.Name = "lblOTDate";
            this.lblOTDate.Size = new System.Drawing.Size(53, 12);
            this.lblOTDate.TabIndex = 2;
            this.lblOTDate.Text = "加班日期";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(280, 40);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            this.txtEmpName.Size = new System.Drawing.Size(100, 22);
            this.txtEmpName.TabIndex = 1;
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(220, 43);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(53, 12);
            this.lblEmpName.TabIndex = 0;
            this.lblEmpName.Text = "申請人員";
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.dgvOTList);
            this.groupBoxList.Location = new System.Drawing.Point(4, 51);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(663, 178);
            this.groupBoxList.TabIndex = 2;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "待審核加班清單";
            // 
            // dgvOTList
            // 
            this.dgvOTList.AllowUserToAddRows = false;
            this.dgvOTList.AllowUserToDeleteRows = false;
            this.dgvOTList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOTList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOTList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOTList.Location = new System.Drawing.Point(3, 18);
            this.dgvOTList.MultiSelect = false;
            this.dgvOTList.Name = "dgvOTList";
            this.dgvOTList.ReadOnly = true;
            this.dgvOTList.RowHeadersVisible = false;
            this.dgvOTList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOTList.Size = new System.Drawing.Size(657, 157);
            this.dgvOTList.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.Location = new System.Drawing.Point(10, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(117, 26);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "加班審核單";
            // 
            // OTApproveUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxDetail);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.labelTitle);
            this.Name = "OTApproveUserControl";
            this.Size = new System.Drawing.Size(670, 750);
            this.Load += new System.EventHandler(this.OTApproveUserControl_Load);
            this.groupBoxDetail.ResumeLayout(false);
            this.groupBoxDetail.PerformLayout();
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOTList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDetail;
        private System.Windows.Forms.TextBox txtManagerRemark;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.TextBox txtOTReason;
        private System.Windows.Forms.Label lblOTReason;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.TextBox txtOTDate;
        private System.Windows.Forms.Label lblOTDate;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dgvOTList;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox txtOTID;
        private System.Windows.Forms.Label lblOTID;
    }
}
