using SkyGate_ADONET.Utilities;
using SkyGate_Winform.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyGate_ADONET
{
    public partial class AttendanceUserControl : UserControl
    {
        private Timer timer;

        public class EmpHRView
        {
            public int EmployeeID { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public DateTime HireDate { get; set; }
        }

        public AttendanceUserControl()
        {
            InitializeComponent();
            InitializeTimer();
            DisplayUserInfo();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1秒更新一次
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 每秒更新時間顯示

            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void DisplayUserInfo()
        {
            // 顯示使用者姓名
            lblUserName.Text = $"登入者：{UserInfo.EmpName}";
        }

        private string GenerateLogID(string now)
        {
            // 使用時間戳記 + 隨機數，避免重複            
            string randomPart = new Random().Next(100, 999).ToString();
            return $"LOG{now}{randomPart}";
        }

        private void SaveAttendanceRecord(string logType, DateTime logTime, string logID)
        {
            string connectionString = ConnectionStringHelper.GetConnectionString();
            string sql = @"INSERT INTO AttendanceLog (LogID, EmpID, LogTime, LogType, DeviceID, Remark) 
                                VALUES (@LogID, @EmpID, @LogTime, @LogType, @DeviceID, @Remark)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@LogID", logID);
                cmd.Parameters.AddWithValue("@EmpID", UserInfo.EmpID);
                cmd.Parameters.AddWithValue("@LogTime", logTime);
                cmd.Parameters.AddWithValue("@LogType", logType);
                cmd.Parameters.AddWithValue("@DeviceID", "APP");
                cmd.Parameters.AddWithValue("@Remark", "系統自動打卡");

                con.Open();
                int result = cmd.ExecuteNonQuery();
            }
        }

        private void Clock(string logType, DateTime now)
        {
            string ClockInNow = now.ToString("yyyyMMddHHmmss");
            string LogId = GenerateLogID(ClockInNow);
            try
            {
                SaveAttendanceRecord(logType, now, ClockInNow);
                lblStatus.Text = $"上班登記成功！時間：{now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"登記失敗：{ex.Message}";
            }
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string logType = "上班";
            Clock(logType, now);
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string logType = "下班";
            Clock(logType, now);
        }

        // 釋放資源
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timer?.Stop();
                timer?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void AttendanceUserControl_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
