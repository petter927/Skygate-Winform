using SkyGate_Winform.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Services
{
    public class ConfigurationService
    {
        public static string GetConnectionString()
        {
            return ConnectionStringHelper.GetConnectionString();
        }
        
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
