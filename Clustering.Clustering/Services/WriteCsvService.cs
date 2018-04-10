using System.Collections.Generic;
using System.IO;
using Clustering.Clustering.Model;

namespace Clustering.Clustering.Services
{
    public static class WriteCsvService
    {
        public static void SaveNodeData(IEnumerable<ClusterHierarchyItem> clusters, string path)
        {
            if (File.Exists(path))
                File.Delete(path);

            using (var fs = File.Create(path))
            using (var wr = new StreamWriter(fs))
            {
                // Шапка
                wr.WriteLine("userId;x;y;flag;cluster");

                var clusterId = 0;

                foreach (var cluster in clusters)
                {
                    foreach (var vertex in cluster.Cluster.Graph.Vertices)
                    {
                        var data = vertex.Data;
                        wr.WriteLine($"{data.EmployeeId};{data.DataPoint.X:F};{data.DataPoint.Y:F};{(data.IsFired ? 1 : 0)};{clusterId}");
                    }

                    clusterId++;
                }

                wr.Flush();
                wr.Close();
                fs.Close();
            }
        }
    }
}
