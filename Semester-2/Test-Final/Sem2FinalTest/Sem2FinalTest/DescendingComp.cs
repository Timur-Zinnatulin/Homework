using System;
using System.Collections.Generic;

namespace Sem2FinalTest
{
    /// <summary>
    /// Descending order comparison class
    /// </summary>
    /// <typeparam name="T">Type of compared element</typeparam>
    public class DescendingComp<T> : Comparer<T>
    {
        /// <summary>
        /// Compare method for comparer
        /// </summary>
        /// <param name="left">Left object</param>
        /// <param name="right">Right object</param>
        /// <returns>Result of comparison</returns>
        public override bool Compare(T left, T right)
        {
            if (left.GetHashCode() >= right.GetHashCode())
            {
                return true;
            }

            return false;
        }
    }
}