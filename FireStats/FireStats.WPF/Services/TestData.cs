using FireStats.WPF.Models.Base;
using FireStats.WPF.Models.Departments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FireStats.WPF.Services
{
    /// <summary> Тестовые данные сотрудников и подразделений. </summary>
    static class TestData
    {

        public static Division[] Divisions { get; } = Enumerable
            .Range(1, 10)
            .Select(i => new Division
            {
                Name = $"Подразделение {i}",
                Employees = new ObservableCollection<Employee>(),
                Units = new ObservableCollection<Unit>()
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

        public static Unit[] Units { get; } = CreateUnit(Divisions);

        private static Unit[] CreateUnit(Division[] divisions)
        {
            var unit_id = 1;
            var units = new List<Unit>(20);

            foreach(var division in divisions)
                for(var i=0; i<2;i++)
                {
                    division.Units.Add(new Unit
                    {
                        Active = true,
                        InDivision = true,
                        Truck = new Truck
                        {
                            Driver = division.Employees.First(),
                            Crew = new ObservableCollection<Employee>() { division.Employees.Last() },
                            Type = $"Автомобиль пожарный {unit_id}",
                            Water = unit_id + 100,
                            Foam = unit_id + 50,
                            WaterSupply = 10* unit_id++
                        }
                    }); 
                }
            return divisions.SelectMany(u => u.Units).ToArray();
        }
    }
}
