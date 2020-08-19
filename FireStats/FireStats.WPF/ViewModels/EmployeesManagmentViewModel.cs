using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services;
using FireStats.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

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

        #region SelecedDivisionEmployees
        private void OnEmployeesFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Employee employee))
            {
                e.Accepted = false;
                return;
            }
            var filter_text = _EmployesFilterText;
            if (string.IsNullOrWhiteSpace(filter_text)) return;
            if (employee.Name is null || employee.Surname is null || employee.Patronymic is null)
            {
                e.Accepted = false;
                return;
            }

            if (filter_text.Length == 0) return;

            if (employee.Name.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
            if (employee.Surname.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
            if (employee.Patronymic.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
            if (employee.Rank.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
            if (employee.Position.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
            if (employee.Note != null && employee.Note.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;

            e.Accepted = false;

        }
        private CollectionViewSource _SelecedDivisionEmployees = new CollectionViewSource();
        public ICollectionView SelecedDivisionEmployees => _SelecedDivisionEmployees?.View;
        #endregion

        #region SelectedDivision
        private Division _SelectedDivision;
        /// <summary>
        /// Выбранное подразделение.
        /// </summary>
        public Division SelectedDivision
        {
            get { return _SelectedDivision; }
            set
            {
                if (!Set(ref _SelectedDivision, value)) return;
                _SelecedDivisionEmployees.Source = value?.Employees;
                OnPropertyChanged(nameof(SelecedDivisionEmployees));
            }
        }
        #endregion

        #region SelectedEmployee
        private Employee _SelectedEmployee;
        /// <summary>
        /// Выбранный сотрудник.
        /// </summary>
        public Employee SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                Set(ref _SelectedEmployee, value);
            }
        }

        #endregion

        #region EmployesFilterText

        private string _EmployesFilterText;

        public string EmployesFilterText
        {
            get => _EmployesFilterText;
            set
            {
                if (!Set(ref _EmployesFilterText, value)) return;
                _SelecedDivisionEmployees.View.Refresh(); //System.NullReferenceException: "Ссылка на объект не указывает на экземпляр объекта."
            }
        }

        #endregion


        public IEnumerable<Employee> Employees => _EmployeesManager.Employees;

        public IEnumerable<Division> Divisions => _EmployeesManager.Divisions;

        public EmployeesManagmentViewModel(EmployeesManagment EmployeesManager) => _EmployeesManager = EmployeesManager;
    }
}
