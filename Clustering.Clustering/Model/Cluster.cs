using Clustering.Graph;

namespace Clustering.Clustering.Model
{
    public class Cluster
    {
        public Cluster()
        {
            Graph = new UndirectedGraph<NodeData>();
        }

        public UndirectedGraph<NodeData> Graph { get; }
        public double GraphMass { get; }
    }
}
