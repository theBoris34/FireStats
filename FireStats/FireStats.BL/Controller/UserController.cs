using FireStats.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace FireStats.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {

        /// <summary>
        /// Список пользователей.
        /// </summary>
        public List<User> Users { get; }   //небезопасно, заменить!
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.",nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }

        /// <summary>
        /// Загрузить сохраненный список пользователей.
        /// </summary>
        /// <returns>Пользователи приложения.</returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else;
                {
                    return new List<User>();
                }
            }
        }

        public void SetNewUserData(string userType, string adress, int personnel, int fireTruck)
        {
            //проверка 
            CurrentUser.UserType = new UserType(userType);
            CurrentUser.Adress = adress;
            CurrentUser.Personnel = personnel;
            CurrentUser.FireTruck = fireTruck;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,Users);
            }
        }

      
    }
}
