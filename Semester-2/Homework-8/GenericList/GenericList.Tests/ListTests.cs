using System;
using GenericList;
using NUnit.Framework;

namespace GenericList.Tests
{
    /// <summary>
    /// Generic list tests
    /// </summary>
    [TestFixture]
    public class ListTests
    {
        private List<int> list;

        [SetUp]
        public void SetUp()
        {
            list = new List<int>();
        }

        [Test]
        public void EmptyAtStartTest()
            => Assert.IsTrue(list.IsEmpty());

        [Test]
        public void AddTest()
        {
            list.Add(1);
            Assert.AreEqual(1, list[0]);
        }

        [Test]
        public void ClearTest()
        {
            list.Add(1);
            list.Add(2);
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void ListSizeUpdatesTest()
        {
            list.Add(2);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void InsertWorksTest()
        {
            list.Insert(0, 1);
            list.Insert(1, 2);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void CanFindItemsTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(2, list[1]);
        }

        [Test]
        public void InsertBetweenItemsTest()
        {
            list.Add(1);
            list.Add(2);
            list.Insert(1, 10);
            Assert.AreEqual(10, list[1]);
        }

        [Test]
        public void IndexOfNoElementTest()
            => Assert.AreEqual(-1, list.IndexOf(0));

        [Test]
        public void IndexOfElementWorksTest()
        {
            list.Add(10);
            list.Add(15);
            Assert.AreEqual(1, list.IndexOf(15));
        }

        [Test]
        public void ContainsWorksTest()
        {
            list.Add(1);
            list.Add(10);
            list.Add(100);
            Assert.IsTrue(list.Contains(10));
        }

        [Test]
        public void DoesntContainTest()
        {
            list.Add(1);
            Assert.IsFalse(list.Contains(10));
        }

        [Test]
        public void CopyToWorksTest()
        {
            for (int i = 0; i < 15; ++i)
            {
                list.Add(i + 10);
            }

            var array = new int[28];
            list.CopyTo(array, 10);
            for (int i = 10; i < 25; ++i)
            {
                Assert.AreEqual(list[i - 10], array[i]);
            }
        }

        [Test]
        public void RemoveWorksTest()
        {
            list.Add(1);
            list.Add(10);
            list.Add(100);
            list.Remove(100);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void RemoveNoElementTest()
        {
            list.Add(2);
            list.Add(3);
            list.Remove(1);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void RemoveAtWorksTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveAt(1);
            Assert.AreEqual(3, list[1]);
        }

        [Test]
        public void RemoveAtCountTest()
        {
            list.Add(10);
            list.Add(21);
            list.Add(32);
            list.RemoveAt(0);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void ForeachWorksTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Add(i);
            }

            int index = 0;
            foreach (var item in list)
            {
                Assert.AreEqual(list[index], item);
                ++index;
            }
        }

        [Test]
        public void ThrowsCopyToBigIndexExceptionTest()
        {
            var array = new int[5];
            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, 10), "Index is out of range.");
        }

        [Test]
        public void ThrowsCantFitInArrayExceptionTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Add(i);
            }

            var array = new int[8];
            Assert.Throws<ArgumentException>(() => list.CopyTo(array, 0), "Can't fit into array.");
        }

        [Test]
        public void InsertExceptionTest()
            => Assert.Throws<ArgumentException>(() => list.Insert(1, 0), "Error! Insert position is invalid!");

        [Test]
        public void RemoveAtExceptionTest()
            => Assert.Throws<ArgumentException>(() => list.RemoveAt(1), "Error! Remove position is invalid!");
    }
}
