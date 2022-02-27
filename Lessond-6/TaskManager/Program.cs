using System;
using System.Diagnostics;
using System.Text;

namespace TaskManager
{
    internal class Program
    {
        /*
         *
         * Написать консольное приложение Task Manager, 
         * которое выводит на экран запущенные процессы и позволяет завершить указанный процесс. 
         * Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса. 
         * В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill.
         *
         */
        static readonly string[] suffixes = new string[]
        {
            "Bytes",
            "KB",
            "MB",
            "GB",
            "TB",
            "PB"
        };
        static readonly string[] nameHeader = new string[]
            {
                "Имя образа",
                "PID",
                "Имя сессии",
                "№ сеанса",
                "Память"
            };
        static int[] sizeColumns = new int[]
        {
                25,
                8,
                10,
                11,
                12,
                0
        };
        static bool loop = true;

        static Command[] commands = new Command[]
        {
            new Command()
            {
                FullCommandName = "tasklist",
                CompactCommandName = "tl",
                IsArg = true,
                Description = "Показывает список запушеных процессов на вашем ПК." +
                "\nПри передаче аргумента показывает список конкретных процессов.\n"
            },
            new Command()
            {
                FullCommandName = "taskkill",
                CompactCommandName = "tk",
                IsArg = true,
                Description = "Завершает процесс.\nПри передачи ID процесса, произведет завершение указаного." +
                "\nПри передаче НАЗВАНИЯ процесса,\nпопытает завершить группу одноименных процессов.\n"
            },
            new Command()
            {
                FullCommandName = "closeUI",
                CompactCommandName = "c",
                IsArg = true,
                Description = "ЗАвершает процессы с графическим интерфайсом,\nотправляя команду закрытия в главное окно." +
                "\nНе работает без передачи аргумента,\nнеобходимо передавать название процесса.\n"
            },
            new Command()
            {
                FullCommandName = "help",
                CompactCommandName = "h",
                IsArg = false,
                Description = "Описание имеющихся команд.\n"
            },
            new Command()
            {
                FullCommandName = "exit",
                CompactCommandName = "e",
                IsArg = false,
                Description = "Выход из программы.\n"
            }
        };

