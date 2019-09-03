using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericList
{
    /// <summary>
    /// Generic list class
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    public class List<T> : IList<T>
    {
        /// <summary>
        /// Node of a singly linked list
        /// </summary>
        private class ListNode
        {
            public T Value { get; set; }
            public ListNode Next { get; set; }
            public ListNode(T value, ListNode next)
            {
                Value = value;
                Next = next;
            }
        }

        private ListNode head;

        /// <summary>
        /// Length of the list
        /// </summary>
        public int Count { get; private set; }

        public bool IsEmpty()
            => Count == 0;

        public bool IsReadOnly => false;

        /// <summary>
        /// Deletes all elements from the list
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// Returns or sets 
        /// </summary>
        public T this[int position] { get => GetValueByPosition(position); set => ChangeValueByPosition(this[position], position); } 

        //Pretty self-explainatory tbh
        private bool FlagCanInsertIntoPosition(int position)
            => position >= 0 && position <= Count;

        //Pretty self-explainatory tbh
        private bool FlagNodeIsInList(int position)
            => position >= 0 && position < Count;

        /// <summary>
        /// Finds the node by given position
        /// </summary>
        /// <param name="position">Position of the desired node</param>
        /// <returns>The desired node</returns>
        private ListNode GetParticularNode(int position)
        {
            var temp = head;

            for (int i = 0; i < position; ++i)
            {
                temp = temp.Next;
            }

            return temp;
        }

        /// <summary>
        /// Returns an index of element by its value
        /// </summary>
        public int IndexOf(T value)
        {
            var temp = head;
            int index = 0;
            while (temp != null)
            {
                if (temp.Value.Equals(value))
                {
                    return index;
                }
                ++index;
                temp = temp.Next;
            }

            return -1;
        }

        /// <summary>
        /// Checks if the value is present in the list
        /// </summary>
        public bool Contains(T value)
        {
            var temp = head;
            while (temp != null)
            {
                if (temp.Value.Equals(value))
                {
                    return true;
                }

                temp = temp.Next;
            }

            return false;
        }

        /// <summary>
        /// Copies the entire list into an array
        /// </summary>
        public void CopyTo(T[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            if (Count > array.Length - index)
            {
                throw new ArgumentException("Can't fit into array.");
            }

            var temp = head;
            while (temp != null)
            {
                array[index] = temp.Value;
                temp = temp.Next;
                ++index;
            }
        }

        /// <summary>
        /// Deletes the first occurence of the value in the list
        /// </summary>
        public bool Remove(T value)
        {
            if (IsEmpty())
            {
                return false;
            }

            if (value.Equals(head.Value))
            {
                RemoveFromHead();
                return true;
            }

            var temp = head;
            while (temp.Next != null)
            {
                if (temp.Next.Value.Equals(value))
                {
                    temp.Next = temp.Next.Next;
                    --Count;
                    return true;
                }
                temp = temp.Next;
            }

            return false;
        }

        private void InsertIntoHead(T value)
        {
            head = new ListNode(value, head);
            ++Count;
        }

        /// <summary>
        /// Inserts a new node into the list
        /// </summary>
        /// <param name="value">Value of the new node</param>
        /// <param name="position">Position of the new node</param>
        public void Insert(int position, T value)
        {
            if (!FlagCanInsertIntoPosition(position))
            {
                throw new ArgumentException("Error! Insert position is invalid!");
            }

            if (position == 0)
            {
                InsertIntoHead(value);
                return;
            }

            var precedingNode = GetParticularNode(position - 1);
            var newNode = new ListNode(value, precedingNode.Next);
            precedingNode.Next = newNode;
            ++Count;
        }

        /// <summary>
        /// Adds an element to the end of the list
        /// </summary>
        public void Add(T value)
            => Insert(Count, value);

        private void RemoveFromHead()
        {
            head = head.Next;
            --Count;
        }

        /// <summary>
        /// Removes a node from the list
        /// </summary>
        /// <param name="position">Position of node that shall be removed</param>
        public void RemoveAt(int position)
        {
            if (!FlagNodeIsInList(position))
            {
                throw new ArgumentException("Error! Remove position is invalid!");
            }

            if (position == 0)
            {
                RemoveFromHead();
                return;
            }

            var precedingNode = GetParticularNode(position - 1);
            precedingNode.Next = precedingNode.Next.Next;
            --Count;
        }

        /// <summary>
        /// Get the value of node by given position
        /// </summary>
        /// <param name="position">Position of desired node</param>
        /// <returns>Desired value</returns>
        private T GetValueByPosition(int position)
        {
            if (!FlagNodeIsInList(position))
            {
                throw new ArgumentException("Error! Node get position is invalid!");
            }

            var node = GetParticularNode(position);
            return node.Value;
        }

        /// <summary>
        /// Changes the value of node by given position
        /// </summary>
        /// <param name="value">New value</param>
        /// <param name="position">Position of desired node</param>
        private void ChangeValueByPosition(T value, int position)
        {
            if (!FlagNodeIsInList(position))
            {
                throw new ArgumentException("Error! Node change position is invalid!");
            }

            var node = GetParticularNode(position);
            node.Value = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var temp = head;
            while (temp != null)
            {
                yield return temp.Value;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}

