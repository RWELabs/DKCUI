using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace Win32_CWI.NET_Application
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            UIVersion.Text = Properties.Settings.Default.DKCUIVersion;
            TBVersion.Text = Properties.Settings.Default.DKCVersion;
            UICurrentVersion.Text = Properties.Settings.Default.DKCUIVersion;
            CurrentToolboxVersion.Text = Properties.Settings.Default.DKCVersion;

            UIDeveloper.Text = "RWE Labs";
            TBDeveloper.Text = "H4v0c21";

            UIPublisher.Text = "RWE Labs";
            TBPublisher.Text = "H4v0c21";

            UICopyright.Text = "2022 - RWE Labs";
            TBCopyright.Text = "2022 - H4v0c21";
        }

        private void UICheckUpdate_Click(object sender, EventArgs e)
        {
            //Check for updates
            string CurrentUpdateVersion = "https://raw.githubusercontent.com/RWELabs/DKCUI/main/Resources/uc.txt";
            UICheckUpdate.Text = "Please wait...";

            //View current stable version number
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(CurrentUpdateVersion);
            StreamReader reader = new StreamReader(stream);
            String CVER = reader.ReadToEnd();

            //Compare current stable version against installed version
            if (CVER.Contains(Properties.Settings.Default.DKCUIVersion))
            {
                //Up to date
                UILatestVersion.Text = CVER;
                UICheckUpdate.Text = "Up to date!";
            }
            else
            {
                UILatestVersion.Text= CVER;
                UICheckUpdate.Text = "Updates available.";
                UICheckUpdate.Enabled = false;
                UIGetUpdate.Enabled = true;
            }
        }

        private void UIGetUpdate_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DownloadURL = "https://raw.githubusercontent.com/RWELabs/DKCUI/main/Resources/DKCSetup.exe";

            UIUpdateDownload dl = new UIUpdateDownload();
            dl.ShowDialog();
        }

        private void ToolboxCheckUpdate_Click(object sender, EventArgs e)
        {
            //Check for updates
            string CurrentUpdateVersion = "https://raw.githubusercontent.com/RWELabs/DKCUI/main/Resources/tb-uc.txt";
            ToolboxCheckUpdate.Text = "Please wait...";

            //View current stable version number
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(CurrentUpdateVersion);
            StreamReader reader = new StreamReader(stream);
            String CVER = reader.ReadToEnd();

            //Compare current stable version against installed version
            if (CVER.Contains(Properties.Settings.Default.DKCVersion))
            {
                //Up to date
                LatestToolboxVersion.Text = CVER;
                ToolboxCheckUpdate.Text = "Up to date!";
                ToolboxCheckUpdate.Enabled = true;
            }
            else
            {
                LatestToolboxVersion.Text = CVER;
                ToolboxCheckUpdate.Text = "Updates available.";
                ToolboxCheckUpdate.Enabled = true;

                DialogResult dr = MessageBox.Show("The DKC Toolbox has updates available. Would you like to download these updates?", "Framework Update | DKCUI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    //Properties.Settings.Default.DownloadURL = "";

                    string AppFolder = AppDomain.CurrentDomain.BaseDirectory;
                    string TBUpdate = AppFolder + @"\tbupdate.exe";
                    Process.Start(TBUpdate);
                    Application.Exit();
                }
            }
        }

        private void PythonReinstall_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PythonVersion = "RESET";
            Properties.Settings.Default.Save();
            string AppFolder = AppDomain.CurrentDomain.BaseDirectory;
            string Recovery = AppFolder + @"\recovery.bat";
            Process.Start(Recovery);
            Application.Exit();
        }
    }
}
