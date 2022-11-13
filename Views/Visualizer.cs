using FastBitmapLib;
using System.Numerics;
using Views.Abstract;
using Views.Enums;
using Timer = System.Windows.Forms.Timer;

namespace Views
{
    public partial class Visualizer : Form, IVisualizer
    {
        private bool _isAnimation;
        private float _kd;
        private float _ks;
        private int _m;
        private int _r;
        private double _animationAngle;
        private double _animationStep;

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
            get => (int)LightPosition.Z; 
            private set
            {
                LightPosition = new(LightPosition.X, LightPosition.Y, value);
                z_label.Text = $"z: {value}";
            }
        }

        public event EventHandler KdChanged;
        public event EventHandler KsChanged;
        public event EventHandler MChanged;
        public event EventHandler<Color> IlluminationColorChanged;
        public event EventHandler<Color> ObjectColorChanged;
        public event EventHandler<Vector3> LightSourceChanged;

        public Form Form => this;
        public Size CanvasSize => new(DrawArea.Width, DrawArea.Height);
        private Bitmap DrawArea { get; }
        private FastBitmap FastDrawArea { get; }
        private Graphics Graphics => Graphics.FromImage(DrawArea);
        private Color DefaultColor { get; }
        private Timer AnimationTimer { get; }
        /// <summary>
        /// Set in normal coordinates (not WinForms)
        /// </summary>
        public Vector3 LightPosition { get; private set; }
        private int R
        {
            get => _r;
            set
            {
                _r = value;
                r_label.Text = $"R: {value}";
            }
        }
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

            AnimationTimer = new Timer();
            AnimationTimer.Tick += new EventHandler(Timer_Tick);

            DefaultColor = Color.Black;

            InitDefaultState();

            kdTrackBar.ValueChanged += OnKdChanged;
            ksTrackBar.ValueChanged += OnKsChanged;
            mTrackBar.ValueChanged += OnMChanged;
            zTrackBar.ValueChanged += OnZChanged;
            rTrackBar.ValueChanged += OnRChanged;
        }

        private void InitDefaultState()
        {
            _isAnimation = false;
            _animationAngle = Math.PI;
            _animationStep = Math.PI / 8;

            SolidColorButton.Checked = true;
            FromVerticesButton.Checked = true;

            R = 125;
            AnimationTimer.Interval = 100;
            LightPosition = new(CanvasSize.Width / 2 - R, CanvasSize.Height / 2, 0);

            kdTrackBar.Value = kdTrackBar.Maximum / 2;
            ksTrackBar.Value = ksTrackBar.Maximum / 2;
            mTrackBar.Value = mTrackBar.Maximum / 2;
            zTrackBar.Value = zTrackBar.Maximum / 2;
            rTrackBar.Value = (R - 50) * rTrackBar.Maximum / 200;

            Kd = (float)kdTrackBar.Value / kdTrackBar.Maximum;
            Ks = (float)ksTrackBar.Value / ksTrackBar.Maximum;
            M = mTrackBar.Value * 100 / mTrackBar.Maximum;
            Z = zTrackBar.Value * 400 / zTrackBar.Maximum + 300;
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
            Z = zTrackBar.Value * 400 / zTrackBar.Maximum + 300;
            LightSourceChanged?.Invoke(sender, LightPosition);
        }

        private void OnRChanged(object sender, EventArgs e)
        {
            R = rTrackBar.Value * 200 / rTrackBar.Maximum + 50;
        }

        private void AnimationButton_Click(object sender, EventArgs e)
        {
            if (_isAnimation)
            {
                AnimationButton.Text = "Enable";
                AnimationTimer.Stop();
            }
            else
            {
                AnimationTimer.Start();
                AnimationButton.Text = "Disable";
            }
            _isAnimation = !_isAnimation;
        }

        private void ChangeIlluminationColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
            IlluminationColorChanged?.Invoke(sender, ColorDialog.Color);
        }

        private void ChangeColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
            ObjectColorChanged?.Invoke(sender, ColorDialog.Color);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _animationAngle += _animationStep;
            _animationAngle %= 2 * Math.PI;

            LightPosition = new(
                R * (float)Math.Cos(_animationAngle) + CanvasSize.Width / 2,
                R * (float)Math.Sin(_animationAngle) + CanvasSize.Height / 2,
                LightPosition.Z
            );

            LightSourceChanged?.Invoke(sender, LightPosition);
        }
        #endregion
    }
}
