using FastBitmapLib;
using System.Numerics;
using Views.Abstract;
using Views.Enums;
using Timer = System.Windows.Forms.Timer;

namespace Views
{
    public partial class Visualizer : Form, IVisualizer
    {
        private readonly Bitmap _drawArea;
        private Graphics _graphics;
        private readonly Color _defaultColor;
        private bool _isAnimation;
        private float _kd;
        private float _ks;
        private int _m;
        private int _r;
        private readonly Timer _animationTimer;
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
        public event EventHandler<Vector3> LightSourceChanged;

        public event EventHandler<FillingMethod> FillingMethodChanged;
        public event EventHandler<Color> ObjectColorChanged;
        public event EventHandler<string> TextureChanged;

        public event EventHandler<InterpolationMethod> InterpolationMethodChanged;

        public event EventHandler<bool> DrawMeshChanged;

        public event EventHandler<string> NormalMapChanged;
        public event EventHandler<bool> ModifyWithNormalMapChanged;

        public Form Form => this;
        public Size CanvasSize => new(_drawArea.Width, _drawArea.Height);
        public FastBitmap FastDrawArea { get; }
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
        public bool NormalMapModification => NormalMapCheckBox.Checked;

        public Visualizer()
        {
            InitializeComponent();

            _drawArea = new Bitmap(PictureBox.Width, PictureBox.Height);
            _graphics = Graphics.FromImage(_drawArea);

            _animationTimer = new Timer();
            _animationTimer.Tick += OnTimerTick;

            _defaultColor = Color.Black;

            FastDrawArea = new FastBitmap(_drawArea);
            PictureBox.Image = _drawArea;

            InitDefaultState();
        }

        private void InitDefaultState()
        {
            _isAnimation = false;
            _animationTimer.Interval = 10;
            _animationAngle = Math.PI;
            _animationStep = Math.PI / 8;
            R = 125;

            SolidColorButton.Checked = true;
            ColorInterpolationButton.Checked = true;

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
        public void SetPixel(int x, int y, Color color) => FastDrawArea.SetPixel(x, CanvasSize.Height - y, color);

        public void DrawLine(PointF p1, PointF p2, Color? color = null)
        {
            using var g = _graphics;
            g.DrawLine(new(color ?? _defaultColor), p1.X, CanvasSize.Height - p1.Y, p2.X, CanvasSize.Height - p2.Y);
        }

        public void ClearArea()
        {
            using var g = _graphics;
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

        private void OnRChanged(object sender, EventArgs e) => R = (rTrackBar.Value * 200 / rTrackBar.Maximum) + 50;

        private void OnInterpolationMethodChanged(object sender, EventArgs e)
        {
            InterpolationMethodChanged?.Invoke(sender, ColorInterpolationButton.Checked ? InterpolationMethod.Color : InterpolationMethod.Vector);
        }

        private void OnFillingMethodChanged(object sender, EventArgs e)
        {
            var filling = FillingMethod.SolidColor;
            if (SolidColorButton.Checked)
            {
                ChangeColorButton.Enabled = true;
                ChangeTextureButton.Enabled = false;
        }
            else
            {
                filling = FillingMethod.Texture;
                ChangeColorButton.Enabled = false;
                ChangeTextureButton.Enabled = true;
            }

            FillingMethodChanged?.Invoke(sender, filling);
        }

        private void OnAnimationButtonClick(object sender, EventArgs e)
        {
            if (_isAnimation)
            {
                _animationTimer.Stop();
                AnimationButton.Text = "Enable";
            }
            else
            {
                _animationTimer.Start();
                AnimationButton.Text = "Disable";
            }
            _isAnimation = !_isAnimation;
        }

        private void OnChangeIlluminationColorButtonClick(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
            IlluminationColorChanged?.Invoke(sender, ColorDialog.Color);
        }
        }

        private void OnChangeColorButtonClick(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
            ObjectColorChanged?.Invoke(sender, ColorDialog.Color);
        }
        }

        private void OnTimerTick(object sender, EventArgs e)
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

        private void OnChangeTextureButtonClick(object sender, EventArgs e)
        {
            if (ShowFileOpenDialog() == DialogResult.OK)
            {
                TextureChanged?.Invoke(sender, OpenFileDialog.FileName);
            }
        }

        private DialogResult ShowFileOpenDialog()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            OpenFileDialog.InitialDirectory = @path;
            OpenFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png) | *.bmp;*.jpg;*.png";
            return OpenFileDialog.ShowDialog();
        }
        #endregion
    }
}
