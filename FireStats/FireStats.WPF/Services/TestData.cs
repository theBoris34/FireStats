using FireStats.WPF.Models.Departments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Services
{
    /// <summary>
    /// Тестовые данные работников.
    /// </summary>
    static class TestData
    {


        public static Division[] Divisions { get; } = Enumerable
            .Range(1, 10)
            .Select(i => new Division 
            { 
                Name = $"Подразделение {i}",
                Employees = new ObservableCollection<Employee>(),
            })
            .ToArray();

        public static Employee[] Employees { get; } = CreateEmployees(Divisions);

        private static Employee[] CreateEmployees(Division[] divisions)
        {
            var random = new Random();
            var employees_id = 1;
            var employees = new List<Employee>(100);

            foreach (var division in divisions)
                for (var i = 0; i < 10; i++) 
                {
                    
                    division.Employees.Add(new Employee
                    {
                        Name = $"Имя {employees_id}",
                        Surname = $"Фамилия {employees_id}",
                        Patronymic = $"Отчество {employees_id}",
                        Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 * random.Next(19, 30))),
                        Position = $"Должность {employees_id++}",
                        Rank = $"Звание {random.Next(1, 100)}"
                    });
                }
            return divisions.SelectMany(d => d.Employees).ToArray();
        }
    }
}
