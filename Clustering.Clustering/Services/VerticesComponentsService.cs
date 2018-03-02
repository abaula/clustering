using Clustering.Clustering.Model;
using Clustering.Graph;

namespace Clustering.Clustering.Services
{
    public class VerticesComponentsService
    {
        private readonly int[] _verticesComponents;

        public VerticesComponentsService(int numberOfVertices)
        {
            _verticesComponents = new int[numberOfVertices];

            for (var i = 0; i < numberOfVertices; i++)
                _verticesComponents[i] = i;
        }

        public bool HasTheSameComponents(GEdge<NodeData> edge)
        {
            var vertAComponent = _verticesComponents[edge.VertexA.Id];
            var vertBComponent = _verticesComponents[edge.VertexB.Id];

            return vertAComponent == vertBComponent;
        }

        public void UpdateComponents(GEdge<NodeData> edge)
        {
            var vertAComponent = _verticesComponents[edge.VertexA.Id];
            var vertBComponent = _verticesComponents[edge.VertexB.Id];

            // Присваиваем наименьший номер компонента, просто для красоты - на алгоритм это не влияет.
            if (vertAComponent < vertBComponent)
                SwitchComponent(vertBComponent, vertAComponent);
            else
                SwitchComponent(vertAComponent, vertBComponent);
        }

        private void SwitchComponent(int from, int to)
        {
            for (var i = 0; i < _verticesComponents.Length; i++)
            {
                if (_verticesComponents[i] == from)
                    _verticesComponents[i] = to;
            }
        }
    }
}
