using FireStats.WPF.Models.Departments;
using FireStats.WPF.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Отделение/подразделение с техникой. </summary>
    class Unit : IEntity
    {
        /// <summary> Id отделения. </summary>
        public int Id { get; set; }

        /// <summary> Id подразделения базирования. </summary>
        public int IdDivision { get; set; }

        /// <summary> В расчёте. </summary>
        public bool Active { get; set; }

        /// <summary> В подразделении. </summary>
        public bool InDivision { get; set; } = true;

        /// <summary> Техника отделения. </summary>
        public Truck Truck { get; set; }
    }
        
}
