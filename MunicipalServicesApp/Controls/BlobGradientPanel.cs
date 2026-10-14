using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MunicipalServicesApp.Controls
{
    public class BlobGradientPanel : Panel
    {
        public Color GradientStart { get; set; } = Color.FromArgb(94, 53, 209);
        public Color GradientEnd { get; set; } = Color.FromArgb(179, 136, 255);

        public BlobGradientPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                      ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, Width, Height);
            if (Width > 0 && Height > 0)
            {
                using (var baseBrush = new LinearGradientBrush(rect, GradientStart, GradientEnd, LinearGradientMode.ForwardDiagonal))
                {
                    g.FillRectangle(baseBrush, rect);
                }

                DrawBlob(g, new Rectangle(-Width / 3, Height / 3, (int)(Width * 1.3), (int)(Height * 0.9)), Color.FromArgb(40, 255, 255, 255));
                DrawBlob(g, new Rectangle(Width / 4, -Height / 4, (int)(Width * 0.9), (int)(Height * 0.9)), Color.FromArgb(28, 255, 255, 255));
                DrawBlob(g, new Rectangle(-Width / 5, -Height / 6, (int)(Width * 0.7), (int)(Height * 0.6)), Color.FromArgb(35, 60, 20, 130));
            }

            base.OnPaint(e);
        }

        private static void DrawBlob(Graphics g, Rectangle bounds, Color color)
        {
            using (var brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, bounds);
            }
        }
    }
}
