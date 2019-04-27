namespace HashTableNamespace.Test
{
    using System;
    using HashTableNamespace;
    using NUnit.Framework;

    [TestFixture]
    public class HashTableTests
    {
        HashTable setJenkins;
        HashTable setFNV;
        HashTable setRecursive;

        [SetUp]
        public void SetUp()
        {
            setJenkins = new HashTable(27, new JenkinsHashFunction());
            setFNV = new HashTable(27, new FNVHashFunction());
            setRecursive = new HashTable(27, new RecursiveHashFunction());
        }

        private void IsEmptyAtStartTest(IHashTable set)
        {
            Assert.AreEqual(0, set.Size);
        }

        [Test]
        public void IsEmptyAtStartJenkinsTest() => IsEmptyAtStartTest(setJenkins);

        [Test]
        public void IsEmptyAtStartFNVTest() => IsEmptyAtStartTest(setFNV);

        [Test]
        public void IsEmptyAtStartRecursiveTest() => IsEmptyAtStartTest(setRecursive);

        private void CanInsertWordsTest(IHashTable set)
        {
            set.Insert("Dog");

            Assert.IsTrue(set.Exists("Dog"));
        }

        [Test]
        public void CanInsertWordsJenkinsTest() => CanInsertWordsTest(setJenkins);

        [Test]
        public void CanInsertWordsFNVTest() => CanInsertWordsTest(setFNV);

        [Test]
        public void CanInsertWordsRecursiveTest() => CanInsertWordsTest(setRecursive);

        private void CanInsertMultipleWordsTest(IHashTable set)
        {
            set.Insert("Dog");
            set.Insert("God");

            Assert.IsTrue(set.Exists("Dog"));
            Assert.IsTrue(set.Exists("God"));
        }

        [Test]
        public void CanInsertMultipleWordsJenkinsTest() => CanInsertMultipleWordsTest(setJenkins);

        [Test]
        public void CanInsertMultipleWordsFNVTest() => CanInsertMultipleWordsTest(setFNV);

        [Test]
        public void CanInsertMultipleWordsRecursiveTest() => CanInsertMultipleWordsTest(setRecursive);

        private void CanRemoveSingleWordTest(IHashTable set)
        {
            set.Insert("Domashka");
            set.Delete("Domashka");

            Assert.AreEqual(0, set.Size);
        }

        [Test]
        public void CanRemoveSingleWordJenkinsTest() => CanRemoveSingleWordTest(setJenkins);
        
        [Test]
        public void CanRemoveSingleWordFNVTest() => CanRemoveSingleWordTest(setFNV);

        [Test]
        public void CanRemoveSingleWordRecursiveTest() => CanRemoveSingleWordTest(setRecursive);

        private void SizeDoesNotLieTest(IHashTable set)
        {
            set.Insert("jkljdsa");
            set.Insert("salkje0q");

            Assert.AreEqual(2, set.Size);
        }

        [Test]
        public void SizeDoesNotLieJenkinsTest() => SizeDoesNotLieTest(setJenkins);

        [Test]
        public void SizeDoesNotLieFNVTest() => SizeDoesNotLieTest(setFNV);

        [Test]
        public void SizeDoesNotLieRecursiveTest() => SizeDoesNotLieTest(setRecursive);

        private void RepeatedWordsArentInsertedTest(IHashTable set)
        {
            set.Insert("M4TM3X");
            set.Insert("M4TM3X");

            Assert.AreEqual(1, set.Size);
        }

        [Test]
        public void RepeatedWordsArentInsertedJenkinsTest() => RepeatedWordsArentInsertedTest(setJenkins);

        [Test]
        public void RepeatedWordsArentInsertedFNVTest() => RepeatedWordsArentInsertedTest(setFNV);

        [Test]
        public void RepeatedWordsArentInsertedRecursiveTest() => RepeatedWordsArentInsertedTest(setRecursive);

        private void DoesntRemoveNonExistingWordsTest(IHashTable set)
        {
            set.Insert("30yoBoomer");
            set.Delete("16yoZoomer");

            Assert.IsTrue(set.Exists("30yoBoomer"));
            Assert.AreEqual(1, set.Size);
        }

        [Test]
        public void DoesntRemoveNonExistingWordsJenkinsTest() => DoesntRemoveNonExistingWordsTest(setJenkins);

        [Test]
        public void DoesntRemoveNonExistingWordsFNVTest() => DoesntRemoveNonExistingWordsTest(setFNV);

        [Test]
        public void DoesntRemoveNonExistingWordsRecursiveTest() => DoesntRemoveNonExistingWordsTest(setRecursive);

        private void SomewhatNormalWorkSimulationTest(IHashTable set)
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
        public void SomewhatNormalWorkSimulationJenkinsTest() => SomewhatNormalWorkSimulationTest(setJenkins);

        [Test]
        public void SomewhatNormalWorkSimulationFNVTest() => SomewhatNormalWorkSimulationTest(setFNV);

        [Test]
        public void SomewhatNormalWorkSimulationRecursiveTest() => SomewhatNormalWorkSimulationTest(setRecursive);

        private void OverwhelmedHashTableWorksWellTest(IHashTable set)
        {
            for (int i = 1; i <= 30; ++i)
            {
                set.Insert(Convert.ToString(i * 19));
            }

            Assert.AreEqual(30, set.Size);
        }

        [Test]
        public void OverwhelmedHashTableWorksWellJenkinsTest() => OverwhelmedHashTableWorksWellTest(setJenkins);

        [Test]
        public void OverwhelmedHashTableWorksWellFNVTest() => OverwhelmedHashTableWorksWellTest(setFNV);

        [Test]
        public void OverwhelmedHashTableWorksWellRecursiveTest() => OverwhelmedHashTableWorksWellTest(setRecursive);
    }
}
