namespace StackCalculatorNamespace
{
    using System;

    /// <summary>
    /// Stack based on list
    /// </summary>
    public class ListStack : IStack
    {
        /// <summary>
        /// Node of list
        /// </summary>
        private class ListNode
        {
            public int Value { get; set; }
            public ListNode Next { get; set; }

            public ListNode(int value)
            {
                Value = value;
                Next = null;
            }
        }

        private ListNode head;

        /// <summary>
        /// Size of the stack
        /// </summary>
        public int Size { get; private set; }

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

            return head.Value;
        }

        /// <summary>
        /// Removes the top element of stack
        /// </summary>
        /// <returns>Top element of stack</returns>
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            int answer = head.Value;
            head = head.Next;
            --Size;

            return answer;
        }

        /// <summary>
        /// Pushes a new value into stack
        /// </summary>
        /// <param name="value">Value pushed into stack</param>
        public void Push(int value)
        {
            var newHead = new ListNode(value)
            {
                Next = head
            };
            head = newHead;
            ++Size;
        }
    }
}
