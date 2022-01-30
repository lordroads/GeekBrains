using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Задача 4

            Для полного закрепления понимания простых типов найдите любой чек, 
            либо фотографию этого чека в интернете и схематично нарисуйте его в 
            консоли, только за место динамических, по вашему мнению, 
            данных (это может быть дата, название магазина, сумма покупок) 
            подставляйте переменные, которые были заранее заготовлены 
            до вывода на консоль.
             
             */
            string nameOrganization = "ООО 'ДВЕРНОЙ СЕЗОН'";
            int unpNumber = 790823530;
            string rNumber = "000000473";
            string nameOperator = "Иванов И.И.";
            string productName = "Товар 1";
            decimal productCost = 1100.00m;
            decimal nds = 20.00m;
            decimal ndsResult;
            decimal totalResult;
            DateTime dateTime = DateTime.Now;
            int receiptNumber = 656;
            string factoryNumber = "TA0000473";

            ndsResult = productCost * nds / 100;            //Подсчет НДС
            totalResult = productCost + ndsResult;          //Сумма ИТОГО

            //"Рисуем" чек на консоли
            Console.WriteLine("|                        |");
            Console.WriteLine($"|   {nameOrganization}  |");
            Console.WriteLine("|                        |");
            Console.WriteLine("**************************");
            Console.WriteLine("|                        |");
            Console.WriteLine($"|      УНП {unpNumber}     |");
            Console.WriteLine($"|      РН  {rNumber}     |");
            Console.WriteLine("|                        |");
            Console.WriteLine($"|  ОПЕРАТОР: {nameOperator} |");
            Console.WriteLine("|                        |");
            Console.WriteLine($"|   ПЛАТЕЖНЫЙ ДОКУМЕНТ   |");
            Console.WriteLine($"|       ЧЕК ПРОДАЖИ      |");
            Console.WriteLine($"|№1                      |");
            Console.WriteLine($"|{productName}          {productCost}|");
            Console.WriteLine($"|НДС А = {nds}%    {Math.Round(ndsResult, 2)}|"); //Math.Round() - округление до 2-х знаков после запятой.
            Console.WriteLine("|                        |");
            Console.WriteLine($"|СУММА НАЛОГОВ     {Math.Round(ndsResult, 2)}|");
            Console.WriteLine($"|ИТОГ             {Math.Round(totalResult, 2)}|");
            Console.WriteLine($"|НАЛИЧНЫМИ        {Math.Round(totalResult, 2)}|");
            Console.WriteLine("|                        |");
            Console.WriteLine($"|{dateTime} №{receiptNumber}|");
            Console.WriteLine($"|    ЗАВ.НОМ {factoryNumber}   |");
            Console.WriteLine($"|Ф_РБ                    |");
            Console.WriteLine("|                        |");
            Console.WriteLine($"|   СПАСИБО ЗА ПОКУПКУ!  |");
            Console.WriteLine("|                        |");
            Console.WriteLine("**************************");
        }
    }
}
