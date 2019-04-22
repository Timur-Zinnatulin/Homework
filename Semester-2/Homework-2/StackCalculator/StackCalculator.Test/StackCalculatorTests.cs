namespace StackCalculatorNamespace.Test
{
    using System;
    using StackCalculatorNamespace;
    using NUnit.Framework;

    [TestFixture]
    public class StackCalculatorTests
    {
        Calculator listCalc;
        Calculator arrayCalc;

        [SetUp]
        public void SetUp()
        {
            listCalc = new Calculator(new ListStack());
            arrayCalc = new Calculator(new ArrayStack(50));
        }

        [Test]
        public void SingleInputTest()
        {
            int listAnswer = listCalc.Calculate("0");
            int arrayAnswer = arrayCalc.Calculate("1");
            Assert.AreEqual(0, listAnswer);
            Assert.AreEqual(1, arrayAnswer);
        }

        [Test]
        public void IfInputIsEmptyTest()
        {
            Assert.Throws<ArgumentException>(_ThrowsEmptyInput, "Input is null or empty!");
        }

        private void _ThrowsEmptyInput()
        {
            int answer = listCalc.Calculate("");
        }
    }
}
