namespace StackCalculatorNamespace
{
    using System;

    /// <summary>
    /// Stack calculator
    /// </summary>
    public class Calculator
    {
        private IStack stack;

        /// <summary>
        /// Calculates the result of an expression
        /// </summary>
        /// <param name="input">The expression which is being calculated</param>
        /// <returns>Result of calculation</returns>
        public int Calculate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input is null or empty!");
            }

            var items = input.Split(' ');

            foreach (var item in items)
            {
                if (int.TryParse(input, out int result))
                {
                    stack.Push(result);
                }

                else
                {
                    Operate(input);
                }
            }

            var answer = stack.Pop();
            if (!stack.IsEmpty())
            {
                throw new ArgumentException("Incorrect input. There are leftover numbers.");
            }

            return answer;
        }

        private void Operate(string operation)
        {
            switch(operation)
            {
                case "+":
                    BinaryOperation((a, b) => a + b);
                    break;
                case "-":
                    BinaryOperation((a, b) => a - b);
                    break;
                case "*":
                    BinaryOperation((a, b) => a * b);
                    break;
                case "/":
                    BinaryOperation((a, b) => a / b);
                    break;
                default:
                    throw new ArgumentException("Incorrect operation. Please check input correctness.");
            }
        }

        //Fiddling around with delegates to understand them better
        private void BinaryOperation(Func<int, int, int> func)
        {
            int rightOperand = stack.Pop();
            int leftOperand = stack.Pop();

            stack.Push(func(leftOperand, rightOperand));
        }
    }
}
