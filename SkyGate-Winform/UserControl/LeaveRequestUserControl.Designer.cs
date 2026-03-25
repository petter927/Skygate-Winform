using System.Drawing;
using System.Windows.Forms;

namespace SkyGate_ADONET
{
    partial class LeaveRequestUserControl
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblApplicant = new System.Windows.Forms.Label();
            this.lblLeaveEmployee = new System.Windows.Forms.Label();
            this.cboLeaveEmployee = new System.Windows.Forms.ComboBox();
            this.lblLeaveType = new System.Windows.Forms.Label();
            this.cboLeaveType = new System.Windows.Forms.ComboBox();
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
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.btnBrowseAttachment = new System.Windows.Forms.Button();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.btnRemoveAttachment = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblHistory = new System.Windows.Forms.Label();
            this.dgvLeaveHistory = new System.Windows.Forms.DataGridView();
            this.btnRefreshHistory = new System.Windows.Forms.Button();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveHistory)).BeginInit();
            this.grpHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "請假申請";
            // 
            // lblApplicant
            // 
            this.lblApplicant.AutoSize = true;
            this.lblApplicant.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblApplicant.Location = new System.Drawing.Point(37, 58);
            this.lblApplicant.Name = "lblApplicant";
            this.lblApplicant.Size = new System.Drawing.Size(73, 20);
            this.lblApplicant.TabIndex = 1;
            this.lblApplicant.Text = "申請人：";
            // 
            // lblLeaveEmployee
            // 
            this.lblLeaveEmployee.AutoSize = true;
            this.lblLeaveEmployee.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblLeaveEmployee.Location = new System.Drawing.Point(37, 98);
            this.lblLeaveEmployee.Name = "lblLeaveEmployee";
            this.lblLeaveEmployee.Size = new System.Drawing.Size(73, 20);
            this.lblLeaveEmployee.TabIndex = 2;
            this.lblLeaveEmployee.Text = "請假者：";
            // 
            // cboLeaveEmployee
            // 
            this.cboLeaveEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeaveEmployee.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cboLeaveEmployee.Location = new System.Drawing.Point(157, 96);
            this.cboLeaveEmployee.Name = "cboLeaveEmployee";
            this.cboLeaveEmployee.Size = new System.Drawing.Size(200, 25);
            this.cboLeaveEmployee.TabIndex = 3;
            // 
            // lblLeaveType
            // 
            this.lblLeaveType.AutoSize = true;
            this.lblLeaveType.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblLeaveType.Location = new System.Drawing.Point(37, 138);
            this.lblLeaveType.Name = "lblLeaveType";
            this.lblLeaveType.Size = new System.Drawing.Size(57, 20);
            this.lblLeaveType.TabIndex = 4;
            this.lblLeaveType.Text = "假別：";
            // 
            // cboLeaveType
            // 
            this.cboLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeaveType.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cboLeaveType.Location = new System.Drawing.Point(157, 136);
            this.cboLeaveType.Name = "cboLeaveType";
            this.cboLeaveType.Size = new System.Drawing.Size(200, 25);
            this.cboLeaveType.TabIndex = 5;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblStartTime.Location = new System.Drawing.Point(37, 178);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(89, 20);
            this.lblStartTime.TabIndex = 6;
            this.lblStartTime.Text = "開始時間：";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(157, 176);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 25);
            this.dtpStartDate.TabIndex = 7;
            // 
            // lblStartHour
            // 
            this.lblStartHour.AutoSize = true;
            this.lblStartHour.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblStartHour.Location = new System.Drawing.Point(337, 178);
            this.lblStartHour.Name = "lblStartHour";
            this.lblStartHour.Size = new System.Drawing.Size(22, 18);
            this.lblStartHour.TabIndex = 8;
            this.lblStartHour.Text = "時";
            // 
            // cmbStartHour
            // 
            this.cmbStartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartHour.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cmbStartHour.Location = new System.Drawing.Point(277, 176);
            this.cmbStartHour.Name = "cmbStartHour";
            this.cmbStartHour.Size = new System.Drawing.Size(60, 25);
            this.cmbStartHour.TabIndex = 9;
            // 
            // lblStartMinute
            // 
            this.lblStartMinute.AutoSize = true;
            this.lblStartMinute.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblStartMinute.Location = new System.Drawing.Point(427, 178);
            this.lblStartMinute.Name = "lblStartMinute";
            this.lblStartMinute.Size = new System.Drawing.Size(22, 18);
            this.lblStartMinute.TabIndex = 10;
            this.lblStartMinute.Text = "分";
            // 
            // cmbStartMinute
            // 
            this.cmbStartMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartMinute.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cmbStartMinute.Location = new System.Drawing.Point(367, 176);
            this.cmbStartMinute.Name = "cmbStartMinute";
            this.cmbStartMinute.Size = new System.Drawing.Size(60, 25);
            this.cmbStartMinute.TabIndex = 11;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblEndTime.Location = new System.Drawing.Point(37, 218);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(89, 20);
            this.lblEndTime.TabIndex = 12;
            this.lblEndTime.Text = "結束時間：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(157, 216);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 25);
            this.dtpEndDate.TabIndex = 13;
            // 
            // lblEndHour
            // 
            this.lblEndHour.AutoSize = true;
            this.lblEndHour.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblEndHour.Location = new System.Drawing.Point(337, 218);
            this.lblEndHour.Name = "lblEndHour";
            this.lblEndHour.Size = new System.Drawing.Size(22, 18);
            this.lblEndHour.TabIndex = 14;
            this.lblEndHour.Text = "時";
            // 
            // cmbEndHour
            // 
            this.cmbEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndHour.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cmbEndHour.Location = new System.Drawing.Point(277, 216);
            this.cmbEndHour.Name = "cmbEndHour";
            this.cmbEndHour.Size = new System.Drawing.Size(60, 25);
            this.cmbEndHour.TabIndex = 15;
            // 
            // lblEndMinute
            // 
            this.lblEndMinute.AutoSize = true;
            this.lblEndMinute.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblEndMinute.Location = new System.Drawing.Point(427, 218);
            this.lblEndMinute.Name = "lblEndMinute";
            this.lblEndMinute.Size = new System.Drawing.Size(22, 18);
            this.lblEndMinute.TabIndex = 16;
            this.lblEndMinute.Text = "分";
            // 
            // cmbEndMinute
            // 
            this.cmbEndMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndMinute.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cmbEndMinute.Location = new System.Drawing.Point(367, 216);
            this.cmbEndMinute.Name = "cmbEndMinute";
            this.cmbEndMinute.Size = new System.Drawing.Size(60, 25);
            this.cmbEndMinute.TabIndex = 17;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblHours.Location = new System.Drawing.Point(37, 258);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(89, 20);
            this.lblHours.TabIndex = 18;
            this.lblHours.Text = "請假時數：";
            // 
            // txtHours
            // 
            this.txtHours.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.txtHours.Location = new System.Drawing.Point(157, 256);
            this.txtHours.Name = "txtHours";
            this.txtHours.ReadOnly = true;
            this.txtHours.Size = new System.Drawing.Size(100, 25);
            this.txtHours.TabIndex = 19;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblReason.Location = new System.Drawing.Point(37, 298);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(89, 20);
            this.lblReason.TabIndex = 21;
            this.lblReason.Text = "請假理由：";
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.txtReason.Location = new System.Drawing.Point(157, 296);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(300, 80);
            this.txtReason.TabIndex = 22;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnSubmit.Location = new System.Drawing.Point(157, 476);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 40);
            this.btnSubmit.TabIndex = 23;
            this.btnSubmit.Text = "送出申請";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.btnCalculate.Location = new System.Drawing.Point(257, 255);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(80, 25);
            this.btnCalculate.TabIndex = 20;
            this.btnCalculate.Text = "計算時數";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblStatus.Location = new System.Drawing.Point(294, 476);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(106, 18);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "請填寫請假資訊";
            // 
            // lblAttachment
            // 
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblAttachment.Location = new System.Drawing.Point(38, 392);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(57, 20);
            this.lblAttachment.TabIndex = 0;
            this.lblAttachment.Text = "附件：";
            // 
            // btnBrowseAttachment
            // 
            this.btnBrowseAttachment.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.btnBrowseAttachment.Location = new System.Drawing.Point(157, 386);
            this.btnBrowseAttachment.Name = "btnBrowseAttachment";
            this.btnBrowseAttachment.Size = new System.Drawing.Size(100, 25);
            this.btnBrowseAttachment.TabIndex = 0;
            this.btnBrowseAttachment.Text = "選擇檔案";
            this.btnBrowseAttachment.Click += new System.EventHandler(this.btnBrowseAttachment_Click);
            // 
            // lstAttachments
            // 
            this.lstAttachments.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.lstAttachments.ItemHeight = 16;
            this.lstAttachments.Location = new System.Drawing.Point(157, 418);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAttachments.Size = new System.Drawing.Size(300, 52);
            this.lstAttachments.TabIndex = 0;
            // 
            // btnRemoveAttachment
            // 
            this.btnRemoveAttachment.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.btnRemoveAttachment.Location = new System.Drawing.Point(263, 387);
            this.btnRemoveAttachment.Name = "btnRemoveAttachment";
            this.btnRemoveAttachment.Size = new System.Drawing.Size(80, 25);
            this.btnRemoveAttachment.TabIndex = 0;
            this.btnRemoveAttachment.Text = "移除選取";
            this.btnRemoveAttachment.Click += new System.EventHandler(this.btnRemoveAttachment_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "所有檔案|*.*|圖片檔案|*.jpg;*.png;*.bmp|文件檔案|*.doc;*.docx;*.pdf;*.txt";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "選擇附件檔案";
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistory.Location = new System.Drawing.Point(230, 18);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(106, 21);
            this.lblHistory.TabIndex = 11;
            this.lblHistory.Text = "請假記錄清單";
            // 
            // dgvLeaveHistory
            // 
            this.dgvLeaveHistory.AllowUserToAddRows = false;
            this.dgvLeaveHistory.AllowUserToDeleteRows = false;
            this.dgvLeaveHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeaveHistory.Location = new System.Drawing.Point(6, 54);
            this.dgvLeaveHistory.Name = "dgvLeaveHistory";
            this.dgvLeaveHistory.ReadOnly = true;
            this.dgvLeaveHistory.RowHeadersVisible = false;
            this.dgvLeaveHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeaveHistory.Size = new System.Drawing.Size(589, 193);
            this.dgvLeaveHistory.TabIndex = 10;
            // 
            // btnRefreshHistory
            // 
            this.btnRefreshHistory.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.btnRefreshHistory.Location = new System.Drawing.Point(256, 253);
            this.btnRefreshHistory.Name = "btnRefreshHistory";
            this.btnRefreshHistory.Size = new System.Drawing.Size(80, 25);
            this.btnRefreshHistory.TabIndex = 12;
            this.btnRefreshHistory.Text = "重新整理";
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.dgvLeaveHistory);
            this.grpHistory.Controls.Add(this.lblHistory);
            this.grpHistory.Controls.Add(this.btnRefreshHistory);
            this.grpHistory.Location = new System.Drawing.Point(41, 522);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(601, 284);
            this.grpHistory.TabIndex = 11;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "請假記錄";
            // 
            // LeaveRequestUserControl
            // 
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblApplicant);
            this.Controls.Add(this.lblLeaveEmployee);
            this.Controls.Add(this.cboLeaveEmployee);
            this.Controls.Add(this.lblLeaveType);
            this.Controls.Add(this.cboLeaveType);
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
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblAttachment);
            this.Controls.Add(this.btnBrowseAttachment);
            this.Controls.Add(this.lstAttachments);
            this.Controls.Add(this.btnRemoveAttachment);
            this.Controls.Add(this.grpHistory);
            this.Name = "LeaveRequestUserControl";
            this.Size = new System.Drawing.Size(657, 829);
            this.Load += new System.EventHandler(this.LeaveRequestUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveHistory)).EndInit();
            this.grpHistory.ResumeLayout(false);
            this.grpHistory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // 控制項宣告
        private Label lblTitle;
        private Label lblApplicant;
        private Label lblLeaveEmployee;
        private ComboBox cboLeaveEmployee;
        private Label lblLeaveType;
        private ComboBox cboLeaveType;
        private Label lblStartTime;
        private DateTimePicker dtpStartDate;
        private Label lblStartHour;
        private ComboBox cmbStartHour;
        private Label lblStartMinute;
        private ComboBox cmbStartMinute;
        private Label lblEndTime;
        private DateTimePicker dtpEndDate;
        private Label lblEndHour;
        private ComboBox cmbEndHour;
        private Label lblEndMinute;
        private ComboBox cmbEndMinute;
        private Label lblHours;
        private TextBox txtHours;
        private Button btnCalculate;
        private Label lblReason;
        private TextBox txtReason;
        private Button btnSubmit;
        private Label lblStatus;

        private Label lblAttachment;
        private Button btnBrowseAttachment;
        private ListBox lstAttachments;
        private Button btnRemoveAttachment;
        private OpenFileDialog openFileDialog;

        private Label lblHistory;
        private DataGridView dgvLeaveHistory;
        private Button btnRefreshHistory;
        private GroupBox grpHistory;
    }
}
