using System;
using System.Collections.Generic;

namespace SortedSet
{
    /// <summary>
    /// List-string transformer class
    /// </summary>
    public class StringToListTransformer
    {
        /// <summary>
        /// Transforms string into list of words
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>List of words in given string</returns>
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

        /// <summary>
        /// Transforms a list of words into a single string
        /// </summary>
        /// <param name="list">List of words</param>
        /// <returns>Single output string</returns>
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
