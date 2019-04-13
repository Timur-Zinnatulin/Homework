namespace SinglyLinkedList.Test
{
    using System;
    using NUnit.Framework;
    using SinglyLinkedList;

    [TestFixture]
    public class LinkedListTests
    {
        LinkedList list;

        [SetUp]
        public void SetUp()
            => list = new LinkedList();

        [Test]
        public void ListIsEmptyAtStartTest()
            => Assert.AreEqual(0, list.Length);

        [Test]
        public void CorrectlyTracksLengthWhenAddOneTest()
        {
            list.Insert(1, 0);
            Assert.AreEqual(1, list.Length);
        }

        [Test]
        public void CorrectLengthForLongerListTest()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            Assert.AreEqual(2, list.Length);
        }

        [Test]
        public void CanAddIntoListTest()
        {
            list.Insert(1, 0);
            Assert.AreEqual(1, list.GetValueByPosition(0));
        }

        [Test]
        public void CanCorrectlyFindItemsTest()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            Assert.AreEqual(2, list.GetValueByPosition(1));
        }

        [Test]
        public void CanInsertIntoHeadTest()
        {
            list.Insert(1, 0);
            list.Insert(10, 0);
            Assert.AreEqual(10, list.GetValueByPosition(0));
        }

        [Test]
        public void CanInsertInsideBetweenItemsTest()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(101, 1);
            Assert.AreEqual(101, list.GetValueByPosition(1));
        }

        [Test]
        public void CanRemoveSingleItemTest()
        {
            list.Insert(1, 0);
            list.Remove(0);
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void CanRemoveHeadTest()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Remove(0);
            Assert.AreEqual(2, list.GetValueByPosition(0));
        }

        [Test]
        public void CanRemoveFromInsideTest()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Remove(1);
            Assert.AreEqual(3, list.GetValueByPosition(1));
        }

        [Test]
        public void CanChangeValueInHeadTest()
        {
            list.Insert(1, 0);
            list.ChangeValueByPosition(10, 0);
            Assert.AreEqual(10, list.GetValueByPosition(0));
        }

        [Test]
        public void CanChangeValueInsideListTest()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.ChangeValueByPosition(20, 1);
            Assert.AreEqual(20, list.GetValueByPosition(1));
        }

        
        [Test]
        public void ThrowsExceptionWhenWrongInsertPositionTest()
            => Assert.Throws<InvalidListPositionException>(_WrongInsert, "Error! Insert position is invalid!");

        private void _WrongInsert()
            => list.Insert(1, 1);

        [Test]
        public void ThrowsExceptionWhenRemovesFromEmptyListTest()
            => Assert.Throws<InvalidListPositionException>(_EmptyRemove, "Error! Remove position is invalid!");

        private void _EmptyRemove()
            => list.Remove(0);

        [Test]
        public void ThrowsExceptionWhenWrongRemoveTest()
            => Assert.Throws<InvalidListPositionException>(_WrongRemove, "Error! Remove position is invalid!");

        private void _WrongRemove()
        {
            list.Insert(1, 0);
            list.Remove(1);
        }

        [Test]
        public void ThrowsExceptionWhenWrongGetValueTest()
            => Assert.Throws<InvalidListPositionException>(_WrongGet, "Error! Node get position is invalid!");

        private void _WrongGet()
        {
            list.Insert(1, 0);
            list.GetValueByPosition(1);
        }

        [Test]
        public void ThrowsExceptionWhenWrongChangeValueTest()
            => Assert.Throws<InvalidListPositionException>(_WrongChange, "Error! Node change position is invalid!");

        private void _WrongChange()
        {
            list.Insert(1, 0);
            list.ChangeValueByPosition(2, 1);
        }
    }
}
