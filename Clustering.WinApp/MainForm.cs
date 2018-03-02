using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Clustering.Clustering.Model;
using Clustering.Clustering.Services;
using Clustering.WinApp.Properties;

namespace Clustering.WinApp
{
    public partial class MainForm : Form
    {
        private readonly Color _colorFrom;
        private readonly Color _colorTo;
        private ClusterHierarchy _clusterHierarchy;
        private int _currentClusterLevel;

        public MainForm()
        {
            InitializeComponent();
            _colorFrom = Color.Gray;
            _colorTo = Color.White;
            _currentClusterLevel = 0;
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
            if (_clusterHierarchy?.Root?.Cluster == null)
                return;

            var rootCluster = _clusterHierarchy.Root.Cluster;
            const int padding = 10;

            var width = rootCluster.MaxDataPoint.X - rootCluster.MinDataPoint.X;
            var height = rootCluster.MaxDataPoint.Y - rootCluster.MinDataPoint.Y;
            var scaleX = (panImage.ClientRectangle.Width - padding * 2) / width;
            var offsetX = rootCluster.MinDataPoint.X * scaleX - padding;
            var scaleY = (panImage.ClientRectangle.Height - padding * 2) / height;
            var offsetY = rootCluster.MinDataPoint.Y * scaleY - padding;
            var gradient = CreateGradient(rootCluster);
            var items = _clusterHierarchy.GetClusterItemsForLevel(_currentClusterLevel);

            foreach (var item in items)
            {
                // Choose a color for the cluster.
                var color = gradient[(int)item.Cluster.Mass - 1];

                // Draw.
                using (var brush = new SolidBrush(color))
                {
                    // ... edges
                    using (var pen = new Pen(brush, 1))
                    {
                        foreach (var edge in item.Cluster.Graph.Edges)
                        {
                            var xA = Convert.ToSingle(edge.VertexA.Data.DataPoint.X * scaleX - offsetX);
                            var yA = Convert.ToSingle(edge.VertexA.Data.DataPoint.Y * scaleY - offsetY);
                            var xB = Convert.ToSingle(edge.VertexB.Data.DataPoint.X * scaleX - offsetX);
                            var yB = Convert.ToSingle(edge.VertexB.Data.DataPoint.Y * scaleY - offsetY);
                            e.Graphics.DrawLine(pen, xA, yA, xB, yB);
                        }
                    }

                    // ... vertices
                    foreach (var vertex in item.Cluster.Graph.Vertices)
                    {
                        var x = Convert.ToSingle(vertex.Data.DataPoint.X * scaleX - offsetX);
                        var y = Convert.ToSingle(vertex.Data.DataPoint.Y * scaleY - offsetY);
                        e.Graphics.FillRectangle(brush, x-1, y-1, 3, 3);
                    }
                }
            }
        }

        private Color[] CreateGradient(Cluster root)
        {
            return root != null
                ? CreateGradient((int)root.Mass)
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
            var clusterHierarchyBuildService = new ClusterHierarchyBuildService();
            _clusterHierarchy = clusterHierarchyBuildService.Build(data);
            lblMaxMass.Text = _clusterHierarchy.Root.Cluster.Mass.ToString("F1");
            lblMinMass.Text = (1.0).ToString("F1");
            trbClusterDivider.Maximum = _clusterHierarchy.Root.Cluster.EdgesCount;

            panMassLegend.Invalidate();
            panMassLegend.Update();
            panImage.Invalidate();
            panImage.Update();
        }

        private void trbClusterDivider_Scroll(object sender, EventArgs e)
        {
            _currentClusterLevel = trbClusterDivider.Value;
            panImage.Invalidate();
            panImage.Update();
        }
    }
}
