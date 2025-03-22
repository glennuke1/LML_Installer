﻿using Ionic.Zip;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LML_Installer
{
    public partial class Installer : Form
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

        public Installer()
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

            if (!Directory.Exists(Path.Combine(mscpath, "mods", "Assets")))
            {
                Directory.CreateDirectory(Path.Combine(mscpath, "mods", "Assets"));
            }

            progressBar.Visible = true;

            InstallFiles();

            progressBar.Visible = false;
            progressBar.Value = 0;

            MessageBox.Show("Installed");
        }

        void InstallFiles()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/doorstop.zip", "doorstop.zip");
                progressBar.PerformStep();
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/NeededDLLS.zip", "NeededDLLS.zip");
                progressBar.PerformStep();
            }

            ZipFile zip = ZipFile.Read("doorstop.zip");
            zip.ExtractAll(mscpath, ExtractExistingFileAction.OverwriteSilently);
            zip.Dispose();

            progressBar.PerformStep();

            ZipFile zip2 = ZipFile.Read("NeededDLLS.zip");
            zip2.ExtractAll(Path.Combine(mscpath, "mysummercar_Data\\Managed"), ExtractExistingFileAction.OverwriteSilently);
            zip2.Dispose();

            progressBar.PerformStep();

            using (var client = new WebClient())
            {
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/LightspeedModLoader.dll", mscpath + "/mysummercar_Data/Managed/LightspeedModLoader.dll");
                progressBar.PerformStep();
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/MSCLoader.dll", mscpath + "/mysummercar_Data/Managed/MSCLoader.dll");
                progressBar.PerformStep();
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/VERSION", mscpath + "/LML_VERSION");
                progressBar.PerformStep();
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/LML_AutoUpdater.exe", mscpath + "/mysummercar_Data/Managed/LML_AutoUpdater.exe");

                progressBar.PerformStep();
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/Official%20Mods/LML_Default_Console.dll", mscpath + "/mods/LML_Default_Console.dll");
                progressBar.PerformStep();
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/Official%20Mods/LML_Default_ModSettings.dll", mscpath + "/mods/LML_Default_ModSettings.dll");
                progressBar.PerformStep();
                client.DownloadFile("https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/Official%20Mods/LML_DevToolset.dll", mscpath + "/mods/LML_DevToolset.dll");
                progressBar.PerformStep();
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

            if (File.Exists(mscpath + "/mysummercar_Data/Managed/LightspeedModLoader.dll"))
            {
                File.Delete(mscpath + "/mysummercar_Data/Managed/LightspeedModLoader.dll");
            }

            if (File.Exists(mscpath + "/mysummercar_Data/Managed/LML_AutoUpdater.exe"))
            {
                File.Delete(mscpath + "/mysummercar_Data/Managed/LML_AutoUpdater.exe");
            }

            if (File.Exists(mscpath + "/mysummercar_Data/Managed/MSCLoader.dll"))
            {
                File.Delete(mscpath + "/mysummercar_Data/Managed/MSCLoader.dll");
            }

            if (File.Exists(mscpath + "/mysummercar_Data/Managed/MSCLoader.Preloader.dll"))
            {
                File.Delete(mscpath + "/mysummercar_Data/Managed/MSCLoader.Preloader.dll");
            }

            MessageBox.Show("Uninstalled");
        }

        private void installer_Load(object sender, EventArgs e)
        {
            InstallButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, InstallButton.Width, InstallButton.Height, 10, 10));
            UninstallButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, UninstallButton.Width, UninstallButton.Height, 10, 10));
            SelectMSCButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SelectMSCButton.Width, SelectMSCButton.Height, 10, 10));

            string path = Path.Combine(Application.LocalUserAppDataPath, "save.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData saveData = JsonConvert.DeserializeObject<SaveData>(json);

                this.Size = new Size(saveData.width, saveData.height);
                this.Location = new Point(saveData.locX, saveData.locY);

                mscpath = saveData.mscpath;
                mscpathLabel.Text = saveData.mscpath;
            }

            if (string.IsNullOrWhiteSpace(mscpath))
            {
                mscpath = GetMySummerCarPath();
                mscpathLabel.Text = mscpath;
            }
        }

        static string GetMySummerCarPath()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam"))
                {
                    if (key == null)
                    {
                        return null;
                    }

                    object steamPath = key.GetValue("SteamPath");

                    if (steamPath == null)
                    {
                        return null;
                    }

                    string libraryFoldersPath = Path.Combine(steamPath.ToString(), "steamapps", "libraryfolders.vdf");

                    if (File.Exists(libraryFoldersPath))
                    {
                        string[] lines = File.ReadAllLines(libraryFoldersPath);
                        foreach (string line in lines)
                        {
                            if (line.Contains("path"))
                            {
                                string libraryPath = line.Split('"')[3].Replace("\\\\", "\\");
                                string mscPath = Path.Combine(libraryPath, "steamapps", "common", "My Summer Car");

                                if (Directory.Exists(mscPath))
                                    return mscPath;
                            }
                        }
                    }

                    string defaultPath = Path.Combine(steamPath.ToString(), "steamapps", "common", "My Summer Car");
                    if (Directory.Exists(defaultPath))
                        return defaultPath;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error finding MSC: " + ex.Message);
            }

            return null;
        }

        private void installer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData saveData = new SaveData()
            {
                mscpath = mscpath,
                width = this.Size.Width,
                height = this.Size.Height,
                locX = this.Location.X,
                locY = this.Location.Y
            };

            string json = JsonConvert.SerializeObject(saveData);
            string path = Path.Combine(Application.LocalUserAppDataPath, "save.json");
            File.WriteAllText(path, json);
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public string mscpath;
        public int width;
        public int height;
        public int locX;
        public int locY;
    }
}
