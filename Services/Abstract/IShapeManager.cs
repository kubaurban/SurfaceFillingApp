using Models;

namespace Services.Abstract
{
    public interface IShapeManager
    {
        IEnumerable<Face> GetAllFaces();

        IEnumerable<Edge> GetDistinctEdges();

        void AddFace(Face face);
    }
}