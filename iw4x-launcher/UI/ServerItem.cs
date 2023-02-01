using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace iw4x_launcher.UI
{
    public partial class ServerItem : UserControl
    {
        private Localization l = Localization.Languages;
        private Functions f = Functions.Methods;

        public string serverTitle { get; set; }
        public string mapName { get; set; }
        public string playerCount { get; set; }
        public string gameMode { get; set; }
        public string serverIP { get; set; }
        public string serverPort { get; set; }
        public string serverVersion { get; set; }
        public int ID { get; set; }
        public bool isHardcore { get; set; }
        public bool isSelected { get; set; }

        public List<string> playerList { get; set; }

        private Color ColorHover = Color.FromArgb(33, 36, 36);
        private Color ColorDefault = Color.FromArgb(47, 51, 51);
        private Color ColorSelected = Color.FromArgb(30, 30, 30);

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

        public ServerItem()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void AdjustSize()
        {
            try
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                this.Invalidate();
            }
            catch (Exception)
            {
            }
        }
        private void ServerItem_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorDefault;
            WireControls();
        }

        public void SetID(int i)
        {
            ID = i;
            lblID.Text = i + ")";
        }

        public void SetServerVersion(string i)
        {
            serverVersion = i;
        }
        public void SetServerTitle(string i)
        {
            serverTitle = i;
            lblServerTitle.Text = i;
        }
        public void SetMapName(string i)
        {
            i = i.Replace("mp_", "");
            i = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(i.ToLower());
            mapName = i;
            lblmapName.Text = i;
        }
        public void SetPlayerCount(string i)
        {
            playerCount = i;
            lblPlayers.Text = i;
        }
        public void SetGamemode(string i, string hc)
        {          
            gameMode = i;
            lblGM.Text = GetGamemode(i, hc);
        }
        public void SetServerIP(string i)
        {
            serverIP = i;
        }
        private string GetGamemode(string i, string hc)
        {
            i = i.ToLower().Trim();
            string dif;
            if (hc.Equals("1"))
            {
                isHardcore = true;
                dif = "HC";
            }
            else
            {
                isHardcore = false;
                dif = "SC";
            }
            if (i == "sd")
            {
                i = "S&&D";
            }else if (i == "war")
            {
                i = "TDM";
            }
            else
            {
                i = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(i.ToLower());
            }
            return i + "/" + dif;
        }

        private void WireControls()
        {
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
            if (!isSelected)
            {
                this.BackColor = ColorHover;
            }
        }
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            if (!isSelected)
            {
                this.BackColor = ColorDefault;
            }
        }
        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (isSelected)
            {
                DeselectControl(false);
            }
            else
            {
                SelectControl();
            }
        }

        private void Remove()
        {
            //Make sure to call Deselect to clear all data.
        }
        private void DeselectExistingControl()
        {
            //ServerItem s = f.SelectedServerItem;
            //if (s != null)
            //{
            //    s.DeselectControl(true);
            //}
        }
        private void SelectControl()
        {
            if (!isSelected)
            {
                DeselectExistingControl();
                isSelected = true;
                this.BackColor = ColorSelected;
                f.SelectedServerIP = serverIP;
                //f.SelectedServerItem = this;
            }
        }
        private void DeselectControl(bool alt)
        {
            if (isSelected)
            {
                isSelected = false;
                if (alt)
                {
                    this.BackColor = ColorDefault;
                }
                else
                {
                    this.BackColor = ColorHover;
                }
                
                if (f.SelectedServerIP == serverIP)
                {
                    f.SelectedServerIP = "";
                }
            }
        }

        private void ServerItem_Resize(object sender, EventArgs e)
        {
            AdjustSize();
        }
    }
}
