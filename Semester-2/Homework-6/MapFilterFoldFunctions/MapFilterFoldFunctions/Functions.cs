using System;
using System.Collections.Generic;

namespace MapFilterFoldFunctions
{
    /// <summary>
    /// List functions class
    /// </summary>
    public static class ListFunctions
    {
        /// <summary>
        /// Map function from problem conditions
        /// </summary>
        /// <param name="list">Given list</param>
        /// <param name="function">Given function</param>
        /// <returns>Transformed list</returns>
        public static List<U> Map<T,U>(List<T> list, Func<T, U> function)
        {
            var newList = new List<U>();

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
        public static List<int> Filter(List<int> list, Func<int, bool> function)
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
        public static U Fold<T, U>(List<T> list, U setupValue, Func<U, T, U> function)
        {
            foreach (var elem in list)
            {
                setupValue = function(setupValue, elem);
            }

            return setupValue;
        }
    }
}
