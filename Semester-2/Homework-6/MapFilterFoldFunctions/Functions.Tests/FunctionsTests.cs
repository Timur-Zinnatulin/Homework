using System;
using System.Collections.Generic;
using MapFilterFoldFunctions;
using NUnit.Framework;

namespace Functions.Tests
{
    [TestFixture]
    public class FunctionsTests
    {
        List<int> list;
        [SetUp]
        public void SetUp()
        {
            list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        }

        [Test]
        public void IdentityMapTest()
        {
            var result = ListFunctions.Map(list, x => x);
            Assert.AreEqual(list, result);
        }

        [Test]
        public void PowerMapTest()
        {
            list = ListFunctions.Map(list, x => x * x);
            var result = new List<int>() { 1, 4, 9, 16, 25, 36, 49, 64, 81, 100 };
            Assert.AreEqual(result, list);
        }

        [Test]
        public void EvenNumbersFilterTest()
        {
            list = ListFunctions.Filter(list, x => (x % 2 == 0));
            var result = new List<int>() { 2, 4, 6, 8, 10};
            Assert.AreEqual(result, list);
        }

        [Test]
        public void SomeFilterTest()
        {
            list = ListFunctions.Filter(list, x => (x == 5));
            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list.Contains(5));
        }

        [Test]
        public void SumFolderTest()
        {
            var foldedList = ListFunctions.Fold(list, 0, (acc, elem) => acc + elem);
            Assert.AreEqual(55, foldedList);
        }

        [Test]
        public void AlternatingSumFoldTest()
        {
            var foldedList = ListFunctions.Fold(list, 0, (acc, elem) => acc + (int)Math.Pow(-1, elem) * elem);
            Assert.AreEqual(5, foldedList);
        }
    }
}
