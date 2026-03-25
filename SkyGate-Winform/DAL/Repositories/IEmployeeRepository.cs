using SkyGate_ADONET.Models.DTOs;
using SkyGate_ADONET.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(string empId);
        List<Employee> GetEmployeesByDept(string deptId);
        List<Employee> GetSupervisors();
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool ChangeEmployeeStatus(string empId, int status, DateTime? leaveDate = null);
        bool AssignRoleToEmployee(string empId, string roleId);
        string GetEmployeeRoleID(string empId);
        bool UpdateEmployeeForDelete(string empid);
        //bool UpdateEmployeeForEdit(Employee employee);
        bool UpdateEmployeeForEdit(Employee employee);
        string GenerateNewEmployeeId();
        string GetEmpIDByName(string empName);

        List<Employee> SearchEmployees(EmployeeSearchCriteria criteria);
    }
}
