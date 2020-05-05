using System;

using MyNUnit.Annotations;

namespace Project2
{
    public class Class1
    {
        [Before]
        public static void Before1()
        {
        }

        [Test]
        public void Test1()
        {
        }

        [After]
        public static void After1()
        {
        }
    }
}
