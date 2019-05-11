using System;

namespace SinglyLinkedList
{
    /// <summary>
    /// Subclass of linked list with unique elements
    /// </summary>
    public class UniqueList : LinkedList
    {
        /// <summary>
        /// Inserts a new node into the list
        /// </summary>
        /// <param name="value">
        /// Value of the new node
        /// </param>
        /// <param name="position">
        /// Position of the new node
        /// </param>
        public override void Insert(int value, int position)
        {
            if (GetPositionByValue(value) != -2)
            {
                throw new AddExistingElementException("Error! Such element already exists in the list!");
            }
            base.Insert(value, position);
        }

        /// <summary>
        /// Changes the value of node by given position
        /// </summary>
        /// <param name="value">
        /// New value
        /// </param>
        /// <param name="position">
        /// Position of desired node
        /// </param>
        public override void ChangeValueByPosition(int value, int position)
        {
            // I've decided to restrict changing elements in the list into ones that already exist in the list
            if (GetPositionByValue(value) != -2)
            {
                throw new AddExistingElementException("Error! Such element already exists in the list");
            }

            base.ChangeValueByPosition(value, position);
        }
    }
}
