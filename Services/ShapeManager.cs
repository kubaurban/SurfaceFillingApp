using Models;
using Services.Abstract;

namespace Services
{
    public class ShapeManager : IShapeManager
    {
        private readonly HashSet<Face> _faces;

        public ShapeManager()
        {
            _faces = new();
        }

        public void AddFace(Face face)
        {
            _faces.Add(face);
        }

        public IEnumerable<Face> GetAllFaces() => _faces.AsEnumerable();

        public IEnumerable<Edge> GetDistinctEdges() => _faces.SelectMany(x => x.Edges).ToHashSet(new EdgeComparator());
    }
}
