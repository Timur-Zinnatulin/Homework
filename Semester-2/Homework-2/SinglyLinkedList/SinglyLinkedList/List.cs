namespace SinglyLinkedList
{
    using System;

    /// <summary>
    /// Singly linked list with required functionality
    /// </summary>
    public class LinkedList : IList
    {
        /// <summary>
        /// Node of a singly linked list
        /// </summary>
        private class ListNode
        {
            public int Value { get; set; }
            public ListNode Next { get; set; }
            public ListNode(int value, ListNode next)
            {
                Value = value;
                Next = next;
            }
        }

        private ListNode head;

        /// <summary>
        /// Amount of elements in the list
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Empty list flag
        /// </summary>
        /// <returns>Flag if the list is empty</returns>
        public bool IsEmpty()
            => Length == 0;

        private bool FlagCanInsertIntoPosition(int position)
            => position >= 0 && position <= Length;

        private bool FlagNodeIsInList(int position)
            => position >= 0 && position < Length;

        private ListNode GetParticularNode(int position)
        {
            var temp = head;

            for (int i = 0; i < position; ++i)
            {
                temp = temp.Next;
            }

            return temp;
        }

        private void InsertIntoHead(int value)
        {
            head = new ListNode(value, head);
            ++Length;
        }

        /// <summary>
        /// Inserts a new node into the list
        /// </summary>
        /// <param name="value">Value of the new node</param>
        /// <param name="position">Position of the new node</param>
        public virtual void Insert(int value, int position)
        {
            if (!FlagCanInsertIntoPosition(position))
            {
                throw new InvalidListPositionException("Error! Insert position is invalid!");
            }

            if (position == 0)
            {
                InsertIntoHead(value);
                return;
            }

            var precedingNode = GetParticularNode(position - 1);
            var newNode = new ListNode(value, precedingNode.Next);
            precedingNode.Next = newNode;
            ++Length;
         }

        private void RemoveFromHead()
        {
            head = head.Next;
            --Length;
        }

        /// <summary>
        /// Removes a node from the list by given position
        /// </summary>
        /// <param name="position">Position of node that shall be removed</param>
        public void RemoveByPosition(int position)
        {
            if (!FlagNodeIsInList(position))
            {
                throw new InvalidListPositionException("Error! Remove position is invalid!");
            }

            if (position == 0)
            {
                RemoveFromHead();
                return;
            }

            var precedingNode = GetParticularNode(position - 1);
            precedingNode.Next = precedingNode.Next.Next;
            --Length;
        }

        /// <summary>
        /// Removes the node by given value
        /// </summary>
        /// <param name="value">Value of node</param>
        public void RemoveByValue(int value)
             => RemoveByPosition(GetPositionByValue(value));

        /// <summary>
        /// Get the value of node by given position
        /// </summary>
        /// <param name="position">Position of desired node</param>
        /// <returns>Desired value</returns>
        public int GetValueByPosition(int position)
        {
            if (!FlagNodeIsInList(position))
            {
                throw new InvalidListPositionException("Error! Node get position is invalid!");
            }

            var node = GetParticularNode(position);
            return node.Value;
        }

        /// <summary>
        /// Changes the value of node by given position
        /// </summary>
        /// <param name="value">New value</param>
        /// <param name="position">Position of desired node</param>
        public virtual void ChangeValueByPosition(int value, int position)
        {
            if (!FlagNodeIsInList(position))
            {
                throw new InvalidListPositionException("Error! Node change position is invalid!");
            }

            var node = GetParticularNode(position);
            node.Value = value;
        }

        /// <summary>
        /// Finds the position of given element
        /// </summary>
        /// <param name="value">Element that we know</param>
        /// <returns>Position of given element. If it doesn't exist in the list, returns -1.</returns>
        public int GetPositionByValue(int value)
        {
            if (IsEmpty())
            {
                return -2;
            }

            var temp = head;
            for (int i = 0; i < Length; ++i)
            {
                if (value == temp.Value)
                {
                    return i;
                }
                temp = temp.Next;
            }

            return -2;
        }
    }
}