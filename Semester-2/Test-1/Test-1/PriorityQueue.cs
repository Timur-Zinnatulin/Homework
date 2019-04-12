using System;

namespace Test1
{
    /// <summary>
    /// Priority queue with dequeue and enqueue abilitites
    /// </summary>
    public class PriorityQueue
    {
        /// <summary>
        /// Element of the queue
        /// </summary>
        private class QueueNode
        {
            public int Value { get; set; }
            public int Priority { get; set; }
            public QueueNode Next { get; set; }

            /// <summary>
            /// Queue node constructor
            /// </summary>
            /// <param name="value">Value of a new node</param>
            /// <param name="priority">Priority of a new node</param>
            /// <param name="next">Next node in queue</param>
            public QueueNode(int value, int priority, QueueNode next)
            {
                this.Value = value;
                this.Priority = priority;
                this.Next = next;
            }

        }

        /// <summary>
        /// Head element of the queue
        /// </summary>
        private QueueNode Head = null;

        /// <summary>
        /// Empty queue checker
        /// </summary>
        /// <returns>Flag if the queue is empty</returns>
        private bool IsEmpty()
            => Head == null;

        /// <summary>
        /// Enqueues a new element 
        /// </summary>
        /// <param name="value">Value of a new element</param>
        /// <param name="priority">Priority of a new element</param>
        public void Enqueue(int value, int priority)
        {
            if (IsEmpty())
            {
                Head = new QueueNode(value, priority, null);
                return;
            }

            if (Head.Priority < priority)
            {
                Head = new QueueNode(value, priority, Head);
                return;
            }

            var temp = Head;
            while ((priority <= temp.Next.Priority) && (temp.Next != null))
            {
                temp = temp.Next;
            }
            
            if (priority > temp.Next.Priority)
            {
                temp.Next = new QueueNode(value, priority, temp.Next);
                return;
            }

            temp.Next = new QueueNode(value, priority, null);
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new EmptyQueueException("Could not dequeue from an empty queue.");
            }

            int headValue = Head.Value;
            Head = Head.Next;

            return headValue;
        }
    }
}
