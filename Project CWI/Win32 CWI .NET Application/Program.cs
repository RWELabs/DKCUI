using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win32_CWI.NET_Application
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LabsAppData = AppData + @"\RWE Labs\DKC-Toolbox\";
            string VersionFile = LabsAppData + @"version.txt";

            if (!Directory.Exists(LabsAppData))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Setup());
            }
            else
            {
                if(Properties.Settings.Default.PythonVersion == "RESET")
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Setup());
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Splash());
                }
            }
            
        }
    }
}
