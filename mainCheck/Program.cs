using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
//using DAL;

namespace mainCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Mother mom = new Mother
            {
                ID = "208497865",
                Lastname = "Lastname",
                FirstName = "FirstName",
                Tel = "052555666",
                Address = new Address { Number = 2, Street = "4", City = "5", ZipCode = "6", Country = "7" },
                HomePhone = "0588889999",
                BabbySitterAdress = new Address { Number = 2, Street = "4", City = "5", ZipCode = "6", Country = "7" },
                Workhours = new Dictionary<DayOfWeek, KeyValuePair<int, int>> { },
                MonthPayment = true
            };
            DateTime date1 = new DateTime(2010, 1, 1, 8, 0, 15);
            DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);
            Console.WriteLine(mom);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
