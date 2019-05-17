using System;
using SinglyLinkedList;
using NUnit.Framework;

namespace SinglyLinkedList.Test
{
    [TestFixture]
    public class UniqueListTest
    {
        private UniqueList list;

        [SetUp]
        public void SetUp()
        {
            list = new UniqueList();
        }

        [Test]
        public void CanInsertIntoListTest()
        {
            list.Insert(1, 0);
            Assert.AreEqual(1, list.GetValueByPosition(0));
        }

        [Test]
        public void DifferentElementsCanBeInsertedTest()
        {
            list.Insert(10, 0);
            list.Insert(20, 1);
            Assert.AreEqual(10, list.GetValueByPosition(0));
            Assert.AreEqual(20, list.GetValueByPosition(1));
        }

        [Test]
        public void ExistingElementExceptionTest()
            => Assert.Throws<AddExistingElementException>(_InsertExistingElement, "Error! Such element already exists in the list!");

        private void _InsertExistingElement()
        {
            list.Insert(1, 0);
            list.Insert(1, 1);
        }

        [Test]
        public void ChangeELementIntoExistingExceptionTest()
            => Assert.Throws<AddExistingElementException>(_ChangeIntoExistingElement, "Error! Such element already exists in the list!");
        
        private void _ChangeIntoExistingElement()
        {
            list.Insert(10, 0);
            list.Insert(20, 1);
            list.ChangeValueByPosition(10, 1);
        }
    }
}
