using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Задача 5
             
             (*) Если пользователь указал месяц из зимнего периода, 
                 а средняя температура > 0, вывести сообщение «Дождливая зима».
             */

            bool isWinter = false;  //булевая переменная для хранения состояния зимний месяц выбрали или нет
            string enterMonth = ""; //строковая переменная для хранения выбранного месяца
            int tempMin;            //целочисленная переменная для хранения минимальной введенной температуры от пользователя
            int tempMax;            //целочисленная переменная для хранения максимальной введенной температуры от пользователя
            int dailyTemp = 0;      //целочисленная переменная для хранения средней температуры

            Console.WriteLine("Введите порядковый номер текущего месяца");
            string userMonth = Console.ReadLine();

            Console.WriteLine("Введите минимальную температуру за месяц");
            string userTempMin = Console.ReadLine();
            Console.WriteLine("Введите максимальную температуру за месяц");
            string userTempMax = Console.ReadLine();

            if (int.TryParse(userTempMin, out tempMin) && int.TryParse(userTempMax, out tempMax))   //проверка на корректность ввода от пользователя
            {
                dailyTemp = (tempMax + tempMin) / 2;                                                //подсчет средней температуры
            }
            else
            {
                Console.WriteLine("Ошиблись при вводе температуры");                                //вывод сообщения об ошибке, если пользователь ввел не числа
                return;                                                                             //выход из программы, т.к. произошла ошибка
            }

            if (int.TryParse(userMonth, out int month))                                             //проверка на корректность ввода от пользователя
            {
                switch (month)                                                                      //если ввод от пользователя корректный, int.TryParse дает выводной результат в целочисленную переменную 'month'
                {
                    case 1:
                        {
                            enterMonth = "Январь";
                            isWinter = true;
                            break;
                        }
                    case 2:
                        {
                            enterMonth = "Февраль";
                            isWinter = true;
                            break;
                        }
                    case 3:
                        {
                            enterMonth = "Март";
                            break;
                        }
                    case 4:
                        {
                            enterMonth = "Апрель";
                            break;
                        }
                    case 5:
                        {
                            enterMonth = "Май";
                            break;
                        }
                    case 6:
                        {
                            enterMonth = "Июнь";
                            break;
                        }
                    case 7:
                        {
                            enterMonth = "Июль";
                            break;
                        }
                    case 8:
                        {
                            enterMonth = "Август";
                            break;
                        }
                    case 9:
                        {
                            enterMonth = "Сентябрь";
                            break;
                        }
                    case 10:
                        {
                            enterMonth = "Октябрь";
                            break;
                        }
                    case 11:
                        {
                            enterMonth = "Ноябрь";
                            break;
                        }
                    case 12:
                        {
                            enterMonth = "Декабрь";
                            isWinter = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введенное число не является месяцем...");            //вывод сообщения об ошибке, если пользователь ввел число не соответсвующие месяцу.
                            return;                                                                 //выход из программы, т.к. произошла ошибка
                        }
                }
            }
            else
            {
                Console.WriteLine("Введено не число для месяца!");                                  //вывод сообщения об ошибке, если пользователь ввел не число.
                return;                                                                             //выход из программы, т.к. произошла ошибка
            }

            if (isWinter && dailyTemp > 0)                                                          //Проверка: если - зима и темперратура > 0, то выводим сообщение 'Дождливая зима'
            {
                Console.WriteLine("Дождливая зима");
            }
            else
            {
                Console.WriteLine($"{enterMonth} - средняя температура: {dailyTemp}");              //Проверка не прошла (получили false) - выводим месяц и ср. температуру.
            }
        }
    }
}
