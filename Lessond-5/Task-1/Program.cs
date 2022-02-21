using System;
using System.IO;

namespace Task_1
{
    internal class Program
    {
        /*
         * Задача 1
         * 
         * Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
         *
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст для записи в файл.");
            string userText = Console.ReadLine();
            SaveTextInFile(userText);
            Console.WriteLine("Файл сохранен.");
        }

        static void SaveTextInFile(string text)
        {
            string currentDir = Directory.GetCurrentDirectory() + "\\data";
            string currentPath = currentDir + "\\text.txt";

            Directory.CreateDirectory(currentDir);
            File.WriteAllText(currentPath, text);
        }
    }
}
