using System;
using System.Threading;
using NUnit.Framework;
using LazyCalculation;

namespace LazyTests
{
    /// <summary>
    /// Multi Thread Lazy Calculation unit test class
    /// </summary>
    [TestFixture]
    public class MultiThreadTests
    {
        private const int magicNumber = 5;
        private Thread[] threads;
        private int[] intResults;
        private string[] strResults;

        [SetUp]
        public void SetUp()
        {
            threads = new Thread[magicNumber];
            intResults = new int[magicNumber];
            strResults = new string[magicNumber];
        }

        [Test]
        public void MultiThreadNormalIntTest()
        {
            int value = 1;
            Func<int> supp = () => 
            {
                value *= 10;
                return value;
            };

            var intLazy = LazyFactory<int>.CreateMultiThread(supp);
            for (int i = 0; i < magicNumber; ++i)
            {
                var index = i;
                threads[i] = new Thread(() => 
                {
                    intResults[index] = intLazy.Get();
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            for (int i = 0; i < magicNumber; ++i)
            {
                Assert.AreEqual(10, intResults[i]);
            }
        }

        [Test]
        public void MultiThreadNormalStringTest()
        {
            var value = "Nate ";
            Func<string> supp = () => value + "Higgers";

            var strLazy = LazyFactory<string>.CreateMultiThread(supp);

            for (int i = 0; i < magicNumber; ++i)
            {
                var index = i;
                threads[i] = new Thread(() => 
                {
                    strResults[index] = strLazy.Get();
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            for (int i = 0; i < magicNumber; ++i)
            {
                Assert.AreEqual("Nate Higgers", strResults[i]);
            }
        }

        [Test]
        public void MultiThreadNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => {var strLazy = LazyFactory<string>.CreateMultiThread(null);});
        }
    }
}