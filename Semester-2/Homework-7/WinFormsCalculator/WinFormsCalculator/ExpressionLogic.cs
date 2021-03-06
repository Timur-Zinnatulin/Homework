﻿using System;

namespace WinFormsCalculator
{
    /// <summary>
    /// Expression logic class
    /// </summary>
    public class ExpressionLogic
    {
        /// <summary>
        /// Expression input string
        /// </summary>
        private string input = string.Empty;

        private bool IfOperationIsLastInput() => input[input.Length - 1] == '*' || input[input.Length - 1] == '/'
            || input[input.Length - 1] == '-' || input[input.Length - 1] == '+';

        private bool IfNumberIsLastInput() => Char.IsDigit(input[input.Length - 1]);

        private void SwapOperations(string newOperation) => input = input.Remove(input.Length - 1, 1).Insert(input.Length - 1, newOperation.ToString());

        private bool doubleNumber = false;
        private bool atLeastOneOperation = false;
        private int bracketBalance = 0;

        /// <summary>
        /// Triggers when number is pressed
        /// </summary>
        public string ClickNumber(string number)
        {
            if (input != string.Empty && input[input.Length - 1] == ')')
            {
                return input;
            }

            input += number;
            return input;
        }

        /// <summary>
        /// Triggers when point is pressed
        /// </summary>
        public string ClickComma()
        {
            if (input == string.Empty || doubleNumber || !IfNumberIsLastInput())
            {
                return input;
            }

            doubleNumber = true;
            input += ",";

            return input;
        }

        /// <summary>
        /// Triggers when left bracket is pressed
        /// </summary>
        public string ClickLeftBracket()
        {
            if (input == string.Empty)
            {
                input = "(";
            }
            else

            if (IfOperationIsLastInput() || input[input.Length - 1] == '(')
            {
                input += "(";
            }
            else
            {
                return input;
            }

            ++bracketBalance;
            atLeastOneOperation = false;
            return input;
        }

        /// <summary>
        /// Triggers when right bracket is pressed
        /// </summary>
        public string ClickRightBracket()
        {
            if (bracketBalance <= 0 || (!IfNumberIsLastInput() && input[input.Length - 1] != ')') || !atLeastOneOperation)
            {
                return input;
            }

            --bracketBalance;
            input += ")";

            return input;
        }

        /// <summary>
        /// Triggers when operation button is pressed
        /// </summary>
        public string ClickOperation(string operation)
        {
            if (input == string.Empty || input[input.Length - 1] == ',' || input[input.Length - 1] == '(')
            {
                return input;
            }

            if (IfOperationIsLastInput())
            {
                SwapOperations(operation);
                return input;
            }

            doubleNumber = false;
            atLeastOneOperation = true;
            input += operation;

            return input;
        }

        /// <summary>
        /// Triggered when equals button is pressed
        /// </summary>
        public string ClickEquals()
        {
            string answer = string.Empty;

            if (input == string.Empty)
            {
                return string.Empty;
            }

            try
            {
                answer = ResultCalculator.Result(input).ToString();
            }

            catch (DivideByZeroException zeroEx)
            {
                answer = zeroEx.Message;
            }
            catch (FormatException formatEx)
            {
                answer = formatEx.Message;
            }

            return answer;
        }

        /// <summary>
        /// Triggered when erase is pressed
        /// </summary>
        public string ClickErase()
        {
            if (input.Length == 0)
            {
                return input;
            }

            if (input[input.Length - 1] == ')')
            {
                ++bracketBalance;
            }

            if (input[input.Length - 1] == ',')
            {
                doubleNumber = false;
            }

            if (input[input.Length - 1] == '(')
            {
                --bracketBalance;
            }
            input = input.Remove(input.Length - 1, 1);

            return input;
        }
    }
}
