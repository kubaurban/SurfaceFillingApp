using Microsoft.Practices.Unity;
using SurfaceFillingApp.Abstract;
using System.Windows.Forms;
using View;
using Views.Abstract;

namespace SurfaceFillingApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var container = new UnityContainer();
            container.RegisterType<ICanvas, Canvas>();
            container.RegisterType<IVisualizer, Visualizer>();

            var canvas = container.Resolve<Canvas>();
            Application.Run(canvas.GetForm());
        }
    }
}