
namespace LML_Installer
{
    partial class installer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(installer));
            this.InstallButton = new System.Windows.Forms.Button();
            this.UninstallButton = new System.Windows.Forms.Button();
            this.SelectMSCButton = new System.Windows.Forms.Button();
            this.mscpathLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.InstallOfficialModsCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // InstallButton
            // 
            this.InstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.InstallButton.FlatAppearance.BorderSize = 0;
            this.InstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallButton.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallButton.ForeColor = System.Drawing.Color.Snow;
            this.InstallButton.Location = new System.Drawing.Point(12, 287);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(103, 32);
            this.InstallButton.TabIndex = 0;
            this.InstallButton.Text = "Install";
            this.InstallButton.UseVisualStyleBackColor = false;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // UninstallButton
            // 
            this.UninstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.UninstallButton.FlatAppearance.BorderSize = 0;
            this.UninstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UninstallButton.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UninstallButton.ForeColor = System.Drawing.Color.Snow;
            this.UninstallButton.Location = new System.Drawing.Point(121, 287);
            this.UninstallButton.Name = "UninstallButton";
            this.UninstallButton.Size = new System.Drawing.Size(103, 32);
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
            this.SelectMSCButton.Location = new System.Drawing.Point(12, 12);
            this.SelectMSCButton.Name = "SelectMSCButton";
            this.SelectMSCButton.Size = new System.Drawing.Size(212, 32);
            this.SelectMSCButton.TabIndex = 2;
            this.SelectMSCButton.Text = "Select MSC EXE";
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
            this.noteLabel.Location = new System.Drawing.Point(12, 50);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(589, 56);
            this.noteLabel.TabIndex = 4;
            this.noteLabel.Text = "If you previously used MSCLoader, \r\nmake sure to backup your mods folder by eithe" +
    "r moving it, or renaming it\r\n";
            // 
            // InstallOfficialModsCheckbox
            // 
            this.InstallOfficialModsCheckbox.AutoSize = true;
            this.InstallOfficialModsCheckbox.Checked = true;
            this.InstallOfficialModsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InstallOfficialModsCheckbox.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallOfficialModsCheckbox.ForeColor = System.Drawing.Color.Snow;
            this.InstallOfficialModsCheckbox.Location = new System.Drawing.Point(12, 249);
            this.InstallOfficialModsCheckbox.Name = "InstallOfficialModsCheckbox";
            this.InstallOfficialModsCheckbox.Size = new System.Drawing.Size(407, 32);
            this.InstallOfficialModsCheckbox.TabIndex = 5;
            this.InstallOfficialModsCheckbox.Text = "Install official mods (e.g. Console, Mod Settings)";
            this.InstallOfficialModsCheckbox.UseVisualStyleBackColor = true;
            // 
            // installer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(692, 331);
            this.Controls.Add(this.InstallOfficialModsCheckbox);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.mscpathLabel);
            this.Controls.Add(this.SelectMSCButton);
            this.Controls.Add(this.UninstallButton);
            this.Controls.Add(this.InstallButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "installer";
            this.Text = "installer";
            this.Shown += new System.EventHandler(this.installer_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.Button UninstallButton;
        private System.Windows.Forms.Button SelectMSCButton;
        private System.Windows.Forms.Label mscpathLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.CheckBox InstallOfficialModsCheckbox;
    }
}