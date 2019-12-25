using System;
using System.IO;
using System.Reflection;
using System.Collection.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using MyNUnit.Annotations;

namespace MyNUnit
{
    /// <summary>
    /// MyNUnit Test Runner
    /// /// </summary>
    public static class TestRunner
    {
        public static BlockingCollection<TestInfo> Tests { get; private set; }

        /// <summary>
        /// Runs all tests in given directory
        /// </summary>
        public static void Run(string path)
        {
            var types = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories).Select(Assembly.LoadFrom).ToHashSet().SelectMany(a => a.ExportedTypes);
            Tests = new BlockingCollection<TestInfo>();
            Parallel.ForEach(types, ExecuteAllMethods);
        }

        /// <summary>
        /// Prints testing results
        /// </summary>
        public static void PrintResults()
        {
            foreach (var test in Tests)
            {
                Console.WriteLine($"{test.AssemblyName}.{test.MethodName} " + 
                    $"{(test.Ignore == null ? ((test.IsPassed ? "Passed" : "Failed") + ". Time:" + test.Time.ToString()) : " ignored: " + test.Ignore)}");
            }
        }

        /// <summary>
        /// Executes all methods of certain type in correct order
        /// </summary>
        private static void ExecuteAllMethods(Type type)
        {
            ExecuteAllMethodsWithAttribute<BeforeClassAttribute>(type);
            ExecuteAllMethodsWithAttribute<TestAttribute>(type);
            ExecuteAllMethodsWithAttribute<AfterClassAttribute>(type);
        }

        /// <summary>
        /// Executes all methods with a certain attribute
        /// </summary>
        private static void ExecuteAllMethodsWithAttribute<AttributeT>(Type type, object instance = null) where AttributeT : Attribute
        {
            var methodsWithAttribute = type.GetTypeInfo()
                                           .DeclaredMethods
                                           .Where(me => Attribute.IsDefined(me, typeof(AttributeT)));
            Action<MethodInfo> RunMethod;

            if (typeof(AttributeT) == typeof(TestAttribute))
            {
                RunMethod = ExecuteTestMethod;
            }

            if (typeof(AttributeT) == (typeof(BeforeClassAttribute)
                || typeof(AfterClassAttribute) || typeof(BeforeAttribute)
                    || typeof(AfterAttribute)))
            {
                var arrtibute = typeof(AttributeT);
                RunMethod = (me => ExecuteAuxiliaryMethod(me, instance, attribute));
            }

            Parallel.ForEach(methodsWithAttribute, RunMethod);
        }

        /// <summary>
        /// Executes test methods
        /// </summary>
        private static void ExecuteTestMethod(MethodInfo info)
        {
            var attributes = Attribute.GetCustomAttribute(info, typeof(TestAttribute)) as TestAttribute;

            if (attributes.Ignore != null)
            {
                Tests.Add(new TestInfo(info.DeclaringType.FullName, info.Name,
                    time: 0, isPassed: false, ignore: attributes.Ignore));
                    return;
            }

            var constructor = info.DeclaringType.GetConstructor(Type.EmptyTypes);
            if (constructor == null)
            {
                throw new InvalidOpertaionException($"{info.DeclaringType.Name} must have a constructor.");
            }
            var instance = constructor.Invoke(null);

            ExecuteAllMethodsWithAttribute<BeforeAttribute>(info.DeclaringType, instance);
            //TODO
            ExecuteAllMethodsWithAttribute<AfterAttribute>(info.DeclaringType, instance);
        }

        /// <summary>
        /// Executes non-test methods
        /// </summary>
        private void ExecuteAuxiliaryMethod(MethodInfo info, object instance, Type attribute)
        {
            if ((attribure == typeof(BeforeClassAttribute) || attribute == typeof(AfterClassAttribute)) && !info.IsStatic)
            {
                throw new InvalidOperationException($"{info.Name}: BeforeClass- and AfterAlassAttributes must be static.");
            }

            info.Invoke(instance, null);
        }
    }
}