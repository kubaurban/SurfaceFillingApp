using Models.Abstract;
using Services.Abstract;
using Services.Extensions;
using SurfaceFillingApp.Abstract;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using Views.Abstract;

namespace SurfaceFillingApp
{
    internal class Canvas : ICanvas
    {
        private readonly IVisualizer _visualizer;
        private readonly IShapeManager _shapeManager;
        private readonly IFillingService _fillingService;

        public Canvas(IVisualizer visualizer, IShapeManager manager, IFillingService fillingService)
        {
            _visualizer = visualizer;
            _shapeManager = manager;
            _fillingService = fillingService;

            InitVisualizerHandlers();

            _fillingService.SetParameters(
                _visualizer.Kd,
                _visualizer.Ks,
                _visualizer.M,
                new Vector3(125, 125, _visualizer.Z),
                Color.SandyBrown.ToVector(),
                Color.White.ToVector()
            );

            _shapeManager.ScaleSurface((int)(_visualizer.CanvasSize.Width * 0.95 / 2));
            _shapeManager.MoveSurface(new(_visualizer.CanvasSize.Width / 2, _visualizer.CanvasSize.Height / 2, 0));

            _visualizer.ClearArea();

            _fillingService.FillSurface();
            DrawSurfaceMesh();

            _visualizer.RefreshArea();
        }

        private void InitVisualizerHandlers()
        {
            _visualizer.KdChanged += HandleKdChange;
            _visualizer.KsChanged += HandleKsChange;
            _visualizer.MChanged += HandleMChange;
            _visualizer.ZChanged += HandleZChange;
            _visualizer.IlluminationColorChanged += HandleIlluminationColorChange;
            _visualizer.ObjectColorChanged += HandleObjectColorChange;
        }

        private void HandleKdChange(object? sender, EventArgs e)
        {
            _fillingService.Kd = _visualizer.Kd;
            DrawSurfaceMesh();
            _visualizer.RefreshArea();
        }

        private void HandleKsChange(object? sender, EventArgs e)
        {
            _fillingService.Ks = _visualizer.Ks;
            DrawSurfaceMesh();
            _visualizer.RefreshArea();
        }

        private void HandleMChange(object? sender, EventArgs e)
        {
            _fillingService.M = _visualizer.M;
            DrawSurfaceMesh();
            _visualizer.RefreshArea();
        }

        private void HandleZChange(object? sender, EventArgs e)
        {
            _fillingService.LightSource = new(125, 125, _visualizer.Z);
            DrawSurfaceMesh();
            _visualizer.RefreshArea();
        }

        private void HandleObjectColorChange(object? sender, Color e)
        {
            _fillingService.Io = e.ToVector();
            DrawSurfaceMesh();
            _visualizer.RefreshArea();
        }

        private void HandleIlluminationColorChange(object? sender, Color e)
        {
            _fillingService.Il = e.ToVector();
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
    }
}
