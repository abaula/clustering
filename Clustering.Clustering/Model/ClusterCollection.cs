using System.Collections.Generic;
using System.Linq;
using Clustering.Clustering.Services;

namespace Clustering.Clustering.Model
{
    public class ClusterCollection
    {
        public ClusterCollection()
        {
            Clusters = new List<Cluster>();
            MinDataPoint = new DataPoint(double.MaxValue, double.MaxValue);
            MaxDataPoint = new DataPoint(double.MinValue, double.MinValue);
        }

        public ICollection<Cluster> Clusters { get; }
        public DataPoint MinDataPoint { get; }
        public DataPoint MaxDataPoint { get; }
        public double Mass { get; private set; }
        public int EdgesCount { get; private set; }
        public double MinMass { get; private set; }
        public double MaxMass { get; private set; }

        public void AddClusterFromData(IEnumerable<NodeData> data)
        {
            var kruskalAlgoService = new KruskalAlgoService();
            var graph = kruskalAlgoService.BuildMinimumSpanningTree(data);
            Clusters.Add(new Cluster(graph));
            UpdateProperties();
        }

        private void RemoveLongestEdges(int edgesToRemove)
        {

        }

        private void UpdateProperties()
        {
            // Update Min.
            MinDataPoint.X = Clusters.SelectMany(c => c.Graph.Vertices.Select(v => v.Data.DataPoint.X)).Min();
            MinDataPoint.Y = Clusters.SelectMany(c => c.Graph.Vertices.Select(v => v.Data.DataPoint.Y)).Min();

            // Update Max.
            MaxDataPoint.X = Clusters.SelectMany(c => c.Graph.Vertices.Select(v => v.Data.DataPoint.X)).Max();
            MaxDataPoint.Y = Clusters.SelectMany(c => c.Graph.Vertices.Select(v => v.Data.DataPoint.Y)).Max();

            // Update Mass.
            Mass = Clusters.Sum(c => c.Mass);
            MinMass = Clusters.Min(c => c.Mass);
            MaxMass = Clusters.Max(c => c.Mass);

            // Update counters.
            EdgesCount = Clusters.Sum(c => c.EdgesCount);
        }
    }
}
