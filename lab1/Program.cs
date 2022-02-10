using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] equationArgs = ReadConsoleArguments();

            PauseConsole();
        }

        private static int[] ReadConsoleArguments()
        {
            Console.WriteLine("Input numbers of Quadratic Equation!");
            Console.Write("a: ");
            var aInput = Console.ReadLine();
            Console.Write("b: ");
            var bInput = Console.ReadLine();
            Console.Write("c: ");
            var cInput = Console.ReadLine();
            return new int[3] { Int32.Parse(aInput), Int32.Parse(bInput), Int32.Parse(cInput) };
        }

        private static void PauseConsole()
        {
            Console.ReadKey();
        }
    }
}
