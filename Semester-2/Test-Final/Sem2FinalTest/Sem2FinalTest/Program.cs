using System;
using System.Collections.Generic;

namespace Sem2FinalTest
{
    /// <summary>
    /// Main program class. Was just testing if it worked
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var compAsc = new AscendingComp<string>();
            var compDesc = new DescendingComp<string>();

            var list = new List<string> { "hochu", "zachet", "po", "proge", "no", "razuchilsya", "progat", "scha", "nagonyu"};

            list = BubbleSort<string>.Sort(list, compAsc);

            foreach(var str in list)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();

            list = BubbleSort<string>.Sort(list, compDesc);

            foreach (var str in list)
            {
                Console.WriteLine(str);
            }
        }
    }
}
