using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET
{
    internal class UserInfo
    {
        public static string EmpID { get; set; }
        public static string AccountID { get; set; }
        //public static string Account { get; set; }
        public static string EmpName { get; set; }
        public static string RoleName { get; set; }

        // 可以根據需要添加其他使用者相關資訊
        public static void Clear()
        {
            EmpID = null;
            AccountID = null;
            //Account = null;
            EmpName = null;
            RoleName = null;  
        }
    }
}
