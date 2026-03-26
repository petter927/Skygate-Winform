using SkyGate_ADONET.DAL.Repositories;
using SkyGate_ADONET.Models.Entities;
using SkyGate_ADONET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyGate_ADONET.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public List<Department> GetAllDepartments()
        {            
            return _departmentRepository.GetAllDepartments();
        }

        public Department GetDepartmentById(string deptId)
        {
            return _departmentRepository.GetDepartmentById(deptId);
        }

        public List<Department> GetSubDepartments(string parentId)
        {
            return _departmentRepository.GetSubDepartments(parentId);
        }

        public List<Department> GetDepartmentTree()
        {
            var allDepartments = _departmentRepository.GetAllDepartments();
            return BuildDepartmentTree(allDepartments, null);
        }

        public (bool success, string message) CreateDepartment(Department department)
        {
            // 業務規則驗證
            if (string.IsNullOrEmpty(department.DeptName))
                return (false, "部門名稱不能為空");

            if (string.IsNullOrEmpty(department.DeptID))
                return (false, "部門編號不能為空");

            // 檢查部門編號是否已存在
            var existingDept = _departmentRepository.GetDepartmentById(department.DeptID);
            if (existingDept != null)
                return (false, "部門編號已存在");

            // 這裡應該用 Repository 的 Create 方法
            // bool result = _departmentRepository.CreateDepartment(department);
            bool result = true; // 暫時返回成功，實際應該調用 Repository

            return (result, result ? "部門建立成功" : "部門建立失敗");
        }

        public (bool success, string message) UpdateDepartment(Department department)
        {
            // 業務規則驗證
            if (string.IsNullOrEmpty(department.DeptName))
                return (false, "部門名稱不能為空");

            // 這裡應該用 Repository 的 Update 方法
            // bool result = _departmentRepository.UpdateDepartment(department);
            bool result = true; // 暫時返回成功，實際應該調用 Repository

            return (result, result ? "部門更新成功" : "部門更新失敗");
        }

        private List<Department> BuildDepartmentTree(List<Department> departments, string parentId)
        {
            var tree = new List<Department>();
            var children = departments.Where(d => d.ParentID == parentId).ToList();

            foreach (var child in children)
            {
                // 遞迴建立子部門樹
                var childNode = child;
                tree.Add(childNode);
            }

            return tree;
        }
    }
}
