using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win32_CWI.NET_Application
{
    public partial class UIUpdateDownload : Form
    {
        public UIUpdateDownload()
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
                    string updatelocation = Path.Combine(dataPath, "DKCUIlatest.exe");

                    wc.DownloadProgressChanged += wc_DownloadProgressChanged2;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;

                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri(Properties.Settings.Default.DownloadURL),
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
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string updatelocation = Path.Combine(dataPath, "DKCUIlatest.exe");

            StartExecute.Stop();

            this.Focus();
            this.BringToFront();
            this.TopMost = true;

            try
            {
                DialogResult dr = MessageBox.Show("The update has been downloaded, the application will now close as the installer will launch.", "Update Software | RWE Labs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    Application.Exit();
                    Process.Start(updatelocation);
                    Application.Exit();
                }
                else
                {
                    this.Close();
                    Application.Exit();
                    Process.Start(updatelocation);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue launching the update package. Do you have administrative priviliges on this user account?" + Environment.NewLine + ex.Message, "RWE Labs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                Application.Exit();
            }
        }
    }
}
