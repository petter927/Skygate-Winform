using SkyGate_ADONET.DAL.Repositories;
using SkyGate_ADONET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Services
{
    public class LogService : ILogService
    {
        private readonly ISysLogRepository _logRepository;

        public LogService(ISysLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void LogAction(string action, string targetId = null, string details = null, string ip = null)
        {
            _logRepository.LogAction(UserInfo.EmpID, action, targetId, details, ip);
        }
    }
}
