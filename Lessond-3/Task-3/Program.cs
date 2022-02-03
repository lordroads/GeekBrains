using System;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * Задание 3
             * 
             * Написать программу, 
             * выводящую введенную пользователем строку в обратном порядке 
             * (olleH вместо Hello).            
             *
             */

            //Получаем строку от пользователя
            Console.WriteLine("Введите слово: ");
            string userEnter = Console.ReadLine();
            //можно проверить точно ли нам пользователь что то отправил
            if (!string.IsNullOrEmpty(userEnter))                               //Если строка не пустая и не null то получим false
            {
                string newString = "";                                          //создаем новую строку для разворота слова от пользователя
                for (int i = userEnter.Length - 1; i >= 0; i--)                 //проходимся по строке от пользователя в обратном порядке и сохраняем символы в новой строке
                {
                    newString += userEnter[i];
                }
                Console.WriteLine($"\"{newString}\" вместо \"{userEnter}\"");   //выводим новую строку на консоль
            }
            else
            {
                Console.WriteLine("Забыли ввести слово!");
            }
        }
    }
}
