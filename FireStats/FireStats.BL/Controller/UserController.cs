using FireStats.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FireStats.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Список пользователей.
        /// </summary>
        public List<User> Users { get; set; }   //небезопасно, заменить!

        /// <summary>
        /// Список пожаров.
        /// </summary>
        public List<Fire> Fires { get; set; }

        /// <summary>
        /// Список чрезвычайных ситуаций.
        /// </summary>
        public List<Emergency> Emergencies { get; set; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; set; }
        /// <summary>
        /// Это новый пользователь.
        /// </summary>
        public bool IsNewUser { get; set; } = false;

        /// <summary>
        /// Установка пользователя.
        /// </summary>
        /// <param name="user">Имя пользователя.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));
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
            return Load<User>() ?? new List<User>();
        }

        /// <summary>
        /// Установить данные пользователя.
        /// </summary>
        /// <param name="userType">Тип пользователя.</param>
        /// <param name="adress">Адрес пользователя(объекта).</param>
        /// <param name="personnel">Личный состав.</param>
        /// <param name="fireTruck">Боевая техника.</param>
        public void SetNewUserData(int userType, string adress, int personnel, int fireTruck)
        {
            //проверка 
            CurrentUser.UserType = CurrentUser.ArrayUserTypes[userType];
            CurrentUser.Adress = adress;
            CurrentUser.Personnel = personnel;
            CurrentUser.FireTruck = fireTruck;
            Save();
        }

        /// <summary>
        /// Добавить пожар в список.
        /// </summary>
        /// <param name="fire">Пожар</param>
        public void Add(Fire fire)
        {
            if (CurrentUser.Fires.Find(f => string.Equals(f.Adress, fire.Adress, StringComparison.CurrentCultureIgnoreCase)) == null)
            {
                CurrentUser.Fires.Add(fire);
                Save();
            }
            else
            {
                throw new ArgumentException("Пожар по этому адресу уже зарегистрирован!", nameof(fire));
            }
        }

        /// <summary>
        /// Добавить ЧС в список.
        /// </summary>
        /// <param name="emergency">ЧС.</param>
        public void Add(Emergency emergency)
        {
            if (CurrentUser.Emergencies.Find(e => string.Equals(e.Adress, emergency.Adress, StringComparison.CurrentCultureIgnoreCase)) == null)
            {
                CurrentUser.Emergencies.Add(emergency);
                Save();
            }
            else
            {
                throw new ArgumentException("ЧС по этому адресу ужке зарегистрирована!", nameof(emergency));
            }
        }

        /// <summary>
        /// Изменить тип пользователя.
        /// </summary>
        public void SetTypeUser()
        {
            //Убрать после тестов.
            Console.Write("\tВведите тип объекта(0-НЦУКС, 1-ЦУКС по ФО, 2-ЦУКС, 3-ЕДДС, 4-ПСЧ): ");
            CurrentUser.UserType = CurrentUser.ArrayUserTypes[Int32.Parse(Console.ReadLine())];
            Console.Write("==Тип пользователя успешно изменён!==\n");

        }

        /// <summary>
        /// Загрузить все ЧС из файла.
        /// </summary>
        /// <returns>Список ЧС.</returns>
        public List<Emergency> GetAllEmergencies()
        {
            return Load<Emergency>() ?? new List<Emergency>();
        }

        /// <summary>
        /// Загрузить все пожары из файла.
        /// </summary>
        /// <returns>Список пожаров.</returns>
        public List<Fire> GetAllFires()
        {
            return Load<Fire>() ?? new List<Fire>();
        }

        /// <summary>
        /// Сохранить данные.
        /// </summary>
        public void Save()
        {
            Save(Users);
            Save(CurrentUser.Fires);
            Save(CurrentUser.Emergencies);
        }


    }
}
