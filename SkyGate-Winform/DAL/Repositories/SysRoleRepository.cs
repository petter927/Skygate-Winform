using SkyGate_ADONET.Models.Entities;
using SkyGate_ADONET.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.DAL.Repositories
{
    public class SysRoleRepository : ISysRoleRepository
    {
        private readonly string _connectionString;

        public SysRoleRepository()
        {
            _connectionString = ConfigurationService.GetConnectionString();
        }

        public List<SysRole> GetAllSysRoles()
        {
            var sysroles = new List<SysRole>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM SysRole ORDER BY RoleID", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sysroles.Add(new SysRole
                        {
                            RoleID = reader["RoleID"].ToString(),
                            RoleName = reader["RoleName"].ToString(),
                            Description = reader["Description"]?.ToString()
                        });
                    }
                }
            }
            return sysroles;
        }

        public SysRole GetSysRoleById(string roleid)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM SysRole WHERE RoleID = @RoleID", conn);
                cmd.Parameters.AddWithValue("@RoleID", roleid);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new SysRole
                        {
                            RoleID = reader["RoleID"].ToString(),
                            RoleName = reader["RoleName"].ToString(),
                            Description = reader["Description"]?.ToString()
                        };
                    }
                }
            }
            return null;
        }
        /*
        public SysRole GetIdByRoleName(string roleName)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM SysRole WHERE RoleName = @RoleName", conn);
                cmd.Parameters.AddWithValue("@RoleName", roleName);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new SysRole
                        {
                            RoleID = reader["RoleID"].ToString(),
                            RoleName = reader["RoleName"].ToString(),
                            Description = reader["Description"]?.ToString()
                        };
                    }
                }
            }
            return null;
        }
        */
        public string GetIdByRoleName(string roleName)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM SysRole WHERE RoleName = @RoleName", conn);
                cmd.Parameters.AddWithValue("@RoleName", roleName);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["RoleID"].ToString();
                    };
                    return null;
                }
            }
        }

        public string GetRoleNameByRoleID(string roleid)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT RoleName FROM SysRole WHERE RoleID = @RoleID", conn);
                cmd.Parameters.AddWithValue("@RoleName", roleid);

                return cmd.ExecuteScalar()?.ToString()??"";
            }
        }


        public bool CreateSysRole(SysRole sysrole)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO SysRole 
                    (RoleID, RoleName, Description) 
                    VALUES (@RoleID, @RoleName, @Description)", conn);

                cmd.Parameters.AddWithValue("@RoleID", sysrole.RoleID);
                cmd.Parameters.AddWithValue("@RoleName", sysrole.RoleID);
                cmd.Parameters.AddWithValue("@Description", (object)sysrole.RoleID ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateSysRole(SysRole sysrole)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE SysRole SET 
                    RoleID = @RoleID, RoleName = @RoleName, Description = @Description
                    WHERE RoleID = @RoleID", conn);

                cmd.Parameters.AddWithValue("@RoleID", sysrole.RoleID);
                cmd.Parameters.AddWithValue("@RoleName", sysrole.RoleName);
                cmd.Parameters.AddWithValue("@Description", (object)sysrole.Description ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
