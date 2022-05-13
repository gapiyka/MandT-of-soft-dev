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
            Handler.HelpText();
            Handler.HandleCommands();
        }

        static void NonInteractiveMode(string[] args)
        {
            Console.WriteLine("Non Interactive Mode!");
        }
    }
}
