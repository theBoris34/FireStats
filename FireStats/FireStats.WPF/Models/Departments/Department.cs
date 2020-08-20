using FireStats.WPF.Models.Interface;
using System.Collections.Generic;

namespace FireStats.WPF.Models.Departments
{
    /// <summary>
    /// Управление.
    /// </summary>
    class Department : IEntity
    {
        public int Id { get; set; }

        /// <summary> Название управления. </summary>
        public string Name { get; set; }

        /// <summary> Примечание. </summary>
        public string Note { get; set; }

        /// <summary>
        /// Список сотрудников.
        /// </summary>
        public ICollection<Division> Divisions { get; set; }
    }

}
