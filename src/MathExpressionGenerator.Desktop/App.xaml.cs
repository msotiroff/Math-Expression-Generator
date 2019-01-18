namespace MathExpressionGenerator.Desktop
{
    using Common.Containers;
    using Models.Factories.Implementations;
    using Models.Factories.Interfaces;
    using Services.Implementations;
    using Services.Interfaces;
    using System;
    using System.Text;
    using System.Windows;
    using Unity;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            
            this.AddServices(container);

            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(TerminatingHandler);

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void TerminatingHandler(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Oops, something went wrong.", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

            Environment.Exit(0);
        }

        private void AddServices(IUnityContainer container)
        {
            container.RegisterSingleton<ILanguageContainer, LanguageContainer>();

            container.RegisterType<IMathExpressionService, MathExpressionService>();
            container.RegisterType<IExpressionExtractor, ExpressionExtractor>();
            container.RegisterType<IExpressionContainer, ExpressionContainer>();
            container.RegisterType<IMathExpressionFactory, MathExpressionFactory>();
            container.RegisterType<IFileService, FileService>();
            
            container.RegisterInstance(typeof(Random), new Random());
            container.RegisterInstance(typeof(StringBuilder), new StringBuilder());
        }
    }
}
