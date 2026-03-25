using SkyGate_Winform.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyGate_ADONET
{
    public partial class AttendanceReportUserControl : UserControl
    {
        string connectionString = ConnectionStringHelper.GetConnectionString();
        DataTable dt;

        public AttendanceReportUserControl()
        {
            InitializeComponent();
            InitialzeCmbReportType();
            InitialzecmbDGVFilter();
        }

        #region Initialze

        private void InitialzeCmbReportType()
        {
            cmbReportType.Items.Add("請假報表");
            cmbReportType.Items.Add("加班報表");

            cmbReportType.SelectedIndex = 0;
        }

        private void InitialzecmbDGVFilter()
        {
            cmbDGVFilter.Items.Add("全部");
            cmbDGVFilter.Items.Add("申請中");
            cmbDGVFilter.Items.Add("核准");
            cmbDGVFilter.Items.Add("駁回");


            cmbDGVFilter.SelectedIndex = 0;

            cmbDGVFilter.SelectedIndexChanged += cmbDGVFilter_SelectedIndexChanged;
        }

        #endregion

        #region 資料庫相關

        private void LoadReportList()
        {
            ClearDGV();
            ClearDataTable();
            
            DateTime firstDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;
            string sql = GetSQLForSheet();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
            {
                da.SelectCommand.Parameters.AddWithValue("@EmpID", UserInfo.EmpID);
                da.SelectCommand.Parameters.AddWithValue("@firstDate", firstDate);
                da.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

                con.Open();

                dt = new DataTable();
                da.Fill(dt);

                dgvHistory.DataSource = dt;
            }
        }
        #endregion

        #region 方法

        private string GetSQLForSheet()
        {
            string sql = "";
            string cmbSelected = cmbReportType.SelectedItem.ToString();
            switch (cmbSelected)
            {
                case "請假報表":
                    sql = @" SELECT lr.LeaveID, le.EmpName , lt.LeaveName, lr.StartTime, lr.EndTime, lr.Hours, lr.Status
                                                FROM LeaveRequest lr
                                                INNER JOIN Employee ae ON lr.ApplyID = ae.EmpID
                                                INNER JOIN Employee le ON lr.EmpID = le.EmpID
                                                INNER JOIN LeaveType lt ON lr.LeaveTypeId = lt.LeaveTypeID
                                                LEFT JOIN Employee approver ON lr.ApproverID = approver.EmpID
                                                WHERE lr.EmpID = @EmpID
                                                AND StartTime >= @firstDate
                                                AND EndTime < @endDate
                                                ORDER BY lr.StartTime DESC";
                    break;
                case "加班報表":
                    sql = @"Select OTID, StartTime, EndTime, Hours, Status
                                    from OverTimeRequest 
                                    where EmpID = @EmpID
                                    AND OTDate >= @firstDate 
                                    AND OTDate < @endDate
                                    Order by OTDate ASC;";
                    break;
            }
            return sql;
        }

        private void ClearDGV()
        {
            dgvHistory.DataSource = null;
        }

        private void ClearDataTable()
        {
            if (dt != null) dt.Clear();
        }

        private void FilterDGV()
        {
            DataView dv = dt.DefaultView;
            string filterword = cmbDGVFilter.SelectedItem.ToString();
            if (filterword == "全部")
            {
                dv.RowFilter = string.Empty;
            }
            else
            {
                dv.RowFilter = string.Format("Status LIKE '%{0}%'", filterword);
            }
        }

        #endregion

        #region 事件

        private void cmbDGVFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDGV();
        }

        #endregion

        private void AttendanceReportUserControl_Load(object sender, EventArgs e)
        {

        }

        private void btnRefreshHistory_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            LoadReportList();
        }
    }
}
