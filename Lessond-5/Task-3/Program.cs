using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task_3
{
    internal class Program
    {
        /*
        * Задача 3
        * 
        * Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
        *
        */
        static void Main(string[] args)
        {
            Console.WriteLine("Ввести с клавиатуры произвольный набор чисел (0...255)");
            string userEnter = Console.ReadLine();

            //Способ 1
            byte[] userNumbers = ConvertStringToArrayByte(userEnter, ' ');
            File.WriteAllBytes("way_1.bin", userNumbers);

            //Способ 2
            MemoryString memoryString = new MemoryString();
            memoryString.Numbers = userEnter;
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(new FileStream("way_2.bin", FileMode.OpenOrCreate), memoryString);

            //Способ 3
            MemoryInt memoryInt = new MemoryInt();
            memoryInt.Numbers = ConvertStringToArrayInt(userEnter, ' ');
            BinaryFormatter formatter2 = new BinaryFormatter();
            formatter2.Serialize(new FileStream("way_3.bin", FileMode.OpenOrCreate), memoryInt);


        }

        public static byte[] ConvertStringToArrayByte(string text, char separator)
        {
            byte[] result = new byte[0];
            string number = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    number += text[i];
                }
                else if (text[i] == separator || i == text.Length - 1)
                {
                    byte[] copy = result;
                    result = new byte[copy.Length + 1];
                    for (int x = 0; x < copy.Length; x++)
                    {
                        result[x] = copy[x];
                    }
                    result[result.Length - 1] = byte.Parse(number);
                    number = string.Empty;
                }
            }

            return result;
        }

        public static int[] ConvertStringToArrayInt(string text, char separator)
        {
            int[] result = new int[0];
            string number = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    number += text[i];
                }
                else if (text[i] == separator || i == text.Length - 1)
                {
                    int[] copy = result;
                    result = new int[copy.Length + 1];
                    for (int x = 0; x < copy.Length; x++)
                    {
                        result[x] = copy[x];
                    }
                    result[result.Length - 1] = int.Parse(number);
                    number = string.Empty;
                }
            }

            return result;
        }

    }

    [Serializable]
    public class MemoryString
    {
        private string _numbers;

        public string Numbers
        {
            get { return _numbers; }
            set { _numbers = value; }
        }
    }

    [Serializable]
    public class MemoryInt
    {
        private int[] _numbers;

        public int[] Numbers
        {
            get { return _numbers; }
            set { _numbers = value; }
        }
    }
}

