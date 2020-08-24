using FireStats.WPF.Models.Base;
using FireStats.WPF.Models.Interface;
using System;

namespace FireStats.WPF.Models.Departments
{
    internal class Employee : People, IEntity
    {

        /// <summary> ID сотрудника. </summary>
        public int Id { get; set; }

        /// <summary> ID подразделения. </summary>
        public int IdDivision { get; set; }

        /// <summary> Должность сотрудника. </summary>
        public string Position { get; set; }

        /// <summary> Звание сотрудника. </summary>
        public string Rank { get; set; }        

    }
}
