using System;
using MyNUnit.Annotations;

namespace Project3
{
    public class Class1
    {
        [Test(Expected = typeof(ArgumentException))]
        public void ExceptionTest()
        {
            throw new ArgumentException();
        }
    }
}
