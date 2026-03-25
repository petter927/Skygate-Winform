using SkyGate_ADONET.Models.DTOs;
using SkyGate_ADONET.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeHRViewModel> GetAllEmployees();
        List<EmployeeHRViewModel> GetAllEmployeesForHR();
        Employee GetEmployeeById(string empId);
        List<Employee> GetSupervisors();
        (bool success, string message, string newID) CreateEmployee(EmployeeCreateDto dto);
        (bool success, string message) UpdateEmployee(Employee employee);
        (bool success, string message) ChangeEmployeeStatus(string empId, int status);
        (bool success, string message) AssignRoleToEmployee(string empId, string roleId);
        (bool success, string message) UpdateEmployeeForEdit(EmployeeEditDto dto);
        string GetEmployeeRole(string empId);
        List<EmployeeHRViewModel> SearchEmployees(EmployeeSearchCriteria criteria);
    }
}
