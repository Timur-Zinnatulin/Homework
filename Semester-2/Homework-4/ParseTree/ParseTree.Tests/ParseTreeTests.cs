using System;
using NUnit.Framework;
using ParseTree;

namespace ParseTree.Tests
{
    [TestFixture]
    public class ParseTreeTests
    {
        [Test]
        [TestCase("2", ExpectedResult = 2)]
        [TestCase("(+ 2 2)", ExpectedResult = 4)]
        [TestCase("(* (+ 1 1) 2)", ExpectedResult = 4)]
        [TestCase("(- (/ (* (+ 28 3) 2) 33) 5)", ExpectedResult = -4)]
        [TestCase("(* 6 (* 6 (* 6 6) ))", ExpectedResult = 1296)]
        [TestCase("(- 2 (+ 2 (- 2 (+ 2 2))))", ExpectedResult = 2)]
        [TestCase("(/10 (+ 2 3))", ExpectedResult = 2)]
        public int TreeCanCalculateSimpleExpression(string input)
        {
            var tree = TreeConstructor.CreateTree(input);
            return tree.Calculate();
        }

        [Test]
        public void ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(_DivideByZero);
        }

        private void _DivideByZero()
        {
            var tree = TreeConstructor.CreateTree("(/ 2 0)");
            tree.Calculate();
        }
    }
}
