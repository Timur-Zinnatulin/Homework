namespace HashTableNamespace
{
    using System;

    interface IHashTable
    {
        /// <summary>
        /// Size of the hash table
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Checks if the string exists in hash table
        /// </summary>
        /// <param name="value">String that we want to check</param>
        /// <returns>Flag if the string exists in hash table</returns>
        bool Exists(string value);

        /// <summary>
        /// Inserts a string into hash table if it isn't contained there
        /// </summary>
        /// <param name="value">String that is being inserted</param>
        void Insert(string value);

        /// <summary>
        /// Removes the word from hash table
        /// </summary>
        /// <param name="value">String that shall be removed.</param>
        void Delete(string value);
    }
}
