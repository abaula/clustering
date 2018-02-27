using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Clustering.Clustering.Services;
using Clustering.WinApp.Properties;

namespace Clustering.WinApp
{
    public partial class MainForm : Form
    {
        private Color _imageColor;

        public MainForm()
        {
            InitializeComponent();
            _imageColor = Color.White;
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

        private Color GetMassLegendPanelPixelColor(double yValueShare)
        {
            var x = panMassLegend.ClientRectangle.Width / 2;
            var y = panMassLegend.Height * yValueShare;

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
            _imageColor = GetMassLegendPanelPixelColor((double)e.Y / panMassLegend.Height);
            panImage.Invalidate();
            panImage.Update();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog {FileName = Settings.Default.CsvFilePath};
            var result = dialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            var data = ReadCsvService.GetNodeData(dialog.FileName);
            var kruskalAlgoService = new KruskalAlgoService();
            var graph = kruskalAlgoService.BuildMinimumSpanningTree(data);


        }
    }
}
