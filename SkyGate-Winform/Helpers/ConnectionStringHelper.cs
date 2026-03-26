using System;
using System.Configuration;

namespace SkyGate_Winform.Helpers
{
    public static class ConnectionStringHelper
    {
        private const string EnvVariableName = "SKYGATE_CONNECTION_STRING";
        private const string ConfigKeyName = "SkyGateConnection";
        
        /// 取得連線字串：優先從環境變數，回退到 App.config        
        public static string GetConnectionString()
        {
            // 優先從環境變數取得
            string envConnection = Environment.GetEnvironmentVariable(EnvVariableName);
            if (!string.IsNullOrWhiteSpace(envConnection))
            {
                return envConnection;
            }

            // 退到 App.config（Local開發測試用）
            string configConnection = ConfigurationManager.ConnectionStrings[ConfigKeyName]?.ConnectionString;
            if (!string.IsNullOrWhiteSpace(configConnection))
            {
                return configConnection;
            }

            throw new InvalidOperationException(
                $"無法找到連線字串。請設定環境變數 '{EnvVariableName}' 或在 App.config 中設定 '{ConfigKeyName}'。");
        }
    }
}