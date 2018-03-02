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
