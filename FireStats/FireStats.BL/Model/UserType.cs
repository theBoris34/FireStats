﻿using System;


namespace FireStats.BL.Model
{    /// <summary>
     /// Тип пользователя.
     /// </summary>
    [Serializable]
    public class UserType
    {
        /// <summary>
        /// ID типа пользователя
        /// </summary>
        public int Id { get; set; }

        public string Name { get; set; }
        public UserType() { }

        /// <summary>
        /// Создать новый тип.
        /// </summary>
        /// <param name="name"> Имя типа. </param>
        public UserType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Тип пользователя не может быть пустым", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
