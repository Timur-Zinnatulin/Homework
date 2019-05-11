using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    /// <summary>
    /// Thrown when list insert/remove is impossible
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
