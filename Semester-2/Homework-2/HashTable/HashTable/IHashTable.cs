namespace HashTableNamespace
{
    using System;

    interface IHashTable
    {
        int Size { get; }
        bool Exists(string value);
        void Insert(string value);
        void Delete(string value);
    }
}
