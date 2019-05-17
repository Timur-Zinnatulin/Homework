using System;
using System.Collections.Generic;

namespace Sem2FinalTest
{
    /// <summary>
    /// Bubble sort class
    /// </summary>
    /// <typeparam name="T">Type of sorted list</typeparam>
    public static class BubbleSort<T>
    {
        /// <summary>
        /// Sort method 
        /// </summary>
        /// <param name="list">List that we need to sort</param>
        /// <param name="comp">Comparer</param>
        /// <param name="flagAscending"></param>
        /// <returns>Sorted list</returns>
        public static List<T> Sort(List<T> list, Comparer<T> comp)
        {
            bool ifSorted = true;

            do
            {
                ifSorted = true;
                for (int i = 0; i < (list.Count - 1); ++i)
                {
                    if (!comp.Compare(list[i], list[i + 1]))
                    {
                        ifSorted = false;
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }
                }
            } while (!ifSorted);

            return list;
        }
    }
}
