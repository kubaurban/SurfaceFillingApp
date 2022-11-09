using Views.Abstract;

namespace Views
{
    public partial class Visualizer : Form, IVisualizer
    {
        public Form Form => this;
        private Bitmap DrawArea { get; }
        private Graphics Graphics => Graphics.FromImage(DrawArea);
        private Color DefaultColor { get; }

        public Visualizer()
        {
            InitializeComponent();

            DrawArea = new Bitmap(PictureBox.Width, PictureBox.Height);
            PictureBox.Image = DrawArea;

            DefaultColor = Color.Black;
        }

        public void DrawLine(PointF p1, PointF p2, Color? color = null)
        {
            using var g = Graphics;
            g.DrawLine(new(color ?? DefaultColor), p1, p2);
        }

        public void ClearArea()
        {
            using var g = Graphics;
            g.Clear(Color.White);
        }

        public void RefreshArea()
        {
            PictureBox.Refresh();
        }
    }
}
