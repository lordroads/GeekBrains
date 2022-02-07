using System;

namespace Task_2
{
    internal class Program
    {
        /*
             * Задача 2
             * 
             * Написать программу, 
             * принимающую на вход строку — набор чисел, разделенных пробелом, 
             * и возвращающую число — сумму всех чисел в строке. 
             * Ввести данные с клавиатуры и вывести результат на экран.
             * 
             */
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа через пробел.");
            string userEnter = Console.ReadLine();
            string[] userWord = SplitBySeparator(userEnter, ' ');
            int[] userNumbers = ConvertArrayStingToInt(userWord);
            int summary = Summary(userNumbers);

            Console.WriteLine($"Сумма введенных чисел - {summary}");
        }

        static string[] SplitBySeparator(string symbols, char separator)
        {
            string[] result = new string[0];
            string[] copy = new string[0];
            string enterWorld = String.Empty;
            int startIndexCharNumber = 47;
            int endIndexCharNumber = 58;

            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == separator || i == symbols.Length - 1)
                {
                    if (i == symbols.Length - 1)
                    {
                        if (symbols[i] > startIndexCharNumber && symbols[i] < endIndexCharNumber) //Взять только символы цифр
                        {
                            enterWorld += symbols[i];
                        }
                    }
                    copy = result;
                    int oldLength = result.Length;
                    result = new string[oldLength + 1];
                    for (int j = 0; j < copy.Length; j++)
                    {
                        result[j] = copy[j];
                    }
                    result[oldLength] = enterWorld;
                    enterWorld = String.Empty;
                }
                else
                {
                    if (symbols[i] > startIndexCharNumber && symbols[i] < endIndexCharNumber)
                    {
                        enterWorld += symbols[i];
                    }
                }
            }
            return result;
        }

        static int[] ConvertArrayStingToInt(string[] words)
        {
            int[] result = new int[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                if (int.TryParse(words[i], out int num))
                {
                    result[i] = num;
                }
                else
                {
                    result[i] = 0;
                }
            }

            return result;
        }

        static int Summary(params int[] numbers)
        {
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }
            return result;
        }
    }
}
