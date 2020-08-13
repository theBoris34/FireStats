using System.Collections.Generic;

namespace FireStats.WPF.Models.Departments
{
    /// <summary>
    /// Подразделение.
    /// </summary>
    class Division
    {
        /// <summary> Название подразделения. </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список сотрудников.
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
    }
}
