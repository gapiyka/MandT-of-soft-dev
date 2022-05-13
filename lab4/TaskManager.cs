using System;
using System.Linq;

namespace lab4
{
    class TaskManager
    {
        public static void ManageCommand(string[] args)
        {
            switch (args[0])
            {
                case "-all":
                    ShowAllTasks();
                    break;
                case "-act":
                    ShowActiveTasks();
                    break;
                case "-sot":
                    ShowOverdueTasks();
                    break;
                case "-add":
                    if (args.Length >= 4) AddTask(args[1], args[2],
                        string.Join(" ", args.Skip(3).Take(args.Length - 3).ToArray()));
                    else Console.WriteLine("Wrong arguments count.");
                    break;
                case "-edit":
                    if (args.Length >= 5) EditTask(args[1], args[2], args[3], 
                        string.Join(" ", args.Skip(4).Take(args.Length-4).ToArray()));
                    else Console.WriteLine("Wrong arguments count.");
                    break;
                case "-remove":
                    if (args.Length == 2) DeleteTask(args[1]);
                    else Console.WriteLine("Wrong arguments count.");
                    break;
                case "-done":
                    if(args.Length == 2) MarkTaskAsDone(args[1]);
                    else Console.WriteLine("Wrong arguments count.");
                    break;
                case "-help":
                    Handler.HelpText();
                    break;
                default:
                    Console.WriteLine("Wrong command.");
                    break;
            }
        }

        static void ShowAllTasks()
        {
            int activeTasks = 3;
            int doneTasks = 9;
            int overdueTasks = 3;
            Console.WriteLine("Active: " + activeTasks + " || " + "Done: " + doneTasks + " || " + "Overdue: " + overdueTasks);
            Console.WriteLine("List of all active|done tasks.");
        }

        static void ShowActiveTasks()
        {
            Console.WriteLine("List of all active tasks, sorted by deadline.");
        }

        static void ShowOverdueTasks()
        {
            Console.WriteLine("List of all overdue tasks.");
        }

        static void MarkTaskAsDone(string taskNumber)
        {
            Console.WriteLine("Task #" + taskNumber + " - D O N E.");
        }

        static void AddTask(string deadline, string caption, string description)
        {
            ulong taskNumber = 0;
            Console.WriteLine("Added task #" + taskNumber + " [" + caption + "]: " + description);
            Console.WriteLine("Deadline: " + deadline + "; Status: active");
        }

        static void EditTask(string taskNumber, string deadline, string caption, string description)
        {
            string taskStatus = "active";
            Console.WriteLine("Changed task #" + taskNumber + " [" + caption + "]: " + description);
            Console.WriteLine("Deadline: " + deadline + "; Status: " + taskStatus);
        }

        static void DeleteTask(string taskNumber)
        {
            Console.WriteLine("Task #" + taskNumber + " - D E L E T E D.");
        }
    }
}
