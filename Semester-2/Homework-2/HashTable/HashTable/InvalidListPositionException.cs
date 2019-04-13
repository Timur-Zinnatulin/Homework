namespace HashTableNamespace
{
    using System;

    public class InvalidListPositionException : Exception
    {
        public InvalidListPositionException()
        {
        }

        public InvalidListPositionException(string message)
            : base(message)
        {
        }
    }
}