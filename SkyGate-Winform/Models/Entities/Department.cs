using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Models.Entities
{
    public class Department
    {
        public string DeptID { get; set; }
        public string DeptName { get; set; }
        public string ParentID { get; set; }
        public string ManagerID { get; set; }
    }
}
