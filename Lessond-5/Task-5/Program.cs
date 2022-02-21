using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task_5
{
    internal class Program
    {
        /*
        * Задача 5
        * 
        *  (*) Список задач (ToDo-list):
        *  написать приложение для ввода списка задач;
        *  задачу описать классом ToDo с полями Title и IsDone;
        *  на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
        *  если задача выполнена, вывести перед её названием строку «[x]»;
        *  вывести порядковый номер для каждой задачи;
        *  при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
        *  записать актуальный массив задач в файл tasks.json/xml/bin.
        *  
        */
        static void Main(string[] args)
        {
            bool isRun = true;

            ListTask.ArrayTask = LoadTask();

            while (isRun)
            {
                ViewTask();

                string userEnter = Console.ReadLine();

                if (int.TryParse(userEnter, out int numberTask))
                {
                    if (numberTask == 0)
                    {
                        isRun = false;
                    }
                    else
                    {
                        ListTask.SetStatusTaskToIndex(numberTask);
                    }
                }
                else
                {
                    ToDo toDo = new ToDo();
                    toDo.Title = userEnter;
                    ListTask.Add(toDo);
                }

                SaveTask(ListTask.ArrayTask);
            }
        }

        static void ViewTask()
        {
            Console.Clear();
            for (int i = 0; i < ListTask.Count; i++)
            {
                string checkIsDone = ListTask.ArrayTask[i].IsDone ? "X" : " ";
                Console.WriteLine($"{i + 1}.\t[{checkIsDone}]\t{ListTask.ArrayTask[i].Title}");
            }
        }

        static void SaveTask(ToDo[] tasks)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("tasks.bin", FileMode.OpenOrCreate);
            formatter.Serialize(fileStream, tasks);
            fileStream.Dispose();
        }
        static ToDo[] LoadTask()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("tasks.bin", FileMode.Open);
            if (fileStream.Length > 0)
            {
                ToDo[] toDos = (ToDo[])formatter.Deserialize(fileStream);
                fileStream.Dispose();
                return toDos;
            }
            else
            {
                fileStream.Dispose();
                return new ToDo[0];
            }

        }
    }

    //List Task
    [Serializable]
    public static class ListTask
    {
        private static ToDo[] _arrayTask;

        public static ToDo[] ArrayTask
        {
            get { return _arrayTask; }
            set { _arrayTask = value; }
        }
        public static int Count
        {
            get { return _arrayTask.Length; }
        }

        public static void Add(ToDo item)
        {
            ToDo[] copy = _arrayTask;
            _arrayTask = new ToDo[_arrayTask.Length + 1];
            for (int i = 0; i < copy.Length; i++)
            {
                _arrayTask[i] = copy[i];
            }
            _arrayTask[_arrayTask.Length - 1] = item;
        }
        public static bool SetStatusTaskToIndex(int index)
        {
            if (index > _arrayTask.Length || index < 0)
            {
                return false;
            }

            _arrayTask[index - 1].IsDone = !_arrayTask[index - 1].IsDone;

            return true;
        }
    }

    [Serializable]
    public class ToDo
    {
        private string _title;
        private bool _isDone;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
    }
}
