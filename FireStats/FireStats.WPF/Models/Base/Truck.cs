using FireStats.WPF.Models.Departments;
using FireStats.WPF.Models.Interface;
using System.Collections;
using System.Collections.Generic;

namespace FireStats.WPF.Models.Base
{
    /// <summary> Автомобиль. </summary>
    class Truck : IEntity
    {
        /// <summary> Id автомобиля. </summary>
        public int Id { get; set; }

        /// <summary> Id подразделения базирования. </summary>
        public int IdDivision { get; set; }

        /// <summary> Водитель. </summary>
        public Employee Driver { get; set; }

        /// <summary> Личный состав. </summary>
        public ICollection<Employee> Crew { get; set; }  
        
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