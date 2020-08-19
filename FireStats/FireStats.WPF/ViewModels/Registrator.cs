using FireStats.WPF.Services;
using FireStats.WPF.Services.Interfaces;
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

            services.AddSingleton<WindowFireStatsViewModel>();

            services.AddSingleton<WebServerViewModel>();
            services.AddSingleton<ShowFirePageViewModel>();
            services.AddSingleton<EmployeeListPageViewModel>();
            services.AddSingleton<EmployeesManagmentViewModel>();
            

            //services.AddTransient<IDataService, DataService>();
            //services.AddScoped<IDataService, DataService>();

            services.AddTransient<IAsyncDataService, AsyncDataService>();
            services.AddTransient<IWebServerService, HttpListenerWebServer>();

            services.AddSingleton<EmployeeRepository>();
            services.AddSingleton<DivisionRepository>();
            services.AddSingleton<EmployeesManagment>();

            //services.AddTransient<IUserDialogService, WindowsUserDialogService>();

            return services;
        }
    }
}
