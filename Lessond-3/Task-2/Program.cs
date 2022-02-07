using System;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * Задание 2
             * 
             * Написать программу — телефонный справочник — создать двумерный массив 5*2, 
             * хранящий список телефонных контактов: первый элемент хранит имя контакта, 
             * второй — номер телефона/e-mail.            
             *
             */

            //Проинициализиролавили двухмерный массив [5,2] и заполнени его данными
            string[,] phoneBook = new string[5, 2]
            {
                { "Bob" , "123-65-98" },
                { "Sten Li" , "sten_li@marvel.com" },
                { "Doc" , "911" },
                { "Vasya" , "89991234567" },
                { "Friman.A" , "fa@apress.com" }
            };

            for (int x = 0; x <= phoneBook.GetUpperBound(0); x++)       //первый цикл for проходит по первому измерению массива
            {
                Console.Write($"{x + 1}: ");                            //порядковый номер для красоты отображения на консоле
                for (int y = 0; y <= phoneBook.GetUpperBound(1); y++)   //второй цикл for проходит по второму измерению массива
                {
                    Console.Write($"{phoneBook[x, y]}");                //выводим поочередно ранее записаные данные на консоль
                    if (y == 0)
                    {
                        Console.Write($" : ");                          //разделитель для красоты отображения на консоле
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
