using FireStats.WPF.Models.Departments;
using FireStats.WPF.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Заявитель </summary>
    class Applicant : People, IEntity
    {
        public int Id { get; set; }

        public Applicant(string name, string surname, string patronymic, string phone)
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
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException($"'{ nameof(phone) }' не может быть пустым или содержать только пробел", nameof(phone));
            } 
            #endregion

            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Phone = phone;
        }


    }
}
