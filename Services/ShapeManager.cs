using Models;
using Services.Abstract;
using System.Numerics;

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

        public void ScaleSurface(int scaleWidth, int scaleHeight)
        {
            foreach (var uv in GetDistinctEdges())
            {
                uv.U = new(uv.U.X * scaleWidth, uv.U.Y * scaleHeight, uv.U.Z, uv.U.NormalVector);
                uv.V = new(uv.V.X * scaleWidth, uv.V.Y * scaleHeight, uv.V.Z, uv.V.NormalVector);
            }
        }

        public void MoveSurface(Vector3 move)
        {
            foreach (var uv in GetDistinctEdges())
            {
                uv.U = new(uv.U.X + move.X, uv.U.Y + move.Y, uv.U.Z + move.Z, uv.U.NormalVector);
                uv.V = new(uv.V.X + move.X, uv.V.Y + move.Y, uv.V.Z + move.Z, uv.V.NormalVector);
            }
        }
    }
}
