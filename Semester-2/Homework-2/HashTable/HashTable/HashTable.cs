namespace HashTableNamespace
{
    using System;

    /// <summary>
    /// Hash Table class
    /// </summary>
    public class HashTable : IHashTable
    {
        private int length;
        private LinkedList[] buckets;

        /// <summary>
        /// Size of the hash table
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Hash Table constructor
        /// </summary>
        /// <param name="length">Amount of buckets in Hash Table</param>
        public HashTable(int length)
        {
            this.length = length;
            buckets = new LinkedList[length];
            for (int i = 0; i < length; ++i)
            {
                buckets[i] = new LinkedList();
            }
        }

        /// <summary>
        /// Calculates hash function of given string
        /// </summary>
        /// <param name="value">Given string</param>
        /// <returns>Calculated hash function</returns>
        private int Key(string value)
            => Math.Abs(value.GetHashCode() % length);

        /// <summary>
        /// Checks if the string exists in hash table
        /// </summary>
        /// <param name="value">String that we want to check</param>
        /// <returns>Flag if the string exists in hash table</returns>
        public bool Exists(string value)
        {
            for (int i = 0; i < buckets[Key(value)].Length; ++i)
            {
                if (buckets[Key(value)].GetValueByPosition(i) == value)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Resizes the hash table
        /// </summary>
        private void Resize()
        {
            if (Size != buckets.Length * 2)
            {
                return;
            }

            length *= 2;
            var newBuckets = new LinkedList[length];

            for (int i = 0; i < length; ++i)
            {
                newBuckets[i] = new LinkedList();
            }

            foreach (var bucket in buckets)
            {
                if (!bucket.IsEmpty())
                {
                    for (int i = 0; i < bucket.Length; ++i)
                    {
                        var current = bucket.GetValueByPosition(i);
                        newBuckets[Key(current)].Insert(current, newBuckets[Key(current)].Length);
                    }
                }
            }
            buckets = newBuckets;
        }

        /// <summary>
        /// Inserts a string into hash table if it isn't contained there
        /// </summary>
        /// <param name="value">String that is being inserted</param>
        public void Insert(string value)
        {
            if (!Exists(value))
            {
                buckets[Key(value)].Insert(value, buckets[Key(value)].Length);
                ++Size;
            }
            Resize();
        }

        /// <summary>
        /// Removes the word from hash table
        /// </summary>
        /// <param name="value">String that shall be removed.</param>
        public void Delete(string value)
        {
            if (Exists(value))
            {
                buckets[Key(value)].Remove(buckets[Key(value)].GetPositionByValue(value));
                --Size;
            }
        }
    }
}
