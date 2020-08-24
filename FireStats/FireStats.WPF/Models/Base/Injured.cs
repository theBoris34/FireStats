using FireStats.WPF.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Пострадавший </summary>
    class Injured : IEntity
    {
        /// <summary> ID пострадавшего. </summary>
        public int Id { get; set; }

        /// <summary> Пострадавший мертв. </summary>
        public bool IsDead { get; set; }

        /// <summary> Имя пострадавшего. </summary>
        public string Name { get; set; }

        /// <summary> Фамилия пострадавшего. </summary>
        public string Surname { get; set; }

        /// <summary> Отчество пострадавшего. </summary>
        public string Patronymic { get; set; }

        /// <summary> Дата рождения пострадавшего. </summary>
        public DateTime Birthday { get; set; }

        /// <summary> Примечание </summary>
        public string Note { get; set; }

    }
}
