using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Services
{

    class EmployeeRepository : RepositoryInMemory<Employee>
    {
        protected override void Update(Employee Source, Employee Destination)
        {
            Destination.Name = Source.Name;
            Destination.Surname = Source.Surname;
            Destination.Patronymic = Source.Patronymic;
            Destination.Rank = Source.Rank;
            Destination.Position = Source.Position;
            Destination.Note = Source.Note;
        }
    }

    class DivisionRepository : RepositoryInMemory<Division>
    {
        protected override void Update(Division Source, Division Destination)
        {
            Destination.Name = Source.Name;           
            Destination.Note = Source.Note;
        }
    }

    class DepartmentRepository : RepositoryInMemory<Department>
    {
        protected override void Update(Department Source, Department Destination)
        {
            Destination.Name = Source.Name;
            Destination.Note = Source.Note;
        }
    }
}
