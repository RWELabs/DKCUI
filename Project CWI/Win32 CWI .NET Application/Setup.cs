using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win32_CWI.NET_Application
{
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();

            InstallProgress.Value = 25;

            StatusText.Text = "Preparing setup...";

            InstallStepOne.Start();
        }

        private void InstallStepOne_Tick(object sender, EventArgs e)
        {
            InstallStepOne.Stop();
            StatusText.Text = "Extracting files...";
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LabsAppData = AppData + @"\RWE Labs\";
            string DataFolder = AppData + @"\RWE Labs\DKC-Toolbox\";

            string InstallFolder = Application.StartupPath;
            string InternalData = InstallFolder + @"\internal.zip";

            //ZipFile.ExtractToDirectory(InternalData, DataFolder);

            using (Ionic.Zip.ZipFile zip1 = Ionic.Zip.ZipFile.Read(InternalData))
            {
                foreach (ZipEntry entry in zip1)
                {
                    entry.Extract(DataFolder, ExtractExistingFileAction.OverwriteSilently);
                }
            }

            InstallProgress.Value = 38;
            InstallStepTwo.Start();
        }

        private void InstallStepTwo_Tick(object sender, EventArgs e)
        {
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LabsAppData = AppData + @"\RWE Labs\";
            string DataFolder = AppData + @"\RWE Labs\DKC-Toolbox\";

            InstallStepTwo.Stop();
            StatusText.Text = "Checking Python...";
            ProcessStartInfo pycheck = new ProcessStartInfo();
            pycheck.FileName = @"python.exe";
            pycheck.WorkingDirectory = DataFolder;
            pycheck.Arguments = "--version";
            pycheck.UseShellExecute = false;
            pycheck.RedirectStandardOutput = true;
            pycheck.CreateNoWindow = true;

            try
            {
                using (Process process = Process.Start(pycheck))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        //PythonVersion.Text = result.Replace("Python ", null);
                        Properties.Settings.Default.PythonVersion = result.Replace("Python ", null);
                        Properties.Settings.Default.Save();

                        Task.Factory.StartNew(() => { Thread.Sleep(25); process.Kill(); });

                        CheckPython();
                    }
                }
            }
            catch
            {
                //Assume that Python is not installed, as per Issue #3 (https://github.com/RWELabs/DKCUI/issues/3#issuecomment-1451052928)
                Properties.Settings.Default.PythonVersion = null;
                Properties.Settings.Default.Save();
                CheckPython();
            }
            
        }

        private void CheckPython()
        {
            var localversion = new Version(Properties.Settings.Default.PythonVersion);
            var minversion = new Version(Properties.Settings.Default.PythonMinVersion);

            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LabsAppData = AppData + @"\RWE Labs\";
            string DataFolder = AppData + @"\RWE Labs\DKC-Toolbox\";

            if (localversion < minversion)
            {
                string PythonInstaller = "https://www.microsoft.com/store/productId/9PJPW5LDXLZ5";
                StatusText.Text = "Python Version Issue";
                MessageBox.Show("This application is missing the following dependencies:" + Environment.NewLine + Environment.NewLine + "Python 3.10.0 or higher." + Environment.NewLine + Environment.NewLine + "Please install these dependencies before retrying the installation process.");
                Process.Start(PythonInstaller);

                //Directory.Delete(DataFolder, true);
                Application.Exit();
            }
            else if (localversion >= minversion)
            {
                InstallStepThree.Start();
                StatusText.Text = "Thinking...";
                InstallProgress.Value = 65;
            }
            else if (localversion == null)
            {
                //no version
                string PythonInstaller = "https://www.microsoft.com/store/productId/9PJPW5LDXLZ5";
                StatusText.Text = "Python Version Issue";
                MessageBox.Show("This application is missing the following dependencies:" + Environment.NewLine + Environment.NewLine + "Python 3.10.0 or higher." + Environment.NewLine + Environment.NewLine + "Please install these dependencies before retrying the installation process.");
                Process.Start(PythonInstaller);

                //Directory.Delete(DataFolder, true);
                Application.Exit();
            }
        }

        private void InstallStepThree_Tick(object sender, EventArgs e)
        {
            InstallStepThree.Stop();
            InstallProgress.Value = 74;

            StatusText.Text = "Installing Python Dependencies...";

            //string InstallFolder = Application.StartupPath;
            //string Data = InstallFolder + @"\install.bat";
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LabsAppData = AppData + @"\RWE Labs\";
            string DataFolder = AppData + @"\RWE Labs\DKC-Toolbox\";

            ProcessStartInfo install = new ProcessStartInfo();
            install.FileName = DataFolder + "install.bat";
            install.WorkingDirectory = DataFolder;
            install.UseShellExecute = false;
            install.RedirectStandardOutput = true;
            install.CreateNoWindow = true;
            Process.Start(install);

            InstallStepFour.Start();
        }

        private void InstallStepFour_Tick(object sender, EventArgs e)
        {
            InstallProgress.Value = 86;
            InstallStepFour.Stop();
            StatusText.Text = "Checking Python Dependencies...";
            CheckDependencies.RunWorkerAsync();
        }

        private void CheckDependencies_DoWork(object sender, DoWorkEventArgs e)
        {
            //string InstallFolder = Application.StartupPath;
            //string Data = InstallFolder + @"\checkpkg.bat";
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LabsAppData = AppData + @"\RWE Labs\";
            string DataFolder = AppData + @"\RWE Labs\DKC-Toolbox\";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = DataFolder + "checkpkg.bat";
            process.StartInfo.WorkingDirectory = DataFolder;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            string q = "";
            while (!process.HasExited)
            {
                q += process.StandardOutput.ReadToEnd();
            }

            piplist.Invoke(new MethodInvoker(delegate { piplist.Text = q; }));
            Task.Factory.StartNew(() => { Thread.Sleep(25); process.Kill(); });
        }

        private void CheckDependencies_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InstallProgress.Value = 97;

            if (piplist.Text.ToLower().Contains("pillow"))
            {
                //Pillow exists
                StatusText.Text = "Writing files...";
                string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string LabsAppData = AppData + @"\RWE Labs\";
                string DataFolder = AppData + @"\RWE Labs\DKC-Toolbox\";

                if (!Directory.Exists(DataFolder))
                {
                    Directory.CreateDirectory(DataFolder);
                }

                Cleanup();
            }
            else
            {
                MessageBox.Show("Some dependencies couldn't be installed automatically. You may need to install these manually for the application to function correctly.");
                
                StatusText.Text = "Writing files...";
                string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string LabsAppData = AppData + @"\RWE Labs\";
                string DataFolder = AppData + @"\RWE Labs\DKC-Toolbox\";

                if (!Directory.Exists(DataFolder))
                {
                    Directory.CreateDirectory(DataFolder);
                }

                Cleanup();
            }
        }

        private void Cleanup()
        {
            StatusText.Text = "Cleaning up...";
            InstallProgress.Value = 100;

            FinishSetupTimer.Start();
        }

        private void FinishSetupTimer_Tick(object sender, EventArgs e)
        {
            FinishSetupTimer.Stop();
            this.Hide();

            Splash sp = new Splash();
            sp.Show();
        }
    }
}
