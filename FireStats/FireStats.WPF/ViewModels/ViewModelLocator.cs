using Microsoft.Extensions.DependencyInjection;

namespace FireStats.WPF.ViewModels
{
    internal class ViewModelLocator
    {
        public WindowFireStatsViewModel FireStatsModel => App.Host.Services.GetRequiredService<WindowFireStatsViewModel>();
        public EmployeesManagmentViewModel EmployeesManagment => App.Host.Services.GetRequiredService<EmployeesManagmentViewModel>();
        public ShowFirePageViewModel ShowFirePage => App.Host.Services.GetRequiredService<ShowFirePageViewModel>();
        public EmployeeListPageViewModel EmployeeListPage => App.Host.Services.GetRequiredService<EmployeeListPageViewModel>();

        #region Страницы - тест

        //public EnterFirePageModel EnterFirePage => App.Host.Services.GetRequiredService<EnterFirePageModel>();
        //public EmployeesManagmentViewModel EmployeesManagment => App.Host.Services.GetRequiredService<EmployeesManagmentViewModel>();
        //public EmployeesManagmentViewModel EmployeesManagment => App.Host.Services.GetRequiredService<EmployeesManagmentViewModel>();
        //public EmployeesManagmentViewModel EmployeesManagment => App.Host.Services.GetRequiredService<EmployeesManagmentViewModel>();
        //public EmployeesManagmentViewModel EmployeesManagment => App.Host.Services.GetRequiredService<EmployeesManagmentViewModel>();
        //public EmployeesManagmentViewModel EmployeesManagment => App.Host.Services.GetRequiredService<EmployeesManagmentViewModel>();


        #endregion


    }
}
