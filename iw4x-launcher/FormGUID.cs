using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iw4x_launcher
{
    public partial class FormGUID : Form
    {
        private Localization l = Localization.Languages;
        private Functions f = Functions.Methods;
        private SettingsClass Settings = SettingsClass.Settings;
        public FormGUID()
        {
            InitializeComponent();
        }

        private void FormGUID_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.HorizontalScroll.Maximum = 0;
            flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel1.VerticalScroll.Visible = false;
            flowLayoutPanel1.AutoScroll = true;
            Populate();
        }
        private void Populate()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach(string s in Settings.GameVersions)
            {
                GUIDElement element = new GUIDElement();
                element.SetGameVersion(s);
                flowLayoutPanel1.Controls.Add(element);
            }
        }

        private void rButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
