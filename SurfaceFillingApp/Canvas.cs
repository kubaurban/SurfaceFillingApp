using Models;
using Services.Abstract;
using SurfaceFillingApp.Abstract;
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

            DrawSurface();

            _visualizer.RefreshArea();
        }

        public Form GetForm() => _visualizer.Form;

        public void DrawSurface()
        {
            foreach (var edge in _shapeManager.GetAllFaces().SelectMany(x => x.Edges).ToHashSet(new EdgeComparator()))
            {
                _visualizer.DrawLine(edge.U, edge.V);
            }
        }
    }
}
