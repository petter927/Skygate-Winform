using SkyGate_ADONET.DAL.Repositories;
using SkyGate_ADONET.Enums;
using SkyGate_ADONET.Models.DTOs;
using SkyGate_ADONET.Models.Entities;
using SkyGate_ADONET.Models.enums;
using SkyGate_ADONET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyGate_ADONET.Utilities;
using SkyGate_ADONET.Services.Utilities;
using System.Transactions;
using System.Windows.Forms;
using System.Data.Common;

namespace SkyGate_ADONET.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ISysLogRepository _logRepository;
        private readonly ISysUserRoleRepository _sysUserRoleRepository;
        private readonly ISysRoleRepository _sysRoleRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,
                             IDepartmentRepository departmentRepository,
                             ISysLogRepository logRepository,
                             ISysRoleRepository sysRoleRepository,
                             ISysUserRoleRepository sysUserRoleRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _logRepository = logRepository;
            _sysUserRoleRepository = sysUserRoleRepository;
            _sysRoleRepository = sysRoleRepository;
            
        }

        public List<EmployeeHRViewModel> GetAllEmployeesForHR()
        {
            var employees = _employeeRepository.GetAllEmployees();
            var departments = _departmentRepository.GetAllDepartments();

            return employees.Select(e => new EmployeeHRViewModel
            {
                EmpID = e.EmpID,
                EmpName = e.EmpName,
                DeptName = departments.FirstOrDefault(d => d.DeptID == e.DeptID)?.DeptName ?? "未知部門",
                Title = e.Title,
                SupervisorName = GetSupervisorName(e.SupervisorID),
                StatusText = ((EmployeeStatus)e.Status).ToString(),
                HireDate = e.HireDate.ToString("yyyy/MM/dd"),
                LeaveDate = e.LeaveDate?.ToString("yyyy/MM/dd") ?? "",
                Email = e.Email,
                Phone = e.Phone,
                RoleName = RoleConverter.GetRoleName(_employeeRepository.GetEmployeeRoleID(e.EmpID))
            }).ToList();
        }
        public List<EmployeeHRViewModel> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            var departments = _departmentRepository.GetAllDepartments();

            return employees.Select(e => new EmployeeHRViewModel
            {
                EmpID = e.EmpID,
                EmpName = e.EmpName,
                DeptName = departments.FirstOrDefault(d => d.DeptID == e.DeptID)?.DeptName ?? "未知部門",
                Title = e.Title,
                SupervisorName = GetSupervisorName(e.SupervisorID),
                StatusText = ((EmployeeStatus)e.Status).ToString(),
                HireDate = e.HireDate.ToString("yyyy/MM/dd"),
                Email = e.Email,
                Phone = e.Phone,
                RoleName = RoleConverter.GetRoleName(_employeeRepository.GetEmployeeRoleID(e.EmpID))
            }).ToList();
        }

        public (bool success, string message, string newID) CreateEmployee(EmployeeCreateDto dto)
        {                        
            if (!ValidationHelper.ValidateEmail(dto.Email))
                return (false, "電子郵件格式不正確","");

            if (!ValidationHelper.ValidatePhone(dto.Phone))
                return (false, "電話格式不正確", "");

            var employee = new Employee
            {
                //EmpID = IdGenerator.GenerateEmployeeId(),
                EmpName = dto.EmpName,
                DeptID = dto.DeptID,
                Title = dto.Title,
                SupervisorID = _employeeRepository.GetEmpIDByName(dto.SupervisorID),
                Email = dto.Email,
                Phone = dto.Phone,
                HireDate = DateTime.Now,
                Status = (int)EmployeeStatus.在職
            };
            
            var sysuserrole = new SysUserRole
            {
                //EmpID = employee.EmpID,
                RoleID = _sysRoleRepository.GetIdByRoleName(dto.RoleID)
            };
           
            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
            {                
                try
                {
                    employee.EmpID = _employeeRepository.GenerateNewEmployeeId();
                    sysuserrole.EmpID = employee.EmpID;
                    bool result = _employeeRepository.CreateEmployee(employee);
                    
                    if (!result)
                    {
                        return (false, "員工資料寫入失敗!", "");
                    }
                  
                  result = _sysUserRoleRepository.CreateSysUserRole(sysuserrole);
                    
                    if (!result)
                  {
                      return (false, "權限寫入失敗!", "");
                  }                          
                  
                  if (result)
                  {
                      _logRepository.LogAction(UserInfo.EmpID, "新增員工", $"{employee.EmpID}", $"新增員工: {employee.EmpName}");                        
                  }

                transaction.Complete(); 

                return (result, result ? "員工建立成功" : "員工建立失敗", employee.EmpID);
                }
                catch (Exception ex) 
                {                                      
                    return (false, $"建立員工時發生錯誤: {ex.Message}", "");
                }    
            }
        }

        public (bool success, string message) UpdateEmployeeForEdit(EmployeeEditDto dto)
        {
            
            if (!ValidationHelper.ValidateEmail(dto.Email))
                return (false, "電子郵件格式不正確");

            if (!ValidationHelper.ValidatePhone(dto.Phone))
                return (false, "電話格式不正確");
            
            var employee = new Employee
            {
                EmpID = dto.EmpID,
                EmpName = dto.EmpName,
                DeptID = dto.DeptID,
                Title = dto.Title,
                SupervisorID = _employeeRepository.GetEmpIDByName(dto.SupervisorID),
                Email = dto.Email,
                Phone = dto.Phone,
                HireDate = DateTime.Parse(dto.HireDate),
                LeaveDate = string.IsNullOrWhiteSpace(dto.LeaveDate)?(DateTime?)null:DateTime.Parse(dto.LeaveDate),
                Status = (int)EmployeeStatus.在職

            };
            
            var sysuserrole = new SysUserRole
            {
                EmpID = employee.EmpID,
                RoleID = dto.RoleID
            };
            
            using (var transaction = new TransactionScope())
            {
               
                try
                {
                    
                    bool result = _employeeRepository.UpdateEmployeeForEdit(employee);
                    

                    if (!result)
                    {
                        return (false, "員工資料寫入失敗!");
                    }
                    
                    result = _sysUserRoleRepository.UpdateSysUserRoleByID(sysuserrole);
                    
                    if (!result)
                    {
                        return (false, "權限寫入失敗!");
                    }

                    if (result)
                    {
                        _logRepository.LogAction(UserInfo.EmpID, "修改員工資料", $"{employee.EmpID}", $"修改員工資料: {employee.EmpName}");
                    }

                    transaction.Complete(); // 提交交易

                    return (result, result ? "員工修改成功" : "員工修改失敗");
                }
                catch (Exception ex)
                {
                    return (false, $"修改員工時發生錯誤: {ex.Message}");
                }



            }
        }

        public (bool success, string message) ChangeEmployeeStatus(string empId, int status)
        {
            DateTime? leaveDate = null;
            if (status == (int)EmployeeStatus.離職)
            {
                leaveDate = DateTime.Now;
            }

            bool result = _employeeRepository.ChangeEmployeeStatus(empId, status, leaveDate);
            string statusText = ((EmployeeStatus)status).ToString();

            // 記錄操作日誌
            if (result)
            {
                var employee = _employeeRepository.GetEmployeeById(empId);
                _logRepository.LogAction(UserInfo.EmpID, "變更員工狀態", empId,
                    $"{employee.EmpName} 狀態變更為: {statusText}");
            }

            return (result, result ? $"員工狀態已變更為{statusText}" : "狀態變更失敗");
        }

        private string GetSupervisorName(string supervisorId)
        {
            if (string.IsNullOrEmpty(supervisorId)) return "";
            var supervisor = _employeeRepository.GetEmployeeById(supervisorId);
            return supervisor?.EmpName ?? "";
        }

        public List<EmployeeHRViewModel> SearchEmployees(EmployeeSearchCriteria criteria)
        {
            // 呼叫 Repository 搜尋
            var employees = _employeeRepository.SearchEmployees(criteria);

            // 轉換為 ViewModel 給 UI 顯示
            return employees.Select(e => ConvertToHRViewModel(e)).ToList();
        }

        private EmployeeHRViewModel ConvertToHRViewModel(Employee employee)
        {  
            var departments = _departmentRepository.GetAllDepartments();
            var sysuserroles = _sysUserRoleRepository.GetAllSysUserRole();
            var sysroles = _sysRoleRepository.GetAllSysRoles();
            var roleid = sysuserroles.FirstOrDefault(s => employee.EmpID == s.EmpID)?.RoleID;
            var rolename = sysroles.FirstOrDefault(r => r.RoleID == roleid)?.RoleName;
            // 您的現有轉換邏輯...
            return new EmployeeHRViewModel
            {
                EmpID = employee.EmpID,
                EmpName = employee.EmpName,
                DeptName = departments.FirstOrDefault(d => d.DeptID == employee.DeptID)?.DeptName ?? "未知部門",
                Title = employee.Title,
                SupervisorName = GetSupervisorName(employee.SupervisorID),
                StatusText = ((EmployeeStatus)employee.Status).ToString(),
                HireDate = employee.HireDate.ToString("yyyy/MM/dd"),
                LeaveDate = employee.LeaveDate?.ToString("yyyy/MM/dd") ?? "",
                Email = employee.Email,
                Phone = employee.Phone,
                //RoleName = _sysUserRoleRepository.GetRoleIDByEmpID(_sysRoleRepository.GetRoleNameByRoleID(employee.EmpID)),
                RoleName = rolename                
            };
        }

        
        public Employee GetEmployeeById(string empId) => _employeeRepository.GetEmployeeById(empId);
        public List<Employee> GetSupervisors() => _employeeRepository.GetSupervisors();
        public (bool success, string message) UpdateEmployee(Employee employee)
        {            
            return (true, "1");
        }
        public (bool success, string message) AssignRoleToEmployee(string empId, string roleId)
        {            
            return (true, "1");
        }
        public string GetEmployeeRole(string empId) => _employeeRepository.GetEmployeeRoleID(empId);
    }
}
