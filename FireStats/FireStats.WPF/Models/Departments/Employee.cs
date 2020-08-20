using FireStats.WPF.Models.Interface;
using System;

namespace FireStats.WPF.Models.Departments
{
    internal class Employee : IEntity
    {

        public int Id { get; set; }
        /// <summary> Имя сотрудника. </summary>
        public string Name { get; set; }

        /// <summary> Фамилия сотрудника. </summary>
        public string Surname { get; set; }

        /// <summary> Отчество сотрудника. </summary>
        public string Patronymic { get; set; }

        /// <summary> Дата рождения сотрудника. </summary>
        public DateTime Birthday { get; set; }

        /// <summary> Должность сотрудника. </summary>
        public string Position { get; set; }

        /// <summary> Звание сотрудника. </summary>
        public string Rank { get; set; }

        /// <summary> Примечание </summary>
        public string Note { get; set; }

    }
}
