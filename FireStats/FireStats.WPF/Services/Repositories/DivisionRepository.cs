using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Base;
using System.Collections.Generic;
using System.Linq;

namespace FireStats.WPF.Services.Repositories
{
    class DivisionRepository : RepositoryInMemory<Division>
    {
        public List<Division> Divisions { get; set; } = new List<Division>();
        public DivisionRepository() 
        {
            using (var context = new DataBaseContext())
            {
                foreach (Division division in context.Divisions)
                    Divisions.Add(division);
            }
        }

        public Division Get(string DivisionName) => GetAll().FirstOrDefault(d => d.Name == DivisionName);

        protected override void Update(Division Source, Division Destination)
        {
            Destination.Name = Source.Name;
            Destination.Note = Source.Note;
            Destination.Department = Source.Department;
        }
    }
}
