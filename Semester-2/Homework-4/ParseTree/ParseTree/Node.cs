using System;

namespace ParseTree
{
    /// <summary>
    /// Parse tree node class
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Calculates the node value
        /// </summary>
        /// <returns>Value of node after calculation</returns>
        public abstract int Calculate();

        /// <summary>
        /// Prints node parsing
        /// </summary>
        public abstract string Print();
    }
}
