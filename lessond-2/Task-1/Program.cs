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
            /*
            Задача 1

            Запросить у пользователя минимальную и максимальную температуру за сутки
            и вывести среднесуточную температуру.
            */
            int dailyTemp = 0;

            Console.WriteLine("Введите минимальную температуру за сегодня");
            string userTempMin = Console.ReadLine();
            Console.WriteLine("Введите максимальную температуру за сегодня");
            string userTempMax = Console.ReadLine();

            if (int.TryParse(userTempMin, out int tempMin) && int.TryParse(userTempMax, out int tempMax))   //проверка на корректность ввода от пользователя
            {
                dailyTemp = (tempMax + tempMin) / 2;                                                        //подсчет средней температуры
                Console.WriteLine($"Среднесуточную температура за сегодня: {dailyTemp}t");
            }
            else
            {
                Console.WriteLine("Ошиблись при вводе температуры");                                        //вывод сообщения об ошибке, если пользователь ввел не числа
            }
        }
    }
}
