﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace iw4x_launcher.UI
{
    class RadioButtonList : ListBox
    {
        Size s;
        public RadioButtonList()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
                s = RadioButtonRenderer.GetGlyphSize(
                    Graphics.FromHwnd(IntPtr.Zero), RadioButtonState.CheckedNormal);
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Color nColor = Color.ForestGreen;
            var text = (Items.Count > 0) ? GetItemText(Items[e.Index]) : Name;
            //if (Functions.Methods.VersionExists(text))
            //{
            //    nColor = Color.Green;
            //}
            //else
            //{
            //    nColor = ForeColor;
            //}
            Rectangle r = e.Bounds; Point p;
            var flags = TextFormatFlags.Default | TextFormatFlags.NoPrefix;
            var selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var state = selected ?
                (Enabled ? RadioButtonState.CheckedNormal :
                           RadioButtonState.CheckedDisabled) :
                (Enabled ? RadioButtonState.UncheckedNormal :
                           RadioButtonState.UncheckedDisabled);
            if (RightToLeft == System.Windows.Forms.RightToLeft.Yes)
            {
                p = new Point(r.Right - r.Height + (ItemHeight - s.Width) / 2,
                    r.Top + (ItemHeight - s.Height) / 2);
                r = new Rectangle(r.Left, r.Top, r.Width - r.Height, r.Height);
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            }
            else
            {
                p = new Point(r.Left + (ItemHeight - s.Width) / 2,
                r.Top + (ItemHeight - s.Height) / 2);
                r = new Rectangle(r.Left + r.Height, r.Top, r.Width - r.Height, r.Height);
            }
            var bc = selected ? (Enabled ? nColor :
                SystemColors.InactiveBorder) : BackColor;
            var fc = selected ? (Enabled ? SystemColors.HighlightText :
                SystemColors.GrayText) : ForeColor;
            using (var b = new SolidBrush(bc))
                e.Graphics.FillRectangle(b, e.Bounds);
            RadioButtonRenderer.DrawRadioButton(e.Graphics, p, state);
            TextRenderer.DrawText(e.Graphics, text, Font, r, fc, bc, flags);
            e.DrawFocusRectangle();
            base.OnDrawItem(e);
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override SelectionMode SelectionMode
        {
            get { return System.Windows.Forms.SelectionMode.One; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override int ItemHeight
        {
            get { return (this.Font.Height + 3); }
            set { }
        }
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DrawMode DrawMode
        {
            get { return base.DrawMode; }
            set { base.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed; }
        }
    }
}
