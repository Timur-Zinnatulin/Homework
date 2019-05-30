namespace HashTableNamespace
{
    using System;

    /// <summary>
    /// Exception that is thrown when list position is invalid
    /// </summary>
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