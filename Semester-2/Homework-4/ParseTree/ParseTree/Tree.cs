using System;

namespace ParseTree
{
    /// <summary>
    /// Parse tree class
    /// </summary>
    public class Tree
    {
        private Node root;

        /// <summary>
        /// Parse tree constructor
        /// </summary>
        /// <param name="rootNode">Root node of the tree</param>
        public Tree(Node rootNode)
        {
            this.root = rootNode;
        }

        /// <summary>
        /// Empty tree flag
        /// </summary>
        /// <returns>True if the tree is empty, false otherwise</returns>
        public bool IsEmpty()
            => root == null;

        /// <summary>
        /// Calculates the parsed expression
        /// </summary>
        /// <returns>Result of calculation</returns>
        public int Calculate()
            => root.Calculate();

        /// <summary>
        /// Puts parsed expression into prefix notation
        /// </summary>
        /// <returns>Parsed expression string</returns>
        public string Print()
            => root.Print();
    }
}
