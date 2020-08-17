using FireStats.WPF.Services.Interfaces;
using FireStats.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FireStats.WPF.Services
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();
            services.AddTransient<IAsyncDataService, AsyncDataService>();

            return services;
        }
    }
}
