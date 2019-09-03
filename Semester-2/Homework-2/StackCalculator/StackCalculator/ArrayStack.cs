namespace StackCalculatorNamespace
{
    using System;

    /// <summary>
    /// Stack based on array
    /// </summary>
    public class ArrayStack : IStack
    {
        private int[] elements;
        
        /// <summary>
        /// Size of the stack
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Array stack constructor
        /// </summary>
        public ArrayStack()
        {
            this.Size = 0;
            elements = new int[100];
        }

        /// <summary>
        /// Check if the stack is empty
        /// </summary>
        /// <returns>Flag if the stack is empty</returns>
        public bool IsEmpty()
            => Size == 0;

        /// <summary>
        /// Sees the top element of stack without popping it
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return elements[Size - 1];
        }

        /// <summary>
        /// Removes the top element of stack
        /// </summary>
        /// <returns>Top element of stack</returns>
        public int Pop()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            --Size;
            return elements[Size];
        }

        /// <summary>
        /// Pushes a new value into stack
        /// </summary>
        /// <param name="value">Value pushed into stack</param>
        public void Push(int value)
        {
            if (Size >= elements.Length)
            {
                Resize();
            }

            elements[Size] = value;
            ++Size;
        }

        private void Resize()
        {
            var newStack = new int[elements.Length * 2 + 1];

            for (int i = 0; i < elements.Length; ++i)
            {
                newStack[i] = elements[i];
            }

            elements = newStack;
        }
    }
}
