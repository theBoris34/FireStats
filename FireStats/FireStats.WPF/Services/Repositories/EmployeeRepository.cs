using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Base;
using System.Collections.Generic;

namespace FireStats.WPF.Services.Repositories
{

    class EmployeeRepository : RepositoryInMemory<Employee>
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public EmployeeRepository() 
        {
            using (var context = new DataBaseContext())
            {
                foreach (Employee employee in context.Employees)
                    Employees.Add(employee);
            }
        }

        protected override void Update(Employee Source, Employee Destination)
        {            
            Destination.Name = Source.Name;
            Destination.Surname = Source.Surname;
            Destination.Patronymic = Source.Patronymic;
            Destination.Rank = Source.Rank;
            Destination.Position = Source.Position;
            Destination.Note = Source.Note;
            Destination.Division = Source.Division;
        }
    }
}
