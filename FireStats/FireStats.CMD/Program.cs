using FireStats.BL.Controller;
using FireStats.BL.Model;
using System;
using System.Collections.Generic;

namespace FireStats.CMD
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Greeting();

            Console.ReadLine();

        }

        /// <summary>
        /// Приветствие программы в консольном режиме.
        /// </summary>
        static void Greeting()
        {
            Console.WriteLine("##################################################################");
            Console.WriteLine("########\t     ВАС  ПРИВЕТСТВУЕТ  ПРИЛОЖЕНИЕ \t  ########");
            Console.WriteLine("########\t\t       FIRESTATS \t\t  ########");
            Console.WriteLine("##################################################################");
            
            Console.Write("Введите имя пользователя(объекта): ");
            var name = Console.ReadLine();
            
            var userController = new UserController(name);
            var workShiftController = new WorkShiftController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите тип объекта: ");
                var userType = Console.ReadLine();
                Console.Write("Введите адрес объекта(Формат: ??? обл., г/д.???, ул/пер. ???, д. ???): ");//разделить на область город улицу...
                var adress = Console.ReadLine();
                var personnel = ParseInt("личного состава");
                var fireTruck = ParseInt("пожарной техники");

                userController.SetNewUserData(userType, adress, personnel,fireTruck);                
            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Текущая дата: {0}", DateTime.Today.ToString("d"));
            Console.WriteLine("Что сделать?");
            Console.WriteLine("D - изменить дату.");
            Console.WriteLine("F - внести пожар.");
            Console.WriteLine("E - внести ЧС.");
            Console.WriteLine("F2 - просмотреть список пожаров.");
            Console.WriteLine("F3 - просмотреть список ЧС.");
            Console.WriteLine("U - просмотреть список пользователей.");//сделать только для админа
            Console.WriteLine("F1 - просмотреть справку.");
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D:
                    SetDateTime();
                    break;
                case ConsoleKey.F:
                    var fire = EnterFire();
                    workShiftController.Add(fire);
                    foreach (var item in workShiftController.WorkShift.Fires) 
                        Console.WriteLine($"{item.Adress} - {item.FireRank} - {item.Applicant}");
                    break;
                case ConsoleKey.E:
                    EnterEmergency(); ;
                    break;
                case ConsoleKey.F2:
                    GetListFires();
                    break;
                case ConsoleKey.F3:
                    GetListEmergency(); ;
                    break;
                case ConsoleKey.U:
                    GetListUsers();
                    break;
                case ConsoleKey.F1:
                    GetHelpInfo();
                    break;

            }

            Console.ReadLine();

        }

        private static void GetHelpInfo()
        {
            throw new NotImplementedException();
        }

        private static void GetListUsers()
        {
            throw new NotImplementedException();
        }

        private static void GetListEmergency()
        {
            throw new NotImplementedException();
        }

        private static void GetListFires()
        {
            throw new NotImplementedException();
        }

        private static void EnterEmergency()
        {
            throw new NotImplementedException();
        }

        private static Fire EnterFire()
        {
            #region для пробы, УДАЛИТЬ!
            List<User> fieldUnits = new List<User>();
            fieldUnits.Add(new User("pch1"));
            fieldUnits.Add(new User("pch2"));
            List<string> injured = new List<string>();
            injured.Add("postr1");
            injured.Add("postr2");
            var test = Guid.NewGuid().ToString();
            var workTime = new WorkTime(DateTime.Now);
            var rnd = new Random();
            //var userController = new UserController(userName);
            #endregion


            //TODO: Сделать отдельный метод для внесения данных.
            Console.Write("Введите адрес пожара: ");
            var adress = Console.ReadLine();
            Console.Write("Введите ранг пожара: ");
            byte runk = Convert.ToByte(Console.ReadLine());

           /* Console.Write("Введите время работ в формате выезд/прибыте/1-ый ствол/лок/лик/сбор ПТВ: ");//??метод для добавления времени
            var adress = Console.ReadLine();
            Console.WriteLine("Введите задействованные подразделения:");//отдельный метод для добавления подразделения
            var adress = Console.ReadLine();
            Console.WriteLine("Введите заявителя: ");
            var adress = Console.ReadLine();
            Console.WriteLine("Введите объект пожара: ");
            var adress = Console.ReadLine();
            Console.WriteLine("Введите владелеца объекта: ");
            var adress = Console.ReadLine();
            Console.WriteLine("Введите результат пожара: ");
            var adress = Console.ReadLine();
            Console.WriteLine("Введите причину пожара: ");
            var adress = Console.ReadLine();
            Console.WriteLine("Введите ущерб: ");
            var adress = Console.ReadLine();
            Console.WriteLine("Введите спасеное: ");
            var adress = Console.ReadLine();
            Console.WriteLine("Введите РТП: ");
            var adress = Console.ReadLine();
            Console.WriteLine("Введите инспектора: ");
            var adress = Console.ReadLine();*/

            var fire = new Fire(adress, runk, workTime, fieldUnits, test, test, test, test, test, rnd.Next(0, 1000000), rnd.Next(0, 1000000), test, test);

            return fire;
        }

        private static void SetDateTime()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получение формата INT
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static int ParseInt(string name)
        {
            while(true)
            {
                Console.Write($"Введите количество {name}: ");
                if(int.TryParse(Console.ReadLine(), out int value))
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
