using System;

namespace Test1
{
    /// <summary>
    /// Exception class for priority queue
    /// </summary>
    public class EmptyQueueException : Exception
    {
        public EmptyQueueException()
        {
        }
        public EmptyQueueException(string message)
        : base(message)
        {
        }
    }
}
