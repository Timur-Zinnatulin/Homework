using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ParseTree
{
    /// <summary>
    /// Expression tree creation class
    /// </summary>
    public static class TreeConstructor
    {
        /// <summary>
        /// Creates a new node for expression tree
        /// </summary>
        /// <param name="inputs">Queue of key symbols and numbers</param>
        /// <returns>Created expression tree node</returns>
        private static Node CreateNode(Queue<string> inputs)
        {
            var nextMatch = inputs.Peek();

            if (nextMatch == "(")
            {
                Operation newNode;
                inputs.Dequeue();
                nextMatch = inputs.Peek();
                switch(nextMatch)
                {
                    case "+":
                        {
                            newNode = new Addition();
                            break;
                        }
                    case "-":
                        {
                            newNode = new Subtraction();
                            break;
                        }
                    case "*":
                        {
                            newNode = new Multiplication();
                            break;
                        }
                    case "/":
                        {
                            newNode = new Division();
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException();
                        }
                }
                inputs.Dequeue();
                newNode.LeftChild = CreateNode(inputs);
                newNode.RightChild = CreateNode(inputs);
                inputs.Dequeue();
                return newNode;
            }
            else
            {
                Number newNode = new Number(int.Parse(nextMatch));
                inputs.Dequeue();
                return newNode;
            }
        }

        /// <summary>
        /// Creates a new expression tree with given input
        /// </summary>
        /// <param name="input">Unedited expression</param>
        /// <returns>Exprettion tree for given expression</returns>
        public static Tree CreateTree(string input)
        {
            Tree newTree;
            const string options = @"-*\d+|[()*/+-]";
            var matches = Regex.Matches(input, options);
            var queue = new Queue<string>();

            foreach (Match match in matches)
            {
                queue.Enqueue(match.Value);
            }

            var head = CreateNode(queue);

            newTree = new Tree(head);

            if (queue.Count > 0)
            {
                throw new ArgumentException();
            }

            return newTree;
        }
    }
}
