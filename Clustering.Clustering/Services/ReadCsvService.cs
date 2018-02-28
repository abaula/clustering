using System;
using System.Collections.Generic;
using System.IO;
using Clustering.Clustering.Model;

namespace Clustering.Clustering.Services
{
    public static class ReadCsvService
    {
        public static IEnumerable<NodeData> GetNodeData(string path)
        {
            var result = new List<NodeData>();

            var buffer = File.ReadAllLines(path);

            for (var i = 1; i < buffer.Length; i++)
            {
                var arr = buffer[i].Split(';');

                result.Add(new NodeData
                {
                    EmployeeId = arr[0],
                    DataPoint = new DataPoint(Convert.ToDouble(arr[1]), Convert.ToDouble(arr[2])),
                    IsFired = Convert.ToInt32(arr[3]) == 1
                });
            }

            return result;
        }
    }
}
