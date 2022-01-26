using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Задача 3
             * 
             * Определить, является ли введённое пользователем число чётным.
             */

            Console.WriteLine("Введите число дл яопределения четности");
            if (int.TryParse(Console.ReadLine(), out int userNumber))   //проверка на корректность ввода от пользователя 
            {
                bool result = userNumber % 2 == 0;                      //Проверка на четность, сохраняем результат в отдельную переменную
                if (result)
                {
                    Console.WriteLine("Четное число");                  //Если true - разделилось без остатка, число четное
                }
                else
                {
                    Console.WriteLine("Не четное число");
                }
            }
            else
            {
                Console.WriteLine("Введено не число!");                 //Если пользователь ввел не число, выводим сообщение об ошибке.
            }
        }
    }
}
