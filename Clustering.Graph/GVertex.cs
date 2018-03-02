using System.Collections.Generic;

namespace Clustering.Graph
{
    public class GVertex<TData> : GObject
    {
        private readonly Dictionary<long, GEdge<TData>> _edges;

        public GVertex(long id, TData data)
            : base(id)
        {
            Data = data;
            _edges = new Dictionary<long, GEdge<TData>>();
        }

        public TData Data { get; }
        public IEnumerable<GEdge<TData>> Edges => _edges.Values;

        public void AddEdge(GEdge<TData> edge)
        {
            _edges.Add(edge.Id, edge);
        }

        public void RemoveEdge(GEdge<TData> edge)
        {
            _edges.Remove(edge.Id);
        }
    }
}
