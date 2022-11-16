using System.Numerics;
using Models.Domain;

namespace Models.Abstract
{
    public interface IShapeManager
    {
        IEnumerable<Face> GetAllFaces();

        IEnumerable<Edge> GetDistinctEdges();

        void AddFace(Face face);
        void RemoveAll();
        void ScaleSurface(int scale);
        void MoveSurface(Vector3 move);
    }
}