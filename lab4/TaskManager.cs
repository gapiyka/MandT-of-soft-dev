using System;
using System.Collections.Generic;
using System.Linq;

namespace lab4
{
    class TaskManager
    {
        static List<Task> tasksList = new List<Task>();
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
            int activeTasks = 0;
            int doneTasks = 0;
            int overdueTasks = 0;
            Console.WriteLine("List of all tasks:\n");
            tasksList.ForEach(task =>
            {
                if (DateTime.Compare(task.deadline, DateTime.Now) < 0) task.taskStatus = TaskStatus.Overdue;
                switch (task.taskStatus)
                {
                    case TaskStatus.Active:
                        activeTasks++;
                        break;
                    case TaskStatus.Overdue:
                        overdueTasks++;
                        break;
                    case TaskStatus.Done:
                        doneTasks++;
                        break;
                }
                Console.WriteLine("Task #" + task.number + " [" + task.caption + "]: " + task.description);
                Console.WriteLine("Deadline: " + task.deadline + "; Status: " + task.taskStatus);
                Console.WriteLine("----");
            });
            Console.WriteLine("Active: " + activeTasks + " || " + "Done: " + doneTasks + " || " + "Overdue: " + overdueTasks);
        }

        static void ShowActiveTasks()
        {
            Console.WriteLine("List of all active tasks, sorted by deadline:\n");
            tasksList.ForEach(task =>
            {
                if (DateTime.Compare(task.deadline, DateTime.Now) < 0) task.taskStatus = TaskStatus.Overdue;

                if (task.taskStatus == TaskStatus.Active)
                {
                    Console.WriteLine("Task #" + task.number + " [" + task.caption + "]: " + task.description);
                    Console.WriteLine("Deadline: " + task.deadline + "; Status: " + task.taskStatus);
                    Console.WriteLine("----");
                }
            });
        }

        static void ShowOverdueTasks()
        {
            Console.WriteLine("List of all overdue tasks:\n");
            tasksList.ForEach(task =>
            {
                if (task.taskStatus == TaskStatus.Overdue || DateTime.Compare(task.deadline, DateTime.Now) < 0)
                {
                    task.taskStatus = TaskStatus.Overdue;
                    Console.WriteLine("Task #" + task.number + " [" + task.caption + "]: " + task.description);
                    Console.WriteLine("Deadline: " + task.deadline + "; Status: " + task.taskStatus);
                    Console.WriteLine("----");
                }
            });
        }

        static void MarkTaskAsDone(string taskNumber)
        {
            bool endProccess = false;
            tasksList.ForEach(task => 
            {
               if(task.number == UInt64.Parse(taskNumber))
                {
                    task.taskStatus = TaskStatus.Done;
                    Console.WriteLine("Task #" + taskNumber + " - D O N E.");
                    endProccess = true;
                    return;
                }
            });
            if(!endProccess) Console.WriteLine("Task #" + taskNumber + " - didn`t find.");
        }

        static void AddTask(string deadline, string caption, string description)
        {
            ulong taskNumber = (ulong)tasksList.Count + 1;
            tasksList.Add(new Task(taskNumber, caption, description, deadline));
            Console.WriteLine("Added task #" + taskNumber + " [" + caption + "]: " + description);
            Console.WriteLine("Deadline: " + deadline + "; Status: active");
        }

        static void EditTask(string taskNumber, string deadline, string caption, string description)
        {
            bool endProccess = false;
            tasksList.ForEach(task =>
            {
                if (task.number == UInt64.Parse(taskNumber))
                {
                    task.caption = caption;
                    task.description = description;
                    DateTime newDate = task.StringToDate(deadline);
                    task.deadline = newDate;
                    if (DateTime.Compare(newDate, DateTime.Now)>0)
                    {
                        task.taskStatus = TaskStatus.Active;
                    }
                    task.deadline = newDate;

                    Console.WriteLine("Changed task #" + taskNumber + " [" + caption + "]: " + description);
                    Console.WriteLine("Deadline: " + deadline + "; Status: " + task.taskStatus);
                    endProccess = true;
                    return;
                }
            });
            if (!endProccess) Console.WriteLine("Task #" + taskNumber + " - didn`t find.");
        }

        static void DeleteTask(string taskNumber)
        {
            bool endProccess = false;
            Task findTask = null;
            tasksList.ForEach(task =>
            {
                if (task.number == UInt64.Parse(taskNumber))
                {
                    findTask = task;
                    endProccess = true;
                    return;
                }
            });
            if (!endProccess) Console.WriteLine("Task #" + taskNumber + " - didn`t find.");
            else
            {
                tasksList.Remove(findTask);
                Console.WriteLine("Task #" + taskNumber + " - D E L E T E D.");
                ulong counter = 0;
                tasksList.ForEach(task =>
                {
                    counter++;
                    if (counter != task.number) task.number--;
                });
            }

        }
    }
}
