using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_FS
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using (var context = new MyDBContext())
            {

                #region 123
                var People1 = new People { Name = "Petr" };
                var People2 = new People { Name = "Vlad" };
                var People3 = new People { Name = "Stas" };
                var People4 = new People { Name = "Igor" };
                var People5 = new People { Name = "Evgen" };
                var People6 = new People { Name = "Pavel" };
                var People7 = new People { Name = "Oleg" };
                var People8 = new People { Name = "Ivan" };
                var People9 = new People { Name = "Sergei" };
                var People10 = new People { Name = "Vitalia" };

                var Home1 = new Home { Name = "Home1", Peoples = new ObservableCollection<People>() };
                var Home2 = new Home { Name = "Home2", Peoples = new ObservableCollection<People>() };
                var Home3 = new Home { Name = "Home3", Peoples = new ObservableCollection<People>() };
                var Home4 = new Home { Name = "Home4", Peoples = new ObservableCollection<People>() };

                Home1.Peoples.Add(People1);
                Home1.Peoples.Add(People2);
                Home1.Peoples.Add(People3);

                Home2.Peoples.Add(People4);
                Home2.Peoples.Add(People5);
                Home2.Peoples.Add(People6);

                Home3.Peoples.Add(People7);
                Home3.Peoples.Add(People8);
                Home3.Peoples.Add(People9);

                Home4.Peoples.Add(People10);

                var Car1 = new Car { Name = "Car1", Peoples = new ObservableCollection<People>() };
                var Car2 = new Car { Name = "Car1", Peoples = new ObservableCollection<People>() };
                var Car3 = new Car { Name = "Car1", Peoples = new ObservableCollection<People>() };


                Car1.Peoples.Add(People4);
                Car1.Peoples.Add(People7);
                Car1.Peoples.Add(People1);

                Car2.Peoples.Add(People2);
                Car2.Peoples.Add(People6);
                Car2.Peoples.Add(People3);

                Car3.Peoples.Add(People5);
                Car3.Peoples.Add(People8);
                Car3.Peoples.Add(People10);
                #endregion

                context.Peoples.Add(People1);
                context.Peoples.Add(People2);
                context.Peoples.Add(People3);
                context.Peoples.Add(People4);
                context.Peoples.Add(People5);
                context.Peoples.Add(People6);
                context.Peoples.Add(People7);
                context.Peoples.Add(People8);
                context.Peoples.Add(People9);
                context.Peoples.Add(People10);

                context.Cars.Add(Car1);
                context.Cars.Add(Car2);
                context.Cars.Add(Car3);

                context.Homes.Add(Home1);
                context.Homes.Add(Home2);
                context.Homes.Add(Home3);
                context.Homes.Add(Home4);

                context.SaveChanges();

                Console.WriteLine("Done!");
                Console.ReadLine();
            }


        }
    }
}
