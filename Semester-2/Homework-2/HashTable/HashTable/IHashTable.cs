namespace HashTableNamespace
{
    using System;

    /// <summary>
    /// Hash table interface
    /// </summary>
    public interface IHashTable
    {
        int Size { get; }
        bool Exists(string value);
        void Insert(string value);
        void Delete(string value);
    }
}
