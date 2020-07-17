using System;


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
        public int UserTypeId { get; set; }
        public User()
        {

        }
        #region Свойства пользователя
        /// <summary>
        /// Имя пользователя (объекта).
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Тип пользователя ПСЧ/ЕДДС (обычный), ЦУКС (админ).
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// Адрес пользователя(объекта). Формат: ??? обл., г/д.???, ул/пер. ???, д. ???.
        /// </summary>
        public string Adress {get; set; }

        /// <summary>
        /// Количество личного состава.
        /// </summary>
        public int Personnel { get; set; }

        /// <summary>
        /// Количество боевой пожарной/специальной техники.
        /// </summary>
        public int FireTruck { get; set; }
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="userType">Тип пользователя.</param>
        /// <param name="adress">Адресс объекта.</param>
        /// <param name="personnel">Личный состав.</param>
        /// <param name="fireTruck">Боевая техника.</param>
        public User(string name,
                    UserType userType, 
                    string adress, 
                    int personnel,
                    int fireTruck)
        {
            #region Проверка условий 
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя объекта не может быть пустым или null", nameof(name));
            }
            if (userType == null)
            {
                throw new ArgumentNullException("Тип пользователя не может быть null", nameof(userType));
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
            UserType = userType;
            Adress = adress;
            Personnel = personnel;
            FireTruck = fireTruck;            
        }

        public User (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя объекта не может быть пустым или null", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Adress;
        }

    }
}
