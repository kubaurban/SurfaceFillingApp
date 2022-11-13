using FastBitmapLib;
using Views.Abstract;
using Views.Enums;

namespace Views
{
    public partial class Visualizer : Form, IVisualizer
    {
        private bool _isAnimation;
        private float _kd;
        private float _ks;
        private int _m;
        private int _z;

        public float Kd
        {
            get => _kd;
            private set
            {
                _kd = value;
                kd_label.Text = $"kd: {Math.Round(_kd, 2)}";
            }
        }
        public float Ks
        {
            get => _ks; 
            private set
            {
                _ks = value;
                ks_label.Text = $"ks: {Math.Round(_ks, 2)}";
            }
        }
        public int M
        {
            get => _m; 
            private set
            {
                _m = value;
                m_label.Text = $"m: {_m}";
            }
        }
        public int Z
        {
            get => _z; 
            private set
            {
                _z = value;
                z_label.Text = $"z: {_z}";
            }
        }

        public event EventHandler KdChanged;
        public event EventHandler KsChanged;
        public event EventHandler MChanged;
        public event EventHandler ZChanged;

        public Form Form => this;
        public Size CanvasSize => new(DrawArea.Width, DrawArea.Height);
        private Bitmap DrawArea { get; }
        private FastBitmap FastDrawArea { get; }
        private Graphics Graphics => Graphics.FromImage(DrawArea);
        private Color DefaultColor { get; }

        public bool Animation => _isAnimation;
        public FillingMethod FillingMethod => SolidColorButton.Checked ? FillingMethod.SolidColor : FillingMethod.Texture;
        public InterpolationMethod InterpolationMethod => FromVerticesButton.Checked ? InterpolationMethod.FromVertices : InterpolationMethod.FromDirectPoint;
        public bool NormalMapModification => NormalMapCheckBox.Checked;

        public Visualizer()
        {
            InitializeComponent();

            DrawArea = new Bitmap(PictureBox.Width, PictureBox.Height);
            FastDrawArea = new FastBitmap(DrawArea);
            PictureBox.Image = DrawArea;

            DefaultColor = Color.Black;

            InitDefaultState();

            kdTrackBar.ValueChanged += OnKdChanged;
            ksTrackBar.ValueChanged += OnKsChanged;
            mTrackBar.ValueChanged += OnMChanged;
            zTrackBar.ValueChanged += OnZChanged;
        }

        private void InitDefaultState()
        {
            _isAnimation = false;
            SolidColorButton.Checked = true;
            FromVerticesButton.Checked = true;

            kdTrackBar.Value = kdTrackBar.Maximum / 2;
            ksTrackBar.Value = ksTrackBar.Maximum / 2;
            mTrackBar.Value = mTrackBar.Maximum / 2;
            zTrackBar.Value = zTrackBar.Maximum / 2;

            Kd = (float)kdTrackBar.Value / kdTrackBar.Maximum;
            Ks = (float)ksTrackBar.Value / ksTrackBar.Maximum;
            M = mTrackBar.Value * 100 / mTrackBar.Maximum;
            Z = (zTrackBar.Value * 400) / zTrackBar.Maximum + 300;
        }

        #region Drawing functions
        public void SetPixel(int x, int y, Color color)
        {
            FastDrawArea.Lock();
            FastDrawArea.SetPixel(x, CanvasSize.Height - y, color);
            FastDrawArea.Unlock();
        }

        public void DrawLine(PointF p1, PointF p2, Color? color = null)
        {
            using var g = Graphics;
            g.DrawLine(new(color ?? DefaultColor), p1.X, CanvasSize.Height - p1.Y, p2.X, CanvasSize.Height - p2.Y);
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
        #endregion

        #region User action handlers
        private void OnKdChanged(object sender, EventArgs e)
        {
            Kd = (float)kdTrackBar.Value / kdTrackBar.Maximum;
            KdChanged?.Invoke(sender, e);
        }

        private void OnKsChanged(object sender, EventArgs e)
        {
            Ks = (float)ksTrackBar.Value / ksTrackBar.Maximum;
            KsChanged?.Invoke(sender, e);
        }

        private void OnMChanged(object sender, EventArgs e)
        {
            M = mTrackBar.Value * 100 / mTrackBar.Maximum;
            MChanged?.Invoke(sender, e);
        }

        private void OnZChanged(object sender, EventArgs e)
        {
            Z = (zTrackBar.Value * 400) / zTrackBar.Maximum + 300;
            ZChanged?.Invoke(sender, e);
        }

        private void AnimationButton_Click(object sender, EventArgs e)
        {
            if (_isAnimation)
            {
                AnimationButton.Text = "Enable";
            }
            else
            {
                AnimationButton.Text = "Disable";
            }
            _isAnimation = !_isAnimation;
        }
        #endregion
    }
}
