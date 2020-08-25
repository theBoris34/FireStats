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
                        Employees = new ObservableCollection<Employee>() { division.Employees.Last() },
                        Truck = new Truck
                        {
                            Type = $"Автомобиль пожарный {unit_id}",
                            Water = unit_id + 100,
                            Foam = unit_id + 50,
                            WaterSupply = 10* unit_id++
                        }
                    }); 
                }
            return divisions.SelectMany(u => u.Units).ToArray();
        }

        public static void AddToDB()
        {
            using (var context = new DataBaseContext())
            {
                var FireCar = new Truck
                {
                    Type = "Автоцистерна пожарная",
                    Number = "A100AA178",
                    Water = 100,
                    Foam = 50,
                    WaterSupply = 10 * 50
                };
                var employees_id = 1;
                var unit_id = 1;
                var random = new Random();

                var deprtments = Enumerable
                   .Range(1, 3)
                   .Select(i => new Department
                   {
                       Name = $"управление {i}",
                       Divisions = new ObservableCollection<Division>()
                   })
                   .ToArray();

                context.Departments.AddRange(deprtments);
                context.SaveChanges();

                foreach (var deprtment in deprtments)
                {
                    for (var i = 0; i < 10; i++)
                    {
                        deprtment.Divisions.Add(new Division
                        {
                            Name = $"Подразделение {i}",
                            Employees = new ObservableCollection<Employee>(),
                            Units = new ObservableCollection<Unit>()
                        });

                        for (var j = 0; j < 10; j++)
                        {
                            deprtment.Divisions.Last().Employees.Add(new Employee
                            {
                                Name = $"Имя {employees_id}",
                                Surname = $"Фамилия {employees_id}",
                                Patronymic = $"Отчество {employees_id}",
                                Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 * random.Next(19, 30))),
                                Position = $"Должность {employees_id++}",
                                Phone = $"8-981-881-{random.Next(1000, 9999)}",
                                Rank = $"Звание {random.Next(1, 100)}"

                            });
                            context.Divisions.AddRange(deprtment.Divisions);
                        }
                        foreach(var division in deprtment.Divisions)
                        {
                            division.Units.Add(new Unit
                                {
                                    Employees = new ObservableCollection<Employee> { division.Employees.Last(), division.Employees.First() },
                                    Truck = FireCar
                                });
                        }
                    }
                    context.SaveChanges();
                }
                //        //for (var j = 0; j < 2; j++)
                //        //{
                //        //    division.Units.Add(new Unit
                //        //    {
                //        //        Active = true,
                //        //        InDivision = true,
                //        //        Employees = new ObservableCollection<Employee>() { division.Employees.Last() },
                //        //        Truck = new Truck
                //        //        {
                //        //           
                //        //        }
                //        //    });
                //        //    //context.Units.Add(division.Units.Last<Unit>());
                //        //    //context.Trucks.Add(Units.Last().Truck);
                //        //}
                //    }
                //    context.Employees.AddRange(division.Employees);

                //}
                //context.SaveChanges();
            }
        }
    }
}