        static string[] enterCommand;


        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                enterCommand = args;
                StartCommand(enterCommand[0]);
            }
            else
            {
                SetSizeColumns(Process.GetProcesses());

                Console.WriteLine($"{new string(' ', sizeColumns[5] / 2 - 3)}Welcome!\n{new string(' ', sizeColumns[5] / 2 - 11)}This is my Task Manager");
                Console.WriteLine("Enter your command...");

                while (loop)
                {
                    enterCommand = Console.ReadLine().Split(' ');
                    StartCommand(enterCommand[0]);
                }
            }
        }

        public static void StartCommand(string command)
        {
            string status = string.Empty;
            switch (command)
            {
                case "tasklist":
                case "tl":
                    if (enterCommand.Length > 1)
                    {
                        GetTaskList(Process.GetProcessesByName(enterCommand[1]));
                    }
                    else
                    {
                        GetTaskList(Process.GetProcesses());
                    }
                    break;
                case "taskkill":
                case "tk":
                    if (enterCommand.Length > 1)
                    {
                        if (int.TryParse(enterCommand[1], out int intResult))
                        {
                            status = KillTask(intResult) ? "kill." : "not kill.";
                            Console.WriteLine($"The process of the program \"{enterCommand[1]}\" is {status}");
                        }
                        else
                        {
                            status = KillTask(enterCommand[1]) ? "kill." : "not kill.";
                            Console.WriteLine($"The process of the program \"{enterCommand[1]}\" is {status}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Enter command not arg. Command \"TaskKill\" added 1 arg! (ID or Name process.");
                    }
                    break;
                case "closeUI":
                case "c":
                    if (enterCommand.Length > 1)
                    {
                        status = CloseTask(enterCommand[1]) ? "closed." : "not closed.";
                        Console.WriteLine($"The process UI of the program \"{enterCommand[1]}\" is {status}"); //the process of the program "Y" is closed
                    }
                    else
                    {
                        Console.WriteLine($"Enter command not arg. Command \"CloseUI\" added 1 arg!");
                    }
                    break;
                case "help":
                case "h":
                    Help();
                    break;
                case "exit":
                case "e":
                    loop = false;
                    Console.WriteLine("Bye bye!");
                    break;
                default:
                    Console.WriteLine($"Not found command \"{command}\". Enter command \"help\" (h) for help.");
                    break;
            }
        }

        public static void Help()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Commands:");
            for (int i = 0; i < commands.Length; i++)
            {
                stringBuilder.Append($"{i + 1}) ");
                stringBuilder.Append(commands[i].FullCommandName);
                stringBuilder.Append(new string(' ', 15 - commands[i].FullCommandName.Length));
                stringBuilder.Append(commands[i].CompactCommandName);
                stringBuilder.Append("\tArgs - ");
                stringBuilder.AppendLine(commands[i].IsArg.ToString());
                stringBuilder.AppendLine("Description: ");
                stringBuilder.Append(commands[i].Description);
                stringBuilder.AppendLine();
            }
            Console.WriteLine(stringBuilder);
        }

        public static bool CloseTask(string nameTask)
        {
            bool result = true;
            Process[] processes = Process.GetProcessesByName(nameTask);
            try
            {
                if (processes.Length > 0)
                {
                    for (int i = 0; i < processes.Length; i++)
                    {
                        Process process = processes[i];
                        process.CloseMainWindow();
                        process.WaitForExit();
                        result = result && process.HasExited;
                    }

                    return result;
                }
                else
                {
                    Console.WriteLine($"[WARNING] - Process not found!");
                    return result = result && false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] - {ex.Message}");
                return result = result && false;
            }
        }
        public static bool KillTask(int idTask)
        {
            try
            {
                Process process = Process.GetProcessById(idTask);
                process.Kill();
                process.WaitForExit();

                return process.HasExited;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] - {ex.Message}");
                return false;
            }
        }
        public static bool KillTask(string nameTask)
        {
            bool result = true;
            Process[] processes = Process.GetProcessesByName(nameTask);
            try
            {
                if (processes.Length > 0)
                {
                    for (int i = 0; i < processes.Length; i++)
                    {
                        Process process = processes[i];
                        process.Kill();
                        process.WaitForExit();
                        result = result && process.HasExited;
                    }

                    return result;
                }
                else
                {
                    Console.WriteLine($"[WARNING] - Process not found!");
                    return result = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] - {ex.Message}");
                return result = false;
            }
        }

        public static void GetTaskList(params Process[] processes)
        {
            Console.Clear();
            SetSizeColumns(processes);
            ViewHeader();
            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine(GenerateStringFromTheProcess(processes[i]));
            }
        }

        static string GenerateStringFromTheProcess(Process process)
        {
            StringBuilder result = new StringBuilder();
            result.Append(process.ProcessName);
            result.Append(new string(' ', sizeColumns[0] - process.ProcessName.Length));

            result.Append(new string(' ', sizeColumns[1] + 1 - process.Id.ToString().Length));
            result.Append(process.Id);

            result.Append(new string(' ', sizeColumns[2] + 1 - GetProcessType(process).Length));
            result.Append(GetProcessType(process));

            result.Append(new string(' ', sizeColumns[3] + 1 - process.SessionId.ToString().Length));
            result.Append(process.SessionId);

            result.Append(new string(' ', sizeColumns[4] + 1 - FormatSize(process.PagedMemorySize64).Length));
            result.Append(FormatSize(process.PagedMemorySize64));

            return result.ToString();
        }

        static string GetProcessType(Process process)
        {
            try
            {
                string myType = process.MainWindowHandle == IntPtr.Zero ? "Service" : "Console";
                return myType;
            }
            catch (Exception)
            {
                return "None";
            }
        }

        public static void SetSizeColumns(Process[] processes)
        {
            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].ProcessName.Length > sizeColumns[0])
                {
                    sizeColumns[0] = processes[i].ProcessName.Length;
                }
                else if (processes[i].Id.ToString().Length > sizeColumns[1])
                {
                    sizeColumns[1] = processes[i].Id.ToString().Length;
                }
                else if (GetProcessType(processes[i]).Length > sizeColumns[2])
                {
                    sizeColumns[2] = GetProcessType(processes[i]).Length;
                }
                else if (FormatSize(processes[i].PagedMemorySize64).Length > sizeColumns[4])
                {
                    sizeColumns[4] = processes[i].SessionId.ToString().Length;
                }
            }
            for (int i = 0; i < sizeColumns.Length - 1; i++)
            {
                sizeColumns[5] += sizeColumns[i];
            }
        }

        public static string FormatSize(long bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1}{1}", number, suffixes[counter]);
        }

        static void ViewHeader()
        {
            for (int i = 0; i < nameHeader.Length - 1; i++)
            {
                if (i < nameHeader.Length - 2)
                {
                    Console.Write($"{nameHeader[i]}{new String(' ', sizeColumns[i] - nameHeader[i].Length)} ");
                }
                else
                {
                    Console.WriteLine($"{nameHeader[i]}{new String(' ', sizeColumns[i] - nameHeader[i].Length)}");
                }
            }
            for (int i = 0; i < sizeColumns.Length - 1; i++)
            {
                if (i < sizeColumns.Length - 2)
                {
                    Console.Write($"{new String('=', sizeColumns[i])} ");
                }
                else
                {
                    Console.WriteLine($"{new String('=', sizeColumns[i])}");
                }
            }
        }

    }

    public class Command
    {
        private string _fullCommandName;
        private string _compactCommandName;
        private bool _isArg;
        private string _description;

        public string FullCommandName
        {
            get { return _fullCommandName; }
            set { _fullCommandName = value; }
        }
        public string CompactCommandName
        {
            get { return _compactCommandName; }
            set { _compactCommandName = value; }
        }
        public bool IsArg
        {
            get { return _isArg; }
            set { _isArg = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
