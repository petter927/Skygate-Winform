using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Models.Entities
{
    public class Employee
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string DeptID { get; set; }
        public string Title { get; set; }
        public string SupervisorID { get; set; }
        public int Status { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
