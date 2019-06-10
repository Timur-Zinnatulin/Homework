using System;
using GenericSet;
using System.Collections.Generic;
using NUnit.Framework;

namespace GenericSet.Tests
{
    /// <summary>
    /// Generic set tests. Int is easier to compare.
    /// </summary>
    [TestFixture]
    public class SetTests
    {
        private GenericSet<int> set;
        private List<int> list;

        [SetUp]
        public void SetUp()
        {
            set = new GenericSet<int>();
            list = new List<int>() { 2, 4, 6, 8, 10 };
        }

        [Test]
        public void AddTest()
        {
            set.Add(1);
            Assert.AreEqual(1, set.Count);
        }

        [Test]
        public void ClearTest()
        {
            set.Add(1);
            set.Clear();
            Assert.AreEqual(0, set.Count);
        }

        [Test]
        public void TrueContainsTest()
        {
            set.Add(1);
            Assert.IsTrue(set.Contains(1));
        }

        [Test]
        public void FalseContainsTest()
        {
            set.Add(10);
            Assert.IsFalse(set.Contains(0));
        }

        [Test]
        public void CopyToTest()
        {
            var array = new int[] { 1, 2, 3, 4 };
            set.Add(5);
            set.Add(6);
            set.CopyTo(array, 2);
            Assert.AreEqual(6, array[3]);
        }

        [Test]
        public void CopyToOutOfRangeExceptionTest()
        {
            var array = new int[] { 1, 2, 3, 4 };
            set.Add(5);
            Assert.Throws<ArgumentOutOfRangeException>(() => set.CopyTo(array, 4), "Index is out of range.");
        }

        [Test]
        public void CopyToCantFitTest()
        {
            var array = new int[] { 1, 2, 3, 4 };
            set.Add(5);
            set.Add(6);
            Assert.Throws<ArgumentException>(() => set.CopyTo(array, 3), "Can't fit into array.");
        }

        [Test]
        public void RemoveWorksTest()
        {
            set.Add(1);
            set.Remove(1);
            Assert.AreEqual(0, set.Count);
        }

        [Test]
        public void CanRemoveExistingItemsTest()
        {
            set.Add(1);
            Assert.IsTrue(set.Remove(1));
        }

        [Test]
        public void CannotRemoveMissingItemsTest()
        {
            set.Add(1);
            Assert.IsFalse(set.Remove(2));
        }

        [Test]
        public void ExceptWithRemovesElementsTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.ExceptWith(list);
            Assert.IsFalse(set.Contains(2));
        }

        [Test]
        public void ExceptWithKeepsNeededElementsTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.ExceptWith(list);
            Assert.IsTrue(set.Contains(3));
        }

        [Test]
        public void ExceptWithCountTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.ExceptWith(list);
            Assert.AreEqual(2, set.Count);
        }

        [Test]
        public void IntersectWithRemovesElementsTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.IntersectWith(list);
            Assert.IsFalse(set.Contains(1));
        }

        [Test]
        public void IntersectWithKeepsNeededElementsTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.IntersectWith(list);
            Assert.IsTrue(set.Contains(2));
        }

        [Test]
        public void IntersectWithCountTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.IntersectWith(list);
            Assert.AreEqual(1, set.Count);
        }

        [Test]
        public void TrueIsProperSubsetOfTest()
        {
            set.Add(2);
            set.Add(6);
            set.Add(10);
            Assert.IsTrue(set.IsProperSubsetOf(list));
        }

        [Test]
        public void FalseIsProperSubsetOfTest()
        {
            set.Add(2);
            set.Add(3);
            Assert.IsFalse(set.IsProperSubsetOf(list));
        }

        [Test]
        public void IsAlmostProperSubsetOfTest()
        {
            set.Add(4);
            set.Add(6);
            set.Add(10);
            set.Add(2);
            set.Add(8);
            Assert.IsFalse(set.IsProperSubsetOf(list));
        }

        [Test]
        public void TrueIsProperSupersetOfTest()
        {
            set.Add(2);
            set.Add(4);
            set.Add(8);
            set.Add(10);
            set.Add(6);
            set.Add(15);
            Assert.IsTrue(set.IsProperSupersetOf(list));
        }

        [Test]
        public void FalseIsProperSupersetOfTest()
        {
            set.Add(1);
            set.Add(3);
            set.Add(5);
            set.Add(8);
            Assert.IsFalse(set.IsProperSupersetOf(list));
        }

        [Test]
        public void IsAlmostProperSupersetOfTest()
        {
            set.Add(2);
            set.Add(4);
            set.Add(6);
            set.Add(8);
            set.Add(10);
            Assert.IsFalse(set.IsProperSupersetOf(list));
        }

        [Test]
        public void TrueIsSubsetOfTest()
        {
            set.Add(2);
            set.Add(10);
            Assert.IsTrue(set.IsSubsetOf(list));
        }

        [Test]
        public void FalseIsSubsetOfTest()
        {
            set.Add(2);
            set.Add(3);
            Assert.IsFalse(set.IsSubsetOf(list));
        }

        [Test]
        public void FullSetIsSubsetOfTest()
        {
            set.Add(2);
            set.Add(4);
            set.Add(6);
            set.Add(8);
            set.Add(10);
            Assert.IsTrue(set.IsSubsetOf(list));
        }

        [Test]
        public void TrueIsSupersetOfTest()
        {
            set.Add(2);
            set.Add(4);
            set.Add(5);
            set.Add(6);
            set.Add(8);
            set.Add(10);
            set.Add(1);
            Assert.IsTrue(set.IsSupersetOf(list));
        }

        [Test]
        public void FalseIsSupersetOfTest()
        {
            set.Add(1);
            set.Add(3);
            set.Add(5);
            set.Add(8);
            Assert.IsFalse(set.IsSupersetOf(list));
        }

        [Test]
        public void FullSetIsSupersetOfTest()
        {
            set.Add(2);
            set.Add(4);
            set.Add(6);
            set.Add(8);
            set.Add(10);
            Assert.IsTrue(set.IsSupersetOf(list));
        }

        [Test]
        public void TrueOverlapsTest()
        {
            set.Add(6);
            Assert.IsTrue(set.Overlaps(list));
        }

        [Test]
        public void FalseOverlapsTest()
        {
            set.Add(0);
            Assert.IsFalse(set.Overlaps(list));
        }

        [Test]
        public void TrueSetEqualsTest()
        {
            set.Add(2);
            set.Add(4);
            set.Add(6);
            set.Add(8);
            set.Add(10);
            Assert.IsTrue(set.SetEquals(list));
        }

        [Test]
        public void FalseSetEqualsTest()
        {
            set.Add(1);
            set.Add(3);
            set.Add(7);
            Assert.IsFalse(set.SetEquals(list));
        }

        [Test]
        public void SymmetricExceptWithTest()
        {
            set.Add(1);
            set.Add(3);
            set.Add(8);
            set.SymmetricExceptWith(list);
            Assert.IsFalse(set.Contains(8));
            Assert.IsTrue(set.Contains(3));
            Assert.IsTrue(set.Contains(1));
        }

        [Test]
        public void UnionWithTest()
        {
            set.Add(9);
            set.UnionWith(list);
            Assert.IsTrue(set.Contains(6));
        }

        [Test]
        public void UnionWithCountTest()
        {
            set.Add(2);
            set.UnionWith(list);
            Assert.AreEqual(5, set.Count);
        }
    }
}
