using System;

namespace lab4
{
    class Handler
    {
        public static void HandleCommands()
        {
            bool exitFlag = false;
            string input;
            while (!exitFlag)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "x") exitFlag = true;
                TaskManager.ManageCommand(input.Split(" "));
            }
            Console.WriteLine("Bye, bye!");
        }

        public static void HelpText()
        {
            Console.WriteLine("[HINTS]: `command_flag` `parameters`");
            Console.WriteLine("[-all] - show all tasks.");
            Console.WriteLine("[-act] - show active tasks.");
            Console.WriteLine("[-sot] - show overdue tasks.");
            Console.WriteLine("[-add yyyy-mm-dd-hh-mm caption description] - add task with `deadline`, `caption` as first arg, `description` and all args separated by space.");
            Console.WriteLine("[-edit taskNumber yyyy-mm-dd-hh-mm caption description] - add task with `taskNumber` as first arg, `deadline`, `caption`, `description` and all args separated by space.");
            Console.WriteLine("[-remove taskNumber] - remove task by `taskNumber`.");
            Console.WriteLine("[-done taskNumber] - mark task by `taskNumber` as done.");
        }
    }
}
