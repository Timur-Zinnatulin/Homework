using System;

namespace ParseTree
{
    /// <summary>
    /// Parse tree node class
    /// </summary>
    public interface Node
    {
        /// <summary>
        /// Calculates the node value
        /// </summary>
        /// <returns>Value of node after calculation</returns>
        int Calculate();

        /// <summary>
        /// Prints node parsing
        /// </summary>
        string Print();
    }
}
