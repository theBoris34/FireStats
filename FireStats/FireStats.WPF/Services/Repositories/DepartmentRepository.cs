using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Base;

namespace FireStats.WPF.Services.Repositories
{
    class DepartmentRepository : RepositoryInMemory<Department>
    {
        protected override void Update(Department Source, Department Destination)
        {
            Destination.Name = Source.Name;
            Destination.Note = Source.Note;
        }
    }
}
