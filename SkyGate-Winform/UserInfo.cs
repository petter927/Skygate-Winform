using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET
{
    // 為什麼用 static ? 為了讓全系統視窗都能直接存取當前登入者資訊，不需透過參數傳遞。
    internal class UserInfo
    {
        public static string EmpID { get; set; }
        public static string AccountID { get; set; }
        //public static string Account { get; set; }
        public static string EmpName { get; set; }
        public static string RoleName { get; set; }

        // 為什麼要 Clear ? 登出時必須手動清空，避免靜態變數駐留在記憶體導致下位使用者讀取到舊資料。
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
