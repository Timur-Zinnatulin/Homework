﻿using System;

namespace ParseTree
{
    /// <summary>
    /// Node subclass that represents number
    /// </summary>
    public class Number : Node
    {
        /// <summary>
        /// Value of a node
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Node constructor
        /// </summary>
        /// <param name="number">Value of number</param>
        public Number(int number)
        {
            this.Value = number;
        }

        /// <summary>
        /// Calculates the node value
        /// </summary>
        /// <returns>Value of node after calculation</returns>
        public int Calculate()
            => Value;

        /// <summary>
        /// Prints node parsing
        /// </summary>
        public string Print()
            => $"{Value} ";
    }
}
