using System;

namespace MyNUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            TestRunner.Run(path);

            TestRunner.PrintResults();
        }
    }
}
