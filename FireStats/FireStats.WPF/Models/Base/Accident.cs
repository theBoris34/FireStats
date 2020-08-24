using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Происшествие. </summary>
    class Accident
    {
        /// <summary> Адрес происшествия. </summary>
        public string Adress { get; set; }

        /// <summary> Дата происшествия. </summary>
        public DateTime Date { get; set; }

        /// <summary> Время происшествия. </summary>
        public DateTime TimeOfAccident { get; set; }

        /// <summary> Время поступления вызова. </summary>
        public DateTime TimeOfCall { get; set; }

        /// <summary> Время прибытия. </summary>
        public DateTime TimeOfArrival { get; set; }

        /// <summary> Список пострадавших. </summary>
        public List<Injured> Injureds { get; set; }

        /// <summary> Список погибших. </summary>
        public List<Injured> Deceaseds { get; set; } //Injured.IsDead = true

        /// <summary> Результат происшествия. </summary>
        public string Result { get; set; }



    }
}
