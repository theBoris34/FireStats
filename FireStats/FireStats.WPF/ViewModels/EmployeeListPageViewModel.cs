using FireStats.WPF.Models.Departments;
using FireStats.WPF.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FireStats.WPF.ViewModels
{
    internal class EmployeeListPageViewModel : ViewModel
    {

        private Division _SelectedDivision;
        /// <summary>
        /// Текущая страница.
        /// </summary>
        public Division SelectedDivision
        {
            get { return _SelectedDivision; }
            set
            {
                Set(ref _SelectedDivision, value);
            }
        }

        public string TESTING = "ТАСТОВАЯ ФРАЗА";
        public ObservableCollection<Division> Divisions { get; }

        public EmployeeListPageViewModel()
        {
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
            

        }
    }
}
