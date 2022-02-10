using System;
using System.IO;

namespace lab1
{
    class Program
    {
        const int MAX_ARGS_COUNT = 3;
        static void Main(string[] args)
        {
            double[] equationArgs = { 0, 0, 0 };
            int argsCount = args.Length;
            if (argsCount == 0) equationArgs = ReadConsoleArguments();
            else if (argsCount == MAX_ARGS_COUNT) equationArgs = ReadMainArguments(args);
            else if (argsCount == 1) equationArgs = ReadFileArguments(args);
            Console.WriteLine("Quadratic equation is: " + equationArgs[0] + "*" +
                                "x^2 + (" + equationArgs[1] + ")*x + (" + equationArgs[2] + ")");
            SolveEquation(equationArgs[0], equationArgs[1], equationArgs[2]);
            PauseConsole();
        }

        private static double[] ReadConsoleArguments()
        {
            Console.WriteLine("Input numbers of Quadratic Equation!");
            double aInput = TryReadNum("a: ");
            double bInput = TryReadNum("b: ");
            double cInput = TryReadNum("c: ");
            return new double[MAX_ARGS_COUNT] { aInput, bInput, cInput };
        }

        private static double TryReadNum(string val)
        {
            Console.Write(val);
            var input = Console.ReadLine();
            if (!double.TryParse(input, out double parsedInput))
            {
                Console.WriteLine("Invalid number value, entered '" + input + "' instead");
                return TryReadNum(val);
            }
            else
            {
                return parsedInput;
            }
        }

        private static double[] ReadMainArguments(string[] args)
        {
            string execptionMSG = "Launch app with another main argument";
            if (!double.TryParse(args[0], out double aVal)) CloseConsole(execptionMSG);
            if (!double.TryParse(args[1], out double bVal)) CloseConsole(execptionMSG);
            if (!double.TryParse(args[2], out double cVal)) CloseConsole(execptionMSG);
            return new double[MAX_ARGS_COUNT] { aVal, bVal, cVal };
        }

        private static double[] ReadFileArguments(string[] args)
        {
            double[] argsD = new double[MAX_ARGS_COUNT];
            string fileText = "";
            try
            {
                fileText = File.ReadAllText(args[0]);
            }
            catch(Exception e)
            {
                CloseConsole("Wrong path to file");
            }

            string[] splitArgs = fileText.Split(" ");
            if (splitArgs.Length == MAX_ARGS_COUNT)
            {
                for(int i = 0; i < MAX_ARGS_COUNT; i++)
                {
                    string str = splitArgs[i];
                    if (!double.TryParse(str, out double res)) CloseConsole("Not correct format of values in file");
                    else argsD[i] = res;
                }
            }
            else CloseConsole("In file should be 3 arguments slpited by space");

            return argsD;
        }

        private static void SolveEquation(double a, double b, double c)
        {
            double x1, x2;
            double discr = b * b - 4 * a * c;
            double sqrt = Math.Sqrt(discr);
            string resultString;

            if (discr > 0)
            {
                x1 = (-b + sqrt) / (2 * a);
                x2 = (-b - sqrt) / (2 * a);

                resultString = "Result: x1=" + x1 + "; x2=" + x2;
            }
            else if (discr < 0)
            {
                resultString = "Result: No roots";
            }
            else
            {
                x1 = (-b) / (2 * a);
                resultString = "Result: x=" + x1;
            }

            Console.WriteLine(resultString);
        }

        private static void CloseConsole(string msg)
        {
            Console.WriteLine(msg);
            PauseConsole();
            Environment.Exit(-1);
        }

        private static void PauseConsole()
        {
            Console.ReadKey();
        }
    }
}
