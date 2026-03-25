using SkyGate_Winform.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyGate_ADONET
{
    public partial class LeaveRequestUserControl : UserControl
    {
        private string connectionString = ConnectionStringHelper.GetConnectionString();
        private List<AttachmentInfo> attachments = new List<AttachmentInfo>();

        public LeaveRequestUserControl()
        {
            InitializeComponent();
            LoadUserInfo();
            LoadLeaveEmployees();
            LoadLeaveTypes();
            InitializeTimeComboBoxes(); 
            SetDefaultDateTime();
            InitializeDataGridView();         
        }
        
        private class AttachmentInfo
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public long FileSize { get; set; }
            public string DisplayText => $"{FileName} ({FormatFileSize(FileSize)})";

            private static string FormatFileSize(long bytes)
            {
                string[] sizes = { "B", "KB", "MB", "GB" };
                int order = 0;
                double len = bytes;
                while (len >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    len = len / 1024;
                }
                return $"{len:0.##} {sizes[order]}";
            }
        }        
        
        private void InitializeTimeComboBoxes()
        {
            for (int i = 0; i < 24; i++)
            {
                string hour = i.ToString("D2");
                cmbStartHour.Items.Add(hour);
                cmbEndHour.Items.Add(hour);
            }

            cmbStartMinute.Items.Add("00");
            cmbStartMinute.Items.Add("30");
            cmbEndMinute.Items.Add("00");
            cmbEndMinute.Items.Add("30");

            cmbStartHour.SelectedIndex = 8;
            cmbStartMinute.SelectedIndex = 0;
            cmbEndHour.SelectedIndex = 17;
            cmbEndMinute.SelectedIndex = 0;

            cmbStartHour.SelectedIndexChanged += TimeComboBox_SelectedIndexChanged;
            cmbStartMinute.SelectedIndexChanged += TimeComboBox_SelectedIndexChanged;
            cmbEndHour.SelectedIndexChanged += TimeComboBox_SelectedIndexChanged;
            cmbEndMinute.SelectedIndexChanged += TimeComboBox_SelectedIndexChanged;
        }

        private void InitializeDataGridView()
        {
            dgvLeaveHistory.Columns.Clear();

            dgvLeaveHistory.Columns.Add("LeaveID", "請假單號");
            //dgvLeaveHistory.Columns.Add("ApplyName", "申請人");
            dgvLeaveHistory.Columns.Add("EmpName", "請假者");
            dgvLeaveHistory.Columns.Add("LeaveName", "假別");
            dgvLeaveHistory.Columns.Add("StartDate", "起始日期");
            //dgvLeaveHistory.Columns.Add("StartTime", "起始時間");
            dgvLeaveHistory.Columns.Add("EndDate", "結束日期");
            //dgvLeaveHistory.Columns.Add("EndTime", "結束時間");
            dgvLeaveHistory.Columns.Add("Hours", "請假時數");
            dgvLeaveHistory.Columns.Add("Status", "狀態");
            //dgvLeaveHistory.Columns.Add("LeaveReason", "請假理由");
            //dgvLeaveHistory.Columns.Add("ApproverName", "核准主管");

            dgvLeaveHistory.Columns["LeaveID"].Width = 120;
            //dgvLeaveHistory.Columns["ApplyName"].Width = 80;
            dgvLeaveHistory.Columns["EmpName"].Width = 80;
            dgvLeaveHistory.Columns["LeaveName"].Width = 80;
            dgvLeaveHistory.Columns["StartDate"].Width = 80;
            //dgvLeaveHistory.Columns["StartTime"].Width = 80;
            dgvLeaveHistory.Columns["EndDate"].Width = 80;
            //dgvLeaveHistory.Columns["EndTime"].Width = 80;
            dgvLeaveHistory.Columns["Hours"].Width = 80;
            dgvLeaveHistory.Columns["Status"].Width = 80;
            //dgvLeaveHistory.Columns["LeaveReason"].Width = 150;
            //dgvLeaveHistory.Columns["ApproverName"].Width = 80;

            foreach (DataGridViewColumn column in dgvLeaveHistory.Columns)
            {
                column.ReadOnly = true;
            }

            dgvLeaveHistory.CellDoubleClick += DgvLeaveHistory_CellDoubleClick;
        }

        private void SetStatusColor()
        {
            foreach (DataGridViewRow row in dgvLeaveHistory.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    switch (status)
                    {
                        case "核准":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                            break;
                        case "駁回":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                            break;
                        case "申請中":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                            break;
                    }
                }
            }
        }

        private void SetDefaultDateTime()
        {
            DateTime today = DateTime.Today;
            dtpStartDate.Value = today;
            dtpEndDate.Value = today;
        }

        private void ClearLeaveRequestForm()
        {
            try
            {
                if (cboLeaveEmployee.Items.Count > 0)
                {
                    cboLeaveEmployee.SelectedIndex = 0;
                }

                if (cboLeaveType.Items.Count > 0)
                {
                    cboLeaveType.SelectedIndex = 0;
                }

                DateTime today = DateTime.Today;
                dtpStartDate.Value = today;
                dtpEndDate.Value = today;

                cmbStartHour.SelectedIndex = 8;
                cmbStartMinute.SelectedIndex = 0;
                cmbEndHour.SelectedIndex = 17;
                cmbEndMinute.SelectedIndex = 0;

                txtHours.Text = "";
                txtHours.Clear();

                txtReason.Text = "";
                txtReason.Clear();

                attachments.Clear();
                lstAttachments.Items.Clear();

                // 8.重置狀態訊息
                //lblStatus.Text = "表單已重置，請填寫新的請假申請";

                // 9.將焦點設置到第一個控制項
                cboLeaveEmployee.Focus();
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"清除表單時發生錯誤：{ex.Message}";
            }
        }
        private bool ValidateTimeNull(string startOrend,string hour,string min)
        {
            if (string.IsNullOrEmpty(hour) || string.IsNullOrEmpty(min))
            {
                lblStatus.Text = $"錯誤：請選擇完整的{startOrend}時間 (時/分)。";
                txtHours.Text = "";
                return false; 
            }
            else             
            {
                return true;
            }
        }
        private bool ValidateInput()
        {
            lblStatus.ForeColor = Color.Red;
            if (cboLeaveEmployee.SelectedItem == null)
            {
                lblStatus.Text = "請選擇請假者";
                return false;
            }

            if (cboLeaveType.SelectedItem == null)
            {
                lblStatus.Text = "請選擇假別";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHours.Text))
            {
                lblStatus.Text = "請先計算請假時數";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                lblStatus.Text = "請填寫請假理由";
                txtReason.Focus();
                return false;
            }

            if (cmbStartHour.SelectedItem == null || cmbStartMinute.SelectedItem == null ||
                cmbEndHour.SelectedItem == null || cmbEndMinute.SelectedItem == null)
            {
                lblStatus.Text = "請完整選擇開始和結束時間";
                return false;
            }

            DateTime startDate = dtpStartDate.Value.Date;
            string startHour = cmbStartHour.SelectedItem.ToString();
            string startMinute = cmbStartMinute.SelectedItem.ToString();
            DateTime startTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, int.Parse(startHour), int.Parse(startMinute), 0);

            DateTime endDate = dtpEndDate.Value.Date;
            string endHour = cmbEndHour.SelectedItem.ToString();
            string endMinute = cmbEndMinute.SelectedItem.ToString();
            DateTime endTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, int.Parse(endHour), int.Parse(endMinute), 0);

            if (endTime <= startTime)
            {
                lblStatus.Text = "結束時間必須晚於開始時間";
                string str1 = lblStatus.Text;
                return false;
            }

            if (startTime < DateTime.Now)
            {
                lblStatus.Text = "請假時間不能是過去時間";
                return false;
            }
            lblStatus.ForeColor = Color.Black;
            return true;
        }

        private void LoadLeaveHistory()
        {
            try
            {                
                dgvLeaveHistory.Rows.Clear();

                string sql = @" SELECT lr.LeaveID, ae.EmpName as ApplyName, le.EmpName as EmpName, lt.LeaveName, lr.StartTime, lr.EndTime, lr.Hours, lr.Status, lr.LeaveReason, approver.EmpName as ApproverName
                                                FROM LeaveRequest lr
                                                INNER JOIN Employee ae ON lr.ApplyID = ae.EmpID
                                                INNER JOIN Employee le ON lr.EmpID = le.EmpID
                                                INNER JOIN LeaveType lt ON lr.LeaveTypeId = lt.LeaveTypeID
                                                LEFT JOIN Employee approver ON lr.ApproverID = approver.EmpID
                                                WHERE lr.EmpID = @EmpID
                                                ORDER BY lr.StartTime DESC";                

                using (SqlConnection con = new SqlConnection(connectionString))
                    
                using (SqlCommand cmd = new SqlCommand(sql, con))               
                {    
                    cmd.Parameters.AddWithValue("@ApplyID", UserInfo.EmpID);
                    cmd.Parameters.AddWithValue("@EmpID", UserInfo.EmpID);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            DateTime startTime = (DateTime)reader["StartTime"];
                            DateTime endTime = (DateTime)reader["EndTime"];

                            dgvLeaveHistory.Rows.Add(
                                reader["LeaveID"].ToString(),
                               //reader["ApplyName"].ToString(),
                                reader["EmpName"].ToString(),
                                reader["LeaveName"].ToString(),
                                startTime.ToString("yyyy-MM-dd"),
                                //startTime.ToString("HH:mm"),
                                endTime.ToString("yyyy-MM-dd"),
                                //endTime.ToString("HH:mm"),
                                reader["Hours"].ToString(),
                                reader["Status"].ToString()
                                //reader["LeaveReason"].ToString(),
                                //reader["ApproverName"]?.ToString() ?? "尚未指派"
                                
                            );
                        }
                    }
                }                
               SetStatusColor();
            }
            catch (Exception ex)
            {               
                MessageBox.Show($"載入請假記錄失敗：{ex.Message}", "錯誤",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLeaveEmployees()
        {
            try
            {
                string sql = "SELECT EmpID, EmpName FROM Employee WHERE Status = 1 ORDER BY EmpName";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cboLeaveEmployee.Items.Clear();

                        cboLeaveEmployee.Items.Add(new
                        {
                            EmpID = UserInfo.EmpID,
                            EmpName = UserInfo.EmpName + " (本人)"
                        });

                        while (reader.Read())
                        {
                            if (reader["EmpID"].ToString() != UserInfo.EmpID)
                            {
                                cboLeaveEmployee.Items.Add(new
                                {
                                    EmpID = reader["EmpID"].ToString(),
                                    EmpName = reader["EmpName"].ToString()
                                });
                            }
                        }
                    }
                }

                cboLeaveEmployee.DisplayMember = "EmpName";
                cboLeaveEmployee.ValueMember = "EmpID";

                if (cboLeaveEmployee.Items.Count > 0)
                {
                    cboLeaveEmployee.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"載入員工清單失敗：{ex.Message}";
            }
        }

        private void LoadLeaveTypes()
        {
            try
            {
                string sql = "SELECT LeaveTypeID, LeaveName FROM LeaveType  ORDER BY LeaveName";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cboLeaveType.Items.Clear();
                        while (reader.Read())
                        {
                            cboLeaveType.Items.Add(new
                            {
                                LeaveTypeID = reader["LeaveTypeID"].ToString(),
                                LeaveName = reader["LeaveName"].ToString()
                            });
                        }
                    }
                }

                cboLeaveType.DisplayMember = "LeaveName";
                cboLeaveType.ValueMember = "LeaveTypeID";

                if (cboLeaveType.Items.Count > 0)
                {
                    cboLeaveType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"載入假別失敗：{ex.Message}";
            }
        }

        private void LoadUserInfo()
        {
            lblApplicant.Text = $"申請人：{UserInfo.EmpName}";
        }

        private void ShowLeaveDetail(string leaveID)
        {
            try
            {
                string sql = @"
                    SELECT 
                        lr.*,
                        applyEmp.EmpName as ApplyName,
                        leaveEmp.EmpName as EmpName,
                        lt.LeaveName,
                        approver.EmpName as ApproverName
                    FROM LeaveRequest lr
                    INNER JOIN Employee applyEmp ON lr.ApplyID = applyEmp.EmpID
                    INNER JOIN Employee leaveEmp ON lr.EmpID = leaveEmp.EmpID
                    INNER JOIN LeaveType lt ON lr.LeaveTypeId = lt.LeaveTypeID
                    LEFT JOIN Employee approver ON lr.ApproverID = approver.EmpID
                    WHERE lr.LeaveID = @LeaveID";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@LeaveID", leaveID);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            StringBuilder detail = new StringBuilder();
                            detail.AppendLine($"申請單號：{reader["LeaveID"]}");
                            detail.AppendLine($"申請人：{reader["ApplyName"]}");
                            detail.AppendLine($"請假者：{reader["EmpName"]}");
                            detail.AppendLine($"假別：{reader["LeaveName"]}");

                            DateTime startTime = (DateTime)reader["StartTime"];
                            DateTime endTime = (DateTime)reader["EndTime"];
                            detail.AppendLine($"請假時間：{startTime:yyyy-MM-dd HH:mm} 至 {endTime:yyyy-MM-dd HH:mm}");
                            detail.AppendLine($"請假時數：{reader["Hours"]} 小時");
                            detail.AppendLine($"狀態：{reader["Status"]}");
                            detail.AppendLine($"請假理由：{reader["LeaveReason"]}");
                            detail.AppendLine($"核准主管：{reader["ApproverName"]?.ToString() ?? "尚未指派"}");
                            detail.AppendLine($"備註：{reader["Remark"]?.ToString() ?? "無"}");

                            MessageBox.Show(detail.ToString(), "請假詳細資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取詳細資訊失敗：{ex.Message}", "錯誤",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetBossEmailByEmpID(string empID)
        {
            string email = string.Empty;
            try
            {
                string sql = "Select b.email from employee a join employee b on a.SupervisorID = b.EmpID where a.empid = @EmpID";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmpID", empID);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        email = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"取得主管Email失敗：{ex.Message}";
            }
            return email;
        }

        private void RefreshAttachmentList()
        {
            lstAttachments.Items.Clear();
            foreach (var attachment in attachments)
            {
                lstAttachments.Items.Add(attachment.DisplayText);
            }
        }
                
        private string GenerateAttachmentID()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string randomPart = new Random().Next(100, 999).ToString();
            return $"ATT{timestamp}{randomPart}";
        }

        private void SendNotificationEmail(string toAddress, string subject, string body)
        {
            try
            {
                // 設定寄件者與SMTP伺服器
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sender@test.local");   // hMailServer建立的帳號
                mail.To.Add(toAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false; // 如果要寄HTML格式可改為 true

                // 設定SMTP
                SmtpClient smtp = new SmtpClient("localhost", 25); // hMailServer預設監聽25 port
                smtp.Credentials = new NetworkCredential("sender@test.local", "12345"); //寄件者帳號及密碼
                smtp.EnableSsl = false; // hMailServer預設不啟用SSL，可依設定調整

                smtp.Send(mail);
                MessageBox.Show("通知信已成功寄出！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("寄信失敗：" + ex.Message);
            }
        }

        private string MailBody(string leaveEmpName,DateTime startTime,DateTime endTime,string leaveID, string leverType,string reason)
        {
            string body = $"請假單號 : {leaveID}\n" +
                            $"員工姓名 : {leaveEmpName}\n" +
                            $"假別 : {leverType}\n" +
                            $"請假開始日期 : {startTime.ToString()}\n" +
                            $"請假結束日期 : {endTime.ToString()}\n" +
                            $"事由 : {reason}";

            return body;
        }

        private void SubmitLeaveRequest()
        {
            try
            {
                if (!ValidateInput()) return;

                string leaveID = GenerateLeaveID();
                
                DateTime startTime = CombineDateTime(dtpStartDate.Value, cmbStartHour.SelectedItem?.ToString(), cmbStartMinute.SelectedItem?.ToString());
                DateTime endTime = CombineDateTime(dtpEndDate.Value, cmbEndHour.SelectedItem?.ToString(), cmbEndMinute.SelectedItem?.ToString());
                decimal hours = decimal.Parse(txtHours.Text);

                dynamic selectedLeaveType = cboLeaveType.SelectedItem;
                string leaveTypeId = selectedLeaveType.LeaveTypeID;

                dynamic selectedEmployee = cboLeaveEmployee.SelectedItem;
                string leaveEmpID = selectedEmployee.EmpID;
                string leaveEmpName = selectedEmployee.EmpName;

                string leverType = selectedLeaveType.LeaveName;
                string reason = txtReason.Text.Trim();

                if (SaveLeaveRequest(leaveID, leaveEmpID, startTime, endTime, hours, leaveTypeId))
                {                    
                    if (attachments.Count > 0)
                    {
                        SaveAttachments(leaveID);
                    }

                    lblStatus.Text = $"已為 {leaveEmpName} 送出請假申請，附件：{attachments.Count} 個，等待主管審核";
                    SendNotificationEmail(
                        GetBossEmailByEmpID(leaveEmpID), 
                        "請假申請通知",
                        MailBody(leaveEmpName, startTime, endTime, leaveID, leverType, reason)
                        ); 
                    ClearLeaveRequestForm();
                    LoadLeaveHistory();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"送出申請失敗：{ex.Message}";
            }
        }

        private DateTime CombineDateTime(DateTime date, string hour, string minute)
        {
            int hourValue = int.Parse(hour ?? "08");
            int minuteValue = int.Parse(minute ?? "00");
            return new DateTime(date.Year, date.Month, date.Day, hourValue, minuteValue, 0);
        }
        
        private bool SaveLeaveRequest(string leaveID, string leaveEmpID, DateTime startTime, DateTime endTime,
                                    decimal hours, string leaveTypeId)
        {
            string sql = @"INSERT INTO LeaveRequest 
                          (LeaveID, ApplyID, EmpID, LeaveTypeId, StartTime, EndTime, 
                           Hours, Status, LeaveReason, Remark) 
                          VALUES 
                          (@LeaveID, @ApplyID, @EmpID, @LeaveTypeId, @StartTime, @EndTime, 
                           @Hours, @Status, @LeaveReason, @Remark)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@LeaveID", leaveID);
                cmd.Parameters.AddWithValue("@ApplyID", UserInfo.EmpID);
                cmd.Parameters.AddWithValue("@EmpID", leaveEmpID);
                cmd.Parameters.AddWithValue("@LeaveTypeId", leaveTypeId);
                cmd.Parameters.AddWithValue("@StartTime", startTime);
                cmd.Parameters.AddWithValue("@EndTime", endTime);
                cmd.Parameters.AddWithValue("@Hours", hours);
                cmd.Parameters.AddWithValue("@Status", "申請中");
                cmd.Parameters.AddWithValue("@LeaveReason", txtReason.Text.Trim());
                cmd.Parameters.AddWithValue("@Remark", $"由 {UserInfo.EmpName} 代為申請，附件：{attachments.Count} 個");

                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        private void SaveAttachmentRecord(string leaveID, string fileName, string filePath, long fileSize)
        {
            string attachmentID = GenerateAttachmentID();

            string sql = @"INSERT INTO SystemAttachment 
                          (AttachmentID, ReferenceType, ReferenceID, FileName, FilePath, FileSize, UploadTime, UploadBy) 
                          VALUES 
                          (@AttachmentID, @ReferenceType, @ReferenceID, @FileName, @FilePath, @FileSize, @UploadTime, @UploadBy)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@AttachmentID", attachmentID);
                cmd.Parameters.AddWithValue("@ReferenceType", "LeaveRequest"); // 固定為請假申請類型
                cmd.Parameters.AddWithValue("@ReferenceID", leaveID); // 對應請假記錄的 LeaveID
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@FilePath", filePath);
                cmd.Parameters.AddWithValue("@FileSize", fileSize);
                cmd.Parameters.AddWithValue("@UploadTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@UploadBy", UserInfo.EmpID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private List<string> SaveAttachments(string leaveID)
        {
            List<string> savedFilePaths = new List<string>();

            string attachmentBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Attachments");
            if (!Directory.Exists(attachmentBasePath))
            {
                Directory.CreateDirectory(attachmentBasePath);
            }

            string referenceFolder = Path.Combine(attachmentBasePath, "LeaveRequest");
            if (!Directory.Exists(referenceFolder))
            {
                Directory.CreateDirectory(referenceFolder);
            }

            foreach (var attachment in attachments)
            {
                try
                {
                    // 使用 GUID 確保檔名唯一性
                    string fileExtension = Path.GetExtension(attachment.FileName);
                    string uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                    string destPath = Path.Combine(referenceFolder, uniqueFileName);

                    File.Copy(attachment.FilePath, destPath, true);

                    SaveAttachmentRecord(leaveID, attachment.FileName, destPath, attachment.FileSize);

                    savedFilePaths.Add(destPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"儲存附件 {attachment.FileName} 失敗：{ex.Message}", "錯誤",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return savedFilePaths;
        }

        private void CalculateHours()
        {
            try
            {                
                DateTime startDate = dtpStartDate.Value.Date;
                string startHour = cmbStartHour.SelectedItem?.ToString() ?? "";
                string startMinute = cmbStartMinute.SelectedItem?.ToString() ?? "";
                if(!ValidateTimeNull("開始", startHour, startMinute)) return;
                DateTime startTime = new DateTime(startDate.Year, startDate.Month, startDate.Day,int.Parse(startHour), int.Parse(startMinute), 0);
                                
                DateTime endDate = dtpEndDate.Value.Date;
                string endHour = cmbEndHour.SelectedItem?.ToString() ?? "";
                string endMinute = cmbEndMinute.SelectedItem?.ToString() ?? "";
                if (!ValidateTimeNull("結束", endHour, endMinute)) return;
                DateTime endTime = new DateTime(endDate.Year, endDate.Month, endDate.Day,int.Parse(endHour), int.Parse(endMinute), 0);
               
                if (endTime <= startTime)
                {
                    lblStatus.Text = "結束時間必須晚於開始時間";
                    txtHours.Text = "";
                    return;
                }

                //TimeSpan duration = endTime - startTime;
                TimeSpan totalDuration = CalculateDurationHours(startTime, endTime);
                decimal totalHours = (decimal)Math.Round(totalDuration.TotalHours, 2);

                txtHours.Text = totalHours.ToString("0.00");
                lblStatus.Text = $"計算完成：{totalHours} 小時";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"計算時數失敗：{ex.Message}";
            }
        }

        public TimeSpan CalculateDurationHours(DateTime start, DateTime end)
        {
            TimeSpan totalTime = TimeSpan.Zero;

            // 每日工作區間參數
            TimeSpan workStart = new TimeSpan(8, 0, 0); // 08:00,早上8點上班
            TimeSpan workEnd = new TimeSpan(17, 0, 0);   // 17:00,下午5點下班
            TimeSpan lunchStart = new TimeSpan(12, 0, 0); // 12:00,中午用餐開始時間
            TimeSpan lunchEnd = new TimeSpan(13, 0, 0);   // 13:00,中午用餐結束時間

            // 以天為計算單位
            for (DateTime date = start.Date; date <= end.Date; date = date.AddDays(1))//從設定的開始日到結束日,每次加一天
            {
                // 排除六日
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue; 
                }

                // 當天的開始時間與結束時間設定
                DateTime currentDayStart = date;
                DateTime currentDayEnd = date;
                
                //確認當天的開始時間
                if (date == start.Date)// 如果是第一天
                {
                    // 將開始時間限制在 08:00 到 17:00 之間，且不能晚於使用者選擇的 start time
                    DateTime earliestStart = currentDayStart.Date.Add(workStart);//將earliestStart設為第一天的日期及時間設為08:00
                    currentDayStart = (start > earliestStart) ? start : earliestStart;//如果第一天日期開始時間是晚於8點，則用此該開始時間，反之設8點

                    // 如果開始時間已經晚於 17:00，則進行下一天的計算
                    if (currentDayStart >= date.Add(workEnd)) continue;
                }
                else // 第一天後的確認，都從 08:00 開始算
                {
                    currentDayStart = currentDayStart.Date.Add(workStart);
                }

                //確認當天的結束時間
                if (date == end.Date)// 如果是最後一天
                {
                    // 將結束時間限制在 08:00 到 17:00 之間，且不能早於使用者選擇的 end time
                    DateTime latestEnd = currentDayEnd.Date.Add(workEnd);//將latestEnd設為最後一天的日期及時間設為17:00
                    currentDayEnd = (end < latestEnd) ? end : latestEnd;//如果最後一天日期結束時間是早於17點，則用此該結束時間，反之設17點

                    // 如果結束時間早於 08:00，則最後一天不必計算
                    if (currentDayEnd <= date.Add(workStart)) continue;
                }
                else // 最後一天之前的結束時間確認，都算 17:00
                {
                    currentDayEnd = currentDayEnd.Date.Add(workEnd);
                }

                // 若結束日期時間早於開始日期時間就不計算, 基本上不會執行, 因為這方法前已經有驗證了
                if (currentDayEnd <= currentDayStart)
                {
                    continue;
                }

                //-------開始計算當天有多少時數-------
                // 2. 計算應扣除午休多少時間
                TimeSpan durationBeforeLunch = TimeSpan.Zero;//先歸0

                // 午休開始時間 (當天 12:00)
                DateTime actualLunchStart = date.Add(lunchStart);
                // 午休結束時間 (當天 13:00)
                DateTime actualLunchEnd = date.Add(lunchEnd);

                // A. 如果當天結束時間是在午休12:00前, 則計算午休12:00前有多少時數(08:00-12:00)
                if (currentDayEnd <= actualLunchStart)
                {
                    durationBeforeLunch = currentDayEnd - currentDayStart;
                }
                // B. 如果當天開始時間是在午休13:00之後, 則計算計算午休13:00後有多少時數(13:00-17:00)
                else if (currentDayStart >= actualLunchEnd)
                {
                    durationBeforeLunch = currentDayEnd - currentDayStart;
                }
                // C. 如果以上都不是, 那就是有跨過午休時段(12:00-13:00)
                else
                {
                    // 計算午休前的時長 (從開始時間到 12:00, 但要確保開始時間早於12點)
                    DateTime part1End = (currentDayStart < actualLunchStart) ? actualLunchStart : currentDayStart;
                    durationBeforeLunch += part1End - currentDayStart;

                    // 計算午休後的時長 (從 13:00 到結束時間, 但要確保結束時間晚於13點)
                    DateTime part2Start = (currentDayEnd > actualLunchEnd) ? actualLunchEnd : currentDayEnd;
                    durationBeforeLunch += currentDayEnd - part2Start;
                }

                // 單日工作時數上限為 8 小時, 超過部分不計算, 基本上不會發生,做個保險
                if (durationBeforeLunch.TotalHours > 8)
                 {
                    durationBeforeLunch = TimeSpan.FromHours(8);
                 }

                totalTime += durationBeforeLunch;
            }

            

            return totalTime;
        }


        private string GenerateLeaveID()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string randomPart = new Random().Next(100, 999).ToString();
            return $"LV{timestamp}{randomPart}";
        }

        private void DgvLeaveHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvLeaveHistory.Rows.Count)
            {
                DataGridViewRow row = dgvLeaveHistory.Rows[e.RowIndex];
                string leaveID = row.Cells["LeaveID"].Value?.ToString();

                if (!string.IsNullOrEmpty(leaveID))
                {
                    ShowLeaveDetail(leaveID);
                }
            }
        }

        private void TimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateHours();
        }

        private void LeaveRequestUserControl_Load(object sender, EventArgs e)
        {
            LoadLeaveHistory(); 
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateHours();
        }

        private void btnRemoveAttachment_Click(object sender, EventArgs e)
        {
            if (lstAttachments.SelectedIndices.Count > 0)
            {
                // 從後往前移除，避免索引變動問題
                for (int i = lstAttachments.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    int selectedIndex = lstAttachments.SelectedIndices[i];
                    if (selectedIndex >= 0 && selectedIndex < attachments.Count)
                    {
                        attachments.RemoveAt(selectedIndex);
                    }
                }
                RefreshAttachmentList();
            }
            else
            {
                MessageBox.Show("請先選擇要移除的附件", "提示",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBrowseAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        FileInfo fileInfo = new FileInfo(filePath);

                        // 檢查檔案大小限制（例如 10MB）
                        if (fileInfo.Length > 10 * 1024 * 1024)
                        {
                            MessageBox.Show($"檔案 {fileInfo.Name} 超過 10MB 大小限制", "檔案太大",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        // 檢查是否已存在相同檔案
                        if (!attachments.Exists(a => a.FileName.Equals(fileInfo.Name, StringComparison.OrdinalIgnoreCase)))
                        {
                            attachments.Add(new AttachmentInfo
                            {
                                FileName = fileInfo.Name,
                                FilePath = filePath,
                                FileSize = fileInfo.Length
                            });
                        }
                    }
                    RefreshAttachmentList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"選擇檔案時發生錯誤：{ex.Message}", "錯誤",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitLeaveRequest();
        }
    }
}
