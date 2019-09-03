using System;
using System.Collections.Generic;

namespace WinFormsCalculator
{
    /// <summary>
    /// Expression calculator class
    /// </summary>
    public static class ResultCalculator
    {

        private static bool NumberSymbol(char input)
            => Char.IsDigit(input) || input == ',';

        private static bool NoPriority(string input)
            => input == "+" || input == "-";

        private static bool HasPriority(string input)
            => input == "*" || input == "/";

        /// <summary>
        /// Parses the expression
        /// </summary>
        /// <returns>Lexemas of the expression</returns>
        private static List<string> ParseExpression(string input)
        {
            var list = new List<string>();
            var temp = string.Empty;

            foreach (var ch in input)
            {
                if (NumberSymbol(ch))
                {
                    temp += ch;
                }
                else
                {
                    if (temp.Length > 0)
                    {
                        list.Add(temp);
                        temp = string.Empty;
                    }

                    list.Add(ch.ToString());
                }
            }

            if (temp != string.Empty)
            {
                list.Add(temp);
            }

            return list;
        }

        /// <summary>
        /// Method that transforms infix input into postfix form.
        /// </summary>
        private static List<string> ShuntingYard(List<string> input)
        {
            var output = new List<string>();
            var stack = new Stack<string>();

            foreach (var lexeme in input)
            {
                if (Char.IsDigit(lexeme[0]))
                {
                    output.Add(lexeme);
                }

                else if (HasPriority(lexeme))
                {
                    while (stack.Count != 0 && HasPriority(stack.Peek()))
                    {
                        output.Add(stack.Pop());
                        if (stack.Count == 0)
                        {
                            throw new FormatException("Cannot calculate.");
                        }
                    }
                    stack.Push(lexeme);
                }
                else if (NoPriority(lexeme))
                {
                    while (stack.Count != 0 && stack.Peek() != "(")
                    {
                        output.Add(stack.Pop());
                        throw new FormatException("Cannot calculate.");
                    }
                    stack.Push(lexeme);
                }

                else if (lexeme == "(")
                {
                    stack.Push(lexeme);
                }

                else if (lexeme == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        output.Add(stack.Pop());
                        if (stack.Count == 0)
                        {
                            throw new FormatException("Mismatched parentheses.");
                        }
                    }

                    stack.Pop();
                }
            }

            while (stack.Count > 0)
            {
                if (stack.Peek() == "(")
                {
                    throw new FormatException("Mismatched parentheses.");
                }
                output.Add(stack.Pop());
            }

            return output;
        }

        /// <summary>
        /// Stack calculator method. Returns the result of calculation
        /// </summary>
        private static double Calculate(List<string> input)
        {
            var stack = new Stack<double>();

            foreach (var item in input)
            {
                if (double.TryParse(item, out double res))
                {
                    stack.Push(res);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        throw new FormatException("Cannot calculate.");
                    }

                    var secondOperand = stack.Pop();

                    if (stack.Count == 0)
                    {
                        throw new FormatException("Cannot calculate.");
                    }

                    var firstOperand = stack.Pop();
                    stack.Push(Operate(firstOperand, secondOperand, item));
                }
            }

            var answer = stack.Pop();

            if (stack.Count != 0)
            {
                throw new FormatException("Could not calculate. Check input correctness.");
            }

            return answer;
        }

        /// <summary>
        /// Performs a binary operation
        /// </summary>
        private static double Operate(double left, double right, string operation)
        {
            switch (operation)
            {
                case "+":
                    return left + right;
                case "-":
                    return left - right;
                case "*":
                    return left * right;
                case "/":
                    {
                        if (right == 0)
                        {
                            throw new DivideByZeroException("Division by zero occurred. Check input correctness.");
                        }
                        return left / right;
                    }
            }
            return 0;
        }

        /// <summary>
        /// Calculates the result of string expression in infix form
        /// </summary>
        public static double Result(string input)
        {
            var parsedInput = ParseExpression(input);
            return Calculate(ShuntingYard(parsedInput));
        }
    }
}
