
namespace Clustering.Graph
{
    public class GEdge<TVertexData> : GObject
    {
        public GEdge(long id) : base(id)
        {
        }

        public GVertex<TVertexData> VertexA { get; set; }
        public GVertex<TVertexData> VertexB { get; set; }
        public double Weight { get; set; }

        public GVertex<TVertexData> GetAnotherVertex(GVertex<TVertexData> v)
        {
            return v.Id == VertexA.Id ? VertexB : VertexA;
        }
    }
}
