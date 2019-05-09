using System;

namespace ParseTree
{
    /// <summary>
    /// Parse tree node class
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Left child of a node
        /// </summary>
        public Node LeftChild { get; set; }

        /// <summary>
        /// Right child of a node
        /// </summary>
        public Node RightChild { get; set; }

        /// <summary>
        /// Value of node after calculation
        /// </summary>
        public abstract int Calculate { get; }

        /// <summary>
        /// Prints node's value
        /// </summary>
        public abstract void Print();
    }
}
