using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.ViewModels
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<ShowFirePageViewModel>();
            services.AddSingleton<WindowFireStatsViewModel>();
            services.AddSingleton<WebServerViewModel>();

            return services;
        }
    }
}
