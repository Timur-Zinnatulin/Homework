namespace HashTableNamespace
{
    using System;

    /// <summary>
    /// Linked list interface
    /// </summary>
    public interface IList
    {
        /// <summary>
        /// Amount of elements in the list
        /// </summary>
        ulong Length { get; }

        /// <summary>
        /// Checks if the list is empty
        /// </summary>
        /// <returns>True if the list is empty, false otherwise</returns>
        bool IsEmpty();
        
        /// <summary>
        /// Inserts a new node into the list
        /// </summary>
        /// <param name="value">Value of the new node</param>
        /// <param name="position">Position of the new node</param>
        void Insert(string value, ulong position);

        /// <summary>
        /// Removes a node from the list
        /// </summary>
        /// <param name="position">Position of node that shall be removed</param>
        void Remove(ulong position);

        /// <summary>
        /// Get the value of node by given position
        /// </summary>
        /// <param name="position">Position of desired node</param>
        /// <returns>Desired value</returns>
        string GetValueByPosition(ulong position);

        /// <summary>
        /// Changes the value of node by given position
        /// </summary>
        /// <param name="value">New value</param>
        /// <param name="position">Position of desired node</param>
        void ChangeValueByPosition(string value, ulong position);

        /// <summary>
        /// Finds the position of given string
        /// </summary>
        /// <param name="value">String that we know</param>
        /// <returns>Position of given string. If it doesn't exist in the list, returns -1.</returns>
        ulong GetPositionByValue(string value);
    }
}