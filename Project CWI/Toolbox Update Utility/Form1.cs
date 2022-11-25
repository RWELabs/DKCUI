using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toolbox_Update_Utility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Downloading Updates | DKCUI";
            StatusText.Text = "Gathering information...";

            StartUpdate();
        }

        private void StartUpdate()
        {
            StatusText.Text = "Retrieving update information...";

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                    string updatelocation = Path.Combine(dataPath, "DKCTOOLBOXUPDATE.zip");

                    wc.DownloadProgressChanged += wc_DownloadProgressChanged2;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;

                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://raw.githubusercontent.com/RWELabs/DKCUI/main/Resources/latesttoolbox.zip"),
                        // Param2 = Path to save
                        updatelocation
                    );

                    this.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // First check for Cancelled and then for other exceptions
            if (e.Cancelled)
            {
                MessageBox.Show("Cancelled");
                Application.Exit();
            }
            if (e.Error != null)
            {
                // handle error scenario
                throw e.Error;
                MessageBox.Show(e.Error.Message);
                Application.Exit();
            }
            else
            {
                StartExecute.Start();
            }
        }

        void wc_DownloadProgressChanged2(object sender, DownloadProgressChangedEventArgs e)
        {
            InstallProgress.Value = e.ProgressPercentage;
            long FileSize = e.TotalBytesToReceive / 1024;
            long FileSizeMB = FileSize / 1000;
            //DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + FileSize.ToString() + " kb";

            StatusText.Text = "Downloading " + e.ProgressPercentage.ToString() + "% of " + FileSizeMB.ToString() + "mb (" + FileSize + "kb)";
        }

        private void StartExecute_Tick(object sender, EventArgs e)
        {
            StartExecute.Stop();

            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string updatelocation = Path.Combine(dataPath, "DKCTOOLBOXUPDATE.zip");

            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LabsAppData = AppData + @"\RWE Labs\DKC-Toolbox\";
            string VersionFile = LabsAppData + @"version.txt";

            using (Ionic.Zip.ZipFile zip1 = Ionic.Zip.ZipFile.Read(updatelocation))
            {
                foreach (ZipEntry entry in zip1)
                {
                    entry.Extract(LabsAppData, ExtractExistingFileAction.OverwriteSilently);
                }
            }

            MessageBox.Show("Toolbox update has been installed successfully. You'll need to relaunch the program to continue.");
            Application.Exit();
        }
    }
}
