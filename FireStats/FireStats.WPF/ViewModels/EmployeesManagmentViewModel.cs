using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services;
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
        private readonly EmployeesManagment _EmployeesManager;
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

        public IEnumerable<Employee> Employees => _EmployeesManager.Employees;

        public IEnumerable<Division> Divisions => _EmployeesManager.Divisions;

        public EmployeesManagmentViewModel(EmployeesManagment EmployeesManager) => _EmployeesManager = EmployeesManager;
    }
}
