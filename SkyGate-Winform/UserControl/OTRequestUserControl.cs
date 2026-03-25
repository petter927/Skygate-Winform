using SkyGate_Winform.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SkyGate_ADONET
{
    public partial class OTRequestUserControl : UserControl
    {
        private string connectionString = ConnectionStringHelper.GetConnectionString();
        public OTRequestUserControl()
        {
            InitializeComponent();
            InitialzeComboBox();
            InitialzeDataGridView();
        }

        #region Initialze相關

        private void InitialzeComboBox()
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

            cmbStartHour.SelectedIndex = 8;  // 08:00
            cmbStartMinute.SelectedIndex = 0;
            cmbEndHour.SelectedIndex = 17;   // 17:00
            cmbEndMinute.SelectedIndex = 0;

            //增加變動時間後計算時數的事件
            cmbStartHour.SelectedIndexChanged += cmbStartHour_SelectedIndexChanged;
            cmbStartMinute.SelectedIndexChanged += cmbStartMinute_SelectedIndexChanged;
            cmbEndHour.SelectedIndexChanged += cmbEndHour_SelectedIndexChanged;
            cmbEndMinute.SelectedIndexChanged += cmbEndMinute_SelectedIndexChanged;
        }

        private void InitialzeDataGridView()
        {
            dgvOTHistory.Rows.Clear();
            
            dgvOTHistory.Columns.Add("OTID", "加班單號");
            dgvOTHistory.Columns.Add("OTDate", "加班日期");
            dgvOTHistory.Columns.Add("StartTime", "開始時間");
            dgvOTHistory.Columns.Add("EndTime", "結束時間");
            dgvOTHistory.Columns.Add("Hours", "加班時數");
            dgvOTHistory.Columns.Add("Status", "狀態");
            dgvOTHistory.Columns.Add("Remark", "加班理由");

            dgvOTHistory.AutoResizeColumns();
        }

        #endregion




        #region 資料庫相關

        private bool saveOTRequest(string otID, string empID, DateTime oTDate, DateTime startTime, DateTime endTime, decimal hours, string status, string remark)
        {
            string sql = @"INSERT INTO OverTimeRequest (OTID, EmpID, OTDate, StartTime, EndTime, Hours, Status, ApproverID, Remark) 
                                        VALUES
                                         (@OTID, @EmpID, @OTDate, @StartTime, @EndTime, @Hours, @Status, @ApproverID, @Remark);";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@OTID", otID);
                cmd.Parameters.AddWithValue("@EmpID", empID);
                cmd.Parameters.AddWithValue("@OTDate", oTDate);
                cmd.Parameters.AddWithValue("@StartTime", startTime);
                cmd.Parameters.AddWithValue("@EndTime", endTime);
                cmd.Parameters.AddWithValue("@Hours", hours);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@ApproverID", DBNull.Value);
                cmd.Parameters.AddWithValue("@Remark", remark);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }

        }

        private void loadOTRequstList()
        {
            dgvOTHistory.Rows.Clear();

            DateTime now = DateTime.Now;
            DateTime firstOfMonth = new DateTime(now.Year,now.Month,1);
            DateTime endOfMonth = firstOfMonth.AddMonths(1);
            string sql = @"Select OTID, OTDate, StartTime, EndTime, Hours, Status, Remark
                                    from OverTimeRequest 
                                    where EmpID = @EmpID
                                    AND OTDate >= @firstOfMonth 
                                    AND OTDate < @endOfMonth
                                    Order by OTDate ASC;";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmpID", UserInfo.EmpID);
                cmd.Parameters.AddWithValue("@firstOfMonth", firstOfMonth);                
                cmd.Parameters.AddWithValue("@endOfMonth", endOfMonth);
                
                con.Open();
                
               using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime startDateTime = (DateTime)reader["startTime"];
                        DateTime endDateTime = (DateTime)reader["endtime"];
                        string remark = getTheString(reader["Remark"].ToString(), "#理由-", "-理由#");
                        string hours = ((Decimal)reader["Hours"]).ToString("0.0");
                        

                        dgvOTHistory.Rows.Add(
                            reader["OTID"].ToString(),
                            startDateTime.ToString("yyyy/MM/dd"),
                            startDateTime.ToString("HH:mm"),
                            endDateTime.ToString("HH:mm"),
                            hours,
                            reader["Status"].ToString(),
                            remark
                            );
                    }

                }

            }
        }
        
        #endregion

        #region 方法
        /// <summary>
        /// 檢查控制項是否都有填寫資料
        /// </summary>
        /// <returns></returns>
        private bool ValidateInput()
        {
            lblStatus.ForeColor = Color.Red;
            //檢查日期是否空值, 失敗回傳false
            if (cmbStartHour.SelectedItem == null)
            {
                lblStatus.Text = "加班開始小時未填寫!";
                return false;
            }
            if (cmbStartMinute.SelectedItem == null)
            {
                lblStatus.Text = "加班開始分鐘未填寫!";
                return false;
            }
            if (cmbEndHour.SelectedItem == null)
            {
                lblStatus.Text = "加班結束小時未填寫!";
                return false;
            }
            if (cmbEndMinute.SelectedItem == null)
            {
                lblStatus.Text = "加班結束分鐘未填寫!";
                return false;
            }

            DateTime startDateTime = getStartDateTime();
            DateTime endDateTime = getEndDateTime();
            if (startDateTime >= endDateTime)
            {
                lblStatus.Text = "開始日期時間不可大於結束時間!";
                return false;
            }

            //檢查加班理由是否沒填寫, 失敗回傳false
            if (txtReason.Text == null)
            {
                lblStatus.Text = "請填寫加班理由!";
                return false;
            }
            lblStatus.ForeColor = Color.Black;
            return true;
        }

        /// <summary>
        /// 製作流水號
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private string generateOTID(string startName)
        {
            string dateTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            string seriesNo = new Random().Next(100, 999).ToString();
            return $"{startName}{dateTimeStamp}{seriesNo}";
        }

        private DateTime getStartDateTime()
        {
            DateTime startDate = dtpStartDate.Value.Date;
            string startHour = cmbStartHour.SelectedItem.ToString();
            string startMinute = cmbStartMinute.SelectedItem.ToString();
            DateTime startDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, int.Parse(startHour), int.Parse(startMinute), 0);
            return startDateTime;
        }
        private DateTime getEndDateTime()
        {
            DateTime endDate = dtpEndDate.Value.Date;
            string endHour = cmbEndHour.SelectedItem.ToString();
            string endMinute = cmbEndMinute.SelectedItem.ToString();
            DateTime endDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, int.Parse(endHour), int.Parse(endMinute), 0);
            return endDateTime;
        }
        private decimal getOTHour()
        {
            DateTime startTime = getStartDateTime();
            DateTime endTime = getEndDateTime();
            if (startTime > endTime)
            {
                lblStatus.Text = "結束時間必須晚於開始時間";
                txtHours.Text = "";
                return 0;
            }
            //TimeSpan duration = endTime - startTime;
            (bool tf,TimeSpan duration, string message) = CalculateOvertimeHours(startTime, endTime);
            decimal oTHour = 0;
            if (tf)
            {
                oTHour = (decimal)Math.Round(duration.TotalHours, 2);
            }
            else
            {
                lblStatus.Text = message;
                txtHours.Text = "";
                return 0;
            }
            return oTHour;
        }

        public (bool,TimeSpan,string) CalculateOvertimeHours(DateTime start, DateTime end)
        {
            // 參數設定
            TimeSpan workStart = new TimeSpan(8, 0, 0);   // 08:00
            TimeSpan workEnd = new TimeSpan(17, 0, 0);    // 17:00
            TimeSpan maxOvertimeWeekday = TimeSpan.FromHours(4);
            TimeSpan maxOvertimeWeekend = TimeSpan.FromHours(12);

            //結束時間必須晚於開始時間
            if (end <= start)
            {
                string message = "結束時間必須晚於開始時間。";
                return (false, TimeSpan.Zero, message);
            }

            //申請時間不可以跨天
            if (start.Date != end.Date)
            {
                //throw new ArgumentException("加班申請禁止跨天，請將不同日期的加班分開申請。");
                string message = "加班申請禁止跨天，請將不同日期的加班分開申請。";
                return (false, TimeSpan.Zero, message);
            }

            DayOfWeek currentDay = start.DayOfWeek;
            bool isWeekend = (currentDay == DayOfWeek.Saturday || currentDay == DayOfWeek.Sunday);

            if (!isWeekend) // 平日 (一到五)
            {
                // 驗證 3: 平日加班時間不可落在常規上班時段內
                // 如果開始時間早於下班時間 (17:00) 且結束時間晚於上班時間 (08:00)
                if (start < start.Date.Add(workEnd) && end > start.Date.Add(workStart))
                {
                    string message = "平日加班時間不可包含常規上班時段 (08:00~17:00)，請分段申請 (例如: 07:00~08:00 和 17:00~18:00)。";
                    return (false, TimeSpan.Zero, message);
                }
            }
            // 週末則整天都可申請，無此限制。


            // --- 階段 2: 計算時數並套用上限 ---

            TimeSpan duration = end - start;
            TimeSpan maxAllowed;

            if (isWeekend)
            {
                maxAllowed = maxOvertimeWeekend;
            }
            else
            {
                maxAllowed = maxOvertimeWeekday;
            }

            // 套用單次加班時數上限
            if (duration > maxAllowed)
            {
                duration = maxAllowed;
            }

            // 返回計算後的結果
            return (true, duration,"");
        }


        private void submitOtRequest()
        {
            try
            {
                if (!ValidateInput()) return;

                string otID = generateOTID("OT");
                string empID = UserInfo.EmpID;
                DateTime oTDate = dtpStartDate.Value.Date;
                DateTime startTime = getStartDateTime();
                DateTime endTime = getEndDateTime();
                decimal hours = getOTHour();
                string status = "申請中";
                string remark = $"#理由-{txtReason.Text}-理由#";
                if(hours <= 0)
                {
                    lblStatus.Text = "沒有加班時數"; 
                    return;
                }
                if (saveOTRequest(otID, empID, oTDate, startTime, endTime, hours, status, remark))
                {
                    lblStatus.Text = $"已送出加班登記!";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"送出登記失敗：{ex.Message}";
            }
        }

        private string getTheString(string OriginalString,string startString, string endString)
        {
            string theString = "";
            int startIndex = OriginalString.IndexOf(startString);
            int endIndex = OriginalString.IndexOf(endString);
            
            if (startIndex != -1 && endIndex != -1 && startIndex < endIndex)
            {
                startIndex += 4;               
                theString = OriginalString.Substring(startIndex, endIndex - startIndex);
            }
            return theString;
        }


        private void refreshOTList()
        {
            loadOTRequstList();
        }

        #endregion


        #region 事件

        private void cmbStartHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHours.Text = getOTHour().ToString();
        }        

        private void cmbStartMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHours.Text = getOTHour().ToString();
        }
        private void cmbEndHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHours.Text = getOTHour().ToString();
        }
        private void cmbEndMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHours.Text = getOTHour().ToString();
        }

        #endregion


        private void OTRequestUserControl_Load(object sender, EventArgs e)
        {
            loadOTRequstList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            submitOtRequest();
            refreshOTList();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {            
            txtHours.Text = getOTHour().ToString();
        }

        private void btnRefreshHistory_Click(object sender, EventArgs e)
        {
            refreshOTList();
        }
    }
}

