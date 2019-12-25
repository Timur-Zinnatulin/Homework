using System;

using MyNUnit.Annotations;

namespace Project5
{
    public class Class1
    {
        [BeforeClass]
        public static void Initialize()
        {
        }

        [Test]
        public void Test()
        {
        }

        [AfterClass]
        public static void Clear()
        {
        }
    }
}
