using System;

namespace HashTableNamespace
{
    /// <summary>
    /// FNV hash function class
    /// </summary>
    public class FNVHashFunction : IHashFunction
    {
        private const ulong HashBigPrime = 32416188809;
        private const ulong FNV_OffsetBasis = 14695981039346656037;

        /// <summary>
        /// FNV hash function calculator
        /// </summary>
        /// <param name="word">Encoded word</param>
        /// <returns>Hash function of the word</returns>
        public ulong Key(string word)
        {
            ulong hash = FNV_OffsetBasis;

            foreach (ulong character in word)
            {
                hash *= HashBigPrime;
                hash ^= character; 
            }

            return hash;
        }
    }
}
