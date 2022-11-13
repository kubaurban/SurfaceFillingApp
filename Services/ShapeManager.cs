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

        public void ScaleSurface(int scale)
        {
            foreach (var uv in GetDistinctEdges())
            {
                uv.U = new(uv.U.X * scale, uv.U.Y * scale, uv.U.Z * scale, uv.U.NormalVector);
                uv.V = new(uv.V.X * scale, uv.V.Y * scale, uv.V.Z * scale, uv.V.NormalVector);
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
