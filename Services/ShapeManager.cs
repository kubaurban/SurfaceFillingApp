using Models;
using Services.Abstract;

namespace Services
{
    public class ShapeManager : IShapeManager
    {
        HashSet<Face> _faces;

        public ShapeManager()
        {
            _faces = new();
        }

        public void AddFace(Face face)
        {
            _faces.Add(face);
        }

        public IEnumerable<Face> GetAllFaces() => _faces.AsEnumerable();
    }
}
