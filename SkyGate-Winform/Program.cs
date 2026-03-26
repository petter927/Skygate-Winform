using System;
using System.Windows.Forms;

namespace SkyGate_ADONET
{
    internal static class Program
    {
        
        // 應用程式的主要進入點（使用 ApplicationContext 管理登入 / 登出流程）。        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainApplicationContext());
        }
    }    
}