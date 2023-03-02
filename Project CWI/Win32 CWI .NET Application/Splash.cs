using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win32_CWI.NET_Application.Properties;

namespace Win32_CWI.NET_Application
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();

            this.Text = "DKCUI [v" + Properties.Settings.Default.DKCUIVersion + "]";

            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LabsAppData = AppData + @"\RWE Labs\DKC-Toolbox\splash.mp4";
            SplashMedia.URL = LabsAppData;
            SplashMedia.enableContextMenu = false;
            SplashMedia.uiMode = "none";
            SplashMedia.stretchToFit = true;
            //SplashMedia.settings.setMode("loop", true);
            //SplashEnd.Start();

            string LabsAppDataFolder = AppData + @"\RWE Labs\DKC-Toolbox\";
            string VersionFile = LabsAppDataFolder + @"version.txt";

            VersionRead.LoadFile(VersionFile, RichTextBoxStreamType.PlainText);
            Properties.Settings.Default.DKCVersion = VersionRead.Text;
            Properties.Settings.Default.Save();
        }

        private void SplashEnd_Tick(object sender, EventArgs e)
        {
            SplashEnd.Stop();
            this.Hide();
            Main dash = new Main();
            dash.Show();
        }

        private void SplashMedia_MediaChange(object sender, _WMPOCXEvents_MediaChangeEvent e)
        {
           
        }

        private void SplashMedia_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(e.newState == 8)
            {
                this.Hide();
                Main dash = new Main();
                dash.Show();
            }
        }
    }
}
