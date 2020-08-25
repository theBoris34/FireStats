using FireStats.WPF.Models.Departments;
using FireStats.WPF.Models.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Отделение/подразделение с техникой. </summary>
    class Unit : IEntity
    {
        #region EntityFramework

        /// <summary> Id отделения. </summary>
        public int Id { get; set; }
      
        public virtual Division Division { get; set; }

        /// <summary> Личный состав. </summary>
        public virtual ICollection<Employee> Employees { get; set; }

        [Required]
        /// <summary> Техника отделения. </summary>
        public virtual Truck Truck { get; set; }

        #endregion

        /// <summary> В расчёте. </summary>
        public bool Active { get; set; }

        /// <summary> В подразделении. </summary>
        public bool InDivision { get; set; } = true;
                
    }
        
}
