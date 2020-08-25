using FireStats.WPF.Models.Base;
using FireStats.WPF.Models.Interface;
using System.Collections.Generic;

namespace FireStats.WPF.Models.Departments
{
    /// <summary>Подразделение.</summary>
    class Division : IEntity
    {
        #region EntityFramework
        /// <summary> Id подразделения. </summary>
        public int Id { get; set; }

        /// <summary> Управление. </summary>
        public virtual Department Department { get; set; }

        /// <summary> Список сотрудников. </summary>
        public virtual ICollection<Employee> Employees { get; set; }

        /// <summary> Отделения. </summary>
        public virtual ICollection<Unit> Units { get; set; } 
        #endregion

        /// <summary> Название подразделения. </summary>
        public string Name { get; set; }

        /// <summary> Примечание </summary>
        public string Note { get; set; }

    }
}
