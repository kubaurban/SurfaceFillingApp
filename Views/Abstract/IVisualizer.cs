using Views.Enums;
using Views.Helpers;

namespace Views.Abstract
{
    public interface IVisualizer
    {
        event EventHandler KdChanged;
        event EventHandler KsChanged;
        event EventHandler MChanged;
        event EventHandler ZChanged;

        Form Form { get; }
        Size CanvasSize { get; }

        float Kd { get; }
        float Ks { get; }
        int M { get; }
        int Z { get; }
        bool Animation { get; }
        FillingMethod FillingMethod { get; }
        InterpolationMethod InterpolationMethod { get; }
        bool NormalMapModification { get; }

        void SetPixel(int x, int y, Color color);
        void DrawLine(PointF p1, PointF p2, Color? color = null);
        void ClearArea();
        void RefreshArea();
    }
}
