using FireStats.WPF.Models.Location;
using System.Collections.Generic;

namespace FireStats.WPF.Services.Interface
{
    internal interface IDataService
    {
        public IEnumerable<AreaInfo> GetData();
    }
}
