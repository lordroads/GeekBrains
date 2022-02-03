using System;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * Задание 4
             * 
             * (*) «Морской бой» — вывести на экран массив 10х10, 
             * состоящий из символов X и O, 
             * где Х — элементы кораблей, 
             * а О — свободные клетки.           
             *
             */

            //Массив 10х10
            char[,] battleField =
            {
                { 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X'},
                { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                { 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X'},
                { 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X'},
                { 'X', 'O', 'O', 'X', 'X', 'X', 'X', 'O', 'O', 'X'},
                { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                { 'O', 'O', 'X', 'O', 'O', 'O', 'O', 'X', 'O', 'O'},
                { 'X', 'O', 'X', 'O', 'X', 'X', 'O', 'X', 'O', 'X'}
            };

            for (int x = 0; x <= battleField.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= battleField.GetUpperBound(1); y++)
                {
                    Console.Write($"\t{battleField[x, y]}");            //Вывод на консоль поочередно каждый символ.
                }
                Console.WriteLine();
            }
        }
    }
}
