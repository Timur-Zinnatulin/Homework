namespace HashTableNamespace
{
    using System;

    /// <summary>
    /// List interface
    /// </summary>
    interface IList
    {
        ulong Length { get; }
        bool IsEmpty();
        void Insert(string value, ulong position);
        void Remove(ulong position);
        string GetValueByPosition(ulong position);
        void ChangeValueByPosition(string value, ulong position);
        ulong GetPositionByValue(string value);
    }
}