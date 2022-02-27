using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string login = "admin";
            string password = "root";

            Console.WriteLine("Hello!\nEnter your login...");
            string userEnterLogin = Console.ReadLine();
            Console.WriteLine("Okey, enter password...");
            string userEnterPassword = Console.ReadLine();

            if (userEnterLogin == login && userEnterPassword == password)
            {
                Console.WriteLine("Ok!");
            }
            else
            {
                Console.WriteLine("Error...");
            }
            Console.ReadKey();
        }
    }
}
