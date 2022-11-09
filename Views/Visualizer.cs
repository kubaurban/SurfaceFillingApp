using Views.Abstract;

namespace View
{
    public partial class Visualizer : Form, IVisualizer
    {
        public Form Form => this;

        public Visualizer()
        {
            InitializeComponent();
        }
    }
}
