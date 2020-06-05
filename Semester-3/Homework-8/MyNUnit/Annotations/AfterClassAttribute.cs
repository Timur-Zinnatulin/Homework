using System;

namespace MyNUnit.Annotations
{
    /// <summary>
    /// Methods with this annotation compute after all tests are run
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AfterClassAttribute : Attribute
    {
    }
}