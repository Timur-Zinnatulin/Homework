using System;

namespace MyNUnit.Annotations
{
    /// <summary>
    /// Methods with this annotation compute before all tests are run
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class BeforeClassAnnotation : Attribute
    {
    }
}