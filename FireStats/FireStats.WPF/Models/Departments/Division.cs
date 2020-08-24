using FireStats.WPF.Models.Base;
using FireStats.WPF.Models.Interface;
using System.Collections.Generic;

namespace FireStats.WPF.Models.Departments
{
    /// <summary>
    /// Подразделение.
    /// </summary>
    class Division : IEntity
    { 
        /// <summary> Id подразделения. </summary>
        public int Id { get; set; }

        /// <summary> Id управления. </summary>
        public int IdDepartment { get; set; }

        /// <summary> Название подразделения. </summary>
        public string Name { get; set; }

        /// <summary> Примечание </summary>
        public string Note { get; set; }

        /// <summary> Список сотрудников. </summary>
        public ICollection<Employee> Employees { get; set; }

        /// <summary> Отделения. </summary>
        public ICollection<Unit> Units { get; set; }
    }
}
