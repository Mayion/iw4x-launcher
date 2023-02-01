using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iw4x_launcher.UI
{
    public class RButton : Button
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
        public RButton()
        {
            this.DoubleBuffered = true;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, _RoundValue, _RoundValue));
            this.Resize += RoundedPanel_Resize;

            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            this.FlatAppearance.BorderSize = 0;
        }
        private int _RoundValue = 15;
        [Description("Corner Value"), Category("Custom")]
        public int CornerRadius
        {
            get { return _RoundValue; }
            set
            {
                if (value > 0)
                {
                    _RoundValue = value;
                }
                else
                {
                    _RoundValue = 0;
                }
                AdjustSize();
                this.Invalidate();
            }
        }
        private void RoundedPanel_Resize(object sender, EventArgs e)
        {
            AdjustSize();
        }
        private void AdjustSize()
        {
            try
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, _RoundValue, _RoundValue));
                this.Invalidate();
            }
            catch (Exception)
            {
            }
        }
    
}
}
