using System;
using System.Collections.Generic;

namespace MapFilterFoldFunctions
{
    public class Functions
    {
        /// <summary>
        /// Map function from problem conditions
        /// </summary>
        /// <param name="list">Given list</param>
        /// <param name="function">Given function</param>
        /// <returns>Transformed list</returns>
        public List<int> Map(List<int> list, Func<int, int> function)
        {
            var newList = new List<int>();

            foreach (var elem in list)
            {
                newList.Add(function(elem));
            }

            return newList;
        }

        /// <summary>
        /// FIlter function from problem conditions
        /// </summary>
        /// <param name="list">Given list</param>
        /// <param name="function">Given function</param>
        /// <returns>List of elements that pass the condition of function</returns>
        public List<int> Filter(List<int> list, Func<int, bool> function)
        {
            var answer = new List<int>();

            foreach (var elem in list)
            {
                if (function(elem))
                {
                    answer.Add(elem);
                }
            }

            return answer;
        }

        /// <summary>
        /// Fold function from problem conditions
        /// </summary>
        /// <param name="list">Given list</param>
        /// <param name="setupValue">Given initial number</param>
        /// <param name="function">Given function</param>
        /// <returns>List folded into one number by given function</returns>
        public int Fold(List<int> list, int setupValue, Func<int, int, int> function)
        {
            foreach (var elem in list)
            {
                setupValue = function(setupValue, elem);
            }

            return setupValue;
        }
    }
}
