using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Models.DTOs
{
    public class EmployeeCreateDto
    {
        public string EmpName { get; set; }
        public string DeptID { get; set; }
        public string Title { get; set; }
        public string SupervisorID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RoleID { get; set; } // 員工角色
    }
}
