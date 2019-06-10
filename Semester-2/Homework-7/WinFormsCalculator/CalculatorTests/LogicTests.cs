using System;
using WinFormsCalculator;
using NUnit.Framework;

namespace CalculatorTests
{
    /// <summary>
    /// Tests for input logic, so that calculator prevents incorrect input how it was designed to.
    /// </summary>
    [TestFixture]
    public class LogicTests
    {
        private ExpressionLogic testLogic;

        [SetUp]
        public void SetUp()
        {
            testLogic = new ExpressionLogic();
        }

        [Test]
        public void InputIsInitiallyEmptyTest()
        {
            Assert.AreEqual(testLogic.ClickEquals(), string.Empty);
        }

        [Test]
        public void NumberInputWorksTest()
        {
            Assert.AreEqual(testLogic.ClickNumber("1"), "1");
        }

        [Test]
        public void MultipleNumbersWorkTest()
        {
            testLogic.ClickNumber("1");
            Assert.AreEqual(testLogic.ClickNumber("2"), "12");
        }

        [Test]
        public void CommaDoesntPressInitiallyTest()
        {
            Assert.AreEqual(testLogic.ClickComma(), string.Empty);
        }

        [Test]
        public void CommaPressesAfterDigitsTest()
        {
            testLogic.ClickNumber("1");
            Assert.AreEqual(testLogic.ClickComma(), "1,");
        }

        [Test]
        public void MultipleCommasDontPressTest()
        {
            testLogic.ClickNumber("0");
            testLogic.ClickComma();
            Assert.AreEqual(testLogic.ClickComma(), "0,");
        }

        [Test]
        public void OperationsDontPressInitiallyTest()
        {
            Assert.AreEqual(testLogic.ClickOperation("+"), string.Empty);
        }

        [Test]
        public void OperationsPressAfterNumbersTest()
        {
            testLogic.ClickNumber("1");
            Assert.AreEqual(testLogic.ClickOperation("*"), "1*");
        }

        [Test]
        public void OperationsDontPressAfterCommasTest()
        {
            testLogic.ClickNumber("1");
            testLogic.ClickComma();
            Assert.AreEqual(testLogic.ClickOperation("-"), "1,");
        }

        [Test]
        public void OperationsSwitchOnPressingTest()
        {
            testLogic.ClickNumber("1");
            testLogic.ClickOperation("+");
            Assert.AreEqual(testLogic.ClickOperation("-"), "1-");
        }

        [Test]
        public void LeftBracketPressesInitiallyTest()
        {
            Assert.AreEqual(testLogic.ClickLeftBracket(), "(");
        }

        [Test]
        public void RightCommaDoesntPressInitiallyTest()
        {
            Assert.AreEqual(testLogic.ClickRightBracket(), string.Empty);
        }

        [Test]
        public void CanMakeExpressionInBracketsTest()
        {
            testLogic.ClickLeftBracket();
            testLogic.ClickNumber("1");
            testLogic.ClickOperation("+");
            testLogic.ClickNumber("1");
            Assert.AreEqual(testLogic.ClickRightBracket(), "(1+1)");
        }

        [Test]
        public void BracketBalanceWorksTest()
        {
            testLogic.ClickLeftBracket();
            testLogic.ClickNumber("2");
            testLogic.ClickOperation("*");
            testLogic.ClickNumber("3");
            testLogic.ClickRightBracket();
            Assert.AreEqual(testLogic.ClickRightBracket(), "(2*3)");
        }
    }
}
