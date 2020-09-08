using FireStats.WPF.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Пострадавший. </summary>
    class Injured : People, IEntity
    {
        /// <summary> ID пострадавшего. </summary>
        public int Id { get; set; }

        public virtual Accident Accident { get; set; }

        /// <summary> Пострадавший мертв. </summary>
        public bool IsDead { get; set; }

        /// <summary> Куда направлен (Больница, морг). </summary>
        public string Hospital { get; set; }

        public Injured()
        {

        }
        public Injured(string name, string surname, string patronymic, bool isDead, string hospital)
        {
            #region Проверка IsNullOrWhiteSpace
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{ nameof(name) } не может быть пустым или содержать только пробел", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new ArgumentException($"'{nameof(surname)}' не может быть пустым или содержать только пробел", nameof(surname));
            }
            if (string.IsNullOrWhiteSpace(patronymic))
            {
                throw new ArgumentException($"'{nameof(patronymic)}' не может быть пустым или содержать только пробел", nameof(patronymic));
            }
            if (string.IsNullOrWhiteSpace(hospital))
            {
                throw new ArgumentException($"'{ nameof(hospital) }' не может быть пустым или содержать только пробел", nameof(hospital));
            }
            #endregion

            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            IsDead = isDead;
            Hospital = hospital;
        }

    }
}
