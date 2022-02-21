using System;
using System.IO;

namespace Task_4
{
    internal class Program
    {
        /*
        * Задача 4
        * 
        *  (*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
        */

        static void Main(string[] args)
        {
            string path = "D:\\downloads";
            if (File.Exists(Directory.GetCurrentDirectory() + "\\saveTree.txt"))
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\saveTree.txt");
            }
            if (File.Exists(Directory.GetCurrentDirectory() + "\\saveTreeCycle.txt"))
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\saveTreeCycle.txt");
            }

            Console.WriteLine($"{new String('*', 50)}С РЕКУРСИЕЙ{new String('*', 50)}");
            GetTreeRecursion(path, 0);

            Console.WriteLine($"{new String('*', 50)}БЕЗ РЕКУРСИЕЙ{new String('*', 48)}");
            GetTreeCycle(path);

            Console.WriteLine("WELL DONE!");
        }

        static void GetTreeCycle(string path)
        {
            ArrayStack.Add(path);

            while (ArrayStack.Count > 0)
            {
                string currentDir = ArrayStack.GetLast();

                if (currentDir.Length != ArrayStack.LastLength)
                {
                    ArrayStack.Offset = currentDir.Length - Path.GetFileName(currentDir).Length - 3;
                }
                else
                {
                    ArrayStack.Offset = 0;
                }

                Console.Write("|");
                Console.Write(new String(' ', ArrayStack.Offset));
                Console.Write("|-");
                Console.WriteLine(Path.GetFileName(currentDir));

                string sectionTreeDirectory = $"\n|{new String(' ', ArrayStack.Offset)}|-{Path.GetFileName(currentDir)}";
                File.AppendAllText(Directory.GetCurrentDirectory() + "\\saveTreeCycle.txt", sectionTreeDirectory);

                string[] subDirs = Directory.GetDirectories(currentDir);
                string[] files = Directory.GetFiles(currentDir);

                for (int i = 0; i < files.Length; i++)
                {
                    Console.Write("|");
                    Console.Write(new String(' ', ArrayStack.Offset + Path.GetFileName(currentDir).Length + 1));
                    Console.Write("|-");
                    Console.WriteLine(Path.GetFileName(files[i]));

                    string sectionTreeFile = $"\n|{new String(' ', ArrayStack.Offset + Path.GetFileName(currentDir).Length + 1)}|-{Path.GetFileName(files[i])}";
                    File.AppendAllText(Directory.GetCurrentDirectory() + "\\saveTreeCycle.txt", sectionTreeFile);
                }

                for (int i = subDirs.Length - 1; i >= 0; i--)
                {
                    ArrayStack.Add(subDirs[i]);
                }

                ArrayStack.LastLength = currentDir.Length;
            }
        }

        static class ArrayStack
        {
            private static string[] _stack = new string[0];
            private static int _offset = 0;
            private static int _lastLength = 0;

            public static string[] Stack
            {
                get { return _stack; }
                set { _stack = value; }
            }
            public static int Offset
            {
                get { return _offset; }
                set { _offset = value; }
            }
            public static int LastLength
            {
                get { return _lastLength; }
                set { _lastLength = value; }
            }
            public static int Count
            {
                get { return _stack.Length; }
            }

            public static void Add(string item)
            {
                string[] copy = _stack;
                _stack = new string[_stack.Length + 1];
                for (int i = 0; i < copy.Length; i++)
                {
                    _stack[i] = copy[i];
                }
                _stack[_stack.Length - 1] = item;
            }

            public static string GetLast()
            {
                string last = _stack[_stack.Length - 1];

                string[] copy = _stack;
                _stack = new string[copy.Length - 1];
                for (int i = 0; i < copy.Length - 1; i++)
                {
                    _stack[i] = copy[i];
                }

                return last;
            }
        }

        static void GetTreeRecursion(string pathSource, int offset)
        {
            Console.WriteLine(Path.GetFileName(pathSource));
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\saveTree.txt", Path.GetFileName(pathSource));

            string[] files = Directory.GetFiles(pathSource);
            for (int i = 0; i < files.Length; i++)
            {
                Console.Write("|");
                Console.Write(new String(' ', Path.GetFileName(pathSource).Length + offset));
                Console.Write("|-");
                Console.WriteLine(Path.GetFileName(files[i]));

                string sectionTree = $"\n|{new String(' ', Path.GetFileName(pathSource).Length + offset)}|-{Path.GetFileName(files[i])}";

                File.AppendAllText(Directory.GetCurrentDirectory() + "\\saveTree.txt", sectionTree);
            }

            string[] directories = Directory.GetDirectories(pathSource);
            for (int i = 0; i < directories.Length; i++)
            {
                Console.Write("|");
                Console.Write(new String(' ', Path.GetFileName(pathSource).Length + offset));
                Console.Write("|-");

                string sectionTree = $"\n|{new String(' ', Path.GetFileName(pathSource).Length + offset)}|-";
                File.AppendAllText(Directory.GetCurrentDirectory() + "\\saveTree.txt", sectionTree);

                GetTreeRecursion(directories[i], Path.GetFileName(pathSource).Length + offset);
            }
        }
    }
}
