using System;
using WinFormsCalculator;
using NUnit.Framework;

namespace CalculatorTests
{
    /// <summary>
    /// Tests for ResultCalculator, checking if it calculates ifnix form expressions correctly
    /// </summary>
    [TestFixture]
    public class CalculationTests
    {
        [Test]
        [TestCase("2", ExpectedResult = "2")]
        [TestCase("(2+2)", ExpectedResult = "4")]
        [TestCase("2*(1+1)", ExpectedResult = "4")]
        [TestCase("(84-11)*(1/73)", ExpectedResult = "1")]
        [TestCase("2+2-2+2-2+2-2+2-2", ExpectedResult = "2")]
        [TestCase("843-1009", ExpectedResult = "-166")]
        [TestCase("2+2*2", ExpectedResult = "6")]
        public string CalculatesExpressionTest(string input)
            => ResultCalculator.Result(input).ToString();

        [Test]
        public void DivisionByZeroIsCaughtTest()
        {
            Assert.Throws<DivideByZeroException>(() => ResultCalculator.Result("2/0"), "Division by zero occurred. Check input correctness.");
        }

        [Test]
        public void MismatchedParenthesesAreCaughtTest()
        {
            Assert.Throws<FormatException>(() => ResultCalculator.Result("(2+2"), "Mismatched parenthesees");
        }
    }
}
