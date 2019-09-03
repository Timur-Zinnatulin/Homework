using System;
using System.Collections.Generic;
using Sem2FinalTest;
using NUnit.Framework;

namespace Sem2FinalUnitTests
{
    [TestFixture]
    public class Sem2FinalTests
    {
        private AscendingComp<int> intComparerAscend;
        private DescendingComp<int> intComparerDescend;
        private List<int> listOfInt;

        private AscendingComp<string> strAscendingComp;
        private DescendingComp<string> strDescendingComp;
        private List<string> listOfStr;

        [SetUp]
        public void Start()
        {
            intComparerAscend = new AscendingComp<int>();
            intComparerDescend = new DescendingComp<int>();
            listOfInt = new List<int>();

            strAscendingComp = new AscendingComp<string>();
            strDescendingComp = new DescendingComp<string>();
            listOfStr = new List<string>();
        }

        [Test]
        public void IntSortAscendingTest()
        {
            listOfInt.Add(185962);
            listOfInt.Add(2);
            listOfInt.Add(10);
            listOfInt.Add(-15);
            listOfInt.Add(-1859);

            BubbleSort<int>.Sort(listOfInt, intComparerAscend);
            var expected = new List<int> { -1859, -15, 2, 10, 185962};
            Assert.AreEqual(expected, listOfInt);
        }

        [Test]
        public void IntSortDescendingTest()
        {
            listOfInt.Add(-100500);
            listOfInt.Add(-50520);
            listOfInt.Add(832);
            listOfInt.Add(666);
            listOfInt.Add(7312);

            BubbleSort<int>.Sort(listOfInt, intComparerDescend);
            var expected = new List<int> { 7312, 832, 666, -50520, -100500 };
            Assert.AreEqual(expected, listOfInt);
        }

        [Test]
        public void StringSortAscendingTest()
        {
            string[] inputs = { "a", "b", "$", "c", "A", "B", "C", "D", "d" };
            listOfStr.AddRange(inputs);

            var expected = new List<string> {"$", "d", "c", "b", "a", "D", "C", "B", "A" };

            listOfStr = BubbleSort<string>.Sort(listOfStr, strAscendingComp);

            Assert.AreEqual(expected, listOfStr);
        }

        [Test]
        public void StringSortDescendingTest()
        {
            string[] inputs = { "hochu", "zachet", "po", "proge", "no", "razuchilsya", "progat", "scha", "nagonyu" };
            listOfStr.AddRange(inputs);
            var expected = new List<string>{ "razuchilsya", "nagonyu", "scha", "progat", "proge", "po", "no", "zachet", "hochu" };

            Assert.AreEqual(expected, BubbleSort<string>.Sort(listOfStr, strDescendingComp));
        }
}
}
