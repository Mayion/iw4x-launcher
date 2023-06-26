using Ionic.Zip;
using iw4x_launcher.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
//using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.Odbc;
using System.Runtime.InteropServices;
using System.Timers;

namespace iw4x_launcher
{
    public partial class frmMain : Form
    {
        // Code unsafe to read for those 40 and under

        public static frmMain frm = null;
        private readonly Localization l = Localization.Languages;
        private readonly Functions f = Functions.Methods;
        private readonly SettingsClass Settings = SettingsClass.Settings;

        private int originalWidth = 0;
        private int prevIndex = -1;
        private bool isSelfFiring = false;

        public frmMain()
        {
            InitializeComponent();
            frm = this;

            PanelServersList.HorizontalScroll.Maximum = 0;
            PanelServersList.AutoScroll = false;
            PanelServersList.VerticalScroll.Visible = false;
            PanelServersList.AutoScroll = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //string[] args = Environment.GetCommandLineArgs(); //args[1] -- To support arguments later.
            originalWidth = PanelServersList.Width;
            RunCheck();
            gameRunning.Start();
            InitiateProgram();

            if (string.IsNullOrEmpty(f.game_path)) //Check if no proper game_path is provided.
            {
                labelVersion.Text = l.LabelVersion_Error2;
                labelVersion.ForeColor = Color.IndianRed;
            }
            else
            {
                GetServers();
            }
        }

