using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Base;
using System.Collections.Generic;

namespace FireStats.WPF.Services.Repositories
{
    class DepartmentRepository : RepositoryInMemory<Department>
    {
        public List<Department> Departments { get; set; } = new List<Department>();
        public DepartmentRepository()
        {
            using (var context = new DataBaseContext())
            {
                foreach (Department department in context.Departments)
                    Departments.Add(department);
            }
        }
        protected override void Update(Department Source, Department Destination)
        {
            Destination.Name = Source.Name;
            Destination.Note = Source.Note;
        }
    }
}
