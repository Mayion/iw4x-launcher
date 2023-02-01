using iw4x_launcher.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iw4x_launcher
{
    public partial class GUIDElement : UserControl
    {
        public GUIDElement()
        {
            InitializeComponent();
            AdjustSize();
        }
        public string GameVersion = "0.0";
        private Localization l = Localization.Languages;
        private Functions f = Functions.Methods;
        private SettingsClass Settings = SettingsClass.Settings;

        private bool isSaved = false;
        private void GUIDElement_Load(object sender, EventArgs e)
        {

        }
        private void AdjustSize()
        {
            try
            {
                Region = System.Drawing.Region.FromHrgn(Common.CreateRoundRectangleRegion(0, 0, Width, Height, 5, 5));
                this.Invalidate();
            }
            catch (Exception)
            {
            }
        }
        public void SetGameVersion(string ver)
        {
            GameVersion = ver;
            labelVersion.Text = "Game Version " + ver;
            isExisting();
        }
        private bool isExisting()
        {
            string _s = "guid_" + GameVersion + ".dat";
            string fPath = f.game_path + f.launcher_folder + _s;

            if (File.Exists(fPath))
            {
                isSaved = true;
                linkLabel2.Text = "Saved - Change";
                linkLabel2.ForeColor = Color.CadetBlue;
                return true;
            }
            isSaved = false;
            linkLabel2.Text = "Select GUID File";
            linkLabel2.ForeColor = Color.CadetBlue;
            return false;
        }
        private bool SelectGUID()
        {
            if(GameVersion == "0.0")
            {
                return false; //Should not happen. But in case. Too tired to think if it can.
            }

            string guidpath = "";
            using (var ofd = new OpenFileDialog())
            {
                string path = f.game_path + @"players\"; // this is the path that you are checking.
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
                    //First check the file is accessible for copying and all that.
                    string _s = "guid_" + GameVersion + ".dat";
                    string fPath = f.game_path + f.launcher_folder + _s;
                    if (File.Exists(fPath))
                    {
                        if (f.DeleteFile(fPath))
                        {
                            File.Copy(guidpath, fPath);
                            isSaved = true;
                            return true;
                        }
                    }
                    else
                    {
                        File.Copy(guidpath, fPath);
                        isSaved = false;
                        return true;
                    }
                    
                }
            }
            catch { }
            return false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectGUID())
            {
                linkLabel2.Text = "Saved - Change";
                linkLabel2.ForeColor = Color.CadetBlue;
            }
            else
            {
                linkLabel2.Text = "Error - Change";
                linkLabel2.ForeColor = Color.Orange;
            }
        }

        private void GUIDElement_Resize(object sender, EventArgs e)
        {
            AdjustSize();
        }
    }
}
