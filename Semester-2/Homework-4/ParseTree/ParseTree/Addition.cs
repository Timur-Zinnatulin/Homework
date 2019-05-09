using System;

namespace ParseTree
{
    /// <summary>
    /// Operation subclass that represents addition
    /// </summary>
    public class Addition : Operation
    {
        /// <summary>
        /// Calculates the node value
        /// </summary>
        /// <returns>Value of node after calculation</returns>
        public override int Calculate()
            => LeftChild.Calculate() + RightChild.Calculate();

        /// <summary>
        /// Prints node's value
        /// </summary>
        public override void Print()
        {
            Console.Write("( + ");
            LeftChild.Print();
            RightChild.Print();
            Console.Write(") ");
        }
    }
}
