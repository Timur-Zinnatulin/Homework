namespace StackCalculator
{
    using System;

    /// <summary>
    /// Stack based on array
    /// </summary>
    public class ArrayStack
    {
        private int[] elements;
        
        public int Size { get; private set; }

        /// <summary>
        /// Array stack constructor
        /// </summary>
        /// <param name="size">Initial size of new stack</param>
        public ArrayStack(int size)
        {
            this.Size = 0;
            elements = new int[size];
        }

        /// <summary>
        /// Sees the top element of stack without popping it
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
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
