using Microsoft.Extensions.DependencyInjection;

namespace FireStats.WPF.ViewModels
{
    internal class ViewModelLocator
    {
        public WindowFireStatsViewModel FireStatsModel => App.Host.Services.GetRequiredService<WindowFireStatsViewModel>();
    }
}
