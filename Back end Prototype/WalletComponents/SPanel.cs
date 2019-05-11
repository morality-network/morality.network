using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalletComponents
{

    public class SPanel : Panel
    {
        //var color = Color.FromArgb(50, 50, 50);
        private Color color = Color.FromArgb(37, 37, 37);

        public SPanel()
        {
        }

        public SPanel(Color color)
        {
            this.color = color;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
           
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRoundedRectangle(new SolidBrush(color), 10, 10, this.Width - 20, this.Height - 30, 10);
            SolidBrush brush = new SolidBrush(
                color
                );
            g.FillRoundedRectangle(brush, 12, 12, this.Width - 22, this.Height - 32, 10);
            g.DrawRoundedRectangle(new Pen(ControlPaint.Light(color, 0.00f)), 12, 12, this.Width - 22, this.Height - 32, 10);
            g.FillRoundedRectangle(new SolidBrush(color), 12, 12 + ((this.Height - 32) / 2), this.Width - 21, (this.Height - 32) / 2, 10);
        }
    }
}
