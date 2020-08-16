using FireStats.WPF.Infrastructure.Commands;
using FireStats.WPF.Models.Departments;
using FireStats.WPF.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace FireStats.WPF.ViewModels
{
    internal class EmployeeListPageViewModel : ViewModel
    {

        #region Команды

        #region CreateDivisionCommand
        public ICommand CreateDivisionCommand { get; }

        private void OnCreateDivisionCommandExecuted(object p)
        {
            var division_max_index = Divisions.Count + 1;
            var new_division = new Division
            {
                Name = $"Подразделение {division_max_index}",
                Employees = new ObservableCollection<Employee>()
            };
            Divisions.Add(new_division);

        }
        private bool CanCreateDivisionCommandExecute(object p) => true;
        #endregion

        #region DeleteDivisionCommand
        public ICommand DeleteDivisionCommand { get; }

        private void OnDeleteDivisionCommandExecuted(object p)
        {
            if (!(p is Division division)) return;
            var division_index = Divisions.IndexOf(division);
            Divisions.Remove(division);
            if (division_index < Divisions.Count)
                SelectedDivision = Divisions[division_index];

        }
        private bool CanDeleteDivisionCommandExecute(object p) => p is Division division && Divisions.Contains(division);
        #endregion

        #region CreateEmployeeCommand
        public ICommand CreateEmployeeCommand { get; }

        private void OnCreateEmployeeCommandExecuted(object p)
        {
            int employee_max_index = 80;
            var new_employee = new Employee
            {
                Name = $"Имя {employee_max_index}",
                Surname = $"Фамилия {employee_max_index}",
                Patronymic = $"Отчество {employee_max_index}",
                Birthday = DateTime.Now,
                Position = $"Должность {employee_max_index}",
                Rank = $"Звание {employee_max_index}"
            };
            SelectedDivision.Employees.Add(new_employee);

        }
        private bool CanCreateEmployeeCommandExecute(object p) => SelectedDivision is Division;
        #endregion

        #region DeleteEmployeeCommand
        public ICommand DeleteEmployeeCommand { get; }

        private void OnDeleteEmployeeCommandExecuted(object p)
        {
            if (!(p is Employee employee)) return;
            SelectedDivision.Employees.Remove(employee);
        }
        private bool CanDeleteEmployeeCommandExecute(object p) => p is Employee employee && SelectedDivision.Employees.Contains(employee);
        #endregion

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
                _SelecedDivisionEmployees.View.Refresh();
            }
        }

        #endregion

        public ObservableCollection<Division> Divisions { get; }

        public EmployeeListPageViewModel()
        {


            #region Команды
            CreateDivisionCommand = new LambdaCommand(OnCreateDivisionCommandExecuted, CanCreateDivisionCommandExecute);
            DeleteDivisionCommand = new LambdaCommand(OnDeleteDivisionCommandExecuted, CanDeleteDivisionCommandExecute);
            CreateEmployeeCommand = new LambdaCommand(OnCreateEmployeeCommandExecuted, CanCreateEmployeeCommandExecute);
            DeleteEmployeeCommand = new LambdaCommand(OnDeleteEmployeeCommandExecuted, CanDeleteEmployeeCommandExecute);
            #endregion

            var employees_id = 1;
            var employees = Enumerable.Range(1, 7).Select(i => new Employee
            {
                Name = $"Имя {employees_id}",
                Surname = $"Фамилия {employees_id}",
                Patronymic = $"Отчество {employees_id}",
                Birthday = DateTime.Now,
                Position = $"Должность {employees_id}",
                Rank = $"Звание {employees_id++}"

            });
            var divisions = Enumerable.Range(1, 10).Select(i => new Division 
            {
                Name = $"Подразделение {i}",
                Employees = new ObservableCollection<Employee>(employees)
            });

            Divisions = new ObservableCollection<Division>(divisions);

            _SelecedDivisionEmployees.Filter += OnEmployeesFilter;
            _SelecedDivisionEmployees.GroupDescriptions.Add(new PropertyGroupDescription("Position"));
        }

        
    }
}
