namespace StackCalculatorNamespace
{
    using System;

    public interface IStack
    {
        int Size { get; }
        bool IsEmpty();
        int Peek();
        int Pop();
        void Push(int value);
    }
}
