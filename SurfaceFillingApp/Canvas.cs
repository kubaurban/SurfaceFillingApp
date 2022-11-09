using Models;
using Services.Abstract;
using SurfaceFillingApp.Abstract;
using System.Drawing;
using System.Windows.Forms;
using Views.Abstract;

namespace SurfaceFillingApp
{
    internal class Canvas : ICanvas
    {
        private IVisualizer _visualizer;
        private IShapeManager _shapeManager;

        public Canvas(IVisualizer visualizer, IShapeManager manager)
        {
            _visualizer = visualizer;
            _shapeManager = manager;

            _visualizer.ClearArea();

            FillSurface();
            DrawSurfaceMesh();

            _visualizer.RefreshArea();
        }

        public Form GetForm() => _visualizer.Form;

        public void DrawSurfaceMesh()
        {
            foreach (var edge in _shapeManager.GetDistinctEdges())
            {
                _visualizer.DrawLine(edge.U, edge.V);
            }
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
                    _visualizer.DrawLine(new(AET[2 * i].X, y_cur), new(AET[2 * i + 1].X, y_cur), Color.Aqua);
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
