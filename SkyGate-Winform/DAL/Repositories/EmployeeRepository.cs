using SkyGate_ADONET.Models.DTOs;
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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository()
        {
            _connectionString = ConfigurationService.GetConnectionString();
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Employee ORDER BY EmpID", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(MapReaderToEmployee(reader));
                    }
                }
            }
            return employees;
        }

        public Employee GetEmployeeById(string empId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Employee WHERE EmpID = @EmpID", conn);
                cmd.Parameters.AddWithValue("@EmpID", empId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapReaderToEmployee(reader);
                    }
                }
            }
            return null;
        }

        public List<Employee> GetSupervisors()
        {
            var supervisors = new List<Employee>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT e.* FROM Employee e
                    INNER JOIN SysUserRole ur ON e.EmpID = ur.EmpID
                    WHERE ur.RoleID = 'R002' AND e.Status = 1", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        supervisors.Add(MapReaderToEmployee(reader));
                    }
                }
            }
            return supervisors;
        }

        public bool CreateEmployee(Employee employee)
        {            
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var transaction = conn.BeginTransaction();

                try
                {                                        
                    string sql = @"
                        INSERT INTO Employee 
                        (EmpID, EmpName, DeptID, Title, SupervisorID, Status, HireDate, Email, Phone) 
                        VALUES (@EmpID, @EmpName, @DeptID, @Title, @SupervisorID, @Status, @HireDate, @Email, @Phone)";
                    
                    var cmd = new SqlCommand(sql,conn, transaction);
                    
                    cmd.Parameters.AddWithValue("@EmpID", employee.EmpID);
                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@DeptID", employee.DeptID);
                    cmd.Parameters.AddWithValue("@Title", employee.Title);
                    cmd.Parameters.AddWithValue("@SupervisorID", (object)employee.SupervisorID ?? DBNull.Value);                    
                    cmd.Parameters.AddWithValue("@Status", employee.Status);
                    cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Phone", employee.Phone);

                    int result = cmd.ExecuteNonQuery();
                    
                    if (result > 0)
                    {                        
                        transaction.Commit();
                        return true;
                    }                    
                    transaction.Rollback();
                    return false;
                }
                catch
                {                    
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool UpdateEmployeeForDelete(string empid)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var transaction = conn.BeginTransaction();

                try
                {
                    string sql = @"UPDATE employee set Status = '1' where EmpID = @EmpID";

                    var cmd = new SqlCommand(sql, conn, transaction);

                    cmd.Parameters.AddWithValue("@EmpID", empid);
                    

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                    transaction.Rollback();
                    return false;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public bool UpdateEmployeeForEdit(Employee employee)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var transaction = conn.BeginTransaction();

                try
                {
                    string sql = @"
                        UPDATE Employee 
                        SET
                        
                        EmpName = @EmpName, 
                        DeptID = @DeptID, 
                        Title = @Title, 
                        SupervisorID = @SupervisorID, 
                        Status = @Status, 
                        HireDate = @HireDate, 
                        LeaveDate = @LeaveDate,
                        Email = @Email, 
                        Phone = @Phone
                        WHERE EmpID = @EmpID;";

                    var cmd = new SqlCommand(sql, conn, transaction);

                    cmd.Parameters.AddWithValue("@EmpID", employee.EmpID);
                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@DeptID", employee.DeptID);
                    cmd.Parameters.AddWithValue("@Title", employee.Title);
                    cmd.Parameters.AddWithValue("@SupervisorID", (object)employee.SupervisorID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", employee.Status);
                    cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    cmd.Parameters.AddWithValue("@LeaveDate", (object)employee.LeaveDate??DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Phone", employee.Phone);
                    //cmd.Parameters.AddWithValue("@RoleName", employee.RoleName);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                    transaction.Rollback();
                    return false;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public bool AssignRoleToEmployee(string empId, string roleId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // 先刪除現有角色
                var deleteCmd = new SqlCommand("DELETE FROM SysUserRole WHERE EmpID = @EmpID", conn);
                deleteCmd.Parameters.AddWithValue("@EmpID", empId);
                deleteCmd.ExecuteNonQuery();

                // 插入新角色
                var insertCmd = new SqlCommand("INSERT INTO SysUserRole (EmpID, RoleID) VALUES (@EmpID, @RoleID)", conn);
                insertCmd.Parameters.AddWithValue("@EmpID", empId);
                insertCmd.Parameters.AddWithValue("@RoleID", roleId);

                return insertCmd.ExecuteNonQuery() > 0;
            }
        }

        public string GetEmployeeRoleID(string empId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT RoleID FROM SysUserRole WHERE EmpID = @EmpID", conn);
                cmd.Parameters.AddWithValue("@EmpID", empId);

                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }
        public string GetEmpIDByName(string empName)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT empID FROM employee WHERE EmpName = @EmpName", conn);
                cmd.Parameters.AddWithValue("@EmpName", empName);
                
                var result = cmd.ExecuteScalar();
                //MessageBox.Show(result.ToString());
                return result?.ToString();
            }
        }
        public string GetEmployeeRoleName(string empId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT sr.RoleName FROM SysUserRole sur 
                                         LEFT JOIN SysRole sr 
                                          ON sr.RoleID = sur.RoleID
                                        WHERE sur.EmpID = @EmpID", conn);
                cmd.Parameters.AddWithValue("@EmpID", empId);

                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        public string GetEmployeeDeptName(string empId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT dep.DeptName FROM employee emp 
                                         LEFT JOIN Department dep 
                                          ON emp.DeptID = dep.DeptID
                                        WHERE emp.EmpID = @EmpID", conn);
                cmd.Parameters.AddWithValue("@EmpID", empId);

                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        private Employee MapReaderToEmployee(SqlDataReader reader)
        {
            return new Employee
            {
                EmpID = reader["EmpID"].ToString(),
                EmpName = reader["EmpName"].ToString(),
                DeptID = reader["DeptID"].ToString(),
                Title = reader["Title"].ToString(),
                SupervisorID = reader["SupervisorID"]?.ToString(),
                Status = Convert.ToInt32(reader["Status"]),
                HireDate = Convert.ToDateTime(reader["HireDate"]),
                LeaveDate = reader["LeaveDate"] as DateTime?,
                Email = reader["Email"]?.ToString(),
                Phone = reader["Phone"]?.ToString()
            };
        }

        public List<Employee> SearchEmployees(EmployeeSearchCriteria criteria)
        {
            var employees = new List<Employee>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // 1. 建立 SQL 查詢骨架
                var sqlBuilder = new StringBuilder("SELECT * FROM Employee WHERE 1=1");
                var parameters = new List<SqlParameter>();

                // 2. 依條件動態添加 WHERE 條件
                if (!string.IsNullOrEmpty(criteria.EmpID))
                {
                    sqlBuilder.Append(" AND EmpID LIKE @EmpID");
                    parameters.Add(new SqlParameter("@EmpID", $"%{criteria.EmpID}%"));
                }

                if (!string.IsNullOrEmpty(criteria.EmpName))
                {
                    sqlBuilder.Append(" AND EmpName LIKE @EmpName");
                    parameters.Add(new SqlParameter("@EmpName", $"%{criteria.EmpName}%"));
                }

                if (!string.IsNullOrEmpty(criteria.DeptID))
                {
                    sqlBuilder.Append(" AND DeptID LIKE @DeptID");
                    parameters.Add(new SqlParameter("@DeptID", $"%{criteria.DeptID}%"));
                }

                if (!string.IsNullOrEmpty(criteria.Title))
                {
                    sqlBuilder.Append(" AND Title LIKE @Title");
                    parameters.Add(new SqlParameter("@Title", $"%{criteria.Title}%"));
                }

                if (!string.IsNullOrEmpty(criteria.SupervisorID))
                {
                    sqlBuilder.Append(" AND SupervisorID LIKE @SupervisorID");
                    parameters.Add(new SqlParameter("@SupervisorID", $"%{criteria.SupervisorID}%"));
                }

                // 3. 添加排序
                sqlBuilder.Append(" ORDER BY EmpID");

                // 4. 建立 SQL Command
                var cmd = new SqlCommand(sqlBuilder.ToString(), conn);

                // 5. 加入所有參數
                cmd.Parameters.AddRange(parameters.ToArray());

                // 6. 執行查詢並讀取結果
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(MapReaderToEmployee(reader));
                    }
                }
            }

            return employees;
        }

        public string GenerateNewEmployeeId()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT TOP 1 EmpID FROM Employee ORDER BY EmpID DESC", conn);
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string lastEmpId = result.ToString();
                    int numericPart = int.Parse(lastEmpId.Substring(1));
                    return $"E{(numericPart + 1).ToString("D3")}";
                }
                else
                {
                    return "E001"; // 如果沒有任何員工，從 E00001 開始
                }
            }
        }

        // 其他方法實作...
        public List<Employee> GetEmployeesByDept(string deptId) 
        {
            /* 實作 */
            List < Employee > demo = new List < Employee >();   
            return demo; 
        }
        public bool UpdateEmployee(Employee employee) 
        {
            /* 實作 */
            return true;
        }
        public bool ChangeEmployeeStatus(string empid, int status, DateTime? leaveDate = null) 
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var transaction = conn.BeginTransaction();

                try
                {
                    string sql = @"UPDATE employee set Status = @Status, LeaveDate = @LeaveDate where EmpID = @EmpID";

                    var cmd = new SqlCommand(sql, conn, transaction);

                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@LeaveDate", leaveDate);
                    cmd.Parameters.AddWithValue("@EmpID", empid);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                    transaction.Rollback();
                    return false;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }            
        }
    }
}
