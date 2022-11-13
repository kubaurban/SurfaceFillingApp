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

            InitVisualizerHandlers();

            _shapeManager.ScaleSurface((int)(_visualizer.CanvasSize.Width * 0.95 / 2), (int)(_visualizer.CanvasSize.Height * 0.95 / 2));
            _shapeManager.MoveSurface(new(_visualizer.CanvasSize.Width / 2, _visualizer.CanvasSize.Height / 2, 0));

            _visualizer.ClearArea();

            FillSurface();
            DrawSurfaceMesh();

            _visualizer.RefreshArea();
        }

        private void InitVisualizerHandlers()
        {
            _visualizer.KdChanged += HandleKdChange;
            _visualizer.KsChanged += HandleKsChange;
            _visualizer.MChanged += HandleMChange;
            _visualizer.ZChanged += HandleZChange;
            }

        private void HandleKdChange(object? sender, EventArgs e)
        {
            _fillingService.Kd = _visualizer.Kd;
                }

        private void HandleKsChange(object? sender, EventArgs e)
            {
            _fillingService.Ks = _visualizer.Ks;
                }

        private void HandleMChange(object? sender, EventArgs e)
                {
            _fillingService.M = _visualizer.M;
                }

        private void HandleZChange(object? sender, EventArgs e)
                {
            _fillingService.Z = _visualizer.Z;
                }

        public Form GetForm() => _visualizer.Form;

        public void DrawSurfaceMesh()
        {
            foreach (var edge in _shapeManager.GetDistinctEdges())
            {
                _visualizer.DrawLine(edge.U, edge.V);
            }
        }
    }
}
