using System.Linq;
using Clustering.Graph;

namespace Clustering.Clustering.Model
{
    public class Cluster
    {
        public Cluster(UndirectedGraph<NodeData> graph)
        {
            Graph = graph;
            Mass = Graph.Vertices.Count();
            EdgesCount = Graph.Edges.Count();
            MinDataPoint = new DataPoint(
                Graph.Vertices.Select(v => v.Data.DataPoint.X).Min(),
                Graph.Vertices.Select(v => v.Data.DataPoint.Y).Min());
            MaxDataPoint = new DataPoint(
                Graph.Vertices.Select(v => v.Data.DataPoint.X).Max(),
                Graph.Vertices.Select(v => v.Data.DataPoint.Y).Max());
        }

        public UndirectedGraph<NodeData> Graph { get; }
        public double Mass { get; }
        public int EdgesCount { get; }
        public DataPoint MinDataPoint { get; }
        public DataPoint MaxDataPoint { get; }
    }
}
