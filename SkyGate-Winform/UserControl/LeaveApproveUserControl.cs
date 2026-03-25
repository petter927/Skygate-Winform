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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyGate_ADONET
{
    public partial class LeaveApproveUserControl : UserControl
    {
        private DataTable pendingLeaves;
        private string currentLeaveID;
        private string connectionString = ConnectionStringHelper.GetConnectionString();


        public LeaveApproveUserControl()
        {
            InitializeComponent();
        }

        private void LeaveApproveUserControl_Load(object sender, EventArgs e)
        {
            LoadPendingLeaves();
        }

        private void LoadPendingLeaves()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT lr.LeaveID, e.EmpName, lr.LeaveTypeId, lr.StartTime, lr.EndTime, lr.Hours, lr.LeaveReason
                        FROM LeaveRequest lr
                        INNER JOIN Employee e ON lr.ApplyID = e.EmpID
                        WHERE lr.Status = '申請中' 
                        AND e.SupervisorID = @SupervisorID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SupervisorID", UserInfo.EmpID);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        pendingLeaves = new DataTable();
                        adapter.Fill(pendingLeaves);

                        dgvLeaveList.DataSource = pendingLeaves;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入待審核清單失敗: {ex.Message}");
            }
        }

        private void dgvLeaveList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLeaveList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvLeaveList.SelectedRows[0];
                currentLeaveID = selectedRow.Cells["LeaveID"].Value.ToString();
                DisplayLeaveDetails(selectedRow);
                LoadAttachments(currentLeaveID);
            }
        }

        private void DisplayLeaveDetails(DataGridViewRow row)
        {
            txtEmpName.Text = row.Cells["EmpName"].Value.ToString();
            txtLeaveType.Text = GetLeaveTypeName(row.Cells["LeaveTypeId"].Value.ToString());
            txtStartTime.Text = Convert.ToDateTime(row.Cells["StartTime"].Value).ToString("yyyy/MM/dd HH:mm");
            txtEndTime.Text = Convert.ToDateTime(row.Cells["EndTime"].Value).ToString("yyyy/MM/dd HH:mm");
            txtHours.Text = row.Cells["Hours"].Value.ToString();
            txtLeaveReason.Text = row.Cells["LeaveReason"].Value.ToString();
            txtManagerRemark.Clear();
        }

        private string GetLeaveTypeName(string leaveTypeId)
        {
            var leaveTypes = new Dictionary<string, string>
            {
                {"L001", "特休"}, {"L002", "事假"}, {"L003", "病假"}, {"L004", "生理假"}
            };
            return leaveTypes.ContainsKey(leaveTypeId) ? leaveTypes[leaveTypeId] : leaveTypeId;
        }

        private void LoadAttachments(string leaveID)
        {
            lstAttachments.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT FileName, FilePath 
                        FROM SystemAttachment 
                        WHERE ReferenceType = 'LeaveRequest' AND ReferenceID = @LeaveID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LeaveID", leaveID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lstAttachments.Items.Add(reader["FileName"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入附件失敗: {ex.Message}");
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentLeaveID))
            {
                MessageBox.Show("請選擇要審核的請假申請");
                return;
            }

            if (MessageBox.Show("確定要核准此請假申請嗎？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UpdateLeaveStatus("核准");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentLeaveID))
            {
                MessageBox.Show("請選擇要審核的請假申請");
                return;
            }

            if (string.IsNullOrEmpty(txtManagerRemark.Text))
            {
                MessageBox.Show("駁回請假申請必須填寫備註");
                return;
            }

            if (MessageBox.Show("確定要駁回此請假申請嗎？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UpdateLeaveStatus("駁回");
            }
        }

        private void UpdateLeaveStatus(string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 先取得原備註
                    string currentRemark = "";
                    string getRemarkQuery = "SELECT Remark FROM LeaveRequest WHERE LeaveID = @LeaveID";
                    using (SqlCommand getCmd = new SqlCommand(getRemarkQuery, conn))
                    {
                        getCmd.Parameters.AddWithValue("@LeaveID", currentLeaveID);
                        var result = getCmd.ExecuteScalar();
                        currentRemark = result != DBNull.Value ? result.ToString() : "";
                    }

                    // 更新請假申請
                    string updateQuery = @"
                        UPDATE LeaveRequest 
                        SET Status = @Status, 
                            ApproverID = @ApproverID,
                            Remark = @Remark
                        WHERE LeaveID = @LeaveID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        string newRemark = currentRemark;
                        if (!string.IsNullOrEmpty(txtManagerRemark.Text))
                        {
                            newRemark += (string.IsNullOrEmpty(newRemark) ? "" : "\r\n") +
                                       $"#主管備註 {DateTime.Now:yyyy/MM/dd HH:mm}\r\n{txtManagerRemark.Text}\r\n主管備註*";
                        }

                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@ApproverID", UserInfo.EmpID);
                        cmd.Parameters.AddWithValue("@Remark", newRemark);
                        cmd.Parameters.AddWithValue("@LeaveID", currentLeaveID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"{status}成功！");
                            LoadPendingLeaves();
                            ClearDetails();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新失敗: {ex.Message}");
            }
        }

        private void ClearDetails()
        {
            txtEmpName.Clear();
            txtLeaveType.Clear();
            txtStartTime.Clear();
            txtEndTime.Clear();
            txtHours.Clear();
            txtLeaveReason.Clear();
            txtManagerRemark.Clear();
            lstAttachments.Items.Clear();
            currentLeaveID = null;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (lstAttachments.SelectedItem == null)
            {
                MessageBox.Show("請選擇要下載的附件");
                return;
            }

            try
            {
                string fileName = lstAttachments.SelectedItem.ToString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT FilePath FROM SystemAttachment WHERE FileName = @FileName AND ReferenceID = @LeaveID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FileName", fileName);
                        cmd.Parameters.AddWithValue("@LeaveID", currentLeaveID);
                        string filePath = cmd.ExecuteScalar()?.ToString();

                        if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                        {
                            SaveFileDialog saveDialog = new SaveFileDialog();
                            saveDialog.FileName = fileName;
                            if (saveDialog.ShowDialog() == DialogResult.OK)
                            {
                                File.Copy(filePath, saveDialog.FileName, true);
                                MessageBox.Show("下載完成！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("檔案不存在或路徑錯誤");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"下載失敗: {ex.Message}");
            }
        }



    }
}
