using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Models.DTOs
{
    public class EmployeeHRViewModel
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public string Title { get; set; }
        public string SupervisorName { get; set; }
        public string StatusText { get; set; }
        public string HireDate { get; set; }
        public string LeaveDate { get; set; } 
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RoleName { get; set; }
    }
}
