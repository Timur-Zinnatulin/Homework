namespace SinglyLinkedList
{
    using System;

    interface IList
    {
        int Length { get; }
        bool IsEmpty();
        void Insert(int value, int position);
        void RemoveByPosition(int position);
        void RemoveByValue(int value);
        int GetValueByPosition(int position);
        void ChangeValueByPosition(int value, int position);
        int GetPositionByValue(int value);
    }
}
