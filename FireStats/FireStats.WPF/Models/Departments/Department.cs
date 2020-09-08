using FireStats.WPF.Models.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FireStats.WPF.Models.Departments
{
    /// <summary> Управление.</summary>
    class Department : IEntity
    {
        [Key]
        /// <summary> Id управления. </summary>
        public int Id { get; set; }

        /// <summary> Название управления. </summary>
        public string Name { get; set; }

        /// <summary> Примечание. </summary>
        public string Note { get; set; }

        /// <summary> Список подразделений. </summary>
        public virtual ICollection<Division> Divisions { get; set; }


    }

}
