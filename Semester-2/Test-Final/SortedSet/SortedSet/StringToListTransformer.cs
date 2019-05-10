using System;
using System.Collections.Generic;

namespace SortedSet
{
    public class StringToListTransformer
    {
        public List<string> TransformToList(string input)
        {
            var list = new List<string>();
            var parsed = input.Split(' ');

            for (int i = 0; i < parsed.Length; ++i)
            {
                if (!String.IsNullOrEmpty(parsed[i]))
                {
                    list.Add(parsed[i]);
                }
            }

            return list;
        }

        public string TransformToString(List<string> list)
        {
            string output = "";

            foreach (var str in list)
            {
                output += str + " ";
            }

            return output;
        }
    }
}
