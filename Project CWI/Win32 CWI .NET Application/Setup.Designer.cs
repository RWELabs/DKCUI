namespace Win32_CWI.NET_Application
{
    partial class Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.InstallStepOne = new System.Windows.Forms.Timer(this.components);
            this.InstallStepTwo = new System.Windows.Forms.Timer(this.components);
            this.StatusText = new System.Windows.Forms.Label();
            this.InstallStepThree = new System.Windows.Forms.Timer(this.components);
            this.InstallProgress = new System.Windows.Forms.ProgressBar();
            this.InstallStepFour = new System.Windows.Forms.Timer(this.components);
            this.piplist = new System.Windows.Forms.RichTextBox();
            this.CheckDependencies = new System.ComponentModel.BackgroundWorker();
            this.FinishSetupTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // InstallStepOne
            // 
            this.InstallStepOne.Interval = 2500;
            this.InstallStepOne.Tick += new System.EventHandler(this.InstallStepOne_Tick);
            // 
            // InstallStepTwo
            // 
            this.InstallStepTwo.Interval = 1500;
            this.InstallStepTwo.Tick += new System.EventHandler(this.InstallStepTwo_Tick);
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.StatusText.Location = new System.Drawing.Point(12, 98);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(73, 13);
            this.StatusText.TabIndex = 0;
            this.StatusText.Text = "Please wait...";
            // 
            // InstallStepThree
            // 
            this.InstallStepThree.Interval = 1800;
            this.InstallStepThree.Tick += new System.EventHandler(this.InstallStepThree_Tick);
            // 
            // InstallProgress
            // 
            this.InstallProgress.Location = new System.Drawing.Point(15, 116);
            this.InstallProgress.Name = "InstallProgress";
            this.InstallProgress.Size = new System.Drawing.Size(265, 23);
            this.InstallProgress.TabIndex = 1;
            // 
            // InstallStepFour
            // 
            this.InstallStepFour.Interval = 11500;
            this.InstallStepFour.Tick += new System.EventHandler(this.InstallStepFour_Tick);
            // 
            // piplist
            // 
            this.piplist.Location = new System.Drawing.Point(15, 116);
            this.piplist.Name = "piplist";
            this.piplist.Size = new System.Drawing.Size(100, 23);
            this.piplist.TabIndex = 2;
            this.piplist.Text = "";
            this.piplist.Visible = false;
            // 
            // CheckDependencies
            // 
            this.CheckDependencies.WorkerReportsProgress = true;
            this.CheckDependencies.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CheckDependencies_DoWork);
            this.CheckDependencies.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CheckDependencies_RunWorkerCompleted);
            // 
            // FinishSetupTimer
            // 
            this.FinishSetupTimer.Interval = 2000;
            this.FinishSetupTimer.Tick += new System.EventHandler(this.FinishSetupTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "DKC Toolbox (Setup)";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Win32_CWI.NET_Application.Properties.Resources.DKCTK;
            this.pictureBox2.Location = new System.Drawing.Point(15, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 57);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Win32_CWI.NET_Application.Properties.Resources.Loading;
            this.pictureBox1.Location = new System.Drawing.Point(230, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(292, 151);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.piplist);
            this.Controls.Add(this.InstallProgress);
            this.Controls.Add(this.StatusText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup | DKC Toolbox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer InstallStepOne;
        private System.Windows.Forms.Timer InstallStepTwo;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.Timer InstallStepThree;
        private System.Windows.Forms.ProgressBar InstallProgress;
        private System.Windows.Forms.Timer InstallStepFour;
        private System.Windows.Forms.RichTextBox piplist;
        private System.ComponentModel.BackgroundWorker CheckDependencies;
        private System.Windows.Forms.Timer FinishSetupTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}