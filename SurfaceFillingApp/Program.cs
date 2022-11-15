using Microsoft.Practices.Unity;
using Models.Abstract;
using Models.Repository;
using Services;
using Services.Abstract;
using SurfaceFillingApp.Abstract;
using System.Windows.Forms;
using Views;
using Views.Abstract;

namespace SurfaceFillingApp
{
    internal static class Program
    {
        private const string _pathToObj = "../../../../donut.obj";

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
            container.RegisterType<IShapeManager, ShapeManager>(new ContainerControlledLifetimeManager());
            container.RegisterType<IShapeParser, ShapeParser>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICanvas, Canvas>(new ContainerControlledLifetimeManager());
            container.RegisterType<IVisualizer, Visualizer>(new ContainerControlledLifetimeManager());
            container.RegisterType<IFillingService, FillingService>(new ContainerControlledLifetimeManager());

            var parser = container.Resolve<IShapeParser>();
            parser.LoadObj(_pathToObj);

            var canvas = container.Resolve<ICanvas>();
            Application.Run(canvas.GetForm());
        }
    }
}