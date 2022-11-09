using Views.Abstract;

namespace Views
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
