using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
