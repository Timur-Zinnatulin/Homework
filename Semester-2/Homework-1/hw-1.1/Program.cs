using System;

namespace hw_1._1
{
    class Program
    {
        private static int Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Factorial of 4 is {Factorial(4)}.");
        }
    }
}
