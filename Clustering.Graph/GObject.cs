
namespace Clustering.Graph
{
    public abstract class GObject
    {
        protected GObject(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
