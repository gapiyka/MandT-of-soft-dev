using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab4
{
    public class TaskManager
    {
        const string fileName = "TaskList.json";
        static List<Task> tasksList;

        public static void FillList()
        {
            tasksList = new List<Task>();
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    tasksList.Add(JSONS.JsonToTask(line));
                }
            }
            else 
            {
                var file = File.CreateText(fileName);
                file.Close();
            }

        }

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
            SaveList();
        }

        static void SaveList()
        {
            string json = "";
            foreach (Task task in tasksList)
            {
                json += JSONS.TaskToJson(task) + "\n";
            }
            File.WriteAllText(fileName, json);
        }

        static void ShowAllTasks()
        {
            int activeTasks = 0;
            int doneTasks = 0;
            int overdueTasks = 0;
            Console.WriteLine("List of all tasks:\n");
            tasksList.ForEach(task =>
            {
                CheckAtOverdue(task);
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
                PrintTaskInfo(task);
            });
            Console.WriteLine("Active: " + activeTasks + " || " + "Done: " + doneTasks + " || " + "Overdue: " + overdueTasks);
        }

        static void ShowActiveTasks()
        {
            Console.WriteLine("List of all active tasks, sorted by deadline:\n");
            List<Task> activeList = new List<Task>();
            tasksList.ForEach(task =>
            {
                CheckAtOverdue(task);

                if (task.taskStatus == TaskStatus.Active)
                {
                    activeList.Add(task);
                }
            });
            BubbleSort(ref activeList, (int)activeList.Count);
            foreach(Task task in activeList)
            {
                PrintTaskInfo(task);
            }
        }

        static void ShowOverdueTasks()
        {
            Console.WriteLine("List of all overdue tasks:\n");
            tasksList.ForEach(task =>
            {
                CheckAtOverdue(task);
                if (task.taskStatus == TaskStatus.Overdue) PrintTaskInfo(task);
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
            Task newTask = new Task(taskNumber, caption, description, deadline);
            tasksList.Add(newTask);
            Console.WriteLine("Added : ");
            PrintTaskInfo(newTask);
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
                    Console.WriteLine("Changed : ");
                    PrintTaskInfo(task);
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

        static void CheckAtOverdue(Task task)
        {
            if (DateTime.Compare(task.deadline, DateTime.Now) < 0) task.taskStatus = TaskStatus.Overdue;
        }

        static void PrintTaskInfo(Task task)
        {
            Console.WriteLine("Task #" + task.number + " [" + task.caption + "]: " + task.description);
            Console.WriteLine("Deadline: " + task.deadline + "; Status: " + task.taskStatus);
            Console.WriteLine("----");
        }

        static void BubbleSort(ref List<Task> list, int size)
        {
            for (int step = 0; step < size; step++)
            {
                for (int i = 0; i < size - step - 1; i++)
                {
                    if (DateTime.Compare(list[i].deadline, list[i+1].deadline) > 0)
                    {
                        Task temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }
                }
            }
        }
    }
}
