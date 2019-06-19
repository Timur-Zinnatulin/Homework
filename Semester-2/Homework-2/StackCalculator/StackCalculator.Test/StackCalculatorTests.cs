namespace StackCalculatorNamespace.Test
{
    using System;
    using StackCalculatorNamespace;
    using NUnit.Framework;

    //Both stacks work perfectly well, so we assert that calculator should work with any variation
    [TestFixture]
    public class StackCalculatorTests
    {
        private Calculator calc;

        [SetUp]
        public void SetUp()
        {
            calc = new Calculator(new ListStack());
        }

        [Test]
        public void SingleInputTest()
        {
            Assert.AreEqual(0, calc.Calculate("0"));
        }

        [Test]
        public void IfInputIsEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => calc.Calculate(""), "Input is null or empty!");
        }

        [Test]
        public void CalculatesBinarySumTest()
        {
            Assert.AreEqual(4, calc.Calculate("2 2 +"));
        }

        [Test]
        public void CalculatesBinarySubtractionTest()
        {
            Assert.AreEqual(-1, calc.Calculate("2 3 -"));
        }

        [Test]
        public void CalculatesBinaryMultiplicationTest()
        {
            Assert.AreEqual(8, calc.Calculate("2 4 *"));
        }

        [Test]
        public void CalculatesBinaryDivisionTest()
        {
            Assert.AreEqual(2, calc.Calculate("6 3 /"));
        }

        [Test]
        public void DivideByZeroExceptionTest()
        {
            Assert.Throws<DivideByZeroException>(() => calc.Calculate("1 0 /"));
        }

        [Test]
        public void RegularExpressionTest()
        {
            Assert.AreEqual(4, calc.Calculate("1 1 + 2 *"));
        }
    }
}
