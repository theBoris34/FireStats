using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Base;

namespace FireStats.WPF.Services.Repositories
{

    class EmployeeRepository : RepositoryInMemory<Employee>
    {
        //public EmployeeRepository():base(TestData.Employees) { }

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
}
