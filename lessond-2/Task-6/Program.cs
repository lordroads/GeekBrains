using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    internal class Program
    {
        /*
             Задача 6
             
             (*) Для полного закрепления битовых масок, 
                попытайтесь создать универсальную структуру расписания недели, 
                к примеру, чтобы описать работу какого либо офиса. 
                Явный пример - офис номер 1 работает со вторника до пятницы, 
                офис номер 2 работает с понедельника до воскресенья и 
                выведите его на экран консоли.
        */

        //Битовые поля (флаги) для обозначени дней недели.
        [Flags]
        public enum Weekday
        {
            Monday = 0b_0000001,
            Tuesday = 0b_0000010,
            Wednesday = 0b_0000100,
            Thursday = 0b_0001000,
            Friday = 0b_0010000,
            Saturday = 0b_0100000,
            Sunday = 0b_1000000
        }
        static void Main(string[] args)
        {
            // Составление графиков работы офисов
            Weekday officeStandartTimetable = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday;
            Weekday officeShiftedTimetable = Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;
            Weekday officeIndividualTimetable = Weekday.Monday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            Weekday fredTimetable = (Weekday)0b_1010101; // График работы Фреда 

            Console.WriteLine($"Офис со стандартным графиком работы: {officeStandartTimetable}");
            Console.WriteLine($"Офис со смещенным графиком работы: {officeShiftedTimetable}");
            Console.WriteLine($"Офис со индивидуальным графиком работы: {officeIndividualTimetable}");
            Console.WriteLine($"График работы Фреда: {fredTimetable}");
        }
    }
}
