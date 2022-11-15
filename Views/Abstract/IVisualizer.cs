using FastBitmapLib;
using System.Numerics;
using Views.Enums;

namespace Views.Abstract
{
    public interface IVisualizer
    {
        event EventHandler KdChanged;
        event EventHandler KsChanged;
        event EventHandler MChanged;

        event EventHandler IlluminationColorChanged;
        event EventHandler LightPositionChanged;

        event EventHandler FillingMethodChanged;
        event EventHandler<Color> ObjectColorChanged;
        event EventHandler<string> TextureChanged;

        event EventHandler InterpolationMethodChanged;

        event EventHandler DrawMeshChanged;

        event EventHandler<string> NormalMapChanged;
        event EventHandler<bool> ModifyWithNormalMapChanged;

        Form Form { get; }
        Size CanvasSize { get; }
        FastBitmap FastDrawArea { get; }

        float Kd { get; }
        float Ks { get; }
        int M { get; }
        int Z { get; }

        bool DrawMesh { get; }
        Vector3 LightPosition { get; }
        Color IlluminationColor { get; }
        FillingMethod FillingMethod { get; }
        InterpolationMethod InterpolationMethod { get; }

        void SetPixel(int x, int y, Color color);
        void DrawLine(PointF p1, PointF p2, Color? color = null);
        void ClearArea();
        void RefreshArea();
    }
}
