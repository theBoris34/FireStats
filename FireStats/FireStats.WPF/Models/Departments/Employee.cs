using FireStats.WPF.Models.Base;
using FireStats.WPF.Models.Interface;
using System;

namespace FireStats.WPF.Models.Departments
{
    internal class Employee : People, IEntity
    {

        /// <summary> ID сотрудника. </summary>
        public int Id { get; set; }

        /// <summary> Подразделение. </summary>
        public virtual Division Division { get; set; }

        /// <summary> Отделение. </summary>
        public virtual Unit Unit { get; set; }

        /// <summary> Должность сотрудника. </summary>
        public string Position { get; set; }

        /// <summary> Звание сотрудника. </summary>
        public string Rank { get; set; }        

    }
}
