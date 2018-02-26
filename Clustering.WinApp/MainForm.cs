using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clustering.WinApp
{
    public partial class MainForm : Form
    {
        private Color _imageColor;
        private int _minY;
        private int _maxY;

        public MainForm()
        {
            InitializeComponent();
            _imageColor = Color.White;
            _minY = 0;
            _maxY = 500;
        }

        private void panMassLegend_Paint(object sender, PaintEventArgs e)
        {
            var colorFrom = Color.Red;
            var colorTo = Color.DeepSkyBlue;
            using (var brush = new LinearGradientBrush(panMassLegend.ClientRectangle, colorFrom, colorTo, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panMassLegend.ClientRectangle);
            }
        }

        private void panImage_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new SolidBrush(_imageColor))
            {
                e.Graphics.FillRectangle(brush, panImage.ClientRectangle);
            }
        }

        private Color GetPixelColor(int yValue, int yFrom, int yTo)
        {
            var x = panMassLegend.ClientRectangle.Width / 2;
            var height = yTo - yFrom;
            var y = panMassLegend.Height * ((double)yValue / height);

            var screenCoords = panMassLegend.PointToScreen(new Point(x, (int)y));
            return Win32.GetPixelColor(screenCoords.X, screenCoords.Y);
        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            panMassLegend.Invalidate();
            panMassLegend.Update();
        }

        private void panMassLegend_MouseClick(object sender, MouseEventArgs e)
        {
            var y = _maxY * ((double)e.Y / panMassLegend.Height);
            _imageColor = GetPixelColor((int)y, _minY, _maxY);
            panImage.Invalidate();
            panImage.Update();
        }
    }
}
