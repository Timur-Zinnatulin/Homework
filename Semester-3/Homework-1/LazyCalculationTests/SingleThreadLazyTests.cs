using System;
using System.Collections.Generic;
using NUnit.Framework;
using LazyCalculation;

namespace LazyTests
{
    [TestFixture]
    public class SingleThreadTests
    {
        private LazySingleThread<int> lazyInt;

        private LazySingleThread<string> lazyStr;

        [Test]
        public void NormalIntTest()
        {
            lazyInt = LazyFactory<int>.CreateSingleThread(() => 100);
            Assert.AreEqual(100, lazyInt.Get());
        }

        [Test]
        public void CalculatesIntOnceTest()
        {
            var value = 0;
            Func<int> supp = () => 
            {
                ++value;
                return value;
            };

            lazyInt = LazyFactory<int>.CreateSingleThread(supp);

            lazyInt.Get();
            Assert.AreEqual(1, lazyInt.Get());
        }

        [Test]
        public void CalculatesStrOnceTest()
        {
            var value = "";
            Func<string> supp = () => 
            {
                value += "Hoba! ";
                return value;
            };

            lazyStr = LazyFactory<string>.CreateSingleThread(supp);

            lazyStr.Get();
            lazyStr.Get();
            Assert.AreEqual("Hoba! ", lazyStr.Get());
        }

        [Test]
        public void NullTest()
        {
            Assert.Throws<ArgumentNullException>(() => lazyStr = LazyFactory<string>.CreateSingleThread(null));
        }
    }
}