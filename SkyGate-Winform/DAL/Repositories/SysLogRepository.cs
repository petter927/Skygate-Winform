using SkyGate_ADONET.Services;
using SkyGate_ADONET.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.DAL.Repositories
{
    public class SysLogRepository : ISysLogRepository
    {
        private readonly string _connectionString;

        public SysLogRepository()
        {
            _connectionString =ConfigurationService.GetConnectionString();
        }

        public void LogAction(string empId, string action, string targetId = null, string details = null, string ip = null)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        INSERT INTO SysLog 
                        (LogID, EmpID, Action, TargetID, Details, LogTime, IP) 
                        VALUES (@LogID, @EmpID, @Action, @TargetID, @Details, @LogTime, @IP)", conn);

                    cmd.Parameters.AddWithValue("@LogID", IdGenerator.GenerateLogId());
                    cmd.Parameters.AddWithValue("@EmpID", empId);
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@TargetID", (object)targetId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Details", (object)details ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LogTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IP", (object)ip ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // 記錄日誌失敗不應該影響主要業務邏輯
                System.Diagnostics.Debug.WriteLine($"記錄操作日誌失敗: {ex.Message}");
            }
        }
    }
}
