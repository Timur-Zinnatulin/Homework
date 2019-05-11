using System;

namespace SinglyLinkedList
{
    /// <summary>
    /// Subclass of linked list with unique elements
    /// </summary>
    public class UniqueList : LinkedList
    {
        public override void Insert(int value, int position)
        {
            if (GetPositionByValue(value) != -1)
            {
                throw new ArgumentException();
            }
            base.Insert(value, position);
        }
    }
}
