namespace StackCalculatorNamespace.Test
{
    using System;
    using StackCalculatorNamespace;
    using NUnit.Framework;

    [TestFixture]
    public class ArrayStackTests
    {
        private ArrayStack stack;

        [SetUp]
        public void SetUp()
        {
            stack = new ArrayStack(100);
        }

        [Test]
        public void EmptyStackTest()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void StackChangesSizeOnPushTest()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Size);
        }

        [Test]
        public void StackElementValueIsCorrectTest()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
        }

        [Test]
        public void PushesMoreThatONeElementTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Size);
        }

        [Test]
        public void PopsOutOfStackTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Size);
        }

        [Test]
        public void PopsLastElementFromStackTest()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void PopExceptionTest()
        {
            Assert.Throws<InvalidOperationException>(_EmptyStackPop, "Stack is empty!");
        }

        private void _EmptyStackPop()
        {
            stack.Pop();
        }
    }
}
