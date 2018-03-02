
namespace Clustering.Graph
{
    public class GEdge<TVertexData> : GObject
    {
        public GEdge(long id, GVertex<TVertexData> vertexA, GVertex<TVertexData> vertexB, double weight) : base(id)
        {
            VertexA = vertexA;
            VertexB = vertexB;
            Weight = weight;
        }

        public GVertex<TVertexData> VertexA { get; }
        public GVertex<TVertexData> VertexB { get; }
        public double Weight { get; }

        public GVertex<TVertexData> GetAnotherVertex(GVertex<TVertexData> v)
        {
            return v.Id == VertexA.Id ? VertexB : VertexA;
        }
    }
}
