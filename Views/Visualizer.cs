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
        private readonly Color _defaultColor;
        private bool _isAnimation;
        private float _kd;
        private float _ks;
        private int _m;
        private int _r;
        private readonly Timer _animationTimer;
        private double _animationAngle;
        private double _animationStep;
        private string _loadedSurfaceFilename;

        private Graphics Graphics => Graphics.FromImage(_drawArea);
        private int R
        {
            get => _r;
            set
            {
                _r = value;
                r_label.Text = $"R: {value}";
            }
        }


        public event EventHandler KdChanged;
        public event EventHandler KsChanged;
        public event EventHandler MChanged;

        public event EventHandler IlluminationColorChanged;
        public event EventHandler LightPositionChanged;

        public event EventHandler FillingMethodChanged;
        public event EventHandler<Color> ObjectColorChanged;
        public event EventHandler<string> TextureChanged;

        public event EventHandler InterpolationMethodChanged;

        public event EventHandler DrawMeshChanged;

        public event EventHandler<string> NormalMapChanged;
        public event EventHandler<bool> ModifyWithNormalMapChanged;

        public event EventHandler<string> LoadedSurfaceFileChanged;

        public Form Form => this;
        public Size CanvasSize => new(_drawArea.Width, _drawArea.Height);
        public FastBitmap FastDrawArea { get; }

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
        public bool DrawMesh => DrawMeshCheckbox.Checked;
        /// <summary>
        /// Set in normal coordinates (not WinForms)
        /// </summary>
        public Vector3 LightPosition { get; private set; }
        public Color IlluminationColor { get; private set; }
        public FillingMethod FillingMethod { get; private set; }
        public InterpolationMethod InterpolationMethod { get; private set; }

        public string LoadedSurfaceFilename
        {
            get => "Loaded surface file: " + _loadedSurfaceFilename; 
            set
            {
                _loadedSurfaceFilename = value;
                LoadedSurfaceLabel.Text = LoadedSurfaceFilename;
            }
        }

        public Visualizer()
        {
            InitializeComponent();

            _drawArea = new Bitmap(PictureBox.Width, PictureBox.Height);

            _animationTimer = new Timer();
            _animationTimer.Tick += OnTimerTick;

            _defaultColor = Color.Black;
            _loadedSurfaceFilename = string.Empty;

            FastDrawArea = new FastBitmap(_drawArea);
            PictureBox.Image = _drawArea;

            InitDefaultState();
        }

        public void InitDefaultState()
        {
            DrawMeshCheckbox.Checked = false;

            kdTrackBar.Value = (kdTrackBar.Maximum + kdTrackBar.Minimum) / 2;
            ksTrackBar.Value = (ksTrackBar.Maximum + ksTrackBar.Minimum) / 2;
            mTrackBar.Value = (mTrackBar.Maximum + mTrackBar.Minimum) / 2;
            zTrackBar.Value = (zTrackBar.Maximum + zTrackBar.Minimum) / 2;
            rTrackBar.Value = 250;

            _isAnimation = false;
            _animationTimer.Interval = 100;
            _animationAngle = Math.PI;
            _animationStep = Math.PI / 8;
            _animationTimer.Stop(); // for reload
            AnimationButton.Text = "Enable";

            SolidColorRadioButton.Checked = true;
            TextureRadioButton.Checked = false;
            ChangeColorButton.Enabled = true;

            VectorInterpolationButton.Checked = true;
            ColorInterpolationButton.Checked = false;
            ChangeTextureButton.Enabled = false;

            NormalMapCheckBox.Checked = false;
            ChangeNormalMapButton.Enabled = false;

            Kd = (float)kdTrackBar.Value / (kdTrackBar.Maximum + kdTrackBar.Minimum);
            Ks = (float)ksTrackBar.Value / (kdTrackBar.Maximum + kdTrackBar.Minimum);
            M = mTrackBar.Value;
            Z = zTrackBar.Value;
            R = rTrackBar.Value;
            FillingMethod = FillingMethod.SolidColor;
            InterpolationMethod = InterpolationMethod.Vector;
            LightPosition = new(CanvasSize.Width / 2 - R, CanvasSize.Height / 2, Z);
            IlluminationColor = Color.White;
        }

        #region Drawing functions
        public void SetPixel(int x, int y, Color color) => FastDrawArea.SetPixel(x, CanvasSize.Height - y, color);

        public void DrawLine(PointF p1, PointF p2, Color? color = null)
        {
            using var g = Graphics;
            g.DrawLine(new(color ?? _defaultColor), p1.X, CanvasSize.Height - p1.Y, p2.X, CanvasSize.Height - p2.Y);
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
            M = mTrackBar.Value;
            MChanged?.Invoke(sender, e);
        }

        private void OnZChanged(object sender, EventArgs e)
        {
            Z = zTrackBar.Value;
            LightPositionChanged?.Invoke(sender, e);
        }

        private void OnRChanged(object sender, EventArgs e) => R = rTrackBar.Value;

        private void OnInterpolationMethodChanged(object sender, EventArgs e)
        {
            InterpolationMethod = ColorInterpolationButton.Checked ? InterpolationMethod.Color : InterpolationMethod.Vector;
            InterpolationMethodChanged?.Invoke(sender, e);
        }

        private void OnFillingMethodChanged(object sender, EventArgs e)
        {
            if (SolidColorRadioButton.Checked)
            {
                FillingMethod = FillingMethod.SolidColor;
                ChangeColorButton.Enabled = true;
                ChangeTextureButton.Enabled = false;
            }
            else
            {
                FillingMethod = FillingMethod.Texture;
                ChangeColorButton.Enabled = false;
                ChangeTextureButton.Enabled = true;
            }

            FillingMethodChanged?.Invoke(sender, e);
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
                IlluminationColor = ColorDialog.Color;
                IlluminationColorChanged?.Invoke(sender, e);
            }
        }

        private void OnChangeColorButtonClick(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                ObjectColorChanged?.Invoke(sender, ColorDialog.Color);
            }
        }

        private void OnChangeTextureButtonClick(object sender, EventArgs e)
        {
            if (ShowOpenImageDialog() == DialogResult.OK)
            {
                TextureChanged?.Invoke(sender, OpenImageDialog.FileName);
            }
        }

        private void OnDrawMeshChanged(object sender, EventArgs e) => DrawMeshChanged?.Invoke(sender, e);

        private void OnModifyWithNormalMapChanged(object sender, EventArgs e)
        {
            ChangeNormalMapButton.Enabled = NormalMapCheckBox.Checked;
            ModifyWithNormalMapChanged?.Invoke(sender, NormalMapCheckBox.Checked);
        }

        private void OnChangeNormalMapButtonClick(object sender, EventArgs e)
        {
            if (ShowOpenImageDialog() == DialogResult.OK)
            {
                NormalMapChanged?.Invoke(sender, OpenImageDialog.FileName);
            }
        }

        private void OnLoadSurfaceButtonClick(object sender, EventArgs e)
        {
            if (ShowOpenObjDialog() == DialogResult.OK)
            {
                LoadedSurfaceFilename = Path.GetFileName(OpenObjDialog.FileName);
                LoadedSurfaceFileChanged?.Invoke(sender, OpenObjDialog.FileName);
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _animationAngle += _animationStep;
            _animationAngle %= 2 * Math.PI;

            LightPosition = new()
            {
                X = R * (float)Math.Cos(_animationAngle) + CanvasSize.Width / 2,
                Y = R * (float)Math.Sin(_animationAngle) + CanvasSize.Height / 2,
                Z = LightPosition.Z
            };

            LightPositionChanged?.Invoke(sender, e);
        }

        private DialogResult ShowOpenImageDialog()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            OpenImageDialog.InitialDirectory = @path;
            OpenImageDialog.Filter = "Image Files (*.bmp, *.jpg, *.png) | *.bmp;*.jpg;*.png";
            return OpenImageDialog.ShowDialog();
        }

        private DialogResult ShowOpenObjDialog()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            OpenObjDialog.InitialDirectory = @path;
            OpenObjDialog.Filter = "Surface Files (*.obj) | *.obj";
            return OpenObjDialog.ShowDialog();
        }
        #endregion
    }
}
