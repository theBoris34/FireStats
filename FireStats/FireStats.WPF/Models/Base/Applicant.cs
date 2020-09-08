using FireStats.WPF.Models.Interface;
using System;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Заявитель </summary>
    class Applicant : People, IEntity
    {
        /// <summary> ID заявителя. </summary>
        public int Id { get; set; }

        /// <summary> ID происшествия. </summary>
        public int IdAccident { get; set; }

        public virtual Accident Accident { get; set; }

        public Applicant() { }

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
            Birthday = DateTime.Now;
        }


    }
}
