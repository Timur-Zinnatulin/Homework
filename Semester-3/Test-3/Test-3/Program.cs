using System;
using System.Diagnostics;

namespace Test_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = args[0];
            
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var answer = CheckSum.CalculateMD5(directory);
            stopwatch.Stop();

            Console.WriteLine(answer);
            
            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                ts.Hours, ts.Minutes, ts.Seconds,
                                                ts.Milliseconds / 10);

            Console.WriteLine("Time: " + elapsedTime);
        }
    }
}
