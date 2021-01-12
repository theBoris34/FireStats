using FireStats.WPF.Infrastructure.Commands;
using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services;
using FireStats.WPF.Services.Interfaces;
using FireStats.WPF.ViewModels.Base;
using FireStats.WPF.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace FireStats.WPF.ViewModels
{
    class EmployeesManagmentViewModel : ViewModel
    {
        private readonly EmployeesManagment _EmployeesManagment;
        private readonly IUserDialogService _UserDialog;
       
        #region Title : string - Заголовок окна
        /// <summary>
        /// Заголовок окна
        /// </summary>
        private string _Title = "Редактирование личного состава";

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

       
        //private void OnEmployeesFilter(object sender, FilterEventArgs e)
        //{
        //    if (!(e.Item is Employee employee))
        //    {
        //        e.Accepted = false;
        //        return;
        //    }
        //    //var filter_text = _EmployesFilterText;
        //    if (string.IsNullOrWhiteSpace(filter_text)) return;
        //    if (employee.Name is null || employee.Surname is null || employee.Patronymic is null)
        //    {
        //        e.Accepted = false;
        //        return;
        //    }

        //    if (filter_text.Length == 0) return;

        //    if (employee.Name.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
        //    if (employee.Surname.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
        //    if (employee.Patronymic.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
        //    if (employee.Rank.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
        //    if (employee.Position.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;
        //    if (employee.Note != null && employee.Note.IndexOf(filter_text, StringComparison.OrdinalIgnoreCase) >= 0) return;

        //    e.Accepted = false;

        //}

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
                Set(ref _SelectedDivision, value);
                //if (!Set(ref _SelectedDivision, value)) return;
                //_SelecedDivisionEmployees.Source = value?.Employees;
                //OnPropertyChanged(nameof(SelecedDivisionEmployees));
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

        //private string _EmployesFilterText;

        //public string EmployesFilterText
        //{
        //    get => _EmployesFilterText;
        //    set
        //    {
        //        if (!Set(ref _EmployesFilterText, value)) return;
        //        _SelecedDivisionEmployees.View.Refresh(); //System.NullReferenceException: "Ссылка на объект не указывает на экземпляр объекта."
        //    }
        //}

        #endregion

        #region Команды

        #region EditEmployeeCommand - Команда редактирования сотрудника
        private ICommand _EditEmployeeCommand;

        public ICommand EditEmployeeCommand => _EditEmployeeCommand ??= new LambdaCommand(OnEditEmployeeCommandExecuted, CanEditEmployeeCommandExecute);

        private static bool CanEditEmployeeCommandExecute(object p) => p is Employee;

        private void OnEditEmployeeCommandExecuted(object p)
        {
            var employee = (Employee)p;

            if(_UserDialog.Edit(p))
            {
                _EmployeesManagment.Update((Employee)p);
                _UserDialog.ShowInformation("Сотрудник отредактирован!", "Редактирование сотрудников");
                OnPropertyChanged(nameof(Employees));
            }
            else
                _UserDialog.ShowWarning("Сотрудник не отредактирован!", "Редактирование сотрудников");

        }
        #endregion 

        #region CreateEmployeeCommand - Команда создания сотрудника
        private ICommand _CreateEmployeeCommand;

        public ICommand CreateEmployeeCommand => _CreateEmployeeCommand ??= new LambdaCommand(OnCreateEmployeeCommandExecuted, CanCreateEmployeeCommandExecute);

        private static bool CanCreateEmployeeCommandExecute(object p) => p is Division;

        private void OnCreateEmployeeCommandExecuted(object p)
        {
            var division = (Division)p;

            var employee =  new Employee();

            if (!_UserDialog.Edit(employee) || _EmployeesManagment.Create(employee, division.Name))
            {
                OnPropertyChanged(nameof(Employees));
                return;
            }
            
            if (_UserDialog.Confirm("Не удалось создать сотрудника. Повторить?", "Создать сотрудника"))
                    OnCreateEmployeeCommandExecuted(p);
           
        }
        #endregion
        #endregion


        public IEnumerable<Employee> Employees => _EmployeesManagment.Employees;

        public IEnumerable<Division> Divisions => _EmployeesManagment.Divisions;

        public EmployeesManagmentViewModel(EmployeesManagment EmployeesManager, IUserDialogService UserDialog)
        {
            #region Команды
            //EditEmployeeCommand = new LambdaCommand(OnEditEmployeeCommandExecuted, CanEditEmployeeCommandExecute);
            #endregion

            _EmployeesManagment = EmployeesManager;
            _UserDialog = UserDialog;
        }
    }
}