        public void RunCheck()
        {
            if (!File.Exists(f.config_path) && !f.isValidGameDirectory(Environment.CurrentDirectory)) // First run probably.
            {
                MessageBox.Show("The launcher needs to detect the game, so make sure to place it in the game's directory, or to select it using the Select Game Directory button.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (!f.CreateConfig())
            {
                MessageBox.Show("Could not create config file! Exiting ..", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                RetrieveSettings(); //Loads settings and if current directory is game folder.
            }
            if (!string.IsNullOrEmpty(f.game_path) && !f.CreateDirectory(f.game_path + "iw4x_launcher"))
            {
                MessageBox.Show("Could not create launcher folder! Exiting ..", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void InitiateProgram()
        {
            InitializeLanguage();

            f.missing_dlcs.Clear();
            f.missing_files.Clear();
            l.Version = f.GetFileVersion(f.game_path + "iw4x.dll");
            if (!string.IsNullOrEmpty(f.game_path) && !f.CreateDirectory(f.game_path + "iw4x_launcher"))
            {
                MessageBox.Show("Could not create launcher folder! Exiting ..", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }

            CheckDLC();
            CheckZone();

            f.RenameLauncherFiles();
            VersionsLoad();
            DisplayGameVersion();
            IW4XWatch();
        }

        private void InitializeLanguage()
        {
            l.SetLanguage();

            btnLaunch.Text = l.ButtonLaunch;
            btnDirectory.Text = l.ButtonSelect;
            headerOptions.Text = l.LabelHeader2;
            headerVersion.Text = l.LabelHeader1;
            header4.Text = l.LabelHeader4;
            labelServers.Text = PanelServersList.Controls.Count + " " + l.LabelHeader3;
            cbComp.Text = l.cbComp;
            cbGameVersions.Text = l.cbGameVersion;
            cbMenuFix.Text = l.MenuFix;
            cbSort.Text = l.cbSort;

            ll1.Text = l.LabelDownload;
            ll2.Text = l.LabelDownload;


            if (string.IsNullOrEmpty(f.game_path))
            {
                lblDirectory.Text = l.MsgDebug4;
            }

            //Following is all redundant code that is already handled by CheckDLC() and CheckZone()
            //But I CBA to actually see if that's true.
            ll1.Visible = false;
            ll2.Visible = false;

            if (f.isCheckingDLC)
            {
                labelDLCFiles.Text = l.LabelDLCFiles_Checking;
                labelDLCFiles.ForeColor = Color.Orange;
                labelDLCFiles.UseWaitCursor = true;

            }
            else
            {
                labelDLCFiles.UseWaitCursor = false;
                if (f.isVerifiedDLC)
                {
                    labelDLCFiles.Text = l.LabelDLCFiles_Verified;
                    labelDLCFiles.ForeColor = Color.ForestGreen;
                }
                else
                {
                    labelDLCFiles.Text = l.LabelDLCFiles_Error;
                    labelDLCFiles.ForeColor = Color.OrangeRed;
                    ll1.Visible = true;
                }
            }

            if (f.isCheckingRaw)
            {
                labelRawfiles.Text = l.LabelRawFiles_Checking;
                labelRawfiles.ForeColor = Color.Orange;
                labelRawfiles.UseWaitCursor = true;
            }
            else
            {
                labelRawfiles.UseWaitCursor = false;
                if (f.isVerifiedRaw)
                {
                    labelRawfiles.Text = l.LabelRawFiles_Verified;
                    labelRawfiles.ForeColor = Color.ForestGreen;
                }
                else
                {
                    labelRawfiles.Text = l.LabelRawFiles_Error;
                    labelRawfiles.ForeColor = Color.OrangeRed;
                    ll2.Visible = true;
                }
            }

            DisplayGameVersion();
        }

        public void AppendText(RichTextBox box, string text, Color color, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.SelectionFont = font;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public void Debugger(string i, int severity = 0)
        {
            Font f = TextDebugger.Font;
            String time = "[" + DateTime.Now.ToString("HH:mm:ss.ff tt") + "] ";
            if (severity == 0 || severity > 2)
            {
                this.Invoke(new Action(() => TextDebugger.AppendText(time + i + "\n")));
            }
            else if (severity == 1)
            {
                this.Invoke(new Action(() => AppendText(TextDebugger, time + i + "\n", Color.Orange, f)));
            }
            else if (severity == 2)
            {
                this.Invoke(new Action(() => AppendText(TextDebugger, time + i + "\n", Color.IndianRed, f)));
            }
            TextDebugger.ScrollToCaret();
        }

        #region IW4x Functionality
        private void CheckZone()
        {
            labelRawfiles.Text = l.LabelRawFiles_Checking;
            labelRawfiles.ForeColor = Color.Orange;
            labelRawfiles.UseWaitCursor = true;
            ll2.Visible = false;

            if (f.CheckZone())
            {
                f.isCheckingRaw = false;
                f.isVerifiedRaw = true;

                labelRawfiles.Text = l.LabelRawFiles_Verified;
                labelRawfiles.ForeColor = Color.ForestGreen;
            }
            else
            {
                string s = String.Format(l.MsgDebug9, f.missing_files.Count) + String.Join(", ", f.missing_files);
                Debugger(s + "\n", 1);
                f.isCheckingRaw = false;
                f.isVerifiedRaw = false;

                labelRawfiles.Text = l.LabelRawFiles_Error;
                labelRawfiles.ForeColor = Color.OrangeRed;
                ll2.Visible = true;
            }
            labelRawfiles.UseWaitCursor = false;
        }
        private void CheckDLC()
        {
            labelDLCFiles.Text = l.LabelDLCFiles_Checking;
            labelDLCFiles.ForeColor = Color.Orange;
            labelDLCFiles.UseWaitCursor = true;
            ll1.Visible = false;

            if (f.CheckDLC())
            {
                f.isCheckingDLC = false;
                f.isVerifiedDLC = true;

                labelDLCFiles.Text = l.LabelDLCFiles_Verified;
                labelDLCFiles.ForeColor = Color.ForestGreen;
            }
            else
            {
                string s = String.Format(l.MsgDebug8, f.missing_dlcs.Count) + String.Join(", ", f.missing_dlcs);
                Debugger(s + "\n", 1);
                f.isCheckingDLC = false;
                f.isVerifiedDLC = false;

                labelDLCFiles.Text = l.LabelDLCFiles_Error;
                labelDLCFiles.ForeColor = Color.OrangeRed;
                ll1.Visible = true;
            }
            labelDLCFiles.UseWaitCursor = false;
        }
        private void IW4XWatch()
        {
            string path = f.game_path; // watch for parent directory
            if (!Directory.Exists(path)) // verify it exists before start
                return;

            FileSystemWatcher watcher = new FileSystemWatcher(path);
            // set option to track files only
            watcher.NotifyFilter = NotifyFilters.FileName;

            watcher.Deleted += (o, e) =>
            {
                if (e.FullPath == f.game_path + "iw4x.dll" || e.FullPath == f.game_path + "iw4x.exe")
                {
                    this.Invoke(new Action(() => DisplayGameVersion()));
                }
            };
            watcher.Created += (o, e) =>
            {
                if (e.FullPath == f.game_path + "iw4x.dll" || e.FullPath == f.game_path + "iw4x.exe")
                {
                    this.Invoke(new Action(() => DisplayGameVersion()));
                }
            };
            watcher.Renamed += (o, e) =>
            {
                if (e.OldName == "iw4x.dll" || e.Name == "iw4x.dll" || e.Name == "iw4x.exe" || e.OldName == "iw4x.exe")
                {
                    this.Invoke(new Action(() => DisplayGameVersion()));
                }
            };


            watcher.EnableRaisingEvents = true;
        }
        private void MenuUpdate(bool apply)
        {
            //Fixes menu issues between 0.6 and 0.7.
            string version = l.Version;
            string fpath = f.game_path + @"userraw\ui_mp\";
            string file_path = fpath + "joinserver.inc";
            if (apply)
            {
                if (f.CreateDirectory(fpath))
                {
                    try
                    {
                        if (version == "0.7.5")
                        {
                            File.WriteAllText(file_path, Properties.Resources.joinserver_7);
                        }
                        else
                        {
                            File.WriteAllText(file_path, Properties.Resources.joinserver_6);
                        }

                    }
                    catch (IOException)
                    {
                    }
                }
            }
            else
            {
                if (Directory.Exists(fpath) && File.Exists(file_path))
                {
                    f.DeleteFile(file_path);
                }
            }
        }
        private void PopulateVersions(string html)
        {
            //Settings.GameVersions.Clear();

            List<string> c = new List<string>();
            var matches = Regex.Matches(html,
                @"(http|https)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?");
            foreach (Match match in matches)
            {
                if (match.Value.Contains("/expanded_assets/"))
                {
                    string last = match.Value.Substring(match.Value.LastIndexOf('/') + 2);
                    string bareVersion;
                    if (last.Contains("."))
                    {
                        string[] tokens = last.Split('.');
                        if(tokens.Length >= 2)
                        {
                            bareVersion = tokens[0] + "." + tokens[1];
                            if (!Settings.GameVersions.Contains(bareVersion))
                            {
                                Settings.GameVersions.Add(bareVersion);
                               
                            }

                        }
                    }
                    c.Add(last);
                }
            }

            if (c.Count > 0)
            {
                labelLoading.Visible = false;
                listVersions.Visible = true;
                labelVersion.Visible = true;
            }

            foreach (string i in c)
            {
                if (!listVersions.Items.Contains("v" + i))
                {
                    listVersions.Items.Add("v" + i);

                }

            }

            DisplayGameVersion();
        }
        private void RetrieveGithub()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => listVersions.Visible = false));
                this.Invoke(new Action(() => labelLoading.Visible = true));
                //return;
            }

            string url = "https://github.com/XLabsProject/iw4x-client/releases";
            string url2 = "https://github.com/XLabsProject/iw4x-client/releases?page=2";

            try
            {
                using (WebClient client = new WebClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    string htmlCode = client.DownloadString(url);
                    string htmlCode2 = client.DownloadString(url2);
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => PopulateVersions(htmlCode)));
                        this.Invoke(new Action(() => PopulateVersions(htmlCode2)));

                        return;
                    }

                }
            }
            catch (Exception e)
            {
                Debugger(l.MsgDebug3);
                MessageBox.Show("frmMain::RetrieveGithub-> " + e.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
        public void DisplayGameVersion()
        {
            btnLaunch.Enabled = true;
            btnLaunch.Cursor = Cursors.Hand;
            listVersions.Enabled = true;
            string v = "v" + l.Version;
            if (f.isDownloading)
            {
                btnLaunch.Enabled = false;
            }

            if (f.isExtracting)
            {
                btnLaunch.Enabled = false;
            }
            if (string.IsNullOrEmpty(f.GetFileVersion(f.game_path + "iw4x.dll")))
            {
                labelVersion.Text = l.LabelVersion_Error;
                labelVersion.ForeColor = Color.IndianRed;
                btnLaunch.Enabled = false;
                btnLaunch.Cursor = Cursors.No;
            }
            else
            {
                string serverName = "None";
                if (f.SelectedServerItem != null)
                {
                    serverName = f.SelectedServerItem.ServerName;
                }
                labelVersion.Text = String.Format(l.LabelVersion, l.Version, serverName);
                labelVersion.ForeColor = Color.ForestGreen;
            }

            if (!File.Exists(f.game_path + "iw4x.exe"))
            {
                labelVersion.Text = l.LabelVersion_Error2;
                labelVersion.ForeColor = Color.IndianRed;
                btnLaunch.Enabled = false;
                btnLaunch.Cursor = Cursors.No;
                listVersions.Enabled = false;
            }


            int x = 0;
            if (f.isDownloading || f.isSelecting)
            {
                return;
            }
            if (listVersions.Items.Count > 0)
            {
                foreach (string i in listVersions.Items)
                {
                    if (i.Trim().ToLower().Equals(v.ToLower().Trim()))
                    {
                        listVersions.SelectedIndex = x;
                        return;
                    }

                    x++;
                }
            }
        }
        private void LaunchGame()
        {
            string i = f.game_path + "iw4x.exe";
            string dll = f.game_path + "iw4x.dll"; 
            string dllVersion = f.GetFileVersion(dll);
            string ip = f.SelectedServerIP;
            string version = l.Version;
            if (File.Exists(i) && !f.isGameRunning() && !f.isDownloading)
            {
                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = i;
                if (!string.IsNullOrEmpty(ip))
                {
                    if (!string.IsNullOrEmpty(f.SelectedServerPassword))
                    {
                        p.StartInfo.Arguments = "iw4x://" + ip + "/ +set password \"" + f.SelectedServerPassword + "\"";
                    }
                    else
                    {
                        p.StartInfo.Arguments = "iw4x://" + ip + "/";
                    }
                }

                if (f.applyMenuUpdate)
                {
                    MenuUpdate(true);
                }
                else
                {
                    MenuUpdate(false);
                }
                if (cbGUID.Checked)
                {
                    if (File.Exists(dll))
                    {

                        string bareVersion;
                        if (dllVersion.Contains("."))
                        {
                            string[] tokens = dllVersion.Split('.');
                            if (tokens.Length >= 2)
                            {
                                bareVersion = tokens[0] + "." + tokens[1];
                                string fPath = f.game_path + f.launcher_folder + "guid_" + bareVersion + ".dat";
                                if (File.Exists(fPath))
                                {
                                    string datPath = f.game_path + @"players\guid.dat";
                                    if (File.Exists(datPath))
                                    {
                                        if (f.DeleteFile(datPath))
                                        {
                                            Debugger("Switched GUID successfully.");
                                            File.Copy(fPath, datPath);
                                        }
                                        else
                                        {
                                            Debugger("Failed to switchh GUID.");
                                        }
                                    }
                                    else
                                    {
                                        Debugger("Switched GUID successfully.");
                                        File.Copy(fPath, datPath);
                                    }

                                }
                            }
                        }
                    }
                }
                string x = !string.IsNullOrEmpty(ip) ? "Launching Game on IP " + ip : "Launching Game";
                Debugger(x);
                p.Start();
            }
        }
        private void ChangeGameVersion(string v)
        {
            var l = Localization.Languages;
            v = v.Replace("v", "");

            l.Version = v;
            DisplayGameVersion();
        }
        private void VersionsLoad()
        {
            listVersions.Items.Clear();
            if (cbGameVersions.Checked)
            {
                labelLoading.Visible = false;
                listVersions.Visible = true;
                List<string> list = f.GetLocalVersions();
                if (list.Count > 0)
                {
                    foreach (string i in list)
                    {
                        listVersions.Items.Add("v" + i);
                    }

                }
                else
                {
                    listVersions.Visible = false;
                }
            }
            else
            {
                Thread thread = new Thread(() => RetrieveGithub());
                thread.Start();
            }

            DisplayGameVersion();

        }
        public void HandlePatchFiles()
        {
            //108,636,207 File size for checksum.
            string zipPath = f.game_path + f.launcher_folder + "patch_rawfiles.zip";

            f.isExtracting = true;
            if (File.Exists(zipPath))
            {
                long zipSize = new System.IO.FileInfo(zipPath).Length;
                if (zipSize == 108636207)
                {
                    if (!f.IsDirectoryWritable(f.game_path))
                    {
                        Debugger("Insufficient permissions to extract patch_rawfiles.zip! Please make sure you have access to the directory and the folder is not set to read-only.", 2);
                    }
                    else
                    {
                        Debugger("Extracting patch_rawfiles.zip .. Please wait.");
                        Extract(zipPath, f.game_path);
                    }

                }

            }

        }
        public void DownloadPatchFiles()
        {
            string path = f.game_path + f.launcher_folder + "patch_rawfiles.zip";
            if (File.Exists(path))
            {
                long zipSize = new System.IO.FileInfo(path).Length;
                if (zipSize == 108636207)
                {
                    if (!f.IsDirectoryWritable(f.game_path))
                    {
                        Debugger("Insufficient permissions to extract patch_rawfiles.zip! Please make sure you have access to the directory and the folder is not set to read-only.", 2);
                    }
                    else
                    {
                        Debugger("Extracting patch_rawfiles.zip .. Please wait.");
                        Extract(path, f.game_path);
                        return;
                    }
                }
            }

            //MessageBox.Show("A");

            f.downloadfile_name = "0.7 Update";
            Debugger("Starting Download: " + f.downloadfile_name);
            DownloadUri("https://github.com/XLabsProject/iw4x-rawfiles/releases/download/v0.0.9/release.zip", path);
        }
        private void SaveSettings()
        {
            if (f.SelectedLanguage == Functions.Language.English)
            {
                f.SetConfigKey("lang", "en");
            }
            else if (f.SelectedLanguage == Functions.Language.Russian)
            {
                f.SetConfigKey("lang", "ru");
            }

            f.SetConfigKey("ver", l.Version);

            if (cbGameVersions.CheckState == CheckState.Unchecked)
            {
                f.SetConfigKey("cb1", "0");
            }
            else if (cbGameVersions.CheckState == CheckState.Checked)
            {
                f.SetConfigKey("cb1", "1");
            }

            //MessageBox.Show(f.game_path);
            f.SetConfigKey("dir", f.game_path);
        }
        private void RetrieveSettings()
        {
            comboLang.SelectedIndex = 1;
            if (f.GetConfigValue("lang") == "en")
            {
                comboLang.SelectedIndex = 0;
            }
            else if (f.GetConfigValue("lang") == "ru")
            {
                comboLang.SelectedIndex = 1;
            }
            else
            {

            }

            if (f.GetConfigValue("cb1") == "0")
            {
                cbGameVersions.Checked = false;
            }
            else
            {
                cbGameVersions.Checked = true;
            }

            string i = f.GetConfigValue("dir");

            if (f.isValidGameDirectory(i))
            {
                lblDirectory.Text = f.GetConfigValue("dir");
                f.game_path = i;
            }
            else
            {
                string cpath = Environment.CurrentDirectory + @"\";

                if (f.isValidGameDirectory(cpath))
                {
                    lblDirectory.Text = cpath;
                    f.game_path = cpath;
                }
                else
                {
                    lblDirectory.Text = l.MsgDebug4;
                }
            }


            string ver = f.GetConfigValue("ver");

            if (f.VersionExists(ver))
            {
                f.SetGameVersion(ver);
            }
        }
        #endregion


        #region Server List

        public void GetServers()
        {
            FlashWindow.Stop(this);
            labelRefreshtime.Text = DateTime.Now.ToString("HH:mm:ss tt");
            timer1.Stop();
            timer1.Start();
            labelServers.Text = "0 " + l.LabelHeader3;
            ClearControls();
            f.SelectedServerItem = null;
            f.SelectedServerIP = "";
            ParseJSONServers(GetFavoritedServersList());
        }

        public string GetFavoritedServers()
        {
            string p = f.game_path + @"players\favourites.json";

            if (File.Exists(p))
            {
                String input = File.ReadAllText(p);
                Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b:\d{1,5}");
                MatchCollection result = ip.Matches(input);

                return String.Join(",", from Match match in result select match.Value);
            }

            return string.Empty;
        }

        public List<string> GetFavoritedServersList()
        {
            List<string> ips = GetFavoritedServers().Split(',').ToList();
            return ips;
        }

        public void ConstructServerItem(string items, string ip)
        {
            if (string.IsNullOrEmpty(items) || string.IsNullOrEmpty(ip))
            {
                return;
            }

            string serverName = f.GetResultValue(items, "hostname");
            string gameType = f.GetResultValue(items, "gametype");
            string onlinePlayers = f.GetResultValue(items, "clients");
            string maxPlayers = f.GetResultValue(items, "sv_maxclients");
            string serverMap = f.GetResultValue(items, "mapname");
            string isHc = f.GetResultValue(items, "hc");
            string bots = f.GetResultValue(items, "bots");
            string serverVersion = f.GetResultValue(items, "shortversion");
            string serverPlayers = f.GetResultValue(items, "players");
            string isPrivate = f.GetResultValue(items, "isPrivate");


            List<string> strings = serverPlayers.Split(',').ToList();

            ServerItemWide si = new ServerItemWide();
            si.Width = originalWidth - 10;
            si.SetServerGameMode(gameType, isHc);
            si.SetServerMap(serverMap);
            si.SetServerCompletePlayers(onlinePlayers + "/" + maxPlayers + " (" + bots + ")");

            //Some bots seem to have normal pings, while some players can freeze with 999 ping, in which case this will not work on them.
            si.SetServerCompleteIP(ip);
            si.SetPlayers(strings);
            int e;
            int.TryParse(onlinePlayers, out e);
            si.Tag = e;
            si.SetServerOnlineClients(e);
            si.SetServerName(f.CleanString(serverName));
            si.SetControlID(PanelServersList.Controls.Count + 1);
            si.SetServerVersion(serverVersion);

            if (isPrivate == "0")
            {
                si.SetServerPrivate(false);
            }
            else if (isPrivate == "1")
            {
                si.SetServerPrivate(true);
            }

            if (Settings.NotifyServers.ContainsKey(ip))
            {
                int noti_number = Settings.NotifyServers[ip];
                si.SetNotifyNumber(noti_number);
                if (e >= noti_number)
                {
                    si.SetNotifiedServer();
                    FlashWindow.Flash(this);
                    Settings.NotifiedServers++;
                }

            }
            AddServerToList(si);
        }

        public void AddServerToList(ServerItemWide s)
        {
            if (!PanelServersList.Contains(s))
            {
                if (f.isOnlyComp)
                {
                    //Same version.
                    if (s.ServerVersion.Remove(s.ServerVersion.Length - 2)
                        .Equals(l.Version.Remove(l.Version.Length - 2)))
                    {
                        AddServerElement(s);
                    }
                }
                else
                {
                    AddServerElement(s);
                }
            }
        }
        public void ClearControls()
        {
            try
            {
                for (int i = PanelServersList.Controls.Count - 1; i >= 0; --i)
                {
                    var ctl = PanelServersList.Controls[i];
                    ctl.Dispose();
                }
            }
            catch { }
            
        }
        public void AddServerElement(ServerItemWide s)
        {
            try
            {
                if (cbSort.CheckState == CheckState.Checked)
                {
                    this.Invoke(new Action(() => labelServers.Text = PanelServersList.Controls.Count + 1 + " " + l.LabelHeader3));
                    this.Invoke(new Action(() => PanelServersList.Controls.Add(s)));

                    if (PanelServersList.Controls.Count > 0)
                    {
                        ServerItemWide[] controlArray = new ServerItemWide[PanelServersList.Controls.Count];
                        PanelServersList.Controls.CopyTo(controlArray, 0);

                        Array.Sort(
                            controlArray,
                            (c1, c2) => (int)c1.Tag - (int)c2.Tag
                            );
                        Array.Reverse(controlArray);

                        foreach (ServerItemWide item in controlArray)
                        {
                            item.SetControlID(Array.IndexOf(controlArray, item) + 1);
                        }

                        this.Invoke(new Action(() => PanelServersList.SuspendLayout()));
                        PanelServersList.Controls.AddRange(controlArray);
                        this.Invoke(new Action(() => PanelServersList.ResumeLayout()));
                    }
                }
                else
                {
                    this.Invoke(new Action(() => labelServers.Text = PanelServersList.Controls.Count + 1 + " " + l.LabelHeader3));
                    this.Invoke(new Action(() => PanelServersList.Controls.Add(s)));
                }
                GC.Collect(); 
            }
            catch { }          
        }

        public void ParseJSONServers(List<string> list)
        {
            if (!File.Exists(@".\Newtonsoft.Json.dll"))
            {
                Debugger("Could not find Newtonsoft.Json.dll. Aborting server retrieval.", 2);
                return;
            }

            if (list == null || list.Count == 0)
            {
                return;
            }

            Debugger("Loading favorited servers.");

            foreach (string i in list)
            {
                try
                {
                    string webURI = "http://" +
                                    i + "/info";
                    if (!Uri.TryCreate(webURI, UriKind.Absolute, out Uri uri))
                    {
                        continue;
                    }
                    WebClient wc = new WebClient();
                    wc.DownloadStringCompleted += delegate(object sender, DownloadStringCompletedEventArgs e)
                    {
                        wc_DownloadStringCompleted(sender, e, i);};
                    wc.DownloadStringAsync(new Uri(webURI));
                }
                catch (WebException we)
                {
                    MessageBox.Show(we.Message);
                }                
            }          
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e, string ip)
        {
            try
            {
                ProcessJsonResult(e.Result, ip);
            }
            catch{ }                                        
        }

        private void ProcessJsonResult(string text, string ip)
        {
            try
            {
                if (!string.IsNullOrEmpty(text) && IsValidJson(text))
                {
                    dynamic data = JObject.Parse(text);
                    string serialize = "";
                    int botCount = 0;
                    int playerCount = 0;
                    serialize += @"\gametype\" + (string)data.status.g_gametype;
                    serialize += @"\hostname\" + (string)data.status.sv_hostname;
                    serialize += @"\mapname\" + (string)data.status.mapname;
                    serialize += @"\shortversion\" + (string)data.status.shortversion;
                    serialize += @"\hc\" + (string)data.status.g_hardcore;
                    serialize += @"\sv_maxclients\" + (string)data.status.sv_maxclients;
                    serialize += @"\isPrivate\" + (string)data.status.isPrivate;
                    int players = data.players.Count;
                    JArray array = (JArray)data.players;
                    List<string> list = new List<string>();
                    List<string> bots = new List<string>();
                    foreach (JObject player in array)
                    {
                        dynamic playerData = (dynamic)player;

                        string name = (string)playerData.name;
                        string ping = (string)playerData.ping;
                        name = Regex.Replace(name, @"\^.", "");
                        if (ping != "999")
                        {
                            playerCount++;
                            list.Add("- " + name.ToString());
                        }
                        else
                        {
                            bots.Add("Bot: " + name.ToString());
                            botCount++;
                        }
                    }
                    serialize += @"\bots\" + botCount;
                    list.AddRange(bots);
                    serialize += @"\players\" + String.Join(",", list);

                    serialize += @"\clients\" + playerCount;
                    ConstructServerItem(serialize, ip);
                }
            }
            catch { }
            
        }

        private bool IsValidJson(string strInput)
        {
            //"frmMain::Extract(string zipPath, string extractPath)-> " + e.Message
            try
            {
                if (string.IsNullOrWhiteSpace(strInput)) { return false; }
                strInput = strInput.Trim();
                if ((strInput.StartsWith("{") && strInput.EndsWith("}")) ||
                    (strInput.StartsWith("[") && strInput.EndsWith("]"))) 
                {
                    try
                    {
                        var obj = JToken.Parse(strInput);
                        return true;
                    }
                    catch (JsonReaderException)
                    {                      
                        return false;
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.ToString());
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Debugger("frmMain::IsValidJson(string strInput)-> " + e.Message, 1);
            }
            return false;
        }

        #endregion


        #region Archive  
        private void Extract(string zipPath, string extractPath)
        {
            try
            {
                if (!File.Exists(@".\Ionic.Zip.Reduced.dll"))
                {
                    Debugger("Could not find Ionic.Zip.Reduced.dll. Aborting archive extraction.", 2);
                    return;
                }
                if (f.isExtracting)
                {
                    return;
                }
                f.isExtracting = true;
                using (ZipFile zip = ZipFile.Read(zipPath))
                {
                    zip.ExtractProgress +=
                        new EventHandler<ExtractProgressEventArgs>(zip_ExtractProgress);
                    zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    Debugger("All files extracted.");
                    f.isExtracting = false;
                    DisplayGameVersion();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("frmMain::Extract(string zipPath, string extractPath)-> " + e.Message);
            }      
        }
        void zip_ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.TotalBytesToTransfer > 0)
            {
                Debugger("Extracting: " + e.CurrentEntry);
            }
        }
        #endregion


        #region Download Handler
        public void DownloadUri(string i, string path)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    f.isDownloading = true;
                    btnLaunch.Enabled = false;
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;

                    wc.DownloadFileAsync(
                        new System.Uri(i),
                        path
                    );
                }
            }
            catch (WebException e)
            {
                Debugger(l.MsgDebug2, 3);
                MessageBox.Show("frmMain::DownloadUri(string i, string path)-> " + e.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            labelDownload.Visible = true;
            labelDownload.Text = String.Format(l.MsgDebug1, "[" + f.downloadfile_name + "] " + e.ProgressPercentage + "% " + ConvertBytesToMegabytes(e.BytesReceived).ToString("N2") + " of " + ConvertBytesToMegabytes(e.TotalBytesToReceive).ToString("N2") + "mb");
            if(e.ProgressPercentage >= 100)
            {
                labelDownload.Visible = false;
            }
        }
        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            f.isDownloading = false;

            if (e.Error == null)
            {
                Debugger(String.Format(l.MsgDebug1, "[" + f.downloadfile_name + "] Done."));

                if (f.downloadfile_name == "Version Update")
                {
                    if (f.SetGameVersion(f.downloadVer))
                    {
                        Debugger("Changed Game Version to " + f.downloadVer);
                        GetServers();
                        ChangeGameVersion(f.downloadVer);
                    }
                }
                else if (f.downloadfile_name == "0.7 Update")
                {
                    Debugger(String.Format(l.MsgDebug1, "[" + f.downloadfile_name + "] Done."));
                    HandlePatchFiles();
                }
            }
            else
            {
                MessageBox.Show("frmMain::wc_DownloadFileCompleted()-> " + e.Error.Message);
            }
            DisplayGameVersion();
        }
        #endregion


        #region UICode
        private void cbGameVersions_CheckedChanged(object sender, EventArgs e)
        {
            VersionsLoad();
        }      
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            Application.ExitThread();

            Environment.Exit(Environment.ExitCode);
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        private void comboLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLang.SelectedIndex == 0)
            {
                f.SelectedLanguage = Functions.Language.English;
            }
            else if (comboLang.SelectedIndex == 1)
            {
                f.SelectedLanguage = Functions.Language.Russian;
            }

            InitializeLanguage();
        }
        private void SelectNewVersion()
        {
            if (prevIndex == listVersions.SelectedIndex)
            {
               
                return;
            }
            if (isSelfFiring)
            {
                isSelfFiring = false;
                return;
            }
            int currentIndex = listVersions.SelectedIndex;
            if (listVersions.SelectedItem != null)
            {
                String _ver = listVersions.SelectedItem.ToString();
                _ver = _ver.Replace("v", "");

                if (l.Version.Contains(_ver)) //|| string.IsNullOrEmpty(f.game_path)
                {
                    //SetPreviousIndex();
                    return;
                }

                f.isSelecting = true;
                if (f.VersionExists(_ver))
                {
                    DialogResult dialogResult =
                        MessageBox.Show("Are you sure you want to switch to version " + _ver + "?",
                            "Switch IW4X Version", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        prevIndex = currentIndex;
                        if (f.SetGameVersion(_ver))
                        {
                            Debugger("Changed Game Version to " + _ver);
                            prevIndex = currentIndex;
                            l.Version = _ver;
                            labelVersion.Visible = true;
                            InitializeLanguage();
                            GetServers();
                            //PopulateServerList();

                        }
                        else
                        {
                            labelVersion.Visible = true;
                            labelVersion.Text = l.LabelVersion_ErrorSwitch;
                            labelVersion.ForeColor = Color.IndianRed;
                            if (string.IsNullOrEmpty(l.Version))
                            {
                                labelVersion.Text = l.LabelVersion_Error;
                                labelVersion.ForeColor = Color.IndianRed;
                                SetPreviousIndex();
                            }
                            else
                            {
                                string serverName = "None";
                                if (f.SelectedServerItem != null)
                                {
                                    serverName = f.SelectedServerItem.ServerName;
                                }
                                labelVersion.Text = String.Format(l.LabelVersion, l.Version, serverName);
                                labelVersion.ForeColor = Color.ForestGreen;
                            }
                        }

                    }
                    else
                    {
                        SetPreviousIndex();
                    }
                }
                else
                {
                    DialogResult dialogResult =
                        MessageBox.Show("You do not have version " + _ver + ". Would you like to download it?",
                            "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes && !File.Exists(f.game_path + f.launcher_folder + "v" + _ver))
                    {
                        prevIndex = currentIndex;
                        f.downloadfile_name = "Version Update";
                        f.downloadVer = "v" + _ver;
                        Debugger("Starting Download: " + f.downloadVer);

                        DownloadUri(
                            String.Format("https://github.com/XLabsProject/iw4x-client/releases/download/{0}/iw4x.dll",
                                "v" + _ver),
                            f.game_path + f.launcher_folder + "v" + _ver + ".dll");
                    }
                    else
                    {
                        SetPreviousIndex();
                    }
                }            
            }
            f.isSelecting = false;
            return;
        }
        private void SetPreviousIndex()
        {
            isSelfFiring = true;
            int verIndex = listVersions.Items.IndexOf("v" + l.Version);
            
            if (verIndex == -1)
            {
                listVersions.SelectedIndex = prevIndex;
            }
            else
            {
                listVersions.SelectedIndex = verIndex;
            }

        }
        private void listVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectNewVersion();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }     
        private void gameRunning_Tick(object sender, EventArgs e)
        {
            f.SetGameRunning();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            GetServers();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }     
        private void ll1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialogResult =
                MessageBox.Show(l.MsgDebug7,
                    "Download DLC", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://dss0.cc/alterwarez/download/iw4x_dlcs.torrent");
            }
        }
        private void ll2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialogResult =
                MessageBox.Show(l.MsgDebug6,
                    "Update IW4X", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                DownloadPatchFiles();
            }
        }
        private void cbMenuFix_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMenuFix.CheckState == CheckState.Checked)
            {
                f.applyMenuUpdate = true;
            }
            else
            {
                f.applyMenuUpdate = false;
            }
        }
        private void btnDirectory_Click(object sender, EventArgs e)
        {
            if (f.SelectGameFolder())
            {
                Debugger("Selected Game Folder: " + f.game_path);
                InitiateProgram();
                lblDirectory.Text = f.game_path;
                GetServers();
            }
        }
        private void cbComp_CheckedChanged(object sender, EventArgs e)
        {
            if (cbComp.CheckState == CheckState.Checked)
            {
                f.isOnlyComp = true;
            }
            else
            {
                f.isOnlyComp = false;
            }

            GetServers();
        }
        private void btnLaunch_Click(object sender, EventArgs e)
        {
            LaunchGame();
        }
        private void label8_Click(object sender, EventArgs e)
        {
            CheckDLC();
        }
        private void label10_Click(object sender, EventArgs e)
        {
            CheckZone();
        }

        private void SetGUIDFolder(int ver)
        {
            //Unused.
            string guidpath = "";
            using (var ofd = new OpenFileDialog())
            {
                string path = f.game_path + @"players\";
                if (Directory.Exists(path))
                {
                    ofd.InitialDirectory = path;
                }
                else
                {
                    ofd.InitialDirectory = @"C:\";
                }
                ofd.Filter = "(*.dat)|*.dat";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.Multiselect = false;
                //ofd.ShowDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    guidpath = ofd.FileName;
                }
                    
            }
            try
            {
                if (!string.IsNullOrEmpty(guidpath))
                {
                    if (ver == 0) //0.6
                    {
                        File.Copy(guidpath, f.game_path + f.launcher_folder + "guid_0.6.dat");
                        Debugger("Saved 0.6.x GUID.");
                    }else if(ver == 1)
                    {
                        File.Copy(guidpath, f.game_path + f.launcher_folder + "guid_0.7.dat");
                        Debugger("Saved 0.7.x GUID.");
                    }
                }
            }
            catch { Debugger("Failed to save GUID. It already exists."); }         
        }
        #endregion

        private void cbSort_CheckedChanged(object sender, EventArgs e)
        {
            GetServers();
        }

        private void set06xGUIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGUIDFolder(0);
        }

        private void set07xGUIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGUIDFolder(1);
        }

        public static class FlashWindow
        {
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

            [StructLayout(LayoutKind.Sequential)]
            private struct FLASHWINFO
            {
                /// <summary>
                /// The size of the structure in bytes.
                /// </summary>
                public uint cbSize;
                /// <summary>
                /// A Handle to the Window to be Flashed. The window can be either opened or minimized.
                /// </summary>
                public IntPtr hwnd;
                /// <summary>
                /// The Flash Status.
                /// </summary>
                public uint dwFlags;
                /// <summary>
                /// The number of times to Flash the window.
                /// </summary>
                public uint uCount;
                /// <summary>
                /// The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
                /// </summary>
                public uint dwTimeout;
            }

            /// <summary>
            /// Stop flashing. The system restores the window to its original stae.
            /// </summary>
            public const uint FLASHW_STOP = 0;

            /// <summary>
            /// Flash the window caption.
            /// </summary>
            public const uint FLASHW_CAPTION = 1;

            /// <summary>
            /// Flash the taskbar button.
            /// </summary>
            public const uint FLASHW_TRAY = 2;

            /// <summary>
            /// Flash both the window caption and taskbar button.
            /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
            /// </summary>
            public const uint FLASHW_ALL = 3;

            /// <summary>
            /// Flash continuously, until the FLASHW_STOP flag is set.
            /// </summary>
            public const uint FLASHW_TIMER = 4;

            /// <summary>
            /// Flash continuously until the window comes to the foreground.
            /// </summary>
            public const uint FLASHW_TIMERNOFG = 12;


            /// <summary>
            /// Flash the spacified Window (Form) until it recieves focus.
            /// </summary>
            /// <param name="form">The Form (Window) to Flash.</param>
            /// <returns></returns>
            public static bool Flash(System.Windows.Forms.Form form)
            {
                // Make sure we're running under Windows 2000 or later
                if (Win2000OrLater)
                {
                    FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0);
                    return FlashWindowEx(ref fi);
                }
                return false;
            }

            private static FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
            {
                FLASHWINFO fi = new FLASHWINFO();
                fi.cbSize = Convert.ToUInt32(Marshal.SizeOf(fi));
                fi.hwnd = handle;
                fi.dwFlags = flags;
                fi.uCount = count;
                fi.dwTimeout = timeout;
                return fi;
            }

            /// <summary>
            /// Flash the specified Window (form) for the specified number of times
            /// </summary>
            /// <param name="form">The Form (Window) to Flash.</param>
            /// <param name="count">The number of times to Flash.</param>
            /// <returns></returns>
            public static bool Flash(System.Windows.Forms.Form form, uint count)
            {
                if (Win2000OrLater)
                {
                    FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, count, 0);
                    return FlashWindowEx(ref fi);
                }
                return false;
            }

            /// <summary>
            /// Start Flashing the specified Window (form)
            /// </summary>
            /// <param name="form">The Form (Window) to Flash.</param>
            /// <returns></returns>
            public static bool Start(System.Windows.Forms.Form form)
            {
                if (Win2000OrLater)
                {
                    FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, uint.MaxValue, 0);
                    return FlashWindowEx(ref fi);
                }
                return false;
            }

            /// <summary>
            /// Stop Flashing the specified Window (form)
            /// </summary>
            /// <param name="form"></param>
            /// <returns></returns>
            public static bool Stop(System.Windows.Forms.Form form)
            {
                if (Win2000OrLater)
                {
                    FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_STOP, uint.MaxValue, 0);
                    return FlashWindowEx(ref fi);
                }
                return false;
            }

            /// <summary>
            /// A boolean value indicating whether the application is running on Windows 2000 or later.
            /// </summary>
            private static bool Win2000OrLater
            {
                get { return System.Environment.OSVersion.Version.Major >= 5; }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => GetServers()));

        }         

        private void reload_Click(object sender, EventArgs e)
        {
            GetServers();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormGUID guid = new FormGUID();
            guid.ShowDialog();
        }

        private void rButton1_Click_1(object sender, EventArgs e)
        {
            string m = "Beware! This is a beta feature. For extra safety, manually backup your guid.dat file in the folder /players/, before proceeding!\n\n" +
                "Осторожно! Это бета-версия функции. Для дополнительной безопасности, перед началом работы вручную создайте резервную копию файла guid.dat в папке /players/!";

            MessageBox.Show(m, "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (Settings.GameVersions.Count > 0)
            {
                FormGUID guid = new FormGUID();
                guid.ShowDialog();
            }
            
        }
    }
}
