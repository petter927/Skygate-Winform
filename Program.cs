using System;
using System.Linq;
using System.Windows.Forms;

namespace SkyGate_ADONET
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainApplicationContext());
        }
    }    
}
