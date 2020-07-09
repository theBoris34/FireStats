﻿using System;


namespace FireStats.BL.Model
{    /// <summary>
     /// Тип пользователя.
     /// </summary>
    public class UserType
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Создать новый тип.
        /// </summary>
        /// <param name="name"> Имя типа. </param>
        public UserType(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
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
