using System.Collections.Generic;
using System.Linq;
using Clustering.Clustering.Model;

namespace Clustering.Clustering.Services
{
    public class ClusterHierarchyBuildService
    {
        public ClusterHierarchy Build(IEnumerable<NodeData> data)
        {
            var hierarchy = new ClusterHierarchy
            {
                Root = CreateRoot(data)
            };

            var i = 0;

            while (true)
            {
                var items = hierarchy.GetClusterItemsForLevel(i);

                // Условие выхода из цикла - все кластеры нижнего уровня состоят из одной вершины - не имеют рёбер.
                if (items.All(it => it.Cluster.EdgesCount == 0))
                    break;

                (var hierarchyItem, var edge) = FindMaximumEdgeService.FindWithMaximumEdgeWeight(items);
                (var clusterA, var clusterB) = ClusterSplitService.Split(hierarchyItem.Cluster, edge.Id);
                AddChildren(hierarchyItem, i + 1, edge.Weight, clusterA, clusterB);
                i++;
            }

            return hierarchy;
        }

        private static void AddChildren(ClusterHierarchyItem parent, int level, double cuttingEdgeWeight, Cluster clusterA, Cluster clusterB)
        {
            var childA = new ClusterHierarchyItem
            {
                Level = level,
                CuttingEdgeWeight = cuttingEdgeWeight,
                Parent = parent,
                Cluster = clusterA,
                Children = null
            };
            var childB = new ClusterHierarchyItem
            {
                Level = level,
                CuttingEdgeWeight = cuttingEdgeWeight,
                Parent = parent,
                Cluster = clusterB,
                Children = null
            };

            parent.Children = new[] { childA, childB };
        }

        private ClusterHierarchyItem CreateRoot(IEnumerable<NodeData> data)
        {
            var kruskalAlgoService = new KruskalAlgoService();
            var graph = kruskalAlgoService.BuildMinimumSpanningTree(data);

            return new ClusterHierarchyItem
            {
                Level = 0,
                CuttingEdgeWeight = 0,
                Parent = null,
                Children = null,
                Cluster = new Cluster(graph)
            };
        }
    }
}
