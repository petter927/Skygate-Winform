using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Models.DTOs
{
    public class EmployeeEditDto
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string DeptID { get; set; }
        public string Title { get; set; }
        public string SupervisorID { get; set; }
        public string Status { get; set; }
        public string HireDate { get; set; }
        public string LeaveDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RoleID { get; set; }
    }
}
