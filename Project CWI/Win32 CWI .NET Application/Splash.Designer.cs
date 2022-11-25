namespace Win32_CWI.NET_Application
{
    partial class Splash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.SplashEnd = new System.Windows.Forms.Timer(this.components);
            this.VersionRead = new System.Windows.Forms.RichTextBox();
            this.SplashMedia = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.SplashMedia)).BeginInit();
            this.SuspendLayout();
            // 
            // SplashEnd
            // 
            this.SplashEnd.Interval = 500;
            this.SplashEnd.Tick += new System.EventHandler(this.SplashEnd_Tick);
            // 
            // VersionRead
            // 
            this.VersionRead.Location = new System.Drawing.Point(12, 12);
            this.VersionRead.Name = "VersionRead";
            this.VersionRead.Size = new System.Drawing.Size(100, 26);
            this.VersionRead.TabIndex = 1;
            this.VersionRead.Text = "";
            // 
            // SplashMedia
            // 
            this.SplashMedia.Enabled = true;
            this.SplashMedia.Location = new System.Drawing.Point(-8, -12);
            this.SplashMedia.Name = "SplashMedia";
            this.SplashMedia.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SplashMedia.OcxState")));
            this.SplashMedia.Size = new System.Drawing.Size(560, 333);
            this.SplashMedia.TabIndex = 0;
            this.SplashMedia.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.SplashMedia_PlayStateChange);
            this.SplashMedia.MediaChange += new AxWMPLib._WMPOCXEvents_MediaChangeEventHandler(this.SplashMedia_MediaChange);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 311);
            this.ControlBox = false;
            this.Controls.Add(this.SplashMedia);
            this.Controls.Add(this.VersionRead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DCK Toolbox";
            ((System.ComponentModel.ISupportInitialize)(this.SplashMedia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer SplashMedia;
        private System.Windows.Forms.Timer SplashEnd;
        private System.Windows.Forms.RichTextBox VersionRead;
    }
}

