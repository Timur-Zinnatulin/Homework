using System;

namespace Hw_1._2
{
    class Program
    {
        private static int Fibonacci(int n)
        {
            if (n < 1)
            {
                return -1;
            }

            int previous = 0;
            int current = 1;

            for (int i = 0; i < n - 1; ++i)
            {
                var difference = previous;
                previous = current;
                current += difference;
            }

            return current;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter an index of a Fibonacci number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"The Fibonacci number is {Fibonacci(n)}");
        }
    }
}
