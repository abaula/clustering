
namespace Clustering.Clustering.Model
{
    public class ClusterHierarchyItem
    {
        public int Level { get; set; }
        public double CuttingEdgeWeight { get; set; }
        public ClusterHierarchyItem Parent { get; set; }
        public ClusterHierarchyItem[] Children { get; set; }
        public Cluster Cluster { get; set; }
    }
}
