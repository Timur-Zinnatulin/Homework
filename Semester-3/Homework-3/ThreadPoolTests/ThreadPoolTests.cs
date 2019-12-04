using NUnit.Framework;
using ThreadPool;
using System;

namespace ThreadPoolTests
{
    /// <summary>
    /// Tests for MyThreadPool
    /// </summary>
    [TestFixture]
    public class ThreadPoolTests
    {
        private MyThreadPool testPool;
        private const int maxAmountOfThreads = 10;

        [SetUp]
        public void Setup()
        {
            testPool = new MyThreadPool(maxAmountOfThreads);
        }

        [Test]
        public void SingleTaskTest()
        {
            var testTask = testPool.AddTask(() => 5);
            Assert.AreEqual(5, testTask.Result);
        }

        [Test]
        public void MultipleTasksWorkTest()
        {
            var tasks = new IMyTask<string>[5];

            for (int i = 0; i < 5; ++i)
            {
                tasks[i] = testPool.AddTask(() => "opa");
            }
            
            foreach (var task in tasks)
            {
                Assert.AreEqual("opa", task.Result);
            }
        }

        [Test]
        public void ThreadPoolSupportsDifferentTypesTest()
        {
            var taskInt = testPool.AddTask(() => 228);
            var taskStr = testPool.AddTask(() => "dva-dva-vosem");

            Assert.AreEqual(228, taskInt.Result);
            Assert.AreEqual("dva-dva-vosem", taskStr.Result);
        }

        [Test]
        public void ShutdownWorksTest()
        {
            testPool.Shutdown();
            Assert.Throws<InvalidOperationException>(() => {testPool.AddTask(() => "zdarova");}, "ThreadPool was shut down!");
        }

        [Test]
        public void TasksFinishBeforeShutdownTest()
        {
            var task = testPool.AddTask(() => 
            {
                System.Threading.Thread.Sleep(100);
                return 5;
            });

            System.Threading.Thread.Sleep(100);

            testPool.Shutdown();
            Assert.AreEqual(5, task.Result);
        }

        [Test]
        public void ContinueWithSimpleTest()
        {
            var task = testPool.AddTask(() => 2 * 2 * 8).ContinueWith(result => result.ToString());

            Assert.AreEqual("32", task.Result);
        }

        [Test]
        public void ContinueWithIsCompletedAfterShutdown()
        {
            var task = testPool.AddTask(() =>
            {
                System.Threading.Thread.Sleep(100);
                return 1 + 4 + 8 + 8;
            }).ContinueWith(result => 
                   {
                       System.Threading.Thread.Sleep(100);
                       return result + 207;
                   });
            System.Threading.Thread.Sleep(100);
            testPool.Shutdown();

            Assert.AreEqual(228, task.Result);
        }

        [Test]
        public void AggregateExceptionTest()
        {
            Assert.Throws<AggregateException>(() => {var task = testPool.AddTask(() => 
                {
                    var array = new int[5];
                    return array[100];
                });
                var answer = task.Result;
            });
        }
    }
}