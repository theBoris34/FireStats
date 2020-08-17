using FireStats.WPF.Models.Location;
using System.Collections.Generic;

namespace FireStats.WPF.Services.Interfaces
{
    internal interface IDataService
    {
        IEnumerable<AreaInfo> GetData();
    }
}
