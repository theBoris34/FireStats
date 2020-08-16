using System.Collections.Generic;
using System.Windows;

namespace FireStats.WPF.Models.Location
{  
        /// <summary>
        /// Общий класс для областей, районов, округов
        /// </summary>
        internal class PlaceInfo
        {
            public string Name { get; set; }

            public virtual Point Location { get; set; }

            public virtual IEnumerable<ConfirmedCount> Counts { get; set; }

            public override string ToString() => $"{Name}({Location})";
        }
   
}
