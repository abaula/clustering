using System.Collections.Generic;
using Clustering.Clustering.Helpers;
using Clustering.Clustering.Model;

namespace Clustering.Clustering.Services
{
    public static class FindMaximumEdgeService
    {
        public static (ClusterHierarchyItem hierarchyItem, long edgeId)
            FindWithMaximumEdgeWeight(IEnumerable<ClusterHierarchyItem> items)
        {
            ClusterHierarchyItem maxItem = null;
            long maxEdgeId = 0;
            var maxEdgeWeight = double.MinValue;

            foreach (var item in items)
            {
                foreach (var edge in item.Cluster.Graph.Edges)
                {
                    if (maxItem == null)
                        maxItem = item;

                    if (maxEdgeWeight < edge.Weight
                        // При совпадении весов рёбер в нескольких кластерах - выбирать кластер с наименьшим весом.
                        || DoubleEqualityHelper.Equal(maxEdgeWeight, edge.Weight)
                        && item.Cluster.Mass < maxItem.Cluster.Mass)
                    {
                        maxItem = item;
                        maxEdgeWeight = edge.Weight;
                        maxEdgeId = edge.Id;
                    }
                }
            }

            return (maxItem, maxEdgeId);
        }
    }
}
