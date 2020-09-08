using FireStats.WPF.Models.Applicants;
using FireStats.WPF.Models.Base;
using FireStats.WPF.Models.Departments;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FireStats.WPF.Services
{
    /// <summary> Тестовые данные сотрудников и подразделений. </summary>
    static class TestData
    {
        static Random rnd = new Random();
        public static Department[] Departments { get; } = Enumerable
         .Range(1, 5)
         .Select(i => new Department
         {
             Name = $"Управление {i}",
             Divisions = Enumerable
             .Range(1, 10)
             .Select(j => new Division
             {
                 Name = $"Подразделение {i}",
                 Employees = Enumerable
                 .Range(1,10)
                 .Select(e => new Employee
                 {
                     Name = $"Имя {e.ToString()}",
                     Surname = $"Фамилия {e.ToString()}",
                     Patronymic = $"Отчество {e.ToString()}",
                     Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 *rnd.Next(19, 30))),
                     Position = $"Должность {e.ToString()}",
                     Rank = $"Звание {rnd.Next(1, 100)}"
                 }
                 ).ToArray(),

                 Units = Enumerable
                 .Range(1,2)
                 .Select(u => new Unit
                 {
                     Active = true,
                     InDivision = true,
                     Staff = new ObservableCollection<Employee> { },
                     Truck = new Truck
                     {
                         Type = $"Автомобиль пожарный {u.ToString()}",
                         Water = 100,
                         Foam = 50,
                         WaterSupply = 10 * 30
                     }
                 }).ToArray()
             }).ToArray(),
         })
         .ToArray();

        //public static Division[] Divisions { get; } = CreateDivision(Departments);

        //private static Division[] CreateDivision(Department[] departments)
        //{
        //    foreach (var deprtment in departments)
        //    {
        //        for (var i = 0; i < 10; i++)
        //        {
        //            deprtment.Divisions.Add(new Division
        //            {
        //                Name = $"Подразделение {i}",
        //                Employees = new ObservableCollection<Employee>(),
        //                Units = new ObservableCollection<Unit>()
        //            });
        //        }
        //    }
        //    return Departments.SelectMany(d => d.Divisions).ToArray();
        //}


        //public static Employee[] Employees { get; } = CreateEmployees(Divisions);

        //private static Employee[] CreateEmployees(Division[] divisions)
        //{
        //    var random = new Random();
        //    var employees_id = 1;
        //    var employees = new List<Employee>(100);

        //    foreach (var division in divisions)
        //        for (var i = 0; i < 10; i++)
        //        {

        //            division.Employees.Add(new Employee
        //            {
        //                Name = $"Имя {employees_id}",
        //                Surname = $"Фамилия {employees_id}",
        //                Patronymic = $"Отчество {employees_id}",
        //                Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 * random.Next(19, 30))),
        //                Position = $"Должность {employees_id++}",
        //                Rank = $"Звание {random.Next(1, 100)}"
        //            });
        //        }
        //    return divisions.SelectMany(d => d.Employees).ToArray();
        //}


        //public static Truck[] Trucks { get; } = CreateTruck();

        //private static Truck[] CreateTruck()
        //{
        //    var truck = Enumerable
        //           .Range(1, 3)
        //           .Select(i => new Truck
        //           {
        //               Type = "Автоцистерна пожарная",
        //               Number = "A100AA178",
        //               Water = 100,
        //               Foam = 50,
        //               WaterSupply = 10 * 50
        //           })
        //           .ToArray();
        //    return truck.ToArray();
        //}



        //public static Unit[] Units { get; } = CreateUnit(Divisions);

        //private static Unit[] CreateUnit(Division[] divisions)
        //{
        //    var unit_id = 1;

        //    foreach (var division in divisions)
        //        for (var i = 0; i < 2; i++)
        //        {
        //            division.Units.Add(new Unit
        //            {
        //                Active = true,
        //                InDivision = true,
        //                Staff = new ObservableCollection<Employee>() { division.Employees.Last() },
        //                Truck = new Truck
        //                {
        //                    Type = $"Автомобиль пожарный {unit_id}",
        //                    Water = unit_id + 100,
        //                    Foam = unit_id + 50,
        //                    WaterSupply = 10 * unit_id++
        //                }
        //            });
        //        }
        //    return divisions.SelectMany(u => u.Units).ToArray();
        //}


        public static Fire[] Fires { get; } = Enumerable
            .Range(1, 8)
            .Select(i => new Fire
            {
                Adress = $"Адрес {i}",
                FireRank = $"Ранг {i}",
                DateAccident = DateTime.Now,
                TimeOfAccident = DateTime.Now,
                TimeOfCall = DateTime.Now,
                TimeOfArrival = DateTime.Now,
                TimeOfDeparture = DateTime.Now,
                WaterFeedTime = DateTime.Now,
                LocalizationTime = DateTime.Now,
                LiquidationTime = DateTime.Now,
                EndOfWorkTime = DateTime.Now,
                Applicants = new ObservableCollection<Applicant> {
                        new Applicant {
                            Name = $"Имя заявителя {i}",
                            Surname = $"Фамилия заявителя {i}",
                            Patronymic = $"Отчество заявителя {i}",
                            Phone = $" 8-910-900-{i}",
                            Birthday = DateTime.Now
                        } },
                Owner = $"Владелец объекта {i}",
                CauseOfFire = $"Причина пожара {i}",
                CostOfDamage = (ulong)(1000000 + i),
                LostInFire = $"Уничтоженно {i}",
                CostOfSalvage = (ulong)(1000000 - i),
                Injureds = new ObservableCollection<Injured> 
                {
                        new Injured {
                            Name = $"Имя заявителя {i}",
                            Surname = $"Фамилия заявителя {i}",
                            Patronymic = $"Отчество заявителя {i}",
                            IsDead = false,
                            Birthday = DateTime.Now
                        } 
                },
                Saved = $"Спасено {i}",
                FightingLeader = new ObservableCollection<Employee>
                {
                    new Employee
                    {
                        Name = $"Имя РТП",
                        Surname = $"Фамилия РТП",
                        Patronymic = $"Отчество РТП",
                        Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 *rnd.Next(19, 30))),
                        Position = $"Должность РТП",
                        Rank = $"Звание РТП"
                    }
                },
                FireInspector = new ObservableCollection<Employee>
                {
                        new Employee
                    {
                        Name = $"Имя Инспектор",
                        Surname = $"Фамилия Инспектор",
                        Patronymic = $"Отчество Инспектор",
                        Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 *rnd.Next(19, 30))),
                        Position = $"Должность Инспектор",
                        Rank = $"Звание Инспектор"
                    }
                }
            })
            .ToArray();
       

        /// <summary> Добавление данных в БД.  </summary>
        public static void AddToDB()
        {
            using (var context = new DataBaseContext())
            {
                context.Departments.AddRange(Departments);
                //context.Divisions.AddRange(Divisions);
                //context.Employees.AddRange(Employees);
                //context.Trucks.AddRange(Trucks);
                //context.Units.AddRange(Units);
                context.Fires.AddRange(Fires);

                context.SaveChanges();
            }

            //using (var context = new DataBaseContext())
            //{
            //    var FireCar = new Truck
            //    {
            //        Type = "Автоцистерна пожарная",
            //        Number = "A100AA178",
            //        Water = 100,
            //        Foam = 50,
            //        WaterSupply = 10 * 50
            //    };
            //    var employees_id = 1;
            //    var unit_id = 1;
            //    var random = new Random();

            //    var deprtments = Enumerable
            //       .Range(1, 3)
            //       .Select(i => new Department
            //       {
            //           Name = $"управление {i}",
            //           Divisions = new ObservableCollection<Division>()
            //       })
            //       .ToArray();

            //    context.Departments.AddRange(deprtments);
            //    context.SaveChanges();

            //    foreach (var deprtment in deprtments)
            //    {
            //        for (var i = 0; i < 10; i++)
            //        {
            //            deprtment.Divisions.Add(new Division
            //            {
            //                Name = $"Подразделение {i}",
            //                Employees = new ObservableCollection<Employee>(),
            //                Units = new ObservableCollection<Unit>()
            //            });

            //            for (var j = 0; j < 10; j++)
            //            {
            //                deprtment.Divisions.Last().Employees.Add(new Employee
            //                {
            //                    Name = $"Имя {employees_id}",
            //                    Surname = $"Фамилия {employees_id}",
            //                    Patronymic = $"Отчество {employees_id}",
            //                    Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 * random.Next(19, 30))),
            //                    Position = $"Должность {employees_id++}",
            //                    Phone = $"8-981-881-{random.Next(1000, 9999)}",
            //                    Rank = $"Звание {random.Next(1, 100)}"

            //                });
            //                context.Divisions.AddRange(deprtment.Divisions);
            //            }
            //            foreach(var division in deprtment.Divisions)
            //            {
            //                division.Units.Add(new Unit
            //                    {
            //                        Employees = new ObservableCollection<Employee> { division.Employees.Last(), division.Employees.First() },
            //                        Truck = FireCar
            //                    });
            //            }
            //        }
            //        context.SaveChanges();
            //    }
            //    //        //for (var j = 0; j < 2; j++)
            //    //        //{
            //    //        //    division.Units.Add(new Unit
            //    //        //    {
            //    //        //        Active = true,
            //    //        //        InDivision = true,
            //    //        //        Employees = new ObservableCollection<Employee>() { division.Employees.Last() },
            //    //        //        Truck = new Truck
            //    //        //        {
            //    //        //           
            //    //        //        }
            //    //        //    });
            //    //        //    //context.Units.Add(division.Units.Last<Unit>());
            //    //        //    //context.Trucks.Add(Units.Last().Truck);
            //    //        //}
            //    //    }
            //    //    context.Employees.AddRange(division.Employees);

            //    //}
            //    //context.SaveChanges();
            //}
        }
    }
}
