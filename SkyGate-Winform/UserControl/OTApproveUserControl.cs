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
    public partial class OTApproveUserControl : UserControl
    {
        private string connectionString = ConnectionStringHelper.GetConnectionString();
        string oRemak = "";
        public OTApproveUserControl()
        {
            InitializeComponent();
            InitialzeDataGridView();
        }

        #region Initialze

        private void InitialzeDataGridView()
        {
            dgvOTList.Rows.Clear();

            dgvOTList.Columns.Add("OTID", "加班單號");
            dgvOTList.Columns.Add("EmpName", "姓名");
            dgvOTList.Columns.Add("OTDate", "加班日期");
            dgvOTList.Columns.Add("StartTime", "開始時間");
            dgvOTList.Columns.Add("EndTime", "結束時間");
            dgvOTList.Columns.Add("Hours", "加班時數");
            //dgvOTList.Columns.Add("Status", "狀態");
            dgvOTList.Columns.Add("Remark", "加班事由");

            dgvOTList.AutoResizeColumns();

            dgvOTList.SelectionChanged += dgvOTList_SelectionChanged;
        }

        #endregion

        #region 資料庫相關

        private void loadOTList()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"select o.otid, e.EmpName, o.OTDate, o.StartTime, o.EndTime, o.Hours, o.Remark
                                        From employee e 
                                        Join OverTimeRequest o on e.empid = o.empid
                                        where e.supervisorid = @EmpID
                                        AND o.status = '申請中'
                                        order by o.OTdate asc;";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpID", UserInfo.EmpID);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        oRemak = "";
                        while (reader.Read())
                        {
                            string otID = reader["otid"].ToString();
                            string empName = reader["EmpName"].ToString();
                            DateTime startTime = (DateTime)reader["StartTime"];
                            DateTime endTime = (DateTime)reader["EndTime"];
                            string hours = ((Decimal)reader["Hours"]).ToString("0.0");
                            string remark = getTheString(reader["Remark"].ToString(), "#理由-", "-理由#");

                            oRemak = reader["Remark"].ToString();

                            dgvOTList.Rows.Add(
                                otID,
                                empName,
                                startTime.ToString("yyyy/MM/dd"),
                                startTime.ToString("HH:mm"),
                                endTime.ToString("HH:mm"),
                                hours,
                                remark);
                        }
                    }
                }
            }
        }

        private bool saveOTRequest(string remark, string OTID,string Status)
        {
            string sql = @"UPDATE OverTimeRequest SET Remark = @Remark, Status = @Status, ApproverID = @ApproverID WHERE OTID = @OTID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@OTID", OTID);
                cmd.Parameters.AddWithValue("@Remark", remark);
                cmd.Parameters.AddWithValue("@ApproverID", UserInfo.EmpID);
                cmd.Parameters.AddWithValue("@Status", Status);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        #endregion

        #region 方法

        private string getTheString(string OriginalString, string startString, string endString)
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

        private void combinTheString(string answer)
        {
            string startAnswer = "#審核結果-";
            string endAnswer = "-審核結果#";
            oRemak += startAnswer;
            oRemak += answer;
            oRemak += endAnswer;
        }

        private void submitReply(string status)
        {
            if (ValidateInput())
            {                
                string answer = txtOTReason.Text;
                combinTheString(answer);
                string otID = txtOTID.Text;

                try
                {
                    if(saveOTRequest(oRemak, otID,status))
                    {
                        MessageBox.Show($"已送出 {status} 加班申請!");
                        refreshOTList();
                    }
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show($"送出登記失敗：{ex.Message}");
                }
            }
            refreshOTList();
            refreshManagerRason();
        }

        private bool ValidateInput()
        {
            //檢查理由是否空值, 失敗回傳false
            if (string.IsNullOrWhiteSpace(txtManagerRemark.Text))
            {
                MessageBox.Show("審核理由未填寫!");
                return false;
            }

            return true;
        }

        private void loadOTDetail(DataGridViewRow row)
        {          
            txtOTID.Text = row.Cells["OTID"].Value.ToString();
            txtEmpName.Text = row.Cells["EmpName"].Value.ToString();
            txtOTDate.Text = row.Cells["OTDate"].Value.ToString();
            txtStartTime.Text = row.Cells["StartTime"].Value.ToString();
            txtEndTime.Text = row.Cells["EndTime"].Value.ToString();
            txtHours.Text = row.Cells["Hours"].Value.ToString();
            txtOTReason.Text = row.Cells["Remark"].Value.ToString();
        }

        private void refreshOTList()
        {
            dgvOTList.Rows.Clear();
            loadOTList();           
        }

        private void refreshManagerRason()
        {
            txtManagerRemark.Text = "";
        }

        #endregion

        #region 事件

        private void dgvOTList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOTList.SelectedRows.Count > 0)
            {
                //因為一次只會選中一列, 所以SelectedRows[0]會是0
                DataGridViewRow selectedRow = dgvOTList.SelectedRows[0];
                loadOTDetail(selectedRow);
            }
        }

        #endregion

        private void OTApproveUserControl_Load(object sender, EventArgs e)
        {
           loadOTList();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            submitReply("核准");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            submitReply("駁回");
        }
    }
}
