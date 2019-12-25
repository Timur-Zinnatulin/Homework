using System;

namespace MyNUnit.Annotations
{
    /// <summary>
    /// Methods marked with this annotation are considered tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : Attribute
    {
        public Type Expected { get; set; }
        public string Ignore { get; set; }
    }
}