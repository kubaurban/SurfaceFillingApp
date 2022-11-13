using Models;
using Services.Abstract;
using Services.Extensions;
using System.Drawing;
using System.Numerics;
using Views.Abstract;

namespace Services
{
    public class FillingService : IFillingService
    {
        private readonly IShapeManager _shapeManager;
        private readonly IVisualizer _visualizer;

        private float _kd;
        private float _ks;
        private int _m;
        private Vector3 _lightSource;
        private Vector3 _io;
        private Vector3 _il;

        public float Kd
        {
            get => _kd;
            set
            {
                _kd = value;
                FillSurface();
            }
        }
        public float Ks
        {
            get => _ks;
            set
            {
                _ks = value;
                FillSurface();
            }
        }
        public int M
        {
            get => _m;
            set
            {
                _m = value;
                FillSurface();
            }
        }
        public Vector3 LightSource
        {
            get => _lightSource;
            set
            {
                _lightSource = value;
                FillSurface();
            }
        }
        public Vector3 Io 
        { 
            get => _io; 
            set 
            { 
                _io = value;
                FillSurface();
            } 
        }
        public Vector3 Il
        {
            get => _il;
            set
            {
                _il = value;
                FillSurface();
            }
        }

        public FillingService(IShapeManager shapeManager, IVisualizer visualizer)
        {
            _shapeManager = shapeManager;
            _visualizer = visualizer;
        }

        public void SetParameters(float kd, float ks, int m, Vector3 lightSource, Vector3 io, Vector3 il) 
        {
            _kd = kd;
            _ks = ks;
            _m = m;
            _lightSource = lightSource;
            _io = io;
            _il = il;
        }

        private void FillFace(Face face)
        {
            var ET = new Dictionary<int, List<Node>>();
            var AET = new List<Node>();

            #region Preprocessing
            foreach (var edge in face.Edges)
            {
                var node = new Node()
                {
                    Ymax = edge.HigherVertex.Y,
                    X = edge.LowerVertex.X,
                    Coeff = edge.M == 0 ? 0 : 1 / edge.M
                };

                var yMin = (int)Math.Round(edge.LowerVertex.Y);
                if (!ET.TryAdd(yMin, new() { node }))
                {
                    ET[yMin].Add(node);
                }
            }
            #endregion

            int y_cur = ET.Min(x => x.Key);
            do
            {
                if (ET.TryGetValue(y_cur, out var list))
                {
                    AET.AddRange(list);
                }
                AET = AET.OrderBy(x => x.X).ToList();

                AET.RemoveAll(x => y_cur == (int)Math.Round(x.Ymax));

                for (int i = 0; i < AET.Count / 2; i++)
                {
                    for (int j = (int)AET[2 * i].X; j < AET[2 * i + 1].X; j++)
                    {
                        _visualizer.SetPixel(j, y_cur, GetPixelColor(j, y_cur, face));
                    }
                }

                foreach (var node in AET)
                {
                    node.X += node.Coeff;
                }

                ET.Remove(y_cur);
                ++y_cur;
            } while (ET.Any() || AET.Any());
        }

        private Color GetPixelColor(int x, int y, Face face)
        {
            var vertices = face.Vertices;
            var c0 = LambertColor(N(vertices[0]), L(vertices[0]));
            var c1 = LambertColor(N(vertices[1]), L(vertices[1]));
            var c2 = LambertColor(N(vertices[2]), L(vertices[2]));

            return Interpolate(c0, c1, c2, InterpolationCoefficients(x, y, face)).ToColor();
        }

        public void FillSurface()
        {
            foreach (var face in _shapeManager.GetAllFaces())
            {
                FillFace(face);
            }
        }

        private Vector3 LambertColor(Vector3 N, Vector3 L)
        {
            Vector3 R = 2 * Vector3.Dot(N, L) * N - L;

            float cos_1 = Vector3.Dot(N, L);
            float cos_2 = Vector3.Dot(new(0, 0, 1), R);

            if (cos_1 < 0) cos_1 = 0;
            if (cos_2 < 0) cos_2 = 0;

            return Io * Il * (Kd * cos_1 + Ks * (float)Math.Pow(cos_2, M));
        }

        private (float u, float v, float w) InterpolationCoefficients(int x, int y, Face face) // vertices interpolation
        {
            var faceVertices = face.Vertices;
            var P = TriangleArea(faceVertices);
            var P0 = TriangleArea(new() { new(x, y), faceVertices[1], faceVertices[2] });
            var P1 = TriangleArea(new() { new(x, y), faceVertices[0], faceVertices[2] });
            var P2 = TriangleArea(new() { new(x, y), faceVertices[0], faceVertices[1] });

            return new(P0 / P, P1 / P, P2 / P);
        }

        private Vector3 Interpolate(Vector3 A, Vector3 B, Vector3 C, (float u, float v, float w) coeff)
            => coeff.u * A + coeff.v * B + coeff.w * C;

        private float TriangleArea(List<Vertex> vertices)
        {
            var a = new Edge(vertices[0], vertices[1]);
            var b = new Edge(vertices[0], vertices[2]);

            return Vector3.Cross(a.AsVector2D, b.AsVector2D).Length() / 2;
        }

        private Vector3 N(Vertex v) => Vector3.Normalize(v.NormalVector);
        private Vector3 L(Vertex v) => Vector3.Normalize(new(LightSource.X - v.X, LightSource.Y - v.Y, LightSource.Z - v.Z));
    }
}
