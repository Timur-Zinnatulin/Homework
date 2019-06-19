namespace StackCalculatorNamespace
{
    using System;

    /// <summary>
    /// General stack interface
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Size of the stack
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Check if the stack is empty
        /// </summary>
        /// <returns>Flag if the stack is empty</returns>
        bool IsEmpty();

        /// <summary>
        /// Sees the top element of stack without popping it
        /// </summary>
        int Peek();

        /// <summary>
        /// Removes the top element of stack
        /// </summary>
        /// <returns>Top element of stack</returns>
        int Pop();

        /// <summary>
        /// Pushes a new value into stack
        /// </summary>
        /// <param name="value">Value pushed into stack</param>
        void Push(int value);
    }
}
