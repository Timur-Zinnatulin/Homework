namespace SinglyLinkedList
{
    using System;

    /// <summary>
    /// List interface
    /// </summary>
    interface IList
    {
        /// <summary>
        /// Length of the list
        /// </summary>
        int Length { get; }

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
        void Insert(int value, int position);

        /// <summary>
        /// Removes a node from the list
        /// </summary>
        /// <param name="position">Position of node that shall be removed</param>
        void Remove(int position);

        /// <summary>
        /// Get the value of node by given position
        /// </summary>
        /// <param name="position">Position of desired node</param>
        /// <returns>Desired value</returns>
        int GetValueByPosition(int position);

        /// <summary>
        /// Changes the value of node by given position
        /// </summary>
        /// <param name="value">New value</param>
        /// <param name="position">Position of desired node</param>
        void ChangeValueByPosition(int value, int position);
    }
}
