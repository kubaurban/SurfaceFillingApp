using Models.Abstract;
using Services;
using Services.Abstract;
using SurfaceFillingApp.Abstract;
using System.Drawing;
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

        private Color DefaultSolidColor { get; set; }
        private string DefaultTexturePath { get; set; }
        private string DefaultNormalMapPath { get; set; }

        private bool DrawMesh => _visualizer.DrawMesh;

        public Form GetForm() => _visualizer.Form;

        public Canvas(IVisualizer visualizer, IShapeManager manager, IFillingService fillingService)
        {
            _visualizer = visualizer;
            _shapeManager = manager;
            _fillingService = fillingService;

            InitVisualizerHandlers();

            DefaultSolidColor = Color.SandyBrown;
            DefaultTexturePath = @"..\..\..\..\vader.jpg";
            DefaultNormalMapPath = @"..\..\..\..\wall.jpg";

            _shapeManager.ScaleSurface((int)(_visualizer.CanvasSize.Width * 0.98 / 2));
            _shapeManager.MoveSurface(new(_visualizer.CanvasSize.Width / 2, _visualizer.CanvasSize.Height / 2, 0));

            _fillingService.EagerLoadFillingAlgorithm();
            _fillingService.Filler = new ColorFiller(DefaultSolidColor);

            _visualizer.ClearArea();

            _fillingService.FillSurface();
            if (DrawMesh)
                DrawSurfaceMesh();

            _visualizer.RefreshArea();
        }

        private void InitVisualizerHandlers()
        {
            _visualizer.KdChanged += HandleFillingParameterChanged;
            _visualizer.KsChanged += HandleFillingParameterChanged;
            _visualizer.MChanged += HandleFillingParameterChanged;
            _visualizer.IlluminationColorChanged += HandleFillingParameterChanged;
            _visualizer.ObjectColorChanged += HandleObjectColorChange;
            _visualizer.LightPositionChanged += HandleFillingParameterChanged;
            _visualizer.FillingMethodChanged += HandleFillingMethodChange;
            _visualizer.InterpolationMethodChanged += HandleFillingParameterChanged;
            _visualizer.TextureChanged += HandleTextureChange;
            _visualizer.DrawMeshChanged += HandleFillingParameterChanged;
            _visualizer.NormalMapChanged += HandleNormalMapChanged;
            _visualizer.ModifyWithNormalMapChanged += HandleModifyWithNormalMapChanged;
        }

        #region View handlers
        private void HandleFillingParameterChanged(object? sender, EventArgs e) => RefreshAll();

        private void HandleFillingMethodChange(object? sender, EventArgs e)
        {
            if (_visualizer.FillingMethod == FillingMethod.SolidColor)
            {
                HandleObjectColorChange(sender, DefaultSolidColor);
            }
            else
            {
                HandleTextureChange(sender, DefaultTexturePath);
            }
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

        private void HandleModifyWithNormalMapChanged(object? sender, bool e)
        {
            if (e)
            {
                HandleNormalMapChanged(sender, DefaultNormalMapPath);
            }
            else
            {
                _fillingService.DisableNormalMap();
                RefreshAll();
            }
        }

        private void HandleNormalMapChanged(object? sender, string e)
        {
            _fillingService.ApplyNormalMap(new NormalMap(e));
            RefreshAll();
        }
        #endregion

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
