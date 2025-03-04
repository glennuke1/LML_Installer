using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LML_Installer
{
    public partial class installer : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public installer()
        {
            InitializeComponent();
        }

        static string mscpath;

        private void InstallButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mscpath))
            {
                MessageBox.Show("Specify msc path");
                return;
            }
            Install();
        }

        void Install()
        {
            if (!Directory.Exists(Path.Combine(mscpath, "mods")))
            {
                Directory.CreateDirectory(Path.Combine(mscpath, "mods"));
            }

            if (!Directory.Exists(Path.Combine(mscpath, "mods", "Config")))
            {
                Directory.CreateDirectory(Path.Combine(mscpath, "mods", "Config"));
            }

            InstallFiles();

            MessageBox.Show("Installed");
        }

        void InstallFiles()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/doorstop.zip", "doorstop.zip");
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/References.zip", "References.zip");
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/NeededDLLS.zip", "NeededDLLS.zip");
            }

            ZipFile zip = ZipFile.Read("doorstop.zip");
            zip.ExtractAll(mscpath, ExtractExistingFileAction.OverwriteSilently);

            ZipFile zip1 = ZipFile.Read("References.zip");
            zip1.ExtractAll(Path.Combine(mscpath, "mysummercar_Data/Managed"), ExtractExistingFileAction.OverwriteSilently);

            ZipFile zip2 = ZipFile.Read("NeededDLLS.zip");
            zip2.ExtractAll(Path.Combine(mscpath, "mysummercar_Data/Managed"), ExtractExistingFileAction.OverwriteSilently);

            using (var client = new WebClient())
            {
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/LightspeedModLoader.dll", mscpath + "/mysummercar_Data/Managed/LightspeedModLoader.dll");
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/MSCLoader.dll", mscpath + "/mysummercar_Data/Managed/MSCLoader.dll");
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/VERSION", mscpath + "/LML_VERSION");
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/LML_AutoUpdater.exe", mscpath + "/mysummercar_Data/Managed/LML_AutoUpdater.exe");
            }

            if (InstallOfficialModsCheckbox.Checked)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/Official%20Mods/LML_Default_Console.dll", mscpath + "/mods/LML_Default_Console.dll");
                    client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/Official%20Mods/LML_Default_ModSettings.dll", mscpath + "/mods/LML_Default_ModSettings.dll");
                    client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/Official%20Mods/LML_DevToolset.dll", mscpath + "/mods/LML_DevToolset.dll");
                }
            }
        }

        private void SelectMSCButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "EXE Files (*.exe)|*.exe|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                mscpath = Path.GetDirectoryName(dlg.FileName);
                mscpathLabel.Text = mscpath;
                File.WriteAllText("mscpath.txt", mscpath);
                return;
            }
        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mscpath))
            {
                MessageBox.Show("Specify msc path");
                return;
            }

            if (File.Exists(mscpath + "/doorstop_config.ini"))
            {
                File.Delete(mscpath + "/doorstop_config.ini");
            }

            MessageBox.Show("Uninstalled");
        }

        private void installer_Shown(object sender, EventArgs e)
        {
            InstallButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, InstallButton.Width, InstallButton.Height, 10, 10));
            UninstallButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, UninstallButton.Width, UninstallButton.Height, 10, 10));
            SelectMSCButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SelectMSCButton.Width, SelectMSCButton.Height, 10, 10));

            if (File.Exists("mscpath.txt"))
            {
                mscpath = File.ReadAllText("mscpath.txt");
                mscpathLabel.Text = mscpath;
            }
        }
    }
}
