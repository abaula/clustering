using System.Collections.Generic;

namespace Clustering.Clustering.Model
{
    public class ClusterCollection
    {
        public ClusterCollection()
        {
            Clusters = new List<Cluster>();
        }

        public ICollection<Cluster> Clusters { get; }
    }
}
