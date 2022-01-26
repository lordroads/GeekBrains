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
            if (int.TryParse(userEnter, out int month))                     //проверка на корректность ввода от пользователя
            {
                switch (month)                                              //если ввод от пользователя корректный, int.TryParse дает выводной результат в целочисленную переменную 'month'
                {
                    case 1:
                        {
                            Console.WriteLine("Январь");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Февраль");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Март");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Апрель");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Май");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Июнь");
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Июль");
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Август");
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Сентябрь");
                            break;
                        }
                    case 10:
                        {
                            Console.WriteLine("Октябрь");
                            break;
                        }
                    case 11:
                        {
                            Console.WriteLine("Ноябрь");
                            break;
                        }
                    case 12:
                        {
                            Console.WriteLine("Декабрь");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введенное число не является месяцем...");//вывод сообщения об ошибке, если пользователь ввел число не соответсвующие месяцу.
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Введено не число!");                                 //вывод сообщения об ошибке, если пользователь ввел не число.
            }
        }
    }
}
