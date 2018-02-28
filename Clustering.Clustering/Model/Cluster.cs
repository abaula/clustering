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
        }

        public UndirectedGraph<NodeData> Graph { get; }
        public double Mass { get; }
        public int EdgesCount { get; }
    }
}
