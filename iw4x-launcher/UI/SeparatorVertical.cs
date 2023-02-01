using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iw4x_launcher.UI
{
    internal class SeparatorVertical : Panel
    {
        public SeparatorVertical()
        {
            this.DoubleBuffered = true;
            this.Width = 1;
            this.Resize += Separator_Resize;
            this.BackColor = Color.White;
        }
        private void Separator_Resize(object sender, EventArgs e)
        {
            if (Width > 1)
            {
                this.Width = 1;
            }
            this.Invalidate();
        }

    }

}
