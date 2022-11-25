using IronPython.Compiler.Ast;
using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win32_CWI.NET_Application
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            this.Text = "DKCUI (Toolbox v" + Properties.Settings.Default.DKCVersion + ")";

            Version.Text = "DKC Version " + Properties.Settings.Default.DKCVersion + "       " + "DKCUI Version " + Properties.Settings.Default.DKCUIVersion;
            CmdOutput.Text = "Starting DKC Toolbox - Python " + Properties.Settings.Default.PythonVersion;

            Begin.Start();
        }

        private void StartApplet()
        {
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string DataFolder = AppData + @"\RWE Labs\DKC-Toolbox\";
            Execute.Enabled = false;
            Execute.Text = "Processing...";

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            start.WorkingDirectory = DataFolder;
            start.Arguments = string.Format("{0} {1}", "toolbox.py", "help");
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    CmdOutput.Clear();
                    string result = reader.ReadToEnd();
                    CmdOutput.Text = result;
                    Execute.Text = "Execute";
                    Task.Factory.StartNew(() => { Thread.Sleep(50); process.Kill(); });
                }
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Process process in Process.GetProcessesByName("Win32 CWI .NET Application (32 bit)"))
            { 
                process.Kill();
            }
            foreach (Process process in Process.GetProcessesByName("Win32 CWI .NET Application (64 bit)"))
            {
                process.Kill();
            }

            Application.Exit();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string DataFolder = AppData + @"\RWE Labs\DKC-Toolbox\";

            Execute.Enabled = false;
            Execute.Text = "Processing...";

            ProcessStartInfo start = new ProcessStartInfo();
            start.WorkingDirectory = DataFolder;
            start.FileName = "python.exe";
            start.Arguments = string.Format("{0} {1}", "toolbox.py", Command.Text);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    CmdOutput.Clear();
                    CmdOutput.Text = result;
                    Execute.Enabled = true;
                    Execute.Text = "Execute";
                    Task.Factory.StartNew(() => { Thread.Sleep(50); process.Kill(); });
                }
            }
        }

        private void Begin_Tick(object sender, EventArgs e)
        {
            Begin.Stop();
            StartApplet();

            Command.Focus();
        }

        private void Command_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Execute.PerformClick();
                e.Handled = true;
            }
        }

        private void Command_TextChanged(object sender, EventArgs e)
        {
            if(Command.Text == null)
            {
                Execute.Enabled = false;
            }
            else if(Command.Text.Trim().Length == 0)
            {
                Execute.Enabled = false;
            }
            else
            {
                Execute.Enabled = true;
            }
        }

        private void Settings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings setabout = new Settings();
            setabout.ShowDialog();
        }
    }
}
