using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    /// <summary>
    /// Exception that is thrown when list position is invalid
    /// </summary>
    public class InvalidListPositionException : Exception
    {
        public InvalidListPositionException()
        {
        }

        public InvalidListPositionException(string message)
            : base(message)
        {
        }
    }
}
