using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iw4x_launcher.UI
{
    internal class RPanel : Panel
    {
        public RPanel()
        {
            this.DoubleBuffered = true;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, _RoundValue, _RoundValue));


            this.Resize += RoundedPanel_Resize;
            this.Paint += RoundedPanel_Paint;

            this.MouseEnter += RoundedPanel_MouseEnter;
            this.MouseLeave += RoundedPanel_MouseLeave;
            this.MouseClick += RoundedPanel_MouseClick;

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
        public void WireControlsHover(Control ctrl)
        {
            foreach (Control c in Controls)
            {
                c.MouseEnter += RoundedPanel_MouseEnter;
                c.MouseLeave += RoundedPanel_MouseLeave;
                if (c.HasChildren)
                {
                    WireControlsClick(c);
                }
            }
        }
        private void SetHeader()
        {
            //Panel p = new Panel();
            //p.BackColor = Color.Gray;
            //p.Size = new Size(this.Width, 35);
            //this.Controls.Add(p);


        }
        private Boolean _ShowHeader = false;
        [Description("Panel Header"), Category("Custom")]
        public Boolean ShowHeader
        {
            get { return _ShowHeader; }
            set
            {
                _ShowHeader = value;
                AdjustSize();
                this.Invalidate();
            }
        }
        public void WireControlsClick(Control ctrl)
        {
            foreach (Control c in Controls)
            {
                c.MouseClick += RoundedPanel_MouseClick;
                if (c.HasChildren)
                {
                    WireControlsClick(c);
                }
            }
        }

        private Color _OriginalBackColor;

        private Color _BorderColor = Color.White;
        [Description("Change BorderColor"), Category("Custom")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; this.Invalidate(); }
        }
        private Color _HoverColor;
        [Description("Change HoverColor"), Category("Custom")]
        public Color HoverColor
        {
            get { return _HoverColor; }
            set { _HoverColor = value; this.Invalidate(); }
        }
        private int _BorderSize = 0;
        [Description("Change BorderSize"), Category("Custom")]
        public int BorderSize
        {
            get { return _BorderSize; }
            set
            {
                int control = (Width <= Height) ? Width / 3 : Height / 3;

                if (value < 0) { value = 0; }
                else if (value > control) { value = control; }

                _BorderSize = value;
                this.Invalidate();
            }
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
        public void RoundedPanel_Load()
        {

        }
        public void RoundedPanel_MouseClick(object sender, EventArgs e)
        {

        }
        public void RoundedPanel_MouseEnter(object sender, EventArgs e)
        {
            if (HoverColor != Color.Empty)
            {
                if (_OriginalBackColor == Color.Empty)
                {
                    _OriginalBackColor = BackColor;
                }
                BackColor = HoverColor;
                this.Invalidate();
            }
        }
        public void RoundedPanel_MouseLeave(object sender, EventArgs e)
        {
            if (HoverColor != Color.Empty)
            {
                BackColor = _OriginalBackColor;
                this.Invalidate();
            }
        }
        private void RoundedPanel_Resize(object sender, EventArgs e)
        {
            AdjustSize();
        }
        private void RoundedPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRegion(
                    new SolidBrush(_BorderColor),
                    Region.FromHrgn(Common.CreateRoundRectangleRegion(
                        1,
                        1,
                        Width - 1,
                        Height - 1,
                        _RoundValue, _RoundValue
                        )));

            e.Graphics.FillRegion(
                    new SolidBrush(BackColor),
                    Region.FromHrgn(Common.CreateRoundRectangleRegion(
                        _BorderSize + 1,
                        _BorderSize + 1,
                        Width - _BorderSize - 1,
                        Height - _BorderSize - 1,
                        _RoundValue,
                        _RoundValue
                        )));
            if (_ShowHeader)
            {
                e.Graphics.FillRegion(
                   new SolidBrush(Color.DimGray),
                   Region.FromHrgn(Common.CreateRoundRectangleRegion(
                       _BorderSize - 10,
                       _BorderSize - 1,
                       Width - _BorderSize - 0,
                       50,
                       _RoundValue,
                       0
                       )));


            }
        }
    }
}
