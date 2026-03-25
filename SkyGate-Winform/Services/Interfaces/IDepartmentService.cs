using SkyGate_ADONET.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Services.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(string deptId);
        List<Department> GetSubDepartments(string parentId);
        List<Department> GetDepartmentTree();
        (bool success, string message) CreateDepartment(Department department);
        (bool success, string message) UpdateDepartment(Department department);
    }
}
