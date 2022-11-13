using Models;
using Services.Abstract;
using System.Drawing;
using Views.Abstract;

namespace Services
{
    public class FillingService : IFillingService
    {
        private readonly IShapeManager _shapeManager;
        private readonly IVisualizer _visualizer;

        public float Kd { get; set; } = 0;
        public float Ks { get; set; } = 0;
        public int M { get; set; } = 1;
        public int Z { get; set; } = 200;

        private Color ObjectColor { get; }
        private Color LightColor { get; }

        public FillingService(IShapeManager shapeManager, IVisualizer visualizer)
        {
            _shapeManager = shapeManager;
            _visualizer = visualizer;

            ObjectColor = Color.SandyBrown;
            LightColor = Color.White;
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

            int y_cur = ET.Max(x => x.Key);
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
                        _visualizer.SetPixel(j, y_cur, ObjectColor);
                    }
                }

                foreach (var node in AET)
                {
                    node.X -= node.Coeff;
                }

                ET.Remove(y_cur);
                --y_cur;
            } while (ET.Any() || AET.Any());
        }

        public void FillSurface()
        {
            foreach (var face in _shapeManager.GetAllFaces())
            {
                FillFace(face);
            }
        }
    }
}
