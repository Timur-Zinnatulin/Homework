using System;

namespace HashTableNamespace
{
    /// <summary>
    /// Jenkins Hash Function class
    /// </summary>
    public class JenkinsHashFunction : IHashFunction
    {
        /// <summary>
        /// Jenkins hash function calculator
        /// </summary>
        /// <param name="word">Encoded word</param>
        /// <returns>Hash function of the word</returns>
        public ulong Key(string word)
        {
            ulong hash = 0;
            foreach (ulong character in word)
            {
                hash += character;
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;

            return hash;
        }
    }
}
