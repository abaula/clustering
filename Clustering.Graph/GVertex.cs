using System.Collections.Generic;

namespace Clustering.Graph
{
    public class GVertex<TData> : GObject
    {
        public GVertex(long id, TData data)
            : base(id)
        {
            Data = data;
            Edges = new Dictionary<long, GEdge<TData>>();
        }

        public TData Data { get; }
        public Dictionary<long, GEdge<TData>> Edges { get; }

        public void AddEdge(GEdge<TData> edge)
        {
            Edges.Add(edge.Id, edge);
        }

        public void RemoveEdge(GEdge<TData> edge)
        {
            Edges.Remove(edge.Id);
        }
    }
}
