namespace HashTable
{
    using System;

    interface IList
    {
        int Length { get; }
        bool IsEmpty();
        void Insert(string value, int position);
        void Remove(int position);
        string GetValueByPosition(int position);
        void ChangeValueByPosition(string value, int position);
        int GetPositionByValue(string value);
    }
}