using System;

namespace MyNUnit.Annotations
{
    /// <summary>
    /// Methods with this annotation compute before every test
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class BeforeAnnotation : Attribute
    {
    }
}