using System;

namespace Task_3
{
    internal class Program
    {
        /*
            * Задача 3
            * 
            * Написать метод по определению времени года. 
            * На вход подаётся число – порядковый номер месяца. 
            * На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn. 
            * Написать метод, 
            * принимающий на вход значение из этого перечисления и возвращающий название времени года (зима, весна, лето, осень). 
            * Используя эти методы, 
            * ввести с клавиатуры номер месяца и вывести название времени года. 
            * Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
            *
            */
        static void Main(string[] args)
        {
            Console.WriteLine("Введите порядковый номер месяца");
            string userEnter = Console.ReadLine();
            if (int.TryParse(userEnter, out int numMonth))
            {
                if (FatalError(numMonth))
                {
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
                }
                else
                {
                    Console.WriteLine(ConvertSeasonToString(GetSeason(numMonth)));
                }
            }
            else
            {
                Console.WriteLine("Введено не число!");
            }
        }

        enum Seasons
        {
            Winter,
            Spring,
            Summer,
            Autumn
        }

        static bool FatalError(int numMonth)
        {
            if (numMonth > 0 && numMonth <= 12)
            {
                return false;
            }
            return true;
        }

        static Seasons GetSeason(int numberMonth)
        {
            switch (numberMonth)
            {
                case 3:
                case 4:
                case 5:
                    return Seasons.Spring;
                case 6:
                case 7:
                case 8:
                    return Seasons.Summer;
                case 9:
                case 10:
                case 11:
                    return Seasons.Autumn;
                default:
                    return Seasons.Winter;

            }
        }

        static string ConvertSeasonToString(Seasons season)
        {
            switch (season)
            {
                case Seasons.Winter:
                    return "Зима";
                case Seasons.Spring:
                    return "Весна";
                case Seasons.Summer:
                    return "Лето";
                case Seasons.Autumn:
                    return "Осень";
                default:
                    return "Непонятный какой то сезон";
            }
        }
    }
}
