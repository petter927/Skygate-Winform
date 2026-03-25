namespace SkyGate_ADONET
{
    partial class OTRequestUserControl
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.lblApplicant = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartHour = new System.Windows.Forms.Label();
            this.cmbStartHour = new System.Windows.Forms.ComboBox();
            this.lblStartMinute = new System.Windows.Forms.Label();
            this.cmbStartMinute = new System.Windows.Forms.ComboBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndHour = new System.Windows.Forms.Label();
            this.cmbEndHour = new System.Windows.Forms.ComboBox();
            this.lblEndMinute = new System.Windows.Forms.Label();
            this.cmbEndMinute = new System.Windows.Forms.ComboBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.dgvOTHistory = new System.Windows.Forms.DataGridView();
            this.lblHistory = new System.Windows.Forms.Label();
            this.btnRefreshHistory = new System.Windows.Forms.Button();
            this.grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOTHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.Location = new System.Drawing.Point(10, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(117, 26);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "加班登記單";
            // 
            // lblApplicant
            // 
            this.lblApplicant.AutoSize = true;
            this.lblApplicant.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblApplicant.Location = new System.Drawing.Point(31, 59);
            this.lblApplicant.Name = "lblApplicant";
            this.lblApplicant.Size = new System.Drawing.Size(73, 20);
            this.lblApplicant.TabIndex = 2;
            this.lblApplicant.Text = "申請人：";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblStartTime.Location = new System.Drawing.Point(31, 96);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(121, 20);
            this.lblStartTime.TabIndex = 18;
            this.lblStartTime.Text = "加班開始時間：";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(153, 94);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 25);
            this.dtpStartDate.TabIndex = 19;
            // 
            // lblStartHour
            // 
            this.lblStartHour.AutoSize = true;
            this.lblStartHour.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblStartHour.Location = new System.Drawing.Point(333, 96);
            this.lblStartHour.Name = "lblStartHour";
            this.lblStartHour.Size = new System.Drawing.Size(22, 18);
            this.lblStartHour.TabIndex = 20;
            this.lblStartHour.Text = "時";
            // 
            // cmbStartHour
            // 
            this.cmbStartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartHour.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cmbStartHour.Location = new System.Drawing.Point(273, 94);
            this.cmbStartHour.Name = "cmbStartHour";
            this.cmbStartHour.Size = new System.Drawing.Size(60, 25);
            this.cmbStartHour.TabIndex = 21;
            // 
            // lblStartMinute
            // 
            this.lblStartMinute.AutoSize = true;
            this.lblStartMinute.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblStartMinute.Location = new System.Drawing.Point(423, 96);
            this.lblStartMinute.Name = "lblStartMinute";
            this.lblStartMinute.Size = new System.Drawing.Size(22, 18);
            this.lblStartMinute.TabIndex = 22;
            this.lblStartMinute.Text = "分";
            // 
            // cmbStartMinute
            // 
            this.cmbStartMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartMinute.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cmbStartMinute.Location = new System.Drawing.Point(363, 94);
            this.cmbStartMinute.Name = "cmbStartMinute";
            this.cmbStartMinute.Size = new System.Drawing.Size(60, 25);
            this.cmbStartMinute.TabIndex = 23;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblEndTime.Location = new System.Drawing.Point(31, 136);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(121, 20);
            this.lblEndTime.TabIndex = 24;
            this.lblEndTime.Text = "加班結束時間：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(153, 134);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 25);
            this.dtpEndDate.TabIndex = 25;
            // 
            // lblEndHour
            // 
            this.lblEndHour.AutoSize = true;
            this.lblEndHour.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblEndHour.Location = new System.Drawing.Point(333, 136);
            this.lblEndHour.Name = "lblEndHour";
            this.lblEndHour.Size = new System.Drawing.Size(22, 18);
            this.lblEndHour.TabIndex = 26;
            this.lblEndHour.Text = "時";
            // 
            // cmbEndHour
            // 
            this.cmbEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndHour.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cmbEndHour.Location = new System.Drawing.Point(273, 134);
            this.cmbEndHour.Name = "cmbEndHour";
            this.cmbEndHour.Size = new System.Drawing.Size(60, 25);
            this.cmbEndHour.TabIndex = 27;
            // 
            // lblEndMinute
            // 
            this.lblEndMinute.AutoSize = true;
            this.lblEndMinute.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblEndMinute.Location = new System.Drawing.Point(423, 136);
            this.lblEndMinute.Name = "lblEndMinute";
            this.lblEndMinute.Size = new System.Drawing.Size(22, 18);
            this.lblEndMinute.TabIndex = 28;
            this.lblEndMinute.Text = "分";
            // 
            // cmbEndMinute
            // 
            this.cmbEndMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndMinute.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cmbEndMinute.Location = new System.Drawing.Point(363, 134);
            this.cmbEndMinute.Name = "cmbEndMinute";
            this.cmbEndMinute.Size = new System.Drawing.Size(60, 25);
            this.cmbEndMinute.TabIndex = 29;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblHours.Location = new System.Drawing.Point(33, 179);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(89, 20);
            this.lblHours.TabIndex = 30;
            this.lblHours.Text = "加班時數：";
            // 
            // txtHours
            // 
            this.txtHours.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.txtHours.Location = new System.Drawing.Point(153, 177);
            this.txtHours.Name = "txtHours";
            this.txtHours.ReadOnly = true;
            this.txtHours.Size = new System.Drawing.Size(100, 25);
            this.txtHours.TabIndex = 31;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.btnCalculate.Location = new System.Drawing.Point(253, 176);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(80, 25);
            this.btnCalculate.TabIndex = 32;
            this.btnCalculate.Text = "計算時數";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblReason.Location = new System.Drawing.Point(33, 219);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(89, 20);
            this.lblReason.TabIndex = 33;
            this.lblReason.Text = "加班理由：";
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.txtReason.Location = new System.Drawing.Point(153, 217);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(300, 80);
            this.txtReason.TabIndex = 34;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnSubmit.Location = new System.Drawing.Point(153, 306);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 40);
            this.btnSubmit.TabIndex = 35;
            this.btnSubmit.Text = "送出申請";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblStatus.Location = new System.Drawing.Point(290, 306);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(106, 18);
            this.lblStatus.TabIndex = 36;
            this.lblStatus.Text = "請填寫加班資訊";
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.dgvOTHistory);
            this.grpHistory.Controls.Add(this.lblHistory);
            this.grpHistory.Controls.Add(this.btnRefreshHistory);
            this.grpHistory.Location = new System.Drawing.Point(37, 351);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(601, 237);
            this.grpHistory.TabIndex = 37;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "本月份加班記錄";
            // 
            // dgvOTHistory
            // 
            this.dgvOTHistory.AllowUserToAddRows = false;
            this.dgvOTHistory.AllowUserToDeleteRows = false;
            this.dgvOTHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOTHistory.Location = new System.Drawing.Point(6, 44);
            this.dgvOTHistory.Name = "dgvOTHistory";
            this.dgvOTHistory.ReadOnly = true;
            this.dgvOTHistory.RowHeadersVisible = false;
            this.dgvOTHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOTHistory.Size = new System.Drawing.Size(589, 154);
            this.dgvOTHistory.TabIndex = 10;
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistory.Location = new System.Drawing.Point(230, 18);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(106, 21);
            this.lblHistory.TabIndex = 11;
            this.lblHistory.Text = "本月記錄清單";
            // 
            // btnRefreshHistory
            // 
            this.btnRefreshHistory.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.btnRefreshHistory.Location = new System.Drawing.Point(256, 204);
            this.btnRefreshHistory.Name = "btnRefreshHistory";
            this.btnRefreshHistory.Size = new System.Drawing.Size(80, 25);
            this.btnRefreshHistory.TabIndex = 12;
            this.btnRefreshHistory.Text = "重新整理";
            this.btnRefreshHistory.Click += new System.EventHandler(this.btnRefreshHistory_Click);
            // 
            // OTRequestUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartHour);
            this.Controls.Add(this.cmbStartHour);
            this.Controls.Add(this.lblStartMinute);
            this.Controls.Add(this.cmbStartMinute);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndHour);
            this.Controls.Add(this.cmbEndHour);
            this.Controls.Add(this.lblEndMinute);
            this.Controls.Add(this.cmbEndMinute);
            this.Controls.Add(this.lblApplicant);
            this.Controls.Add(this.labelTitle);
            this.Name = "OTRequestUserControl";
            this.Size = new System.Drawing.Size(670, 750);
            this.Load += new System.EventHandler(this.OTRequestUserControl_Load);
            this.grpHistory.ResumeLayout(false);
            this.grpHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOTHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label lblApplicant;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStartHour;
        private System.Windows.Forms.ComboBox cmbStartHour;
        private System.Windows.Forms.Label lblStartMinute;
        private System.Windows.Forms.ComboBox cmbStartMinute;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEndHour;
        private System.Windows.Forms.ComboBox cmbEndHour;
        private System.Windows.Forms.Label lblEndMinute;
        private System.Windows.Forms.ComboBox cmbEndMinute;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgvOTHistory;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Button btnRefreshHistory;
    }
}
