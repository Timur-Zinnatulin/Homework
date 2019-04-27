using System;

namespace HashTable
{
    /// <summary>
    /// Jenkins Hash Function class
    /// </summary>
    public class JenkinsHashFunction
    {
        /// <summary>
        /// Jenkins hash function calculator
        /// </summary>
        /// <param name="word">Encoded word</param>
        /// <returns>Hash function of the word</returns>
        public int Key(string word)
        {
            int hash = 0;
            for (int i = 0; i < word.Length; ++i)
            {
                hash += Convert.ToInt32(word[i]);
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
