using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.DAL.Repositories
{
    public interface ISysLogRepository
    {
        void LogAction(string empId, string action, string targetId = null, string details = null, string ip = null);
    }
}
