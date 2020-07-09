using FireStats.BL.Controller;
using System;


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
            if(userController.IsNewUser)
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
            Console.ReadLine();

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
