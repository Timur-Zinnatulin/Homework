using System;

namespace HashTableNamespace
{
    /// <summary>
    /// Hash function interface
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Hash function calculator
        /// </summary>
        /// <param name="word">Encoded word</param>
        /// <returns>Hash function of word</returns>
        ulong Key(string word);
    }
}
