using System;

namespace Task_4
{
    internal class Program
    {
        /*
        * Задача 4
        * 
        *  (*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.
        */

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число для вычесление числа Фибоначчи.");
            string userEnter = Console.ReadLine();
            if (int.TryParse(userEnter, out int number))
            {
                double numFibonachi = Fibonachi(number);
                Console.WriteLine($"Число Фибоначчи для числа {userEnter} - {numFibonachi}");
            }
            else
            {
                Console.WriteLine("Вы ввели не число.");
            }
        }

        //Формула чисел Фибоначчи: Fn = Fn-1 + Fn-2;
        //F0 = 0;
        //F1 = 1;
        //F2 = F1 + F0 = 1;
        //F3 = F2 + F1 = 2 и т.д
        static double Fibonachi(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }

            return Fibonachi(number - 1) + Fibonachi(number - 2);
        }
    }
}
