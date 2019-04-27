using System;

namespace HashTableNamespace
{
    /// <summary>
    /// Recursive hash function class
    /// </summary>
    public class RecursiveHashFunction : IHashFunction
    {
        /// <summary>
        /// Recursive hash function calculator
        /// </summary>
        /// <param name="word">Encoded word</param>
        /// <returns>Hash function of the word</returns>
        public ulong Key(string word)
        {
            ulong hash = 0;
            ulong primeBase = 1;

            foreach (ulong character in word)
            {
                hash += character * primeBase;
                primeBase *= 129;
            }

            return hash;
        }
    }
}
