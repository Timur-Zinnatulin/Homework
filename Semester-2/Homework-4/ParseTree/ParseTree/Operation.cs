using System;

namespace ParseTree
{
    /// <summary>
    /// Node subclass that represents operation
    /// </summary>
    public abstract class Operation : Node
    {
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
