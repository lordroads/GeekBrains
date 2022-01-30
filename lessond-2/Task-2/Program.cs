using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Задача 2

            Запросить у пользователя порядковый номер текущего месяца и 
            вывести его название.
            */

            Console.WriteLine("Введите порядковый номер текущего месяца");
            
            string userEnter = Console.ReadLine();
            if (int.TryParse(userEnter, out int month))                         //проверка на корректность ввода от пользователя
            {
                DateTime _date = new DateTime();                                //иницилизируем объект даты
                string dateToParse = $"10.{userEnter}.1990";                    //создаем строку для парса даты

                if (DateTime.TryParse(dateToParse, out _date))                  //проверяем корректность ввода от пользователя
                {
                    Console.WriteLine(_date.ToString("MMMM"));                  //вывод месяца на консоль
                }
                else
                {
                    Console.WriteLine("Введенное число не является месяцем...");//вывод сообщения об ошибке, если пользователь ввел число не соответсвующие месяцу.
                }
            }
            else
            {
                Console.WriteLine("Введено не число!");                                 //вывод сообщения об ошибке, если пользователь ввел не число.
            }
        }
    }
}
