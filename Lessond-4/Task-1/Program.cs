using System;

namespace Task_1
{
    internal class Program
    {
        /*
             * Задача 1
             * 
             * Написать метод GetFullName(string firstName, string lastName, string patronymic), 
             * принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. 
             * Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
             *
             */
        static void Main(string[] args)
        {
            string[][] arrayPersonsName = new string[4][]
            {
                new string[3]{"Иванов","Иван","Иванович"},
                new string[3]{"Петров","Петров","Петрович"},
                new string[3]{"Сидоров","Семен","Семенович"},
                new string[3]{"Токарев","Александ","Александрович"}
            };

            for (int i = 0; i < arrayPersonsName.Length; i++)
            {
                string fullName = GetFullName(arrayPersonsName[i][0], arrayPersonsName[i][1], arrayPersonsName[i][2]);
                Console.WriteLine(fullName);
            }

            //Альтернатива методу GetFullName 
            Console.WriteLine(JoinStringOnSpace("0:", "Пупкин", "Василий", "Васильевич"));

            for (int i = 0; i < arrayPersonsName.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {JoinStringOnSpace(arrayPersonsName[i])}");
            }
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            string fullName = $"{lastName} {firstName} {patronymic}";
            return fullName;
        }

        static string JoinStringOnSpace(params string[] value)
        {
            string joinString = "";
            for (int i = 0; i < value.Length; i++)
            {
                joinString += value[i];
                joinString += i < value.Length - 1 ? " " : "";
            }

            return joinString;
        }
    }
}
