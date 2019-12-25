using NUnit.Framework;

using MyNUnit;

using Project1;
using Project2;
using Project3;
using Project4;
using Project5;

using System;
namespace Tests
{
    [TestFixture]
    public class TestsForTests
    {
        [Test]
        public void TestPasses()
        {
            MyNUnit.TestRunner.Run("../../../../MyTestProjects/Project1");
            Assert.IsTrue(MyNUnit.TestRunner.Tests.Take().IsPassed);
        }

        [Test]
        public void TestThrowsException()
        {
            MyNUnit.TestRunner.Run("../../../../MyTestProjects/Project3");
            var result = MyNUnit.TestRunner.Tests.Take();
            Assert.IsTrue(result.IsPassed);
            Assert.AreEqual(typeof(ArgumentException), result.Expected);
        }

        [Test]
        public void TestIgnores()
        {
            MyNUnit.TestRunner.Run("../../../../MyTestProjects/Project4");
            var result = MyNUnit.TestRunner.Tests.Take();
            Assert.IsTrue(!result.IsPassed);
            Assert.AreEqual("This test is stupid", result.Ignore);
        }
    }
}