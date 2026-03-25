using SkyGate_ADONET.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.DAL.Repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(string deptId);
        List<Department> GetSubDepartments(string parentId);
        bool CreateDepartment(Department department);
        bool UpdateDepartment(Department department);
    }
}
