using FireStats.WPF.Infrastructure.Commands;
using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services;
using FireStats.WPF.Services.Interfaces;
using FireStats.WPF.Services.Repositories;
using FireStats.WPF.ViewModels.Base;
using FireStats.WPF.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace FireStats.WPF.ViewModels
{
    internal class EmployeeListPageViewModel : ViewModel
    {
        private readonly IDataService _DataService;
        public WindowFireStatsViewModel MainModel { get; internal set; }

        private readonly EmployeesManagment _EmployeesManager;

        #region Команды

        #region ManagmentEmployeesCommand
        private EmployeesManagmentWindow _ManagmentEmployees;

        public ICommand ManagmentEmployeesCommand { get; }

        private void OnManagmentEmployeesCommandExecuted(object p)
        {
            var ManagmentEmployees = new EmployeesManagmentWindow
            {
                Owner = Application.Current.MainWindow
            };
            _ManagmentEmployees = ManagmentEmployees;

            ManagmentEmployees.Closed += OnWindowClosed;

            ManagmentEmployees.ShowDialog();

        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnWindowClosed;
            _ManagmentEmployees = null;
        }

        private bool CanManagmentEmployeesCommandExecute(object p) => _ManagmentEmployees == null;
        #endregion

        #region SelecedDivisionEmployees
        private void OnEmployeesFilter(object sender, FilterEventArgs e)
         {
            if(!(e.Item is Employee employee))
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
                if(!Set(ref _EmployesFilterText, value))return;
                _SelecedDivisionEmployees.View.Refresh(); //System.NullReferenceException: "Ссылка на объект не указывает на экземпляр объекта."
            }
        }

        #endregion

        #endregion

        public IEnumerable<Employee> Employees => _EmployeesManager.Employees;
        public IEnumerable<Division> Divisions => _EmployeesManager.Divisions;
        

        public EmployeeListPageViewModel(IDataService DataService)
        {
            _DataService = DataService;
            _SelecedDivisionEmployees.Filter += OnEmployeesFilter;
            _SelecedDivisionEmployees.GroupDescriptions.Add(new PropertyGroupDescription("Position"));

            #region Команды           
            ManagmentEmployeesCommand = new LambdaCommand(OnManagmentEmployeesCommandExecuted, CanManagmentEmployeesCommandExecute);
            #endregion
                        
            var er = new EmployeeRepository();
            var dr = new DivisionRepository();
            _EmployeesManager = new EmployeesManagment(er ,dr);

        }

        
    }
}
