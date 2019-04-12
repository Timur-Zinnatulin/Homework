using System;

namespace Tests
{
    using NUnit.Framework;
    using Test1;
    [TestFixture]
    public class UnitTest1
    {
        PriorityQueue queue;

        [SetUp]
        public void SetUp()
        {
            queue = new PriorityQueue();
        }

        [Test]
        public void PutsIntoQueueTest()
        {
            queue.Enqueue(1, 1);
            Assert.AreEqual(1, queue.Dequeue());
        }

        [Test]
        public void WorksAsPriorityQueueTest()
        {
            queue.Enqueue(2, 1);
            queue.Enqueue(3, 2);
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
        }

        [Test]
        public void EmptyQueueTest()
        {
            Assert.Throws<EmptyQueueException>(_TestExceptionThrow, "Could not dequeue from an empty queue.");
        }

        private void _TestExceptionThrow()
        {
            queue.Dequeue();
        }

        [Test]
        public void WorksAsQueueAsWellTest()
        {
            queue.Enqueue(2, 2);
            queue.Enqueue(3, 2);
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
        }
    }
}
