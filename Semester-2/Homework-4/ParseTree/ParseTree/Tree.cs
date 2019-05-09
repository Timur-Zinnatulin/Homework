using System;

namespace ParseTree
{
    /// <summary>
    /// Parse tree class
    /// </summary>
    public class Tree
    {
        private Node root;

        public Tree(Node rootNode)
        {
            this.root = rootNode;
        }

        public bool IsEmpty()
            => root == null;

        public int Calculate()
            => root.Calculate();

        public string Print()
            => root.Print();
    }
}
