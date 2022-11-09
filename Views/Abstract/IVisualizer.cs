namespace Views.Abstract
{
    public interface IVisualizer
    {
        Form Form { get; }

        void DrawLine(PointF p1, PointF p2, Color? color = null);
        void ClearArea();
        void RefreshArea();
    }
}
