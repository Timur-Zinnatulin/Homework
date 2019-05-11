using System;

namespace SinglyLinkedList
{
    /// <summary>
    /// Thrown when we try to add an existing element into unique list
    /// </summary>
    public class AddExistingElementException : Exception
    {
        public AddExistingElementException()
        {
        }

        public AddExistingElementException(string message)
            : base(message)
        {
        }
    }
}
