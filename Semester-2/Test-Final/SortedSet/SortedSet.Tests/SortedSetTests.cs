using System;
using System.Collections.Generic;
using NUnit.Framework;
using SortedSet;

namespace SortedSet.Tests
{
    [TestFixture]
    public class SortedSetTests
    {
        SortedSet<List<string>> set = new SortedSet<List<string>>(new ByListSize());
        StringToListTransformer trans = new StringToListTransformer();

        [Test]
        public void CanAddIntoSetTest()
        {
            set.Add(trans.TransformToList("aaaaa"));
            Assert.AreEqual(1, set.Count);
        }

        [Test]
        public void DoesNotDuplicateTest()
        {
            set.Add(trans.TransformToList("ohmygod"));
            set.Add(trans.TransformToList("ohmygod"));
            Assert.AreEqual(1, set.Count);
        }

        [Test]
        public void CanAddMultipleTest()
        {
            set.Add(trans.TransformToList("Proga"));
            set.Add(trans.TransformToList("Topchik"));
            Assert.AreEqual(2, set.Count);
        }

        [Test]
        public void CanDeleteFromSet()
        {
            set.Add(trans.TransformToList("Laptop"));
            set.Add(trans.TransformToList("Computer"));
            set.Remove(trans.TransformToList("Computer"));

            Assert.AreEqual(1, set.Count);
        }

        [Test]
        public void SetIsSorted()
        {
            set.Add(trans.TransformToList("Oneword"));
            set.Add(trans.TransformToList("Three wor ds"));
            set.Add(trans.TransformToList("Fo ur wo rds"));
            set.Add(trans.TransformToList("Two words"));
            int i = 0;
            var strings = new string[] { "Oneword", "Two words", "Three wor ds", "Fo ur wo rds" };

            foreach (var list in set)
            {
                Assert.AreEqual(trans.TransformToString(list), strings[i]);
                ++i;
            }

        }
    }
}
