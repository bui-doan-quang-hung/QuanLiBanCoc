using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QuanLiBanCoc
{
    public class LoginPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a rounded rectangle path
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(0, 0, 10, 10, 180, 90);
            roundedRect.AddArc(Width - 11, 0, 10, 10, 270, 90);
            roundedRect.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            roundedRect.AddArc(0, Height - 11, 10, 10, 90, 90);
            roundedRect.CloseFigure();

            // Set the Panel control's background to white and apply the rounded rectangle path
            this.BackColor = Color.White;
            this.Region = new Region(roundedRect);
        }
    }
}
