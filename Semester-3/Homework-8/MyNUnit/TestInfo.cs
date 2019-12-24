using System;

namespace MyNUnit
{
    /// <summary>
    /// Basic test information
    /// </summary>
    public class TestInfo
    {
        /// <summary>
        /// Name of the assembly being built
        /// </summary>
        public string AssemblyName { get; }

        /// <summary>
        /// Name of the method being tested
        /// </summary>
        public string MethodName { get; }

        /// <summary>
        /// Expected exception type
        /// </summary>
        public Type Expected { get; }

        /// <summary>
        /// Ignore specification
        /// </summary>
        public string Ignore { get; }

        /// <summary>
        /// Test result
        /// </summary>
        public bool IsPassed { get; }

        /// <summary>
        /// Test execution time
        /// </summary>
        public long Time { get; }

        public TestInfo(string assembly, string method, Type expected = null, 
            bool isPassed, string ignore = null, long time)
        {
            this.AssemblyName = assembly;
            this.MethodName = method;
            this.Expected = expected;
            this.Ignore = ignore;
            this. IsPassed = isPassed;
            this.Time = time;
        }
    }
}
