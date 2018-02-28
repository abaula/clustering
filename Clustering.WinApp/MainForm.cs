using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Clustering.Clustering.Model;
using Clustering.Clustering.Services;
using Clustering.WinApp.Properties;

namespace Clustering.WinApp
{
    public partial class MainForm : Form
    {
        private readonly ClusterCollection _clusterCollection;
        private readonly Color _colorFrom;
        private readonly Color _colorTo;

        public MainForm()
        {
            InitializeComponent();
            _clusterCollection = new ClusterCollection();
            _colorFrom = Color.DeepSkyBlue;
            _colorTo = Color.Red;
        }

        private void panMassLegend_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(panMassLegend.ClientRectangle, _colorTo, _colorFrom, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panMassLegend.ClientRectangle);
            }
        }

        private void panImage_Paint(object sender, PaintEventArgs e)
        {
            const int padding = 10;
            var width = _clusterCollection.MaxDataPoint.X - _clusterCollection.MinDataPoint.X;
            var height = _clusterCollection.MaxDataPoint.Y - _clusterCollection.MinDataPoint.Y;
            var scaleX = (panImage.ClientRectangle.Width - padding * 2) / width;
            var offsetX = _clusterCollection.MinDataPoint.X * scaleX - padding;
            var scaleY = (panImage.ClientRectangle.Height - padding * 2) / height;
            var offsetY = _clusterCollection.MinDataPoint.Y * scaleY - padding;
            var gradient = CreateGradientForClusters(_clusterCollection.Clusters);

            foreach (var cluster in _clusterCollection.Clusters)
            {
                // Choose a color for the cluster.
                var color = gradient[(int)cluster.Mass - 1];

                // Draw.
                using (var brush = new SolidBrush(color))
                {
                    // ... edges
                    using (var pen = new Pen(brush, 1))
                    {
                        foreach (var edge in cluster.Graph.Edges)
                        {
                            var xA = Convert.ToSingle(edge.VertexA.Data.DataPoint.X * scaleX - offsetX);
                            var yA = Convert.ToSingle(edge.VertexA.Data.DataPoint.Y * scaleY - offsetY);
                            var xB = Convert.ToSingle(edge.VertexB.Data.DataPoint.X * scaleX - offsetX);
                            var yB = Convert.ToSingle(edge.VertexB.Data.DataPoint.Y * scaleY - offsetY);
                            e.Graphics.DrawLine(pen, xA, yA, xB, yB);
                        }
                    }

                    // ... vertices
                    foreach (var vertex in cluster.Graph.Vertices)
                    {
                        var x = Convert.ToSingle(vertex.Data.DataPoint.X * scaleX - offsetX);
                        var y = Convert.ToSingle(vertex.Data.DataPoint.Y * scaleY - offsetY);
                        e.Graphics.FillRectangle(brush, x-1, y-1, 3, 3);
                    }
                }
            }
        }

        private Color[] CreateGradientForClusters(ICollection<Cluster> clusters)
        {
            return clusters.Count > 0
                ? CreateGradient((int) clusters.Max(c => c.Mass))
                : new [] {_colorFrom};
        }

        private Color[] CreateGradient(int size)
        {
            var result = new Color[size];

            int rMin = _colorFrom.R;
            int rMax = _colorTo.R;
            int gMin = _colorFrom.G;
            int gMax = _colorTo.G;
            int bMin = _colorFrom.B;
            int bMax = _colorTo.B;

            for (var i = 0; i < size; i++)
            {
                var rAverage = rMin + (rMax - rMin) * i / size;
                var gAverage = gMin + (gMax - gMin) * i / size;
                var bAverage = bMin + (bMax - bMin) * i / size;
                result[i] = Color.FromArgb(rAverage, gAverage, bAverage);
            }

            return result;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            panMassLegend.Invalidate();
            panMassLegend.Update();

            panImage.Invalidate();
            panImage.Update();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog {FileName = Settings.Default.CsvFilePath, CheckFileExists = true};
            var result = dialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            var data = ReadCsvService.GetNodeData(dialog.FileName);
            _clusterCollection.AddClusterFromData(data);
            lblMaxMass.Text = _clusterCollection.MaxMass.ToString("F");
            lblMinMass.Text = _clusterCollection.MinMass.ToString("F");
            trbClusterDivider.Maximum = _clusterCollection.EdgesCount;

            panMassLegend.Invalidate();
            panMassLegend.Update();
            panImage.Invalidate();
            panImage.Update();
        }

        private void trbClusterDivider_Scroll(object sender, EventArgs e)
        {

        }
    }
}
