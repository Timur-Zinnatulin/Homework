using System;

namespace MyNUnit.Annotations
{
    /// <summary>
    /// Methods with this annotation compute after every test
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AfterAttribute : Attribute
    {
    }
}