using FireStats.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.ViewModels
{
    class EmployeesManagmentViewModel : ViewModel
    {
        #region Title : string - Заголовок окна
        /// <summary>
        /// Заголовок окна
        /// </summary>
        private string _Title = "Управление сотрудниками";

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title { get => _Title; set => Set(ref _Title, value); } 
        #endregion

    }
}
