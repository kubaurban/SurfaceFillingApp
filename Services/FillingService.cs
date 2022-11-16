using Models.Abstract;
using Models.Domain;
using Models.Helpers;
using Services.Abstract;
using Services.Extensions;
using System.Drawing;
using System.Numerics;
using Views.Abstract;
using Views.Enums;

namespace Services
{
    public class FillingService : IFillingService
    {
        private readonly IShapeManager _shapeManager;
        private readonly IVisualizer _visualizer;

        #region Eagerly loaded data for faster surface filling
        private readonly Dictionary<(int x, int y), (float u, float v, float w)> _interpolationCoeffs;

        private readonly Dictionary<Vertex, Vector3> _vertexNormalVectors;
        private readonly Dictionary<Vertex, Vector3> _effectiveVertexNormalVectors;

        private readonly Dictionary<(int x, int y), Vector3> _interpNormalVectors;
        private readonly Dictionary<(int x, int y), Vector3> _effectiveInterpNormalVectors;
        #endregion

        private float Kd => _visualizer.Kd;
        private float Ks => _visualizer.Ks;
        private int M => _visualizer.M;
        private Vector3 LightPosition => _visualizer.LightPosition;
        private Vector3 Il => _visualizer.IlluminationColor.ToVector();
        private InterpolationMethod InterpolationMethod => _visualizer.InterpolationMethod;

        public IFiller Filler { get; set; }

        public FillingService(IShapeManager shapeManager, IVisualizer visualizer)
        {
            _shapeManager = shapeManager;
            _visualizer = visualizer;
            _interpolationCoeffs = new();

            _vertexNormalVectors = new();
            _effectiveVertexNormalVectors = new();

            _interpNormalVectors = new();
            _effectiveInterpNormalVectors = new();

            Filler = new ColorFiller(Color.Aqua);
        }

