using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericSet
{
    /// <summary>
    /// Generic set class.
    /// Built on binary tree.
    /// </summary>
    public class GenericSet<T> : ISet<T> where T : IComparable<T>
    {
        private class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Value { get; set; }
            public Node(T value)
            {
                Value = value;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        /// <summary>
        /// Removes all elements from the set
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        private bool PutIntoSet(Node node, T value)
        {
            if (value.CompareTo(node.Value) == 0)
            {
                return false;
            }

            else if (value.CompareTo(node.Value) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node(value);
                    ++Count;
                    return true;
                }

                return PutIntoSet(node.Right, value);
            }

            else
            {
                if (node.Left == null)
                {
                    node.Left = new Node(value);
                    ++Count;
                    return true;
                }

                return PutIntoSet(node.Left, value);
            }
        }

        /// <summary>
        /// Puts value into the set
        /// </summary>
        public bool Add(T value)
        {
            if (head == null)
            {
                head = new Node(value);
                ++Count;
                return true;
            }

            return PutIntoSet(head, value);
        }

        /// <summary>
        /// Checks if the calue is in set
        /// </summary>
        public bool Contains(T value)
        {
            var temp = head;
            while (true)
            {
                if (temp == null)
                {
                    return false;
                }

                if (value.CompareTo(temp.Value) == 0)
                {
                    return true;
                }

                if (value.CompareTo(temp.Value) > 0)
                {
                    temp = temp.Right;
                }

                else
                {
                    temp = temp.Left;
                }
            }
        }

        /// <summary>
        /// Finds the smallest value of the subtree
        /// </summary>
        private T Minimum(Node node)
        {
            if (node.Left != null)
            {
                return Minimum(node.Left);
            }
            else
            {
                return node.Value;
            }
        }

        private void RemoveNoChildren(Node node)
        {
            --Count;
            node = null;
        }

        private void RemoveOneChild(Node node)
        {
            --Count;
            var newNode = (node.Left != null ? node.Left : node.Right);
            node.Value = newNode.Value;
            node.Left = newNode.Left;
            node.Right = newNode.Right;
            newNode = null;
        }

        private void RemoveTwoChildren(Node node)
        {
            --Count;
            var newValue = Minimum(node.Right);
            NodeRemoval(node, newValue);
            node.Value = newValue;
        }

        /// <summary>
        /// Node removal process
        /// </summary>
        private void NodeRemoval(Node node, T value)
        {
            if (value.CompareTo(node.Value) > 0)
            {
                NodeRemoval(node.Right, value);
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                NodeRemoval(node.Left, value);
            }

            else
            {
                if (node.Left == null && node.Right == null)
                {
                    RemoveNoChildren(node);
                }
                else if (node.Left != null && node.Right != null)
                {
                    RemoveTwoChildren(node);
                }
                else
                {
                    RemoveOneChild(node);
                }
            }
        }

        /// <summary>
        /// Removes the value from the set
        /// </summary>
        public bool Remove(T value)
        {
            if (!Contains(value))
            {
                return false;
            }

            NodeRemoval(head, value);
            return true;
        }

        /// <summary>
        /// Copies the set elemets into an array. It traverses the set from top to bottom
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

            foreach (var item in this)
            {
                array[index] = item;
                ++index;
            }
        }

        /// <summary>
        /// Makes so that all elements from this collection are present in the set
        /// </summary>
        public void UnionWith(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Makes so that the set contains only the elements that are also in this collection
        /// </summary>
        public void IntersectWith(IEnumerable<T> collection)
        {
            var intersectSet = new GenericSet<T>();
            foreach (var item in collection)
            {
                if (Contains(item))
                {
                    intersectSet.Add(item);
                }
            }

            this.head = intersectSet.head;
            this.Count = intersectSet.Count;
            intersectSet.Clear();
        }

        /// <summary>
        /// Removes all the elements that are also from the collection
        /// </summary>
        public void ExceptWith(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Remove(item);
            }
        }

        /// <summary>
        /// Makes so that the set contains elements either from the original set or from the collection, but not both.
        /// </summary>
        public void SymmetricExceptWith(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                if (Contains(item))
                {
                    Remove(item);
                }
                else
                {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// Checks if the set is a subset of given collection
        /// </summary>
        public bool IsSubsetOf(IEnumerable<T> collection)
        {
            var newSet = new GenericSet<T>();

            foreach (var item in collection)
            {
                newSet.Add(item);
            }

            foreach (var element in this)
            {
                if (!newSet.Contains(element))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the set is a superset of given collection
        /// </summary>
        public bool IsSupersetOf(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                if (!Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the set is a proper subset of given collection
        /// </summary>
        public bool IsProperSubsetOf(IEnumerable<T> collection)
        {
            var newSet = new GenericSet<T>();

            foreach (var item in collection)
            {
                newSet.Add(item);
            }

            foreach (var element in this)
            {
                if (!newSet.Contains(element))
                {
                    return false;
                }
            }

            return newSet.Count > Count;
        }

        /// <summary>
        /// Checks if the set is a proper superset of given collection
        /// </summary>
        public bool IsProperSupersetOf(IEnumerable<T> collection)
        {
            int count = 0;
            foreach (var item in collection)
            {
                if (!Contains(item))
                {
                    return false;
                }
                ++count;
            }

            return count < Count;
        }

        /// <summary>
        /// Checks if the set and given collection overlap
        /// </summary>
        public bool Overlaps(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                if (Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the set and given collection contain the same elements
        /// </summary>
        public bool SetEquals(IEnumerable<T> collection)
        {
            int count = 0;
            foreach (var item in collection)
            {
                if (!Contains(item))
                {
                    return false;
                }
                ++count;
            }

            return Count == count;
        }

        void ICollection<T>.Add(T item) => Add(item);

        /// <summary>
        /// Enumerator for generic set
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            if (head == null)
            {
                yield break;
            }

            var queue = new Queue<Node>();
            queue.Enqueue(head);
            while (queue.Count > 0)
            {
                var temp = queue.Dequeue();
                yield return temp.Value;

                if (temp.Left != null)
                {
                    queue.Enqueue(temp.Left);
                }

                if (temp.Right != null)
                {
                    queue.Enqueue(temp.Right);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
