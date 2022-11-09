using Views.Abstract;
using Views.Enums;
using Views.Helpers;

namespace Views
{
    public partial class Visualizer : Form, IVisualizer
    {
        private bool _isAnimation;
        private float _kd;
        private float _ks;
        private int _m;
        private int _z;

        private float Kd
        {
            get => _kd; set
            {
                _kd = value;
                kd_label.Text = $"kd: {Math.Round(_kd, 2)}";
            }
        }
        private float Ks
        {
            get => _ks; set
            {
                _ks = value;
                ks_label.Text = $"ks: {Math.Round(_ks, 2)}";
            }
        }
        private int M
        {
            get => _m; set
            {
                _m = value;
                m_label.Text = $"m: {_m}";
            }
        }
        private int Z
        {
            get => _z; set
            {
                _z = value;
                z_label.Text = $"z: {_z}";
            }
        }

        public event ValueChangedEventHandler<float> KdChanged;
        public event ValueChangedEventHandler<float> KsChanged;
        public event ValueChangedEventHandler<int> MChanged;
        public event ValueChangedEventHandler<int> ZChanged;

        public Form Form => this;
        private Bitmap DrawArea { get; }
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
            PictureBox.Image = DrawArea;

            DefaultColor = Color.Black;

            kdTrackBar.ValueChanged += OnKdChanged;
            ksTrackBar.ValueChanged += OnKsChanged;
            mTrackBar.ValueChanged += OnMChanged;
            zTrackBar.ValueChanged += OnZChanged;

            InitDefaultState();
        }

        private void InitDefaultState()
        {
            _isAnimation = false;
            SolidColorButton.Checked = true;
            FromVerticesButton.Checked = true;
        }

        #region Drawing functions
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
        #endregion

        #region User action handlers
        private void OnKdChanged(object sender, EventArgs e)
        {
            Kd = (float)kdTrackBar.Value / kdTrackBar.Maximum;
            KdChanged?.Invoke(sender, new ValueChangedEventArgs<float>(Kd));
        }

        private void OnKsChanged(object sender, EventArgs e)
        {
            Ks = (float)ksTrackBar.Value / ksTrackBar.Maximum;
            KsChanged?.Invoke(sender, new ValueChangedEventArgs<float>(Ks));
        }

        private void OnMChanged(object sender, EventArgs e)
        {
            M = mTrackBar.Value * 100 / mTrackBar.Maximum;
            MChanged?.Invoke(sender, new ValueChangedEventArgs<int>(M));
        }

        private void OnZChanged(object sender, EventArgs e)
        {
            Z = zTrackBar.Value * 250 / zTrackBar.Maximum;
            ZChanged?.Invoke(sender, new ValueChangedEventArgs<int>(Z));
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
