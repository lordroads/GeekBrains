﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace less_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            Console.WriteLine($"Привет, {userName}, сегодня {DateTime.Now.ToShortDateString()}");
        }
    }
}
