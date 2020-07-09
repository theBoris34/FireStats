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
            
            Console.Write("Введите тип пользователя: ");
            var type = Console.ReadLine();
            
            Console.Write("Введите адрес объекта (Формат: ??? обл., г/д.???, ул/пер. ???, д. ?) :");
            var adress = Console.ReadLine();
            
            Console.Write("Введите количество личного состава: ");
            var personnel = int.Parse(Console.ReadLine());

            Console.Write("Введите количество техники: ");
            var fireTruck = int.Parse(Console.ReadLine());

            var userController = new UserController(name, type, adress, personnel, fireTruck);

            userController.Save();


        }
    }
}
