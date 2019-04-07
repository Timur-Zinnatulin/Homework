namespace SinglyLinkedList
{
    using System;

    interface IList
    {
        int Length { get; }
        bool IsEmpty();
        void Insert(int value, int position);
        void Remove(int position);
        int GetValueByPosition(int position);
        void ChangeValueByPosition(int value, int position);
    }
}
