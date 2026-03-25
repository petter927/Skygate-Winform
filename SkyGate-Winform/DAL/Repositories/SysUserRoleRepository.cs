using SkyGate_ADONET.Models.Entities;
using SkyGate_ADONET.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyGate_ADONET.DAL.Repositories
{

    public class SysUserRoleRepository : ISysUserRoleRepository
    {
        private readonly string _connectionString;

        public SysUserRoleRepository()
        {
            _connectionString = ConfigurationService.GetConnectionString();
        }

        public List<SysUserRole> GetAllSysUserRole()
        {
            var sysuserroles = new List<SysUserRole>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from SysUserRole", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sysuserroles.Add(new SysUserRole
                        {
                            EmpID = reader["EmpID"].ToString(),
                            RoleID = reader["RoleID"].ToString()
                        });
                    }
                }

            }
            return sysuserroles;
        }

        public bool CreateSysUserRole(SysUserRole sysuserrole)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"Insert into SysuserRole
                                            (EmpID,RoleID)
                                             VALUES(@empID, @RoleID)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", sysuserrole.EmpID);
                    cmd.Parameters.AddWithValue("@RoleID", sysuserrole.RoleID);
                    int success = cmd.ExecuteNonQuery();
                    if (success > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public string GetRoleIDByEmpID(string empID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select RoleID from SysUserRole where EmpID = @EmpID", conn))
                {
                    cmd.Parameters.AddWithValue("@EmpID", empID);
                    
                    return cmd.ExecuteScalar()?.ToString()??"";
                }
            }
        }

        public bool UpdateSysUserRoleByID(SysUserRole sysuserrole)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"UPDATE SysUserRole 
                                                       SET  RoleID = @RoleID
                                                       WHERE EmpID = @EmpID", conn))

                {
                    cmd.Parameters.AddWithValue("@RoleID", sysuserrole.RoleID);
                    cmd.Parameters.AddWithValue("@EmpID", sysuserrole.EmpID);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
