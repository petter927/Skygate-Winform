using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Models.Entities
{
    public class SysLog
    {
        public string LogID { get; set; }
        public string EmpID { get; set; }
        public string Action { get; set; }
        public string TargetID { get; set; }
        public string Details { get; set; }
        public DateTime LogTime { get; set; }
        public string IP { get; set; }
    }
}
