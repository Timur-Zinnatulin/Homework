using System;

namespace Hw_1._2
{
    class Program
    {
        private static int Fibonacci(int n)
        {
            if ((n == 1) || (n == 2))
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter an index of a Fibonacci number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"The Fibonacci number is {Fibonacci(n)}");
        }
    }
}
