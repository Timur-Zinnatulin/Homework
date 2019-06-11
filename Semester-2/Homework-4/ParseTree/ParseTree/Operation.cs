using System;

namespace ParseTree
{
    /// <summary>
    /// Node subclass that represents operation
    /// </summary>
    public abstract class Operation : Node
    {
        public abstract int Calculate();

        public abstract string Print();

        /// <summary>
        /// Left child of a node
        /// </summary>
        public Node LeftChild { get; set; }

        /// <summary>
        /// Right child of a node
        /// </summary>
        public Node RightChild { get; set; }
    }
}
