﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace FireStats.WPF
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] Args)
        {
            var host_builder = Host.CreateDefaultBuilder(Args);

            host_builder.UseContentRoot(Environment.CurrentDirectory);

            host_builder.ConfigureAppConfiguration((host, cfg) =>
            {
                cfg.SetBasePath(Environment.CurrentDirectory);
                cfg.AddJsonFile("appsetings.json", optional: true, reloadOnChange: true);
            });

            host_builder.ConfigureServices(App.ConfigureServices);

            return host_builder;
        }
    }
}
