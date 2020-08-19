using FireStats.WPF.Infrastructure.Commands;
using FireStats.WPF.Models.Location;
using FireStats.WPF.Services;
using FireStats.WPF.Services.Interfaces;
using FireStats.WPF.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace FireStats.WPF.ViewModels
{
    internal class ShowFirePageViewModel : ViewModel
    {
        private readonly IDataService _DataService;

        public WindowFireStatsViewModel MainModel { get; internal set; }


        #region IEnumerable<AreaInfo> - Статистика по областям

        private IEnumerable<AreaInfo> _Areas;

        public IEnumerable<AreaInfo> Areas
        {
            get => _Areas;
            private set => Set(ref _Areas, value);
        }

        #endregion


        #region AreaInfo - Выбранная область

        private AreaInfo _SelectedArea;

        public AreaInfo SelectedArea
        {
            get => _SelectedArea;
            set => Set(ref _SelectedArea, value);
        }

        #endregion

      


        #region Команды

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Areas = _DataService.GetData();
        }

        //private void CanRefreshDataCommandExecute(object p) => true;    

        #endregion

        /// <summary>
        /// Отладочный конструктор, используемый в визуальном дизайнере.
        /// </summary>
        //public ShowFirePageViewModel():this(null)
        //{
        //    
        //   if (!App.IsDesignMode)
        //        throw new InvalidOperationException("Вызов конструктора, непредназначенного для использования в обычном режиме!");

        //    _Areas = Enumerable.Range(1, 10)
        //        .Select(i => new AreaInfo
        //        {
        //            Name = $"Area|Область {i}",
        //            Districts = Enumerable.Range(1, 10).Select(j => new PlaceInfo
        //            {
        //                Name = $"District|Район {j}",
        //                Location = new Point(i, j),
        //                Counts = Enumerable.Range(1,10).Select(k=> new ConfirmedCount 
        //                {
        //                    Date =  DateTime.Now.Subtract(TimeSpan.FromDays(100-k)),
        //                    Count = k
        //                }).ToArray()
        //            }).ToArray()
        //        }).ToArray(); 
            
        //}



        public ShowFirePageViewModel(IDataService DataService)
        {
            
            _DataService = DataService;


            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
        }
    }
}
