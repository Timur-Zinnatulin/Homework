using System;
using System.Collections.Generic;

namespace SortedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter strings of characters. Empty string signifies end of input.");

            var flag = true;
            var toList = new StringToListTransformer();
            SortedSet<List<string>> setOfLists = new SortedSet<List<string>>(new ByListSize());

            while (flag)
            {
                var input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    flag = false;
                }

                if (flag)
                {
                    var newList = toList.TransformToList(input);
                    setOfLists.Add(newList);
                }
            }

            Console.WriteLine();

            foreach (var list in setOfLists)
            {
                Console.WriteLine(toList.TransformToString(list));
            }

        }
    }
}
