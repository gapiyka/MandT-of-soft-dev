using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] equationArgs = ReadConsoleArguments();
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
            return new double[3] { aInput, bInput, cInput };
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

        private static void PauseConsole()
        {
            Console.ReadKey();
        }
    }
}
