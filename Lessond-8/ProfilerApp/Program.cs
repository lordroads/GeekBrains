using System;
using System.Text;

namespace ProfilerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Создать консольное приложение, 
                которое при старте выводит приветствие, 
                записанное в настройках приложения (application-scope). 
                Запросить у пользователя имя, возраст и род деятельности, 
                а затем сохранить данные в настройках. 
                При следующем запуске отобразить эти сведения. 
                Задать приложению версию и описание.
             */


            if (Properties.Settings.Default.Name == String.Empty)
            {
                Console.WriteLine(Properties.Settings.Default.WelcomeAll);
                Console.WriteLine("ВВедите ваше имя.");
                Properties.Settings.Default.Name = Console.ReadLine();
                Console.WriteLine("ВВедите ваш возраст.");
                Properties.Settings.Default.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("ВВедите род вашей деятельности");
                Properties.Settings.Default.Activity = Console.ReadLine();
                Properties.Settings.Default.Save();
                Console.WriteLine("Спасибо, данные сохранены");
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                Console.WriteLine(Properties.Settings.Default.WelcomeUser, Properties.Settings.Default.Name);
                stringBuilder.AppendLine($"Я тебя помню. Твой возраст: {Properties.Settings.Default.Age}\nТы занимаешься: {Properties.Settings.Default.Activity}");

                Console.WriteLine(stringBuilder);
            }


            Console.WriteLine("Если хочешь стереть сохраненные данные нажми F1, для продолжения нажми Space");
            if (Console.ReadKey().Key == ConsoleKey.F1)
            {
                Properties.Settings.Default.Reset();
                Console.WriteLine("Данные стерты, перезапусти приложение.");
            }
        }
    }
}
