using Models.Abstract;
using Services;
using Services.Abstract;
using Services.Extensions;
using SurfaceFillingApp.Abstract;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using Views.Abstract;
using Views.Enums;

namespace SurfaceFillingApp
{
    internal class Canvas : ICanvas
    {
        private readonly IVisualizer _visualizer;
        private readonly IShapeManager _shapeManager;
        private readonly IFillingService _fillingService;

        private bool DrawMesh { get; set; }
        private bool ModifyWithNormalMap { get; set; }

        public Canvas(IVisualizer visualizer, IShapeManager manager, IFillingService fillingService)
        {
            _visualizer = visualizer;
            _shapeManager = manager;
            _fillingService = fillingService;

            InitVisualizerHandlers();

            InitDefaultState();

            _shapeManager.ScaleSurface((int)(_visualizer.CanvasSize.Width * 0.95 / 2));
            _shapeManager.MoveSurface(new(_visualizer.CanvasSize.Width / 2, _visualizer.CanvasSize.Height / 2, 0));

            _visualizer.ClearArea();

            _fillingService.FillSurface();
            if (DrawMesh)
                DrawSurfaceMesh();

            _visualizer.RefreshArea();
        }

        private void InitDefaultState()
        {
            DrawMesh = false;
            ModifyWithNormalMap = false;

            _fillingService.SetParameters(
                kd: _visualizer.Kd,
                ks: _visualizer.Ks,
                m: _visualizer.M,
                lightSource: _visualizer.LightPosition,
                il: Color.White.ToVector(),
                filling: FillingMethod.SolidColor,
                filler: new ColorFiller(Color.SandyBrown),
                interpolation: InterpolationMethod.Color
            );
        }

        private void InitVisualizerHandlers()
        {
            _visualizer.KdChanged += HandleKdChange;
            _visualizer.KsChanged += HandleKsChange;
            _visualizer.MChanged += HandleMChange;
            _visualizer.IlluminationColorChanged += HandleIlluminationColorChange;
            _visualizer.ObjectColorChanged += HandleObjectColorChange;
            _visualizer.LightSourceChanged += HandleLightSourceChange;
            _visualizer.FillingMethodChanged += HandleFillingMethodChange;
            _visualizer.InterpolationMethodChanged += HandleInterpolationMethodChange;
            _visualizer.TextureChanged += HandleTextureChange;
            _visualizer.DrawMeshChanged += HandleDrawMeshChanged;
            _visualizer.NormalMapChanged += HandleNormalMapChanged;
            _visualizer.ModifyWithNormalMapChanged += HandleModifyWithNormalMapChanged;
        }

        private void HandleModifyWithNormalMapChanged(object? sender, bool e) => ModifyWithNormalMap = e;

        private void HandleNormalMapChanged(object? sender, string e)
        {
            return;
        }

        private void HandleDrawMeshChanged(object? sender, bool e)
        {
            DrawMesh = e;
            RefreshAll();
        }


        private void HandleFillingMethodChange(object? sender, FillingMethod e) => _fillingService.Filling = e;

        private void HandleInterpolationMethodChange(object? sender, InterpolationMethod e)
        {
            _fillingService.Interpolation = e;
            RefreshAll();
        }

        private void HandleKdChange(object? sender, EventArgs e)
        {
            _fillingService.Kd = _visualizer.Kd;
            RefreshAll();
        }

        private void HandleKsChange(object? sender, EventArgs e)
        {
            _fillingService.Ks = _visualizer.Ks;
            RefreshAll();
        }

        private void HandleMChange(object? sender, EventArgs e)
        {
            _fillingService.M = _visualizer.M;
            RefreshAll();
        }

        private void HandleZChange(object? sender, EventArgs e)
        {
            _fillingService.LightSource = new(125, 125, _visualizer.Z);
            RefreshAll();
        }

        private void HandleObjectColorChange(object? sender, Color e)
        {
            _fillingService.Filler = new ColorFiller(e);
            RefreshAll(); 
        }

        private void HandleTextureChange(object? sender, string e)
        {
            _fillingService.Filler = new TextureFiller(e);
           RefreshAll();
        }

        private void HandleIlluminationColorChange(object? sender, Color e)
        {
            _fillingService.Il = e.ToVector();
           RefreshAll();
        }

        private void HandleLightSourceChange(object? sender, Vector3 e)
        {
            _fillingService.LightSource = e;
           RefreshAll();
        }

        public Form GetForm() => _visualizer.Form;

        public void DrawSurfaceMesh()
        {
            foreach (var edge in _shapeManager.GetDistinctEdges())
            {
                _visualizer.DrawLine(edge.U, edge.V);
            }
        }

        private void RefreshAll()
        {
            _fillingService.FillSurface();
            if (DrawMesh)
                DrawSurfaceMesh();
            _visualizer.RefreshArea();
        }
    }
}
