using Models;
using System.Numerics;

namespace Services.Abstract
{
    public interface IShapeManager
    {
        IEnumerable<Face> GetAllFaces();

        IEnumerable<Edge> GetDistinctEdges();

        void AddFace(Face face);
        void ScaleSurface(int scale);
        void MoveSurface(Vector3 move);
    }
}