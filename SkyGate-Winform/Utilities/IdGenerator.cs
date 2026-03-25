using SkyGate_ADONET.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Utilities
{    
    public static class IdGenerator
    {
        
        public static string GenerateEmployeeId()
        {
            // 簡單的員工編號生成邏輯，實際應用中可能需要從資料庫獲取最新編號
            return $"Etemp{DateTime.Now:yyyyMMddHHmmss}";
        }

        public static string GenerateLogId()
        {
            return $"LOG{DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}