        public void EagerLoadFillingAlgorithm()
        {
            foreach (var face in _shapeManager.GetAllFaces())
            {
                var vertices = face.Vertices;

                _effectiveVertexNormalVectors[vertices[0]] = _vertexNormalVectors[vertices[0]] = Vector3.Normalize(vertices[0].NormalVector);
                _effectiveVertexNormalVectors[vertices[1]] = _vertexNormalVectors[vertices[1]] = Vector3.Normalize(vertices[1].NormalVector);
                _effectiveVertexNormalVectors[vertices[2]] = _vertexNormalVectors[vertices[2]] = Vector3.Normalize(vertices[2].NormalVector);

                FillFacePreprocessing(face, out var ET);

                var AET = new List<Node>();
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
                            var coeffs = InterpolationCoefficients(j, y_cur, face);

                            _interpolationCoeffs[(j, y_cur)] = coeffs;
                            _interpNormalVectors[(j, y_cur)] = Interpolate(_vertexNormalVectors[vertices[0]],
                                _vertexNormalVectors[vertices[1]], _vertexNormalVectors[vertices[2]], coeffs);
                            _effectiveInterpNormalVectors[(j, y_cur)] = _interpNormalVectors[(j, y_cur)];
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
        }

        public void FreeEagerlyLoadedData()
        {
            _interpolationCoeffs.Clear();
            _vertexNormalVectors.Clear();
            _effectiveVertexNormalVectors.Clear();
            _interpNormalVectors.Clear();
            _effectiveInterpNormalVectors.Clear();
        }

        public void FillSurface()
        {
            foreach (var face in _shapeManager.GetAllFaces())
            {
                FillFace(face);
            }
        }

        #region NormalMap
        public void ApplyNormalMap(NormalMap map)
        {
            for (int x = 0; x < _visualizer.CanvasSize.Width; x++)
            {
                for (int y = 0; y < _visualizer.CanvasSize.Height; y++)
                {
                    if (_interpNormalVectors.TryGetValue((x, y), out var N_surf))
                    {
                        _effectiveInterpNormalVectors[(x, y)] = ComputeEffectiveNormalVector(x, y, N_surf, map);
                    }
                }
            }

            foreach (var v in _shapeManager.GetAllFaces().SelectMany(x => x.Vertices).Distinct())
            {
                _effectiveVertexNormalVectors[v] = ComputeEffectiveNormalVector((int)v.X, (int)v.Y, _vertexNormalVectors[v], map);
            }
        }

        public void DisableNormalMap()
        {
            _effectiveInterpNormalVectors.Clear();
            _effectiveVertexNormalVectors.Clear();

            foreach (var item in _interpNormalVectors)
            {
                _effectiveInterpNormalVectors.Add(item.Key, item.Value);
            }
            foreach (var item in _vertexNormalVectors)
            {
                _effectiveVertexNormalVectors.Add(item.Key, item.Value);
            }
        }
        #endregion

        #region Face filling algorithm
        private void FillFace(Face face)
        {
            FillFacePreprocessing(face, out var ET);

            var AET = new List<Node>();
            int y_cur = ET.Min(x => x.Key);
            do
            {
                if (ET.TryGetValue(y_cur, out var list))
                {
                    AET.AddRange(list);
                }
                AET = AET.OrderBy(x => x.X).ToList();

                AET.RemoveAll(x => y_cur == (int)Math.Round(x.Ymax));

                _visualizer.FastDrawArea.Lock();
                for (int i = 0; i < AET.Count / 2; i++)
                {
                    for (int j = (int)AET[2 * i].X; j < AET[2 * i + 1].X; j++)
                    {
                        _visualizer.SetPixel(j, y_cur, GetPixelColor(j, y_cur, face));
                    }
                }
                _visualizer.FastDrawArea.Unlock();

                foreach (var node in AET)
                {
                    node.X += node.Coeff;
                }

                ET.Remove(y_cur);
                ++y_cur;
            } while (ET.Any() || AET.Any());
        }

        private static void FillFacePreprocessing(Face face, out Dictionary<int, List<Node>> ET)
        {
            ET = new Dictionary<int, List<Node>>();

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
        }
        #endregion

        private Vector3 LambertColor(int x, int y, Vector3 N, Vector3 L)
        {
            Vector3 R = 2 * Vector3.Dot(N, L) * N - L;

            float cos_1 = Vector3.Dot(N, L);
            float cos_2 = Vector3.Dot(new(0, 0, 1), R);

            if (cos_1 < 0) cos_1 = 0;
            if (cos_2 < 0) cos_2 = 0;

            return Io(x, y) * Il * (Kd * cos_1 + Ks * (float)Math.Pow(cos_2, M));
        }

        private Color GetPixelColor(int x, int y, Face face)
        {
            var vertices = face.Vertices;

            if (InterpolationMethod == InterpolationMethod.Color)
            {
                var c0 = LambertColor((int)vertices[0].X, (int)vertices[0].Y, _effectiveVertexNormalVectors[vertices[0]], L(vertices[0]));
                var c1 = LambertColor((int)vertices[1].X, (int)vertices[1].Y, _effectiveVertexNormalVectors[vertices[1]], L(vertices[1]));
                var c2 = LambertColor((int)vertices[2].X, (int)vertices[2].Y, _effectiveVertexNormalVectors[vertices[2]], L(vertices[2]));
                return Interpolate(c0, c1, c2, _interpolationCoeffs[(x, y)]).ToColor();
            }
            else
            {
                var nv = _effectiveInterpNormalVectors[(x, y)];
                var lv = Interpolate(L(vertices[0]), L(vertices[1]), L(vertices[2]), _interpolationCoeffs[(x, y)]);
                return LambertColor(x, y, nv, lv).ToColor();
            }
        }

        private static (float u, float v, float w) InterpolationCoefficients(int x, int y, Face face)
        {
            var faceVertices = face.Vertices;
            var P0 = TriangleArea(new() { new(x, y), faceVertices[1], faceVertices[2] });
            var P1 = TriangleArea(new() { new(x, y), faceVertices[0], faceVertices[2] });
            var P2 = TriangleArea(new() { new(x, y), faceVertices[0], faceVertices[1] });
            var P = P0 + P1 + P2;

            return new(P0 / P, P1 / P, P2 / P);
        }

        private static Vector3 Interpolate(Vector3 A, Vector3 B, Vector3 C, (float u, float v, float w) coeff)
            => coeff.u * A + coeff.v * B + coeff.w * C;

        private static float TriangleArea(List<Vertex> vertices)
        {
            var a = new Edge(vertices[0], vertices[1]);
            var b = new Edge(vertices[0], vertices[2]);

            return Vector3.Cross(a.AsVector2D, b.AsVector2D).Length() / 2;
        }

        private Vector3 Io(int x, int y) => Filler.GetPixelColorVector(x, _visualizer.CanvasSize.Height - y);

        private Vector3 L(Vertex v) => Vector3.Normalize(new(LightPosition.X - v.X, LightPosition.Y - v.Y, LightPosition.Z - v.Z));

        private Vector3 ComputeEffectiveNormalVector(int x, int y, Vector3 N_surf, NormalMap map)
        {
            var B = Vector3.Normalize(Vector3.Cross(N_surf, new(0, 0, 1)));
            if (N_surf.X < 1e-6 && N_surf.Y < 1e-6 && Math.Abs(N_surf.Z - 1) < 1e-6)
            {
                B = new(0, 1, 0);
            }
            var T = Vector3.Normalize(Vector3.Cross(B, N_surf));
            var N_map = map.GetPixelColorVector(x, _visualizer.CanvasSize.Height - y);

            return Vector3.Normalize(new()
            {
                X = T.X * N_surf.X + B.X * N_surf.Y + N_map.X * N_surf.Z,
                Y = T.Y * N_surf.X + B.Y * N_surf.Y + N_map.Y * N_surf.Z,
                Z = T.Z * N_surf.X + B.Z * N_surf.Y + N_map.Z * N_surf.Z
            });
        }
    }
}
