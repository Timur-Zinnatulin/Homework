using NUnit.Framework;
using Test_3;

namespace UnitTests
{
    /// <summary>
    /// MD5 checksum calculator unit tests
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Checks if encoding for same directory is constant
        /// </summary>
        [Test]
        public void CypherIsConstantTest()
        {
            var code = CheckSum.CalculateMD5("../../../../");
            Assert.AreEqual(code, CheckSum.CalculateMD5("../../../../"));
        }

        /// <summary>
        /// Checks if different directories are encoded differently
        /// </summary>
        [Test]
        public void CyphersAreNotTheSameTest()
        {  
            var code = CheckSum.CalculateMD5("../../../");
            Assert.AreNotEqual(code, CheckSum.CalculateMD5("../../"));
        }
    }
}