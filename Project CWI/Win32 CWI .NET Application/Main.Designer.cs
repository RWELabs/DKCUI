namespace Win32_CWI.NET_Application
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Command = new System.Windows.Forms.TextBox();
            this.Execute = new System.Windows.Forms.Button();
            this.CmdOutput = new System.Windows.Forms.RichTextBox();
            this.Begin = new System.Windows.Forms.Timer(this.components);
            this.Settings = new System.Windows.Forms.LinkLabel();
            this.Version = new System.Windows.Forms.Label();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Tab_CommandLine = new System.Windows.Forms.TabPage();
            this.Tabs.SuspendLayout();
            this.Tab_CommandLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // Command
            // 
            this.Command.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Command.Location = new System.Drawing.Point(8, 10);
            this.Command.Name = "Command";
            this.Command.Size = new System.Drawing.Size(355, 20);
            this.Command.TabIndex = 0;
            this.Command.TextChanged += new System.EventHandler(this.Command_TextChanged);
            this.Command.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Command_KeyDown);
            // 
            // Execute
            // 
            this.Execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Execute.Enabled = false;
            this.Execute.Location = new System.Drawing.Point(369, 8);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(72, 22);
            this.Execute.TabIndex = 1;
            this.Execute.Text = "Execute";
            this.Execute.UseVisualStyleBackColor = true;
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // CmdOutput
            // 
            this.CmdOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdOutput.BackColor = System.Drawing.Color.Black;
            this.CmdOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CmdOutput.Font = new System.Drawing.Font("Cascadia Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdOutput.ForeColor = System.Drawing.Color.White;
            this.CmdOutput.Location = new System.Drawing.Point(6, 6);
            this.CmdOutput.Name = "CmdOutput";
            this.CmdOutput.ReadOnly = true;
            this.CmdOutput.Size = new System.Drawing.Size(417, 367);
            this.CmdOutput.TabIndex = 2;
            this.CmdOutput.Text = "";
            // 
            // Begin
            // 
            this.Begin.Interval = 2250;
            this.Begin.Tick += new System.EventHandler(this.Begin_Tick);
            // 
            // Settings
            // 
            this.Settings.ActiveLinkColor = System.Drawing.Color.Blue;
            this.Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Settings.AutoSize = true;
            this.Settings.Location = new System.Drawing.Point(394, 447);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(45, 13);
            this.Settings.TabIndex = 3;
            this.Settings.TabStop = true;
            this.Settings.Text = "Settings";
            this.Settings.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Settings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Settings_LinkClicked);
            // 
            // Version
            // 
            this.Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Version.AutoSize = true;
            this.Version.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Version.Location = new System.Drawing.Point(12, 447);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(54, 13);
            this.Version.TabIndex = 4;
            this.Version.Text = "Loading...";
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Controls.Add(this.Tab_CommandLine);
            this.Tabs.Location = new System.Drawing.Point(8, 36);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(437, 405);
            this.Tabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Tabs.TabIndex = 5;
            // 
            // Tab_CommandLine
            // 
            this.Tab_CommandLine.BackColor = System.Drawing.Color.Black;
            this.Tab_CommandLine.Controls.Add(this.CmdOutput);
            this.Tab_CommandLine.Location = new System.Drawing.Point(4, 22);
            this.Tab_CommandLine.Name = "Tab_CommandLine";
            this.Tab_CommandLine.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_CommandLine.Size = new System.Drawing.Size(429, 379);
            this.Tab_CommandLine.TabIndex = 0;
            this.Tab_CommandLine.Text = "Command Line";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 469);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Execute);
            this.Controls.Add(this.Command);
            this.Controls.Add(this.Tabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DKCUI (Toolbox v0.00)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Tabs.ResumeLayout(false);
            this.Tab_CommandLine.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Command;
        private System.Windows.Forms.Button Execute;
        private System.Windows.Forms.RichTextBox CmdOutput;
        private System.Windows.Forms.Timer Begin;
        private System.Windows.Forms.LinkLabel Settings;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Tab_CommandLine;
    }
}