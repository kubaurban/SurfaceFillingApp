using SurfaceFillingApp.Abstract;
using System.Windows.Forms;
using Views.Abstract;

namespace SurfaceFillingApp
{
    internal class Canvas : ICanvas
    {
        private IVisualizer _visualizer;

        public Canvas(IVisualizer visualizer)
        {
            _visualizer = visualizer;
        }

        public Form GetForm() => _visualizer.Form;
    }
}
