using FireStats.WPF.Models.Departments;
using FireStats.WPF.Models.Interface;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Автомобиль. </summary>
    class Truck : IEntity
    {
        #region EntityFramework
        /// <summary> Id автомобиля. </summary>
        public int Id { get; set; }

        /// <summary>Подразделение. </summary>
        //public virtual Division Division { get; set; }

        /// <summary>Отделение. </summary>
        public virtual Unit Unit { get; set; } 
        #endregion

        /// <summary>Тип автомобиля. </summary>
        public string Type { get; set; } //словарь типов автомобилей

        /// <summary>Объем воды в резервуаре, л. </summary>
        public int Water { get; set; }

        /// <summary>Объем пены в резервуаре, л. </summary>
        public int Foam { get; set; }

        /// <summary>Подача воды, л/с. </summary>
        public int WaterSupply { get; set; }

        
    }
}