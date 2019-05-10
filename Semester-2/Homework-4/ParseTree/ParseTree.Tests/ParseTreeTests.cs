using System;
using NUnit.Framework;
using ParseTree;

namespace ParseTree.Tests
{
    [TestFixture]
    public class ParseTreeTests
    {
        [Test]
        public void TreeCanCalculateSimpleExpression()
        {
            var tree = ExpressionCalculator.CreateTree("(* (+ 1 1) 2)");
            Assert.AreEqual(4, tree.Calculate());
        }
    }
}
