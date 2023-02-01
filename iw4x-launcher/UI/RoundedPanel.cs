using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iw4x_launcher.UI
{
    public partial class RoundedPanel : Panel
    {
        public RoundedPanel()
        {
            this.DoubleBuffered = true;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.Resize += RoundedPanel_Resize;
        }
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
        private void RoundedPanel_Load(object sender, EventArgs e)
        {

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

        private void RoundedPanel_Resize(object sender, EventArgs e)
        {
            AdjustSize();
        }
    }
}
