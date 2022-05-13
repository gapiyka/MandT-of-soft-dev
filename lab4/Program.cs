using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                InteractiveMode();
            }
            else
            {
                NonInteractiveMode(args);
            }
        }

        static void InteractiveMode()
        {
            Console.WriteLine("Interactive Mode!");
            Console.Write("Please, input your identifier-number and press `ENTER`: ");
            string identifier = Console.ReadLine(); 
            Console.Write("Please, input your password and press `ENTER`: ");
            string password = Console.ReadLine();
            if(AuthorizationSuccess(identifier, password))
            {
                HandleCommands(identifier);
            }
        }

        static void NonInteractiveMode(string[] args)
        {
            Console.WriteLine("Non Interactive Mode!");
        }

        static bool AuthorizationSuccess(string identifier, string password)
        {
            return true;
        }

        static void HandleCommands(string identifier)
        {
            bool exitFlag = false;
            string input;
            while (!exitFlag)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "x") exitFlag = true;
            }
            Console.WriteLine("Bye, bye!");
        }

        static void ShowAllTasks()
        {
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

        static void StatsOfTasks()
        {
            int activeTasks = 3;
            int doneTasks = 9;
            int overdueTasks = 3;
            Console.WriteLine("Active tasks: " + activeTasks);
            Console.WriteLine("Done tasks: " + doneTasks);
            Console.WriteLine("Overdue tasks: " + overdueTasks);
        }

        static void MarkTaskAsDone(ulong taskNumber)
        {
            Console.WriteLine("Task #" + taskNumber + " - D O N E.");
        }
        
        static void AddTask(string caption, string description, string deadline)
        {
            ulong taskNumber = 0;
            Console.WriteLine("Added task #" + taskNumber + " [" + caption + "]: " + description);
            Console.WriteLine("Deadline: " + deadline + "; Status: active");
        }
        
        static void EditTask(ulong taskNumber, string caption, string description, string deadline)
        {
            string taskStatus = "active";
            Console.WriteLine("Changed task #" + taskNumber + " [" + caption + "]: " + description);
            Console.WriteLine("Deadline: " + deadline + "; Status: " + taskStatus);
        }
         
        static void DeleteTask(ulong taskNumber)
        {
            Console.WriteLine("Task #" + taskNumber + " - D E L E T E D.");
        }
    }
}
