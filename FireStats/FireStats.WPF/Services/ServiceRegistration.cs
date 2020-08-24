using FireStats.WPF.Services.Interfaces;
using FireStats.WPF.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FireStats.WPF.Services
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.AddSingleton<IDataService, DataService>();
            services.AddTransient<IAsyncDataService, AsyncDataService>();
            services.AddTransient<IWebServerService, HttpListenerWebServer>();
            services.AddSingleton<EmployeeRepository>();
            services.AddSingleton<DivisionRepository>();
            services.AddSingleton<EmployeesManagment>();
            services.AddSingleton<IUserDialogService,WindowsUserDialogService>();

            return services;
        }
    }
}
