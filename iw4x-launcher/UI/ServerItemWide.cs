using iw4x_launcher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace iw4x_launcher.UI
{
    public partial class ServerItemWide : UserControl
    {
        #region Setters
        private Localization l = Localization.Languages;
        private Functions f = Functions.Methods;
        private  SettingsClass Settings = SettingsClass.Settings;


        private Color ColorHover = Color.FromArgb(28, 29, 31);
        private Color ColorDefault = Color.FromArgb(21, 21, 21);
        private Color ColorSelected = Color.FromArgb(39, 41, 42);

        public List<string> ListPlayers = new List<string>();
        public string ServerName { get; private set; }
        public string ServerMapName { get; private set; }
        public string ServerVersion { get; private set; }
        public string ServerGameType { get; private set; }
        public string ServerGameMode { get; private set; }
        public string ServerCompleteIP { get; private set; }
        public string ServerCompletePlayers { get; private set; }

        public bool isServerPrivate { get; private set; }
        public int ServerPort { get; private set; }
        public int ServerIP { get; private set; }
        public int ServerOnlineClients { get; private set; }
        public int ServerMaximumClients { get; private set; }
        public int ServerOnlineBots { get; private set; }
        public int ControlID { get; private set; }
        public bool IsPopulated { get; private set; }
        public bool IsSelected { get; set; }

        
        public void SetPlayers(List<string> i)
        {
            ListPlayers = i;
            ToolTip t = new ToolTip();
            t.ShowAlways = true;
            t.OwnerDraw = true;
            t.BackColor = Color.FromArgb(39, 41, 42);
            t.Draw += t_Draw;
            t.SetToolTip(labelPlayers, "[Online Players]\n\n" + String.Join("\n", i));

        }
        private void t_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font f = new Font("Arial", 9f);
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.White, new PointF(2, 2));
        }
        public void SetServerName(string i)
        {
            ServerName = i;
            labelServerName.Text = i;          
        }
        public void SetServerMap(string i)
        {
            i = i.ToLower();
            List<string> Maps_List = Resources.Resource_String_Maps.Split('\n').ToList();
                foreach(string e in Maps_List)
                {
                    if (e.StartsWith(i))
                    {
                        string[] tokens = e.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    //MessageBox.Show("C " + tokens[1]);
                    if (tokens.Length == 2)
                        {
                            string name = tokens[1].Trim();
                            ServerMapName = name;
                            labelMapName.Text = name;
                            return;
                        }
                    }
                }
            i = i.Replace("mp_", "");
            i = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(i.ToLower());
            ServerMapName = i;
            labelMapName.Text = i;

        }
        public void SetServerVersion(string i)
        {
            ServerVersion = i;
        }
        public void SetServerGameType(string i)
        {
            labelGameType.Text = i;
            ServerGameType = i;
        }
        public void SetServerCompletePlayers(string i)
        {
            labelPlayers.Text = i;
        }
        public void SetServerGameMode(string i, string hc)
        {
            if (i == "sd")
            {
                i = "S&&D";
            }
            else if (i == "war")
            {
                i = "TDM";
            }else if(i == "dm")
            {
                i = "FFA";
            }
            else
            {
                i = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(i.ToLower());
            }
            if (hc.Equals("1"))
            {
                SetServerGameType("Hardcore");
            }
            else
            {
                SetServerGameType("Softcore");
            }
            labelGameMode.Text = i;
            ServerGameMode = i;
        }

        public void SetServerCompleteIP(string i)
        {
            ServerCompleteIP = i;
            //By setting IP, the control is not a header.
            this.ForeColor = Color.CadetBlue;
            IsPopulated = true;
            this.Cursor = Cursors.Hand;
        }
        public void SetServerPrivate(bool i)
        {
            isServerPrivate = i;
        }
        public void SetServerPort(int i)
        {
            ServerPort = i;
        }
        public void SetServerIP(int i)
        {
            ServerIP = i;
        }
        public void SetServerOnlineClients(int i)
        {
            ServerOnlineClients = i;
        }
        public void SetServerMaximumClients(int i)
        {
            ServerMaximumClients = i;
        }
        public void SetServerOnlineBots(int i)
        {
            ServerOnlineBots = i;
        }
        public void SetControlID(int i)
        {
            ControlID = i;
            labelID.Text = i.ToString();
            labelID.Visible = true;
        }
        #endregion

        public ServerItemWide()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Region = System.Drawing.Region.FromHrgn(Common.CreateRoundRectangleRegion(0, 0, Width, Height, 5, 5));
        }

        private void ServerItemWide_Load(object sender, EventArgs e)
        {
            //this.BackColor = ColorDefault;
            WireControls();
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
        private void ServerItemWide_Resize(object sender, EventArgs e)
        {
            AdjustSize();
        }
        #region Selection Events
        private void WireControls()
        {
            if (!IsPopulated)
            {
                return;
            }
            foreach (Control c in this.Controls)
            {
                c.MouseEnter += Control_MouseEnter;
                c.MouseClick += Control_MouseClick;
                c.MouseLeave += Control_MouseLeave;
            }

            this.MouseEnter += Control_MouseEnter;
            this.MouseClick += Control_MouseClick;
            this.MouseLeave += Control_MouseLeave;
        }
        private void Control_MouseEnter(object sender, EventArgs e)
        {
            if (!IsSelected)
            {
                this.BackColor = ColorHover;
            }
        }
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            if (!IsSelected)
            {
                this.BackColor = ColorDefault;
            }
        }
        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsSelected)
            {
                DeselectControl(false);
            }
            else
            {
                SelectControl();
            }
        }

        private void DeselectExistingControl()
        {
            ServerItemWide s = f.SelectedServerItem;
            if (s != null)
            {
                s.DeselectControl(true);
            }
        }
        private void SelectControl()
        {
            if (!IsSelected)
            {
                if (isServerPrivate)
                {
                    f.SelectedServerPassword = ""; //This ensures if a password was set before is removed.
                                                   //However, this method will not reselect the previous server, in case the player aborted.
                                                   //But who cares. I certainly dont
                    ServerPassword sp = new ServerPassword();
                    sp.ShowDialog();
                    if (string.IsNullOrEmpty(f.SelectedServerPassword))
                    {
                        return;
                    }
                }
                
                DeselectExistingControl();
                IsSelected = true;
                this.BackColor = ColorSelected;
                f.SelectedServerIP = ServerCompleteIP;
                f.SelectedServerItem = this;
            }
        }
        public void DeselectControl(bool alt)
        {
            if (IsSelected)
            {
                IsSelected = false;
                if (alt)
                {
                    this.BackColor = ColorDefault;
                }
                else
                {
                    this.BackColor = ColorHover;
                }

                if (f.SelectedServerIP == ServerCompleteIP)
                {
                    f.SelectedServerIP = "";
                    f.SelectedServerItem = null;
                    f.SelectedServerPassword = "";
                }
            }
        }

        #endregion

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!IsPopulated)
            {
                e.Cancel = true;
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void SetNotifiedServer()
        {
            this.ForeColor = Color.Orange;
        }
        public void SetNotifyNumber(int value)
        {
            toolStripTextBox1.Text = value.ToString();
        }
        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            int a = 0;

            if(int.TryParse(toolStripTextBox1.Text, out a)){
                if(a > 0)
                {
                    if (Settings.NotifyServers.Keys.Contains(ServerCompleteIP))
                    {
                        Settings.NotifyServers.Remove(ServerCompleteIP);
                        Settings.NotifyServers.Add(ServerCompleteIP, a);
                    }
                    else
                    {
                        Settings.NotifyServers.Add(ServerCompleteIP, a);
                    }
                }
                else
                {
                    toolStripTextBox1.Text = "";
                    if (Settings.NotifyServers.Keys.Contains(ServerCompleteIP))
                    {
                        Settings.NotifyServers.Remove(ServerCompleteIP);
                    }
                }
            }else if(a <= 0)
            {
                toolStripTextBox1.Text = "";
                if (Settings.NotifyServers.Keys.Contains(ServerCompleteIP))
                {
                    Settings.NotifyServers.Remove(ServerCompleteIP);
                }
            }
        }
    }
}
