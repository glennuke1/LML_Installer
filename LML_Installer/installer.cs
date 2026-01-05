using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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

            string baseDir = AppContext.BaseDirectory;

            string newtonsoftPath = Path.Combine(baseDir, "Newtonsoft.Json.dll");
            string ionicPath = Path.Combine(baseDir, "Ionic.Zip.dll");


            if (!File.Exists(ionicPath))
            {
                using (var http = new HttpClient())
                {
                    http.DefaultRequestHeaders.UserAgent.ParseAdd("LightspeedModLoader-Installer");

                    var data = http.GetByteArrayAsync(
                        "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LML_Installer/Ionic.Zip.dll"
                    ).GetAwaiter().GetResult();

                    File.WriteAllBytes(ionicPath, data);
                }
            }

            if (!File.Exists(newtonsoftPath))
            {
                using (var http = new HttpClient())
                {
                    http.DefaultRequestHeaders.UserAgent.ParseAdd("LightspeedModLoader-Installer");

                    var data = http.GetByteArrayAsync(
                        "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LML_Installer/Newtonsoft.Json.dll"
                    ).GetAwaiter().GetResult();

                    File.WriteAllBytes(newtonsoftPath, data);
                }
            }
        }

        static string mwcpath;

        private async void InstallButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mwcpath))
            {
                MessageBox.Show("Specify mwc path");
                return;
            }
            InstallButton.Enabled = false;
            await Install();
            InstallButton.Enabled = true;
        }

        async Task Install()
        {
            if (!Directory.Exists(Path.Combine(mwcpath, "mods")))
            {
                Directory.CreateDirectory(Path.Combine(mwcpath, "mods"));
            }

            if (!Directory.Exists(Path.Combine(mwcpath, "mods", "Config")))
            {
                Directory.CreateDirectory(Path.Combine(mwcpath, "mods", "Config"));
            }

            if (!Directory.Exists(Path.Combine(mwcpath, "mods", "Assets")))
            {
                Directory.CreateDirectory(Path.Combine(mwcpath, "mods", "Assets"));
            }

            progressBar.Visible = true;

            await InstallFiles();

            progressBar.Visible = false;
            progressBar.Value = 0;

            MessageBox.Show("Installed");
        }

        async Task InstallFiles()
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.UserAgent.ParseAdd("LightspeedModLoader-Installer");

                var data = await http.GetByteArrayAsync(
                    "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/doorstop.zip"
                );

                File.WriteAllBytes("doorstop.zip", data);

                progressBar.PerformStep();

                data = await http.GetByteArrayAsync(
                    "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/NeededDLLS.zip"
                );

                File.WriteAllBytes("NeededDLLS.zip", data);

                progressBar.PerformStep();
            }

            Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read("doorstop.zip");
            zip.ExtractAll(mwcpath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
            zip.Dispose();

            progressBar.PerformStep();

            Ionic.Zip.ZipFile zip2 = Ionic.Zip.ZipFile.Read("NeededDLLS.zip");
            zip2.ExtractAll(Path.Combine(mwcpath, "mywintercar_Data\\Managed"), Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
            zip2.Dispose();

            progressBar.PerformStep();

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.UserAgent.ParseAdd("LightspeedModLoader-Installer");

                byte[] data = await http.GetByteArrayAsync(
                    "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/LightspeedModLoader.dll"
                );
                File.WriteAllBytes(Path.Combine(mwcpath, "mywintercar_Data", "Managed", "LightspeedModLoader.dll"), data);
                progressBar.PerformStep();

                data = await http.GetByteArrayAsync(
                    "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/MSCLoader.dll"
                );
                File.WriteAllBytes(Path.Combine(mwcpath, "mywintercar_Data", "Managed", "MSCLoader.dll"), data);
                progressBar.PerformStep();

                data = await http.GetByteArrayAsync(
                    "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/VERSION"
                );
                File.WriteAllBytes(Path.Combine(mwcpath, "LML_VERSION"), data);
                progressBar.PerformStep();

                data = await http.GetByteArrayAsync(
                    "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/LightspeedModLoader/Builds/LML_AutoUpdater.exe"
                );
                File.WriteAllBytes(Path.Combine(mwcpath, "mywintercar_Data", "Managed", "LML_AutoUpdater.exe"), data);
                progressBar.PerformStep();

                data = await http.GetByteArrayAsync(
                    "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/Official%20Mods/LML_Default_Console.dll"
                );
                Directory.CreateDirectory(Path.Combine(mwcpath, "mods"));
                File.WriteAllBytes(Path.Combine(mwcpath, "mods", "LML_Default_Console.dll"), data);
                progressBar.PerformStep();

                data = await http.GetByteArrayAsync(
                    "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/Official%20Mods/LML_Default_ModSettings.dll"
                );
                File.WriteAllBytes(Path.Combine(mwcpath, "mods", "LML_Default_ModSettings.dll"), data);
                progressBar.PerformStep();

                data = await http.GetByteArrayAsync(
                    "https://github.com/glennuke1/LightspeedModLoader/raw/refs/heads/master/Official%20Mods/LML_DevToolset.dll"
                );
                File.WriteAllBytes(Path.Combine(mwcpath, "mods", "LML_DevToolset.dll"), data);
                progressBar.PerformStep();
            }
        }

        private void SelectMSCButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "EXE Files (*.exe)|*.exe|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                mwcpath = Path.GetDirectoryName(dlg.FileName);
                mscpathLabel.Text = mwcpath;
                return;
            }
        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mwcpath))
            {
                MessageBox.Show("Specify msc path");
                return;
            }

            if (File.Exists(mwcpath + "/doorstop_config.ini"))
            {
                File.Delete(mwcpath + "/doorstop_config.ini");
            }

            if (File.Exists(mwcpath + "/mywintercar_Data/Managed/LightspeedModLoader.dll"))
            {
                File.Delete(mwcpath + "/mywintercar_Data/Managed/LightspeedModLoader.dll");
            }

            if (File.Exists(mwcpath + "/mywintercar_Data/Managed/LML_AutoUpdater.exe"))
            {
                File.Delete(mwcpath + "/mywintercar_Data/Managed/LML_AutoUpdater.exe");
            }

            if (File.Exists(mwcpath + "/mywintercar_Data/Managed/MSCLoader.dll"))
            {
                File.Delete(mwcpath + "/mywintercar_Data/Managed/MSCLoader.dll");
            }

            if (File.Exists(mwcpath + "/mywintercar_Data/Managed/MSCLoader.Preloader.dll"))
            {
                File.Delete(mwcpath + "/mywintercar_Data/Managed/MSCLoader.Preloader.dll");
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
                SaveData saveData = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveData>(json);

                this.Size = new Size(saveData.width, saveData.height);
                this.Location = new Point(saveData.locX, saveData.locY);

                mwcpath = saveData.mscpath;
                mscpathLabel.Text = saveData.mscpath;
            }

            if (string.IsNullOrWhiteSpace(mwcpath))
            {
                mwcpath = GetMyWinterCarPath();
                mscpathLabel.Text = mwcpath;
            }
        }

        static string GetMyWinterCarPath()
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
                                string mscPath = Path.Combine(libraryPath, "steamapps", "common", "My Winter Car");

                                if (Directory.Exists(mscPath))
                                    return mscPath;
                            }
                        }
                    }

                    string defaultPath = Path.Combine(steamPath.ToString(), "steamapps", "common", "My Winter Car");
                    if (Directory.Exists(defaultPath))
                        return defaultPath;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error finding MWC: " + ex.Message);
            }

            return null;
        }

        private void installer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData saveData = new SaveData()
            {
                mscpath = mwcpath,
                width = this.Size.Width,
                height = this.Size.Height,
                locX = this.Location.X,
                locY = this.Location.Y
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(saveData);
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
