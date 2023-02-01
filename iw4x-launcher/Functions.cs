using iw4x_launcher.Properties;
using iw4x_launcher.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iw4x_launcher
{
    public sealed class Functions
    {

        /*
         * Code is written in a very simplistic (and bad) way. Do not use it for reference. Fix it if you wish, but I CBA.
         * I had no intention of having standards in this project. It works, but that's it.       
         */

        private static Functions instance;
        public static Functions Methods
        {
            get
            {
                if (instance == null)
                    instance = new Functions();
                return instance;
            }
        }
        private Functions()
        {

        }
        private SettingsClass Settings = SettingsClass.Settings;

        private Localization l = Localization.Languages;
        public List<string> launch_args = new List<string>();
        public string patches_path = "";
        public string launcher_folder = @"iw4x_launcher\";
        public string config_path = @"iw4xl.cfg";
        public string game_path = @""; //H:\Games\Call of Duty Modern Warfare 2\
        public string temp_path = Path.Combine(System.IO.Path.GetTempPath(), "mayion.iw4x.launcher");
        public string downloadfile_name = "";

        public bool isDownloading = false; //Insurance to make sure only one file downloads at a time.
        public bool isExtracting = false;
        public string downloadVer = "";

        public string SelectedServerPassword = "";
        public string SelectedServerIP = "";
        public ServerItemWide SelectedServerItem;
        public List<ServerItemWide> TotalServers = new List<ServerItemWide>();

        public bool isCheckingDLC = true;
        public bool isCheckingRaw = true;
        public bool isOnlyComp = true;
        public bool applyMenuUpdate = true;
        public bool isVerifiedDLC = false;
        public bool isVerifiedRaw = false;
        public bool isSelecting = false;
        public List<string> missing_dlcs = new List<string>();
        public List<string> missing_files = new List<string>();

        public List<string> bad_ips = new List<string>();
        public List<string> good_ips = new List<string>();
        public List<string> favorited_ips = new List<string>();

        public Language SelectedLanguage { get; set; }

        public enum Language
        {
            English,
            Russian            
        }

        public string GetResultValue(string input, string key)
        {
            List<string> items = input.Split('\\').ToList();
            
            int x = items.IndexOf(key);
            if (items.Count >= x + 1)
            {
                return items[x + 1];
            }

            return string.Empty;
        }
        public static string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(" " + t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }

        public static string FromHexString(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }

        private bool isAllowedChar(char c)
        {
            char ch = '&';
            bool isNumeric = Regex.IsMatch(c.ToString(), "[1-9]", RegexOptions.IgnoreCase);
            bool isAlphaBet = Regex.IsMatch(c.ToString(), "[a-z]", RegexOptions.IgnoreCase);
            if (isNumeric || isAlphaBet || c == ch)
            {
                return true;
            }

            return false;
        }
        public string CleanString(string input)
        {
            input = input.Replace("&", "&&");
            string b = "";
            string modified_i = "";
            string[] new_i = input.Split(' ');


            foreach (string j in new_i)
            {
                if (!j.ToLower().StartsWith("cardicon"))
                {
                    modified_i += j + " ";
                }
            }

            for (int i = 0; i < modified_i.Length; i++)
            {
                if (modified_i[i] == '^')
                {
                    i++;
                }
                else
                {
                    b += modified_i[i];
                }
            }
            string hex = ToHexString(b);
            hex = hex.Replace("2F", "00");
            return FromHexString(hex);
        }
        public bool SetGameRunning()
        {          
            if (isGameRunning())
            {
                frmMain.frm.labelVersion.Text = l.MsgDebug5;
                frmMain.frm.btnLaunch.Enabled = false;
                return true;
            }

            frmMain.frm.DisplayGameVersion();
            return false;
        }
        public bool isGameRunning()
        {
            try
            {
                Process[] pname = Process.GetProcessesByName("iw4x");
                if (pname.Length == 0)
                {
                    return false;
                }
                foreach(Process p in pname)
                {
                    if(p.MainWindowTitle == "IW4x: Multiplayer")
                    {
                        return true;
                    }
                }
                
            }
            catch { }
            return false;
        }
        public bool CreateConfig()
        {
            try
            {
                List<string> lines = new List<string>();
                string path = config_path;
                
                if (!IsDirectoryWritable(Environment.CurrentDirectory))
                {
                    return false;
                }

                if (VerifyFileAccessibility(path))
                {
                    return true;
                }
                else
                {
                    lines.Add("lang:ru");
                    lines.Add("cb1:0");
                    lines.Add("ver:0.0.0");
                    lines.Add("dir:null");
                    File.WriteAllLines(path, lines);
                    if (VerifyFileAccessibility(path))
                    {
                        return true;
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Functions::CreateConfig()-> " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public bool isValidGameDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                if(File.Exists(path + @"\iw4x.exe" ))
                {
                    return true;
                }
            }
            return false; 
        }

        public bool SelectGameFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (isValidGameDirectory(fbd.SelectedPath))
                    {
                        game_path = fbd.SelectedPath + @"\";
                        SetConfigKey("dir", game_path);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid game folder. Please make sure iw4x.exe exist.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    
                }
            }
            return false;
        }


        public string GetConfigValue(string key)
        {
            try
            {
                string path = config_path;
                List<string> lines = new List<string>();
                if (!VerifyFileAccessibility(path))
                {
                    return string.Empty;
                }
                lines = File.ReadAllLines(path).ToList();
                foreach (string i in lines)
                {
                    if (i.Contains(":"))
                    {
                        string[] tokens = i.Split(new char[] { ':' }, 2);
                        if (tokens.Length >= 2)
                        {
                            if (tokens[0].Trim().ToLower().Equals(key))
                            {
                                return tokens[1].Trim();
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Functions::GetConfigValue()-> " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return string.Empty;
        }

        public List<string> GetConfigKeys()
        {
            string path = config_path;
            List<string> lines = new List<string>();
            List<string> keys = new List<string>();
            if (!VerifyFileAccessibility(path))
            {
                return keys;
            }
            lines = File.ReadAllLines(path).ToList();
            foreach (string i in lines)
            {
                if (i.Contains(":"))
                {
                    string[] tokens = i.Split(':');
                    if (tokens.Length >= 2)
                    {
                        keys.Add(tokens[0].ToLower().Trim());
                    }
                }
            }
            return keys;
        }

        public bool SetConfigKey(string key, string value)
        {
            try
            {
                bool found = false;
                string path = config_path;
                List<string> lines = new List<string>();
                List<string> new_lines = new List<string>();
                if (!VerifyFileAccessibility(path))
                {
                    return false;
                }
                else
                {
                    lines = File.ReadAllLines(path).ToList();
                    if (!GetConfigKeys().Contains(key))
                    {
                        new_lines.AddRange(lines);
                        new_lines.Add(key + ":" + value);
                        File.WriteAllLines(path, new_lines);
                        if (VerifyFileAccessibility(path))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    foreach (string i in lines)
                    {
                        if (i.Contains(":"))
                        {
                            string[] tokens = i.Split(':');
                            if (tokens.Length >= 2)
                            {
                                if (tokens[0].Trim().ToLower().Equals(key.ToLower()) && tokens[1].Trim().ToLower() != value)
                                {
                                    new_lines.Add(key + ":" + value);
                                    found = true;
                                    continue;
                                }
                            }
                        }

                        new_lines.Add(i);
                    }
                    File.WriteAllLines(path, new_lines);
                    if (VerifyFileAccessibility(path))
                    {
                        return true;
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Functions::SetConfigKey()-> " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        //@priit
        public bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        dirPath,
                        Path.GetRandomFileName()
                    ),
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                if (throwIfFails)
                    throw;
                else
                    return false;
            }
        }

        public bool CheckDLC()
        {
            string[] parts = l.DLCFiles.Split(',');

            foreach (string p in parts)
            {
                    string filepath = game_path + p;

                    if (!File.Exists(filepath))
                    {
                        missing_dlcs.Add(p);
                    }
            }

            if (missing_dlcs.Count > 0)
            {
                return false;
            }
            return true;
        }

        public bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public bool CheckZone()
        {
            //For checking rawfiles.
            string[] parts = l.Godbless.Split(',');
            
            foreach (string p in parts)
            {
                string[] part_tokens = p.Split(':');
                if (IsNumeric(part_tokens[1]))
                {
                    long size = long.Parse(part_tokens[1]);                   
                    string filepath = game_path + part_tokens[0];
                    
                    if (!File.Exists(filepath))
                    {
                        missing_files.Add(part_tokens[0]);
                    }
                    else
                    {
                        long fileSize = new System.IO.FileInfo(filepath).Length;
                        if (fileSize != size)
                        {
                            missing_files.Add(part_tokens[0]);
                        }
                    }
                }
            }
            if (missing_files.Count > 0)
            {
                return false;
            }
            return true;

        }

        public bool CreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(path);
                    return true;
                }
                catch (IOException e)
                {
                    MessageBox.Show("Functions::CreateDirectory()-> " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void UnsetReadOnlyAttribute(string filePathWithName)
        {
            FileInfo fileInfo = new FileInfo(filePathWithName);
            if (fileInfo.IsReadOnly)
            {
                fileInfo.IsReadOnly = false;
            }
        }

        public bool VerifyFileAccessibility(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    FileInfo _file = new FileInfo(path);
                    if (_file.IsReadOnly)
                    {
                        UnsetReadOnlyAttribute(path);
                        if (_file.IsReadOnly)
                        {
                            return false;
                        }        
                    }
                    _file.Open(FileMode.Open, FileAccess.ReadWrite).Dispose();
                    return true;
                }
                catch (IOException)
                {
                    return false;
                }
            }
            return false;
        }

        public bool VersionExists(string ver)
        {
            FileInfo[] files = GetFolderFI(game_path + launcher_folder);
            if (files == null)
            {
                return false;
            }
            foreach (var j in files)
            {
                if (GetFileVersion(j.FullName) == ver && VerifyFileAccessibility(j.FullName))
                {
                    return true;
                }
            }
            return false;
        }

        public string GetFileFromVer(string ver)
        {
            FileInfo[] files = GetFolderFI(game_path + launcher_folder);
            if (files == null)
            {
                return string.Empty;
            }
            foreach (var j in files)
            {
                if (GetFileVersion(j.FullName) == ver && VerifyFileAccessibility(j.FullName))
                {
                    return j.FullName;
                }
            }
            return string.Empty;
        }

        public bool DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.SetAttributes(path, FileAttributes.Normal);
                    File.Delete(path);
                    return true;
                }
                catch (Exception)
                {
                    
                }
            }
            return false;
        }

        public bool RenameLauncherFiles()
        {
            try
            {
                string newpath = game_path + launcher_folder;
                FileInfo[] files = GetFolderFI(game_path + launcher_folder);
                if (files == null)
                {
                    return false;
                }
                foreach (var j in files)
                {
                    var name = System.Diagnostics.FileVersionInfo.GetVersionInfo(j.FullName);
                    if (name.ProductName != null && name.ProductName.ToLower().Contains("iw4x"))
                    {
                        string ver = name.ProductVersion;
                        if (!string.IsNullOrEmpty(ver) && !File.Exists(newpath + "v" + ver + ".dll"))
                        {
                            File.Move(j.FullName, newpath + "v" + ver + ".dll");
                            return true;
                        }
                    }
                }
            }
            catch (IOException)
            {

            }
            return false;
        }

        public List<string> GetLocalVersions()
        {
            //Settings.GameVersions.Clear();
            FileInfo[] files = GetFolderFI(game_path + launcher_folder);
            List<string> list = new List<string>();
            if (files == null)
            {
                return list;
            }
            foreach (var j in files)
            {
                var name = System.Diagnostics.FileVersionInfo.GetVersionInfo(j.FullName);
                if (name.ProductName != null && name.ProductName.ToLower().Contains("iw4x"))
                {
                    list.Add(name.ProductVersion);
                }
            }

            string iw4path = game_path + "iw4x.dll";

            if (File.Exists(iw4path) && !list.Contains(GetFileVersion(iw4path)))
            {
                list.Add(GetFileVersion(iw4path));
            }

            string bareVersion;
            foreach(string j in list)
            {
                if (j.Contains("."))
                {
                    string[] tokens = j.Split('.');
                    if (tokens.Length >= 2)
                    {
                        bareVersion = tokens[0] + "." + tokens[1];
                        if (!Settings.GameVersions.Contains(bareVersion))
                        {
                            Settings.GameVersions.Add(bareVersion);
                        }

                    }
                }
            }
            

            return list;
        }

        public void WriteResourceToFile(string resourceName, string fileName)
        {
            try
            {
                using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    {
                        resource.CopyTo(file);
                    }
                }
            }
            catch
            {

            }
           
        }

        public bool SetGameVersion(string ver)
        {
            //Rubbish code. CBA to beautify it.
            try
            {
                
                ver = ver.Replace("v", "");
                string path = game_path + "iw4x.dll";
                if (GetFileVersion(path) == ver)
                {
                    
                    return true;
                }
                if (VersionExists(ver))
                {
                    string ver_path = GetFileFromVer(ver);
                    if (!File.Exists(path))
                    {
                        // No need to replace files.
                        File.Copy(ver_path, path);
                        if (VerifyFileAccessibility(path))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (MoveFromMainToLauncher())
                        {
                            if (VerifyFileAccessibility(ver_path))
                            {
                                File.Copy(ver_path, path);
                                if (VerifyFileAccessibility(path))
                                {
                                    
                                    return true;
                                }
                            }
                        }
                                        
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Functions::SetGameVersion()-> " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool MoveFromMainToLauncher()
        {
            try
            {
                string path = game_path + "iw4x.dll";
                string newpath = "";
                if (VerifyFileAccessibility(path))
                {
                    string ver = GetFileVersion(path);
                    if (!VersionExists(ver))
                    {
                        newpath = game_path + launcher_folder + "v" + ver + ".dll";
                        if (File.Exists(newpath))
                        {
                            //File already exists, but is not genuine. Probably user testing.
                            if (DeleteFile(newpath))
                            {
                                File.Move(path, newpath);
                                File.SetAttributes(newpath, FileAttributes.Normal);
                            }
                        }
                        else
                        {
                            File.Move(path, newpath);
                            File.SetAttributes(newpath, FileAttributes.Normal);

                        }

                    }
                    else
                    {
                        if (DeleteFile(path))
                        {
                            return true;
                        }
                        
                    }
                }

                if (!File.Exists(path) && File.Exists(newpath))
                {
                    return true;
                }
                
            }
            catch (IOException e)
            {
                MessageBox.Show("Functions::MoveFromMainToLauncher()-> " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public string GetFileVersion(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return FileVersionInfo.GetVersionInfo(path).FileVersion;
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Functions::GetFileVersion()-> " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return string.Empty;
        }

        public FileInfo[] GetFolderFI(string i)
        {
            if (!Directory.Exists(i))
            {
                return null;
            }
            return new DirectoryInfo(i).GetFiles();
        }

        public List<string> GetFolderFiles(string i)
        {
            return new DirectoryInfo(i).GetFiles().Select(o => o.Name).ToList();
        }
    }
}
