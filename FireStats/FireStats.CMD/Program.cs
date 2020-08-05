using FireStats.BL.Controller;
using FireStats.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace FireStats.CMD
{
    //Начать делать WPF
    //TODO:
    //Сделать ввод чс\происшествий
    //Списки пользователей для внесения их в список участников ликвидации\
    //Изменить способ создания пользователя, чтобы спрашивал регистрацию.
    //Сделать другой вариант с пользователем + пароль.
    //Сделать отображение пожаров/чс по датам (от\до)
    //Возможность отчетов
    //Доделать локализацию
    //Проверки на ввод
    //Тесты

    class Program
    {
        static DateTime CurrentDate = DateTime.Now;
        /// <summary>
        /// Флаг для повторения меню. Пока true меню будет постоянно появляться. 
        /// Когда false программа попрощается с пользователем. 
        /// </summary>
        static bool MenuFlag = true; //Для повторения меню

        static void Main(string[] args)
        {
            Console.Title = "FIRESTAT";
            var cul = CultureInfo.CreateSpecificCulture("en-us"); ;
            var resourseManager = new ResourceManager("FireStats.CMD.Language.Text", typeof(Program).Assembly);
            Console.WriteLine(resourseManager.GetString("Hello"), cul);
            //Console.Write(resourseManager.GetString("EnterName"), cul);

            var userController = UserChange();
            do
            {
                GoToMenu(userController);
            }
            while (MenuFlag);
            Console.WriteLine("Спасибо за использование программы!");
            Console.ReadLine();
        }

        /// <summary>
        /// Изменить пользователя.
        /// </summary>
        /// <returns>Текущий пользователь.</returns>
        public static UserController UserChange()
        {
            Console.Title = $"FIRESTAT. Изменение пользователя.";
            Console.Clear();
            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();
            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Такого пользователя не существует. Зарегистрируйтесь.");
                Console.Title = $"FIRESTAT. Изменение пользователя. Регистрация нового пользователя.";
                Console.Write("Введите тип объекта(0-НЦУКС, 1-ЦУКС по ФО, 2-ЦУКС, 3-ЕДДС, 4-ПСЧ): ");
                var userType = int.Parse(Console.ReadLine());//проверка
                Console.Write("Введите адрес объекта: ");
                var adress = Console.ReadLine();//проверка
                var personnel = ParseInt("личного состава");
                var fireTruck = ParseInt("пожарной техники");
                userController.SetNewUserData(userType, adress, personnel, fireTruck);
            }
            Console.Title = $"FIRESTAT. Изменение пользователя.";
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
            return userController;
        }

        private static void GoToMenu(UserController userController)
        {

            Console.Title = $"FIRESTAT. Пользователь: {userController.CurrentUser.Name}";
            Console.Clear();
            Headler(userController.CurrentUser.Name);
            Console.WriteLine("Что сделать?");
            Console.WriteLine("F - внести пожар.");
            Console.WriteLine("E - внести ЧС.");
            Console.WriteLine("V - просмотреть список пожаров.");
            Console.WriteLine("B - просмотреть список ЧС.");
            Console.WriteLine("H - просмотреть справку.");
            Console.WriteLine("D - изменить дату.");
            Console.WriteLine("P - изменить тип пользователя.");
            Console.WriteLine("Q - изменить пользователя.");
            if (userController.CurrentUser.UserType == "NCUKS")
            {
                Console.WriteLine("U - просмотреть список пользователей.");//сделать только для админа
            }
            Console.WriteLine("ESC - выход.");
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D:
                    Headler(userController.CurrentUser.Name);
                    CurrentDate = Convert.ToDateTime(EnterData("дата", CurrentDate.GetType()));
                    break;
                case ConsoleKey.F:
                    Headler(userController.CurrentUser.Name);
                    var fire = EnterFire(userController.CurrentUser);
                    userController.Add(fire);
                    Console.WriteLine(fire.ToString());
                    Console.ReadLine();
                    break;
                case ConsoleKey.E:
                    Headler(userController.CurrentUser.Name);
                    var emergency = EnterEmergency(userController.CurrentUser);
                    userController.Add(emergency);
                    Console.WriteLine(emergency.ToString());
                    Console.ReadLine();
                    break;
                case ConsoleKey.V:
                    Headler(userController.CurrentUser.Name);
                    GetListFires(userController.CurrentUser);
                    break;
                case ConsoleKey.B:
                    Headler(userController.CurrentUser.Name);
                    GetListEmergency(userController.CurrentUser); ;
                    break;
                case ConsoleKey.U:
                    if (userController.CurrentUser.UserType == "NCUKS")
                    {
                        Headler(userController.CurrentUser.Name);
                        GetListUsers(userController);
                    }
                    break;
                case ConsoleKey.P:
                    Headler(userController.CurrentUser.Name);
                    userController.SetTypeUser();
                    userController.Save();
                    break;
                case ConsoleKey.Q:
                    userController.CurrentUser = UserChange().CurrentUser;
                    break;
                case ConsoleKey.H:
                    Headler(userController.CurrentUser.Name);
                    GetHelpInfo();
                    break;
                case ConsoleKey.Escape:
                    MenuFlag = false;
                    break;
            }

        }



        /// <summary>
        /// Заголовок консоли.
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        private static void Headler(string name)
        {
            Console.Clear();
            Console.WriteLine($"---Текущий пользователь: {name}---");
            Console.WriteLine("Текущая дата: {0}", CurrentDate.ToString("d"));
        }

        /// <summary>
        /// Показать информацию о программе.
        /// </summary>
        private static void GetHelpInfo()
        {
            Console.Clear();
            Console.Title = "FIRESTAT. Информация о приложении.";
            Console.WriteLine("--Информация о программе--");
            Console.WriteLine("Название приложения: FireStats");
            Console.WriteLine("Версия приложения 1.0.0");
            Console.WriteLine("Санкт-Петербург, 2020 г.");
            Console.ReadLine();
        }

        /// <summary>
        /// Показать список всех пользователей.
        /// </summary>
        private static void GetListUsers(UserController userController)
        {
            Console.Title = $"FIRESTAT. Список пользователей. {userController.CurrentUser.Name}.";
            Headler(userController.CurrentUser.Name);
            Console.WriteLine($"Список пользователей FireStat");
            foreach (var item in userController.Users)
            {
                //Console.WriteLine($"{item.Adress} - {item.FireRank} - {item.Applicant}");
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Показать список происшествий/ЧС.
        /// </summary>
        /// <param name="currentUser">Текущий пользователь</param>
        private static void GetListEmergency(User currentUser)
        {
            Console.Title = $"FIRESTAT. Список происшествий/ЧС. {currentUser.Name}.";
            Headler(currentUser.Name);
            Console.WriteLine("Список происшествий/ЧС.");
            foreach (var item in currentUser.Emergencies)
                Console.WriteLine($"{item.Adress} - {item.Applicant}");
            Console.ReadLine();
        }

        /// <summary>
        /// Показать список пожаров.
        /// </summary>
        /// <param name="currentUser">Текущий пользователь.</param>
        private static void GetListFires(User currentUser)
        {
            Console.Title = $"FIRESTAT. Список пожаров. {currentUser.Name}.";

            Headler(currentUser.Name);
            Console.WriteLine($"Список пожаров внесенных пользователем {currentUser.Name}");

            foreach (var item in currentUser.Fires)
            {
                //Console.WriteLine($"{item.Adress} - {item.FireRank} - {item.Applicant}");
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Внести происшествие/ЧС.
        /// </summary>
        /// <returns>Новое происшствие/ЧС.</returns>
        private static Emergency EnterEmergency(User currentUser)
        {
            Console.Title = $"FIRESTAT. Ввод происшествия/ЧС. {currentUser.Name}.";
            Headler(currentUser.Name);
            Emergency emergency = new Emergency();
            return emergency;
        }

        /// <summary>
        /// Внести пожар.
        /// </summary>
        /// <returns>Новый пожар.</returns>
        private static Fire EnterFire(User currentUser)
        {
            Console.Title = $"FIRESTAT. Ввод пожара. {currentUser.Name}.";
            Headler(currentUser.Name);
            //TODO: Сделать отдельный метод для внесения данных.
            Console.Write("Введите адрес пожара: ");
            var adress = Console.ReadLine();
            Console.Write("Введите ранг пожара: ");
            byte runk = Convert.ToByte(Console.ReadLine());
            WorkTime workTime = EnterTime();

            //Console.WriteLine("Введите задействованные подразделения:");//отдельный метод для добавления подразделения
            List<User> fieldUnits = new List<User>
            {
                new User("pch1"),
                new User("pch2")
            };
            Console.Write("Введите заявителя: ");
            var applicant = Console.ReadLine();
            Console.Write("Произошел пожар: ");
            var fireObject = Console.ReadLine();
            Console.Write("Введите владелеца объекта: ");
            var owner = Console.ReadLine();
            Console.Write("Введите результат пожара: ");
            var damageResult = Console.ReadLine();
            Console.Write("Введите причину пожара: ");
            var causeOfFire = Console.ReadLine();
            Console.Write("Введите ущерб: ");
            var costOfDamage = Int32.Parse(Console.ReadLine());
            Console.Write("Введите спасеное: ");
            var costOfSalvage = Int32.Parse(Console.ReadLine());
            Console.Write("Введите РТП: ");
            var leader = Console.ReadLine();
            Console.Write("Введите инспектора: ");
            var fireInspector = Console.ReadLine();

            Fire fire = new Fire(adress, runk, workTime, fieldUnits,
                                applicant, fireObject, owner, damageResult,
                                causeOfFire, costOfDamage, costOfSalvage, leader, fireInspector, currentUser.Name);
            return fire;
        }

        /// <summary>
        /// Установка времени работ.
        /// </summary>
        /// <returns>Время работ на пожаре/ЧС.</returns>
        private static WorkTime EnterTime()
        {
            //DateTime s =...
            //TimeSpan ts = new TimeSpan(10,30,0);
            //sbyte = s.Date + ts;
            //или s.Date.Add(new TimeSpan(0,0,0))



            Console.WriteLine("Введите время работ: ");//??метод для добавления времени
            WorkTime workTime = new WorkTime(CurrentDate);

            //WorkTime workTime = new WorkTime(DateTime.Parse(Console.ReadLine()));

            Console.Write("\tВведите время полступления вызова (часы): ");
            workTime.CallTime = workTime.CallTime.AddHours(Double.Parse(Console.ReadLine()));
            Console.Write("\tВведите время полступления вызова (минуты): ");
            workTime.CallTime = workTime.CallTime.AddMinutes(Double.Parse(Console.ReadLine()));

            workTime.CheckOutTime = workTime.CallTime.AddMinutes(1.0);

            Console.Write("\tВведите время прибытия первого подразделения(часы): ");
            workTime.ArrivalTime = workTime.ArrivalTime.AddHours(Double.Parse(Console.ReadLine()));
            Console.Write("\tВведите время прибытия первого подразделения(минуты): ");
            workTime.ArrivalTime = workTime.ArrivalTime.AddMinutes(Double.Parse(Console.ReadLine()));

            workTime.BarrelFeedTime = workTime.ArrivalTime.AddMinutes(1.0);//подача первого ствола

            Console.Write("\tВведите время локализации(часы): ");
            workTime.LocalizationTime = workTime.LocalizationTime.AddHours(Double.Parse(Console.ReadLine()));
            Console.Write("\tВведите время локализации(минуты): ");
            workTime.LocalizationTime = workTime.LocalizationTime.AddMinutes(Double.Parse(Console.ReadLine()));

            Console.Write("\tВведите время ликвидации(часы): ");
            workTime.LiquidationTime = workTime.LiquidationTime.AddHours(Double.Parse(Console.ReadLine()));
            Console.Write("\tВведите время ликвидации(минуты): ");
            workTime.LiquidationTime = workTime.LiquidationTime.AddMinutes(Double.Parse(Console.ReadLine()));

            Console.Write("\tВведите время полной ликвидации пожара и сбора ПТВ(часы): ");
            workTime.CollectionTime = workTime.CollectionTime.AddHours(Double.Parse(Console.ReadLine()));
            Console.Write("\tВведите время полной ликвидации пожара и сбора ПТВ(минуты): ");
            workTime.CollectionTime = workTime.CollectionTime.AddMinutes(Double.Parse(Console.ReadLine()));

            Console.Write(workTime.ToString());
            Console.Write("\n==Временные характеристики успешно внесены!==");
            return workTime;
        }

        /// <summary>
        /// Ввод данных.
        /// </summary>
        /// <param name="name">Имя параметра для ввода.</param>
        /// <returns>Значение введеное с кавиатуры. </returns>
        public static object EnterData(string name, Type type)
        {

            if (type == typeof(DateTime))
            {
                DateTime data;
                do
                    Console.Write("Введите дату: ");
                while (!DateTime.TryParse(Console.ReadLine(), out data));
                Console.WriteLine($"Дата успешно внесена!");
                return data;
            }
            else if (type == typeof(Int32))
            {
                int digital;
                do
                    Console.Write($"Введите {name}: ");
                while (!Int32.TryParse(Console.ReadLine(), out digital));
                Console.WriteLine($"Поле {name} успешно внесено!");
                return digital;
            }
            else if (type == typeof(Double))
            {
                double digital;
                do
                    Console.Write($"Введите {name}: ");
                while (!Double.TryParse(Console.ReadLine(), out digital));
                Console.WriteLine($"Поле {name} успешно внесено!");
                return digital;
            }
            else
            {
                string text;
                do
                    Console.Write($"Введите {name}: ");
                while (!String.IsNullOrWhiteSpace(text = Console.ReadLine()));
                Console.WriteLine($"Поле {name} успешно внесено!");
                return text;
            }
        }

        /// <summary>
        /// Получение формата INT
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static int ParseInt(string name)
        {
            while (true)
            {
                Console.Write($"Введите количество {name}: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Количество {name} должно быть больше 0!");
                }
            }
        }
    }
}
