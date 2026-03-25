using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Services.Interfaces
{
    public interface ILogService
    {
        void LogAction(string action, string targetId = null, string details = null, string ip = null);
    }
}
