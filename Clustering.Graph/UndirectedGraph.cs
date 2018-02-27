using System.Collections.Generic;

namespace Clustering.Graph
{
    public class UndirectedGraph<TVertexData>
    {
        private readonly Dictionary<long, GVertex<TVertexData>> _vertices;
        private readonly Dictionary<long, GEdge<TVertexData>> _edges;

        public UndirectedGraph()
        {
            _vertices = new Dictionary<long, GVertex<TVertexData>>();
            _edges = new Dictionary<long, GEdge<TVertexData>>();
        }

        public void AddVertex(GVertex<TVertexData> vertex)
        {
            _vertices.Add(vertex.Id, vertex);
        }

        public void AddEdge(GEdge<TVertexData> edge)
        {
            _edges.Add(edge.Id, edge);
        }

        public GVertex<TVertexData> GetVertex(int vertexId)
        {
            return _vertices.ContainsKey(vertexId)
                ? _vertices[vertexId]
                : null;
        }

        public GEdge<TVertexData> GetEdge(int edgeId)
        {
            return _edges.ContainsKey(edgeId)
                ? _edges[edgeId]
                : null;
        }

        public bool HasVertex(GVertex<TVertexData> vertex) => _vertices.ContainsKey(vertex.Id);
    }
}
