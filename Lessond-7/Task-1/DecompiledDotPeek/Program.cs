// Decompiled with JetBrains decompiler
// Type: Task_1.Program
// Assembly: Program, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9F88A7B9-DD58-4F99-B282-3522406D7B65
// Assembly location: E:\WorkTable\Program.exe

using System;

namespace Task_1
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      string str1 = "crack";
      string str2 = "1234";
      Console.WriteLine("Hello!\nEnter your login...");
      string str3 = Console.ReadLine();
      Console.WriteLine("Okey, enter password...");
      string str4 = Console.ReadLine();
      if (str3 == str1 && str4 == str2)
        Console.WriteLine("Ok!");
      else
        Console.WriteLine("Error...");
      Console.ReadKey();
    }
  }
}
