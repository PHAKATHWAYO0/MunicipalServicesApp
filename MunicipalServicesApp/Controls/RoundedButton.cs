using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MunicipalServicesApp.Controls
{
    /// <summary>
    /// A Button with rounded corners and an optional two-colour gradient
    /// fill. Used throughout the app's purple theme to give buttons a
    /// friendlier, more modern look than the default square WinForms button.
    /// Set <see cref="UseGradient"/> to false for a flat "outline" style
    /// button (e.g. secondary actions).
    /// </summary>
    public class RoundedButton : Button
    {
        public int CornerRadius { get; set; } = 14;
        public Color GradientStart { get; set; } = Color.FromArgb(124, 77, 255);
        public Color GradientEnd { get; set; } = Color.FromArgb(94, 53, 209);
        public bool UseGradient { get; set; } = true;

        public RoundedButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                      ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.White;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            Cursor = Cursors.Hand;
        }

        private static GraphicsPath GetRoundedRectPath(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            if (d > bounds.Width) d = bounds.Width;
            if (d > bounds.Height) d = bounds.Height;

            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);

            // Paint the parent's background behind the button first so the
            // corners "outside" the rounded rectangle look transparent
            // instead of showing square white corners.
            using (var backBrush = new SolidBrush(Parent != null ? Parent.BackColor : Color.White))
            {
                g.FillRectangle(backBrush, ClientRectangle);
            }

            using (var path = GetRoundedRectPath(rect, CornerRadius))
            {
                if (!Enabled)
                {
                    using (var disabledBrush = new SolidBrush(Color.FromArgb(228, 224, 240)))
                    {
                        g.FillPath(disabledBrush, path);
                    }
                    using (var disabledPen = new Pen(Color.FromArgb(205, 198, 225)))
                    {
                        g.DrawPath(disabledPen, path);
                    }
                }
                else if (UseGradient)
                {
                    using (var brush = new LinearGradientBrush(rect, GradientStart, GradientEnd, LinearGradientMode.ForwardDiagonal))
                    {
                        g.FillPath(brush, path);
                    }
                }
                else
                {
                    using (var brush = new SolidBrush(BackColor))
                    {
                        g.FillPath(brush, path);
                    }
                    using (var pen = new Pen(GradientEnd, 1.5f))
                    {
                        g.DrawPath(pen, path);
                    }
                }

                Color textColor = Enabled ? ForeColor : Color.FromArgb(150, 140, 170);
                TextRenderer.DrawText(g, Text, Font, rect, textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            }
        }
    }
}
