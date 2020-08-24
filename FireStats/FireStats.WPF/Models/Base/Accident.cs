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
        /// <summary> Адресс события. </summary>
        public string Adress { get; set; }

        /// <summary> Дата события. </summary>
        public DateTime Date { get; set; }


        /// <summary> Время события. </summary>
        public DateTime TimeOfAccident { get; set; }


        /// <summary> Время поступления вызова. </summary>
        public DateTime TimeOfCall { get; set; }


        /// <summary> Время прибытия. </summary>
        public DateTime TimeOfArrival { get; set; }




    }
}
