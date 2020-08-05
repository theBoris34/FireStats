using System;
using System.Collections.Generic;

namespace FireStats.BL.Model
{
    //разные типы с помощью интерфейсов?


    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        public int Id { get; set; }

        #region Свойства пользователя
        /// <summary>
        /// Имя пользователя (объекта).
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Адрес пользователя(объекта). Формат: ??? обл., г/д.???, ул/пер. ???, д. ???.
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Количество личного состава.
        /// </summary>
        public int Personnel { get; set; }

        /// <summary>
        /// Количество боевой пожарной/специальной техники.
        /// </summary>
        public int FireTruck { get; set; }

        /// <summary>
        /// Список пожаров.
        /// </summary>
        public List<Fire> Fires { get; set; }

        /// <summary>
        /// Список чрезвычайных ситуаций.
        /// </summary>
        public List<Emergency> Emergencies { get; set; }

        /// <summary>
        ///Тип пользователя
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// Название типа (НЦУКС, ЦУКС ФО, ЦУКС Региона, ЕДДС, ПСЧ).
        /// </summary>
        public string[] ArrayUserTypes = new string[] { "NCUKS", "CUKS FO", "CUKC", "EDDS", "PSCH" };
        #endregion

        public User() { }

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        public User(string name)
            : this(name, 4, "Адрес не задан!", 1, 1)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя объекта не может быть пустым или null", nameof(name));
            }
            Name = name;
        }

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="userType">Тип пользователя.</param>
        /// <param name="adress">Адресс объекта.</param>
        /// <param name="personnel">Личный состав.</param>
        /// <param name="fireTruck">Боевая техника.</param>
        public User(string name,
                    int userType,
                    string adress,
                    int personnel,
                    int fireTruck)
        {
            #region Проверка условий 
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя объекта не может быть пустым или null", nameof(name));
            }
            if (userType < 0 && userType > 4)
            {
                throw new ArgumentNullException("Неверный тип объекта (Типы от 0 до 4)", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(adress))
            {
                throw new ArgumentNullException("Адрес объекта не может быть пустым или null", nameof(adress));
            }
            if (personnel <= 0)
            {
                throw new ArgumentException("Количество личного состава не может быть 0", nameof(personnel));
            }
            if (fireTruck <= 0)
            {
                throw new ArgumentException("Количество техники не может быть 0", nameof(fireTruck));
            }
            #endregion

            Name = name;
            UserType = ArrayUserTypes[userType];
            Adress = adress;
            Personnel = personnel;
            FireTruck = fireTruck;
            Fires = new List<Fire>();
            Emergencies = new List<Emergency>();
        }

        public override string ToString()
        {
            return $"Имя пользователя: {Name}. Тип пользователя: {UserType}";
        }

    }
}
