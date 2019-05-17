namespace HashTable.Test
{
    using System;
    using HashTableNamespace;
    using NUnit.Framework;

    [TestFixture]
    public class HashTableTests
    {
        private HashTable set;

        [SetUp]
        public void SetUp()
        {
            set = new HashTable(13);
        }

        [Test]
        public void IsEmptyAtStartTest()
        {
            Assert.AreEqual(0, set.Size);
        }

        [Test]
        public void CanInsertWordsTest()
        {
            set.Insert("Dog");

            Assert.IsTrue(set.Exists("Dog"));
        }

        [Test]
        public void CanInsertMultipleWordsTest()
        {
            set.Insert("Dog");
            set.Insert("God");

            Assert.IsTrue(set.Exists("Dog"));
            Assert.IsTrue(set.Exists("God"));
        }

        [Test]
        public void CanRemoveSingleWordTest()
        {
            set.Insert("Domashka");
            set.Delete("Domashka");

            Assert.AreEqual(0, set.Size);
        }

        [Test]
        public void SizeDoesNotLieTest()
        {
            set.Insert("jkljdsa");
            set.Insert("salkje0q");

            Assert.AreEqual(2, set.Size);
        }

        [Test]
        public void RepeatedWordsArentInsertedTest()
        {
            set.Insert("M4TM3X");
            set.Insert("M4TM3X");

            Assert.AreEqual(1, set.Size);
        }

        [Test]
        public void DoesntRemoveNonExistingWords()
        {
            set.Insert("30yoBoomer");
            set.Delete("16yoZoomer");

            Assert.IsTrue(set.Exists("30yoBoomer"));
            Assert.AreEqual(1, set.Size);
        }

        [Test]
        public void SomewhatNormalWorkSimulationTest()
        {
            set.Insert("Sobaka");
            set.Insert("Kotik");
            set.Insert("Sobaka");
            set.Insert("Homyak");
            set.Delete("Sobaka");
            set.Insert("Programmer");
            set.Delete("Homyak");
            set.Delete("Kotik");
            set.Delete("Programmer");

            Assert.AreEqual(0, set.Size);
        }

        [Test]
        public void OverwhelmedHashTableWorksWellTest()
        {
            for (int i = 1; i <= 30; ++i)
            {
                set.Insert(Convert.ToString(i * 19));
            }

            Assert.AreEqual(30, set.Size);
        }
    }
}
