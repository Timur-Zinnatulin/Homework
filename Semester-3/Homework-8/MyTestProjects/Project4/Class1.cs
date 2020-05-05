using System;

using MyNUnit.Annotations;

namespace Project4
{
    public class Class1
    {
        [Test(Ignore = "This test is stupid")]
        public void IgnoredTest()
        {
        }
    }
}
