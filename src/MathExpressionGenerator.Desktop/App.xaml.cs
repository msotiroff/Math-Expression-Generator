namespace MathExpressionGenerator.Desktop
{
    using Common.Containers;
    using Microsoft.Extensions.DependencyInjection;
    using Models.Factories.Implementations;
    using Models.Factories.Interfaces;
    using Services.Implementations;
    using Services.Interfaces;
    using System;
    using System.Text;
    using System.Windows;

    public partial class App : Application
    {
        private IServiceProvider serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            this.serviceProvider = this.ConfigureServices();

            var currentDomain = AppDomain.CurrentDomain;

            currentDomain.UnhandledException += 
                new UnhandledExceptionEventHandler(TerminatingHandler);

            var mainWindow = this.serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ILanguageContainer, LanguageContainer>();

            services.AddTransient<MainWindow>();
            services.AddTransient<IMathExpressionService, MathExpressionService>();
            services.AddTransient<IExpressionExtractor, ExpressionExtractor>();
            services.AddTransient<IExpressionContainer, ExpressionContainer>();
            services.AddTransient<IMathExpressionFactory, MathExpressionFactory>();
            services.AddTransient<IFileService, FileService>();

            services.AddTransient(typeof(Random), sp => new Random());
            services.AddTransient(typeof(StringBuilder), sp => new StringBuilder());

            return services.BuildServiceProvider();
        }

        private void TerminatingHandler(object sender, UnhandledExceptionEventArgs e)
        {
            var messageBase = "Something went wrong.";
            var ex = (Exception)e.ExceptionObject;
            var success = false;

            this.ShowMessageBoxAndExit(messageBase, success);
        }

        private void ShowMessageBoxAndExit(string messageBase, bool isSuccess)
        {
            var message = isSuccess
                ? $"{messageBase} An error report has been sent to the application administrator."
                : messageBase;

            MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

            Environment.Exit(0);
        }
    }
}
