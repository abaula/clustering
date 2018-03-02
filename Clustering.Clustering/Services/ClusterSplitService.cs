using System.Collections.Generic;
using System.Linq;
using Clustering.Clustering.Model;
using Clustering.Graph;

namespace Clustering.Clustering.Services
{
    public static class ClusterSplitService
    {
        public static (Cluster clusterA, Cluster clusterB) Split(Cluster cluster, long splitterEdgeId)
        {
            var splitter = cluster.Graph.GetEdge(splitterEdgeId);
            var graphA = CreateGraph(splitter.VertexA, splitter);
            var graphB = CreateGraph(splitter.VertexB, splitter);

            return (new Cluster(graphA), new Cluster(graphB));
        }

        private static UndirectedGraph<NodeData> CreateGraph(GVertex<NodeData> vertex, GEdge<NodeData> splitter)
        {
            var edges = GetAllEdgesFromVertex(vertex, splitter).ToArray();
            var graph = new UndirectedGraph<NodeData>();

            if (!edges.Any())
            {
                graph.AddVertex(new GVertex<NodeData>(vertex.Id, vertex.Data));
            }
            else
            {
                foreach (var edge in edges)
                    AddEdgeToGraph(edge, graph);
            }

            return graph;
        }

        private static void AddEdgeToGraph(GEdge<NodeData> edge, UndirectedGraph<NodeData> graph)
        {
            var vertexA = GetOrCreateVertex(edge.VertexA, graph);
            var vertexB = GetOrCreateVertex(edge.VertexB, graph);
            var newEdge = new GEdge<NodeData>(edge.Id, vertexA, vertexB, edge.Weight);
            vertexA.AddEdge(newEdge);
            vertexB.AddEdge(newEdge);
            graph.AddEdge(newEdge);
        }

        private static GVertex<NodeData> GetOrCreateVertex(GVertex<NodeData> vertex, UndirectedGraph<NodeData> graph)
        {
            var graphVertex = graph.GetVertex(vertex.Id);

            if (graphVertex == null)
            {
                graphVertex = new GVertex<NodeData>(vertex.Id, vertex.Data);
                graph.AddVertex(graphVertex);
            }

            return graphVertex;
        }

        private static IEnumerable<GEdge<NodeData>> GetAllEdgesFromVertex(GVertex<NodeData> vertex,
            GEdge<NodeData> splitter)
        {
            var result = new List<GEdge<NodeData>>();
            HandleVertex(vertex, splitter.GetAnotherVertex(vertex), result);

            return result;
        }

        private static void HandleVertex(GVertex<NodeData> vertex,
            GVertex<NodeData> previousVertex,
            List<GEdge<NodeData>> list)
        {
            foreach (var edge in vertex.Edges)
            {
                var nextVertex = edge.GetAnotherVertex(vertex);

                if (nextVertex.Id == previousVertex.Id)
                    continue;

                list.Add(edge);
                HandleVertex(nextVertex, vertex, list);
            }
        }
    }
}
