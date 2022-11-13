using Views.Enums;
using Views.Helpers;

namespace Views.Abstract
{
    public interface IVisualizer
    {
        event ValueChangedEventHandler<float> KdChanged;
        event ValueChangedEventHandler<float> KsChanged;
        event ValueChangedEventHandler<int> MChanged;
        event ValueChangedEventHandler<int> ZChanged;

        Form Form { get; }
        Size CanvasSize { get; }

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
