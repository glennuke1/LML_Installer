
namespace LML_Installer
{
    partial class Installer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
            this.InstallButton = new System.Windows.Forms.Button();
            this.UninstallButton = new System.Windows.Forms.Button();
            this.SelectMSCButton = new System.Windows.Forms.Button();
            this.mscpathLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.bottomleft = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.middle = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.bottom = new System.Windows.Forms.Panel();
            this.bottomleft.SuspendLayout();
            this.panel3.SuspendLayout();
            this.middle.SuspendLayout();
            this.bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // InstallButton
            // 
            this.InstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.InstallButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.InstallButton.FlatAppearance.BorderSize = 0;
            this.InstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallButton.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallButton.ForeColor = System.Drawing.Color.Snow;
            this.InstallButton.Location = new System.Drawing.Point(0, 0);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(103, 36);
            this.InstallButton.TabIndex = 0;
            this.InstallButton.Text = "Install";
            this.InstallButton.UseVisualStyleBackColor = false;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // UninstallButton
            // 
            this.UninstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.UninstallButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.UninstallButton.FlatAppearance.BorderSize = 0;
            this.UninstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UninstallButton.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UninstallButton.ForeColor = System.Drawing.Color.Snow;
            this.UninstallButton.Location = new System.Drawing.Point(131, 0);
            this.UninstallButton.Name = "UninstallButton";
            this.UninstallButton.Size = new System.Drawing.Size(103, 36);
            this.UninstallButton.TabIndex = 1;
            this.UninstallButton.Text = "Uninstall";
            this.UninstallButton.UseVisualStyleBackColor = false;
            this.UninstallButton.Click += new System.EventHandler(this.UninstallButton_Click);
            // 
            // SelectMSCButton
            // 
            this.SelectMSCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SelectMSCButton.FlatAppearance.BorderSize = 0;
            this.SelectMSCButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectMSCButton.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectMSCButton.ForeColor = System.Drawing.Color.Snow;
            this.SelectMSCButton.Location = new System.Drawing.Point(10, 12);
            this.SelectMSCButton.Name = "SelectMSCButton";
            this.SelectMSCButton.Size = new System.Drawing.Size(212, 32);
            this.SelectMSCButton.TabIndex = 2;
            this.SelectMSCButton.Text = "Select MWC EXE";
            this.SelectMSCButton.UseVisualStyleBackColor = false;
            this.SelectMSCButton.Click += new System.EventHandler(this.SelectMSCButton_Click);
            // 
            // mscpathLabel
            // 
            this.mscpathLabel.AutoSize = true;
            this.mscpathLabel.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mscpathLabel.ForeColor = System.Drawing.Color.Snow;
            this.mscpathLabel.Location = new System.Drawing.Point(230, 20);
            this.mscpathLabel.Name = "mscpathLabel";
            this.mscpathLabel.Size = new System.Drawing.Size(0, 19);
            this.mscpathLabel.TabIndex = 3;
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.noteLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noteLabel.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLabel.ForeColor = System.Drawing.Color.Snow;
            this.noteLabel.Location = new System.Drawing.Point(10, 50);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(589, 56);
            this.noteLabel.TabIndex = 4;
            this.noteLabel.Text = "If you previously used MSCLoader, \r\nmake sure to backup your mods folder by eithe" +
    "r moving it, or renaming it\r\n";
            // 
            // bottomleft
            // 
            this.bottomleft.Controls.Add(this.UninstallButton);
            this.bottomleft.Controls.Add(this.panel3);
            this.bottomleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.bottomleft.Location = new System.Drawing.Point(0, 0);
            this.bottomleft.Name = "bottomleft";
            this.bottomleft.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.bottomleft.Size = new System.Drawing.Size(367, 46);
            this.bottomleft.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.InstallButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(121, 36);
            this.panel3.TabIndex = 2;
            // 
            // middle
            // 
            this.middle.Controls.Add(this.progressBar);
            this.middle.Controls.Add(this.SelectMSCButton);
            this.middle.Controls.Add(this.mscpathLabel);
            this.middle.Controls.Add(this.noteLabel);
            this.middle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middle.Location = new System.Drawing.Point(0, 0);
            this.middle.Name = "middle";
            this.middle.Size = new System.Drawing.Size(689, 318);
            this.middle.TabIndex = 8;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(10, 109);
            this.progressBar.Maximum = 13;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(589, 15);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;
            // 
            // bottom
            // 
            this.bottom.Controls.Add(this.bottomleft);
            this.bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom.Location = new System.Drawing.Point(0, 272);
            this.bottom.Name = "bottom";
            this.bottom.Size = new System.Drawing.Size(689, 46);
            this.bottom.TabIndex = 5;
            // 
            // Installer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(689, 318);
            this.Controls.Add(this.bottom);
            this.Controls.Add(this.middle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(619, 245);
            this.Name = "Installer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.installer_FormClosing);
            this.Load += new System.EventHandler(this.installer_Load);
            this.bottomleft.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.middle.ResumeLayout(false);
            this.middle.PerformLayout();
            this.bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.Button UninstallButton;
        private System.Windows.Forms.Button SelectMSCButton;
        private System.Windows.Forms.Label mscpathLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Panel bottomleft;
        private System.Windows.Forms.Panel middle;
        private System.Windows.Forms.Panel bottom;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}