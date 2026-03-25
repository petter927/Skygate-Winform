using SkyGate_ADONET.Models.Entities;
using SkyGate_ADONET.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyGate_ADONET.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;

        public DepartmentRepository()
        {
            _connectionString = ConfigurationService.GetConnectionString();
        }

        public List<Department> GetAllDepartments()
        {           
            var departments = new List<Department>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Department ORDER BY DeptID", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departments.Add(new Department
                        {
                            DeptID = reader["DeptID"].ToString(),
                            DeptName = reader["DeptName"].ToString(),
                            ParentID = reader["ParentID"]?.ToString(),
                            ManagerID = reader["ManagerID"]?.ToString()                            
                        });
                       

                    }
                }
            }
            return departments;
        }

        public Department GetDepartmentById(string deptId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Department WHERE DeptID = @DeptID", conn);
                cmd.Parameters.AddWithValue("@DeptID", deptId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Department
                        {
                            DeptID = reader["DeptID"].ToString(),
                            DeptName = reader["DeptName"].ToString(),
                            ParentID = reader["ParentID"]?.ToString(),
                            ManagerID = reader["ManagerID"]?.ToString()
                        };
                    }
                }
            }
            return null;
        }

        public List<Department> GetSubDepartments(string parentId)
        {
            var departments = new List<Department>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query;
                SqlCommand cmd;

                if (string.IsNullOrEmpty(parentId))
                {
                    query = "SELECT * FROM Department WHERE ParentID IS NULL ORDER BY DeptID";
                    cmd = new SqlCommand(query, conn);
                }
                else
                {
                    query = "SELECT * FROM Department WHERE ParentID = @ParentID ORDER BY DeptID";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ParentID", parentId);
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departments.Add(new Department
                        {
                            DeptID = reader["DeptID"].ToString(),
                            DeptName = reader["DeptName"].ToString(),
                            ParentID = reader["ParentID"]?.ToString(),
                            ManagerID = reader["ManagerID"]?.ToString()
                        });
                    }
                }
            }
            return departments;
        }

        public bool CreateDepartment(Department department)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO Department 
                    (DeptID, DeptName, ParentID, ManagerID) 
                    VALUES (@DeptID, @DeptName, @ParentID, @ManagerID)", conn);

                cmd.Parameters.AddWithValue("@DeptID", department.DeptID);
                cmd.Parameters.AddWithValue("@DeptName", department.DeptName);
                cmd.Parameters.AddWithValue("@ParentID", (object)department.ParentID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ManagerID", (object)department.ManagerID ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateDepartment(Department department)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE Department SET 
                    DeptName = @DeptName, ParentID = @ParentID, ManagerID = @ManagerID
                    WHERE DeptID = @DeptID", conn);

                cmd.Parameters.AddWithValue("@DeptID", department.DeptID);
                cmd.Parameters.AddWithValue("@DeptName", department.DeptName);
                cmd.Parameters.AddWithValue("@ParentID", (object)department.ParentID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ManagerID", (object)department.ManagerID ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
