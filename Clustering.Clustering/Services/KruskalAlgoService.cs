using System.Collections.Generic;
using System.Linq;
using Clustering.Clustering.Model;
using Clustering.Graph;

namespace Clustering.Clustering.Services
{
    public class KruskalAlgoService
    {
        private VerticesComponentsService _verticesComponentsService;

        public UndirectedGraph<NodeData> BuildMinimumSpanningTree(NodeData[] data)
        {
            var vertices = BuildVertices(data);
            _verticesComponentsService = new VerticesComponentsService(vertices.Length);
            var edges = BuildEdges(vertices).OrderBy(e => e.Weight).ToArray();
            var graph = new UndirectedGraph<NodeData>();

            foreach (var edge in edges)
            {
                if (_verticesComponentsService.HasTheSameComponents(edge))
                    continue;

                AddEdgeToGraph(edge, graph);
                _verticesComponentsService.UpdateComponents(edge);
            }

            return graph;
        }

        private void AddEdgeToGraph(GEdge<NodeData> edge, UndirectedGraph<NodeData> graph)
        {
            if(!graph.HasVertex(edge.VertexA))
                graph.AddVertex(edge.VertexA);

            if(!graph.HasVertex(edge.VertexB))
                graph.AddVertex(edge.VertexB);

            graph.AddEdge(edge);
        }

        private GVertex<NodeData>[] BuildVertices(NodeData[] data)
        {
            return data
                .Select((d, i) => new GVertex<NodeData>(i, d))
                .ToArray();
        }

        private GEdge<NodeData>[] BuildEdges(GVertex<NodeData>[] data)
        {
            var result = new List<GEdge<NodeData>>();
            var cnt = 0;

            for(var i = 0; i < data.Length; i++)
            for(var j = 0; j < data.Length; j++)
            {
                if (i == j)
                    continue;

                var edge = new GEdge<NodeData>(cnt++)
                {
                    VertexA = data[i],
                    VertexB = data[j],
                    Weight = data[i].Data.Point.GetDistance(data[j].Data.Point)
                };

                result.Add(edge);
            }

            return result.ToArray();
        }
    }
}
