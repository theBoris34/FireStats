using FireStats.WPF.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Пострадавший. </summary>
    class Injured : People, IEntity
    {
        /// <summary> ID пострадавшего. </summary>
        public int Id { get; set; }

        /// <summary> Пострадавший мертв. </summary>
        public bool IsDead { get; set; }

        /// <summary> Куда направлен (Больница, морг). </summary>
        public string Hospital { get; set; }       

    }
}
