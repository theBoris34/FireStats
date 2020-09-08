using FireStats.WPF.Models.Base;
using FireStats.WPF.Services.Base;

namespace FireStats.WPF.Services.Repositories
{
    class UnitRepository : RepositoryInMemory<Unit>
    {
        public UnitRepository() { }
        protected override void Update(Unit Source, Unit Destination)
        {
            Destination.Active = Source.Active;
            Destination.InDivision = Source.InDivision;
            Destination.Truck = Source.Truck;
            Destination.Division = Source.Division;
        }
    }
}
