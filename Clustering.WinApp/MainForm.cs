using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Clustering.Clustering.Model;
using Clustering.Clustering.Services;
using Clustering.WinApp.Properties;

namespace Clustering.WinApp
{
    public partial class MainForm : Form
    {
        private ClusterHierarchy _clusterHierarchy;
        private int _currentClusterLevel;

        public MainForm()
        {
            InitializeComponent();
            _currentClusterLevel = 0;
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
            var items = _clusterHierarchy.GetClusterItemsForLevel(_currentClusterLevel)
                .OrderByDescending(it => it.Cluster.Mass);

            var clusterNumber = 1;

            foreach (var item in items)
            {
                // Choose a color for the cluster.
                var color = GetRainbowColor(clusterNumber++);

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

        private Color GetRainbowColor(int number)
        {
            switch (number)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Orange;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.Green;
                case 5:
                    return Color.LightSkyBlue;
                case 6:
                    return Color.Blue;
                case 7:
                    return Color.Purple;
                default:
                    return Color.LightGray;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
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
            trbClusterDivider.Maximum = _clusterHierarchy.Root.Cluster.EdgesCount;

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
