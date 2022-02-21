using System;
using System.IO;

namespace Task_2
{
    internal class Program
    {
        /*
         * Задача 2
         * 
         * Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
         * 
         */
        static void Main(string[] args)
        {
            File.AppendAllText("startup.txt", "\n" + DateTime.Now.ToString("T"));
        }
    }
}
