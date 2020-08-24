using FireStats.WPF.Models.Interface;
using System.Collections.Generic;

namespace FireStats.WPF.Models.Departments
{
    /// <summary>
    /// Подразделение.
    /// </summary>
    class Division : IEntity
    {
        public int Id { get; set; } 
        /// <summary> Название подразделения. </summary>
        public string Name { get; set; }

        /// <summary> Примечание </summary>
        public string Note { get; set; }

        /// <summary>
        /// Список сотрудников.
        /// </summary>
        public ICollection<Employee> Employees { get; set; }

         
        
    }
}
