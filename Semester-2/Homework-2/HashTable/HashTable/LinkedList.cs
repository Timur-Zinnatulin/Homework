namespace HashTableNamespace
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
            public string Value { get; set; }
            public ListNode Next { get; set; }
            public ListNode(string value, ListNode next)
            {
                Value = value;
                Next = next;
            }
        }

        private ListNode Head;

        /// <summary>
        /// Amount of elements in the list
        /// </summary>
        public ulong Length { get; private set; }

        /// <summary>
        /// Checks if the list is empty
        /// </summary>
        /// <returns>True if the list is empty, false otherwise</returns>
        public bool IsEmpty()
            => Length == 0;

        //Pretty self-explainatory tbh
        private bool FlagCanInsertIntoPosition(ulong position)
            => position >= 0 && position <= Length;

        //Pretty self-explainatory tbh
        private bool FlagNodeIsInList(ulong position)
            => position >= 0 && position < Length;

        /// <summary>
        /// Finds the node by given position
        /// </summary>
        /// <param name="position">Position of the desired node</param>
        /// <returns>The desired node</returns>
        private ListNode GetParticularNode(ulong position)
        {
            var temp = Head;

            for (ulong i = 0; i < position; ++i)
            {
                temp = temp.Next;
            }

            return temp;
        }

        private void InsertIntoHead(string value)
        {
            Head = new ListNode(value, Head);
            ++Length;
        }

        /// <summary>
        /// Inserts a new node into the list
        /// </summary>
        /// <param name="value">Value of the new node</param>
        /// <param name="position">Position of the new node</param>
        public void Insert(string value, ulong position)
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
            Head = Head.Next;
            --Length;
        }

        /// <summary>
        /// Removes a node from the list
        /// </summary>
        /// <param name="position">Position of node that shall be removed</param>
        public void Remove(ulong position)
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
        /// Get the value of node by given position
        /// </summary>
        /// <param name="position">Position of desired node</param>
        /// <returns>Desired value</returns>
        public string GetValueByPosition(ulong position)
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
        public void ChangeValueByPosition(string value, ulong position)
        {
            if (!FlagNodeIsInList(position))
            {
                throw new InvalidListPositionException("Error! Node change position is invalid!");
            }

            var node = GetParticularNode(position);
            node.Value = value;
        }
        
        /// <summary>
        /// Finds the position of given string
        /// </summary>
        /// <param name="value">String that we know</param>
        /// <returns>Position of given string. If it doesn't exist in the list, returns -1.</returns>
        public ulong GetPositionByValue(string value)
        {
            var temp = Head;
            for (ulong i = 0; i < Length; ++i)
            {
                if (value == temp.Value)
                {
                    return i;
                }
                temp = temp.Next;
            }

            return Length;
        }
    }
}