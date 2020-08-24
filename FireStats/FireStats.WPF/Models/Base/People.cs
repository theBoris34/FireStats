using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Базовый класс людей. </summary>
    class People
    {
        /// <summary> Имя. </summary>
        public string Name { get; set; }

        /// <summary> Фамилия. </summary>
        public string Surname { get; set; }

        /// <summary> Отчество. </summary>
        public string Patronymic { get; set; }

        /// <summary> Дата рождения. </summary>
        public DateTime Birthday { get; set; }

        /// <summary> Номер телефона. </summary>
        public string Phone { get; set; }

        /// <summary> Примечание. </summary>
        public string Note { get; set; } = "";     

    }
}
