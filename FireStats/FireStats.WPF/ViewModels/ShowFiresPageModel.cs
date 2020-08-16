using FireStats.WPF.Infrastructure.Commands;
using FireStats.WPF.Models.Location;
using FireStats.WPF.Services;
using FireStats.WPF.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace FireStats.WPF.ViewModels
{
    internal class ShowFiresPageModel : ViewModel
    {

        #region IEnumerable<AreaInfo> - Статистика по областям

        private IEnumerable<AreaInfo> _Areas;

        public IEnumerable<AreaInfo> Areas 
        { 
            get => _Areas;
            private set => Set(ref _Areas, value);
        }

        #endregion


        #region DataService 
        private DataService _DataService;
        private WindowFireStatsViewModel WindowFireStatsModel { get; } 
        #endregion

        #region Команды

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Areas = _DataService.GetData();
        }

        //private void CanRefreshDataCommandExecute(object p) => true;    

        #endregion




        public ShowFiresPageModel(WindowFireStatsViewModel WindowFireStatsModel)
        {
            this.WindowFireStatsModel = WindowFireStatsModel;
            _DataService = new DataService();
            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
        }
        
    }
}
