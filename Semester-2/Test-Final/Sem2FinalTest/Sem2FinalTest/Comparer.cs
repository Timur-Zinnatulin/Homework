using System;
using System.Collections.Generic;

namespace Sem2FinalTest
{
    /// <summary>
    /// Comparer class for generic bubble sort
    /// </summary>
    /// <typeparam name="T">Type of sorted elements</typeparam>
    public abstract class Comparer<T>
    {
        /// <summary>
        /// Compare method for comparer
        /// </summary>
        /// <param name="left">Left object</param>
        /// <param name="right">Right object</param>
        /// <param name="flagAscending">Flag for order of elements</param>
        /// <returns>Result of comparison</returns>
        public abstract bool Compare(T left, T right);
    }
}
