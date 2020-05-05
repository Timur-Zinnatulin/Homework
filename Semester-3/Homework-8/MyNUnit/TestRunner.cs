using System;
using System.IO;
using System.Reflection;
using System.Collections.Concurrent;
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
        /// Checks if the method has input or return params
        /// </summary>
        private static void CheckIfMethodIsWrong(MethodInfo info)
        {
            if (info.GetParameters().Length != 0)
            {
                throw new InvalidOperationException($"{info.Name}: Method cannot have parameters.");
            }
            if (info.ReturnType != typeof(void))
            {
                throw new InvalidOperationException($"{info.Name}: Method cannot return value.");
            }
        }

        /// <summary>
        /// Executes all methods of certain type in correct order
        /// </summary>
        private static void ExecuteAllMethods(Type type)
        {
            ExecuteAllMethodsWithAnnotation<BeforeClassAttribute>(type);
            ExecuteAllMethodsWithAnnotation<TestAttribute>(type);
            ExecuteAllMethodsWithAnnotation<AfterClassAttribute>(type);
        }

        private static bool IsNonTestAnnotation(Type type)
            => (type == typeof(BeforeClassAttribute))
                || (type == typeof(AfterClassAttribute)) 
                    || (type == typeof(BeforeAttribute))
                        || (type == typeof(AfterAttribute));

        /// <summary>
        /// Executes all methods with a certain annotation
        /// </summary>
        private static void ExecuteAllMethodsWithAnnotation<AttributeT>(Type type, object instance = null) where AttributeT : Attribute
        {
            var methodsWithAnnotation = type.GetTypeInfo()
                                           .DeclaredMethods
                                           .Where(me => Attribute.IsDefined(me, typeof(AttributeT)));
            Action<MethodInfo> RunMethod;

            if (typeof(AttributeT) == typeof(TestAttribute))
            {
                RunMethod = ExecuteTestMethod;
            }

            else if (IsNonTestAnnotation(typeof(AttributeT)))
            {
                var attribute = typeof(AttributeT);
                RunMethod = (me => ExecuteAuxiliaryMethod(me, instance, attribute));
            }

            else
            {
                throw new InvalidProgramException("Wrong annotation.");
            }

            Parallel.ForEach(methodsWithAnnotation, RunMethod);
        }

        /// <summary>
        /// Executes test methods
        /// </summary>
        private static void ExecuteTestMethod(MethodInfo info)
        {
            CheckIfMethodIsWrong(info);

            var attributes = Attribute.GetCustomAttribute(info, typeof(TestAttribute)) as TestAttribute;

            if (attributes.Ignore != null)
            {
                Tests.Add(new TestInfo(info.DeclaringType.FullName, info.Name,
                    0, false, ignore: attributes.Ignore));
                    return;
            }

            var constructor = info.DeclaringType.GetConstructor(Type.EmptyTypes);
            if (constructor == null)
            {
                throw new InvalidOperationException($"{info.DeclaringType.Name} must have a constructor.");
            }
            var instance = constructor.Invoke(null);

            ExecuteAllMethodsWithAnnotation<BeforeAttribute>(info.DeclaringType, instance);

            bool flagFailed = true;
            var time = Stopwatch.StartNew();
            try
            {
                info.Invoke(instance, null);
                if (attributes.Expected == null)
                {
                    flagFailed = false;
                }
            }
            catch (Exception ex)
            {
                if (attributes.Expected == ex.InnerException.GetType())
                {
                    flagFailed = false;
                }
            }
            finally
            {
                time.Stop();
                Tests.Add(new TestInfo(info.DeclaringType.FullName, info.Name,
                    time.ElapsedMilliseconds, !flagFailed, attributes.Ignore, attributes.Expected));
            }

            ExecuteAllMethodsWithAnnotation<AfterAttribute>(info.DeclaringType, instance);
        }

        /// <summary>
        /// Executes non-test methods
        /// </summary>
        private static void ExecuteAuxiliaryMethod(MethodInfo info, object instance, Type attribute)
        {
            CheckIfMethodIsWrong(info);

            if ((attribute == typeof(BeforeClassAttribute) || attribute == typeof(AfterClassAttribute)) && !info.IsStatic)
            {
                throw new InvalidOperationException($"{info.Name}: BeforeClass- and AfterAlassAttributes must be static.");
            }

            info.Invoke(instance, null);
        }

    }
}