using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Models.DTOs
{
    public class EmployeeSearchCriteria
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string DeptID { get; set; }
        public string Title { get; set; }
        public string SupervisorID { get; set; }

        // 檢查是否有任何搜尋條件
        public bool HasCriteria()
        {
            return !string.IsNullOrEmpty(EmpID) ||
                   !string.IsNullOrEmpty(EmpName) ||
                   !string.IsNullOrEmpty(DeptID) ||
                   !string.IsNullOrEmpty(Title) ||
                   !string.IsNullOrEmpty(SupervisorID);
        }
    }
}
