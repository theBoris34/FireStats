using FireStats.WPF.Services;
using FireStats.WPF.Services.Interfaces;
using FireStats.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Windows;

namespace FireStats.WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesignMode { get; private set; } = true;

        private static IHost __Host;

        public static IHost Host => __Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;
            var host = Host;
            base.OnStartup(e);

            await host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            var host = Host;
            await host.StartAsync().ConfigureAwait(false);
            host.Dispose();
            __Host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
                .RegisterServices()
                .RegisterViewModels();

        public static string CurrentDirectory => IsDesignMode 
            ? Path.GetDirectoryName(GetSourceCodePath()) 
            : Environment.CurrentDirectory;

        private static string GetSourceCodePath([CallerFilePath] string Path = null) => Path;
    }
}
