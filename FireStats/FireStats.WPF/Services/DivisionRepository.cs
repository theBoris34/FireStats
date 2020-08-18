using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Base;

namespace FireStats.WPF.Services
{
    class DivisionRepository : RepositoryInMemory<Division>
    {
        public DivisionRepository(): base(TestData.Divisions) { }
        protected override void Update(Division Source, Division Destination)
        {
            Destination.Name = Source.Name;           
            Destination.Note = Source.Note;
        }
    }
}
