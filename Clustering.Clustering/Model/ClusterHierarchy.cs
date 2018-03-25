using System;
using System.Collections.Generic;
using System.Linq;

namespace Clustering.Clustering.Model
{
    public class ClusterHierarchy
    {
        public ClusterHierarchyItem Root { get; set; }

        /// <summary>
        /// Выбирает листовые кластеры не ниже указанного уровня.
        /// </summary>
        public ClusterHierarchyItem[] GetClusterItemsForLevel(int level)
        {
            var list = new List<ClusterHierarchyItem>();
            HandleItem(Root, level, list);
            return list.ToArray();
        }

        /// <summary>
        /// Возвращает самый нижний уровень, у которого вес больше или равен указанному.
        /// </summary>
        public int GetMaxClusterLevelForCuttingEdgeWeight(double weight)
        {
            return HandleItem(Root, weight);
        }

        private int HandleItem(ClusterHierarchyItem item, double weight)
        {
            if (item.Children == null
                || !item.Children.Any()
                || item.Children.Any(ch => ch.CuttingEdgeWeight < weight))
            {
                return item.Level;
            }

            var level = int.MinValue;

            foreach (var child in item.Children)
                level = Math.Max(level, HandleItem(child, weight));

            return level;
        }

        private void HandleItem(ClusterHierarchyItem item, int level, List<ClusterHierarchyItem> list)
        {
            if (item.Children == null
                || !item.Children.Any()
                // Пояснение - кластеры всегда разбиваются на 2 потомка с одинаковым значением уровня.
                || item.Children.Any(it => it.Level > level))
            {
                list.Add(item);
                return;
            }

            foreach (var child in item.Children)
                HandleItem(child, level, list);
        }
    }
}
