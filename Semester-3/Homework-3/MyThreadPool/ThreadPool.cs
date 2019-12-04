using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ThreadPool
{
    /// <summary>
    /// Self-made ThreadPool class
    /// </summary>
    public class MyThreadPool
    {
        /// <summary>
        /// Amount of threads in pool
        /// </summary>
        private readonly Thread[] threads;

        /// <summary>
        /// Queue for tasks ready to be executed
        /// </summary>
        private ConcurrentQueue<Action> taskQueue = new ConcurrentQueue<Action>();

        /// <summary>
        /// Cancellation token
        /// </summary>
        private CancellationTokenSource cancel = new CancellationTokenSource();

        /// <summary>
        /// Unlocks availeble threads
        /// </summary>
        private readonly AutoResetEvent threadBlocker = new AutoResetEvent(false);

        private Object lockObject = new Object();

        /// <summary>
        /// Checks if cancellation has been requested
        /// </summary>
        private void CancellationCheck()
        {
            if (cancel.IsCancellationRequested)
            {
                throw new InvalidOperationException("ThreadPool was shut down!");
            }
        }

        /// <summary>
        /// ThreadPool generated task
        /// </summary>
        private class MyTask<TResult> : IMyTask<TResult>
        {
            /// <summary>
            /// Task supplier function
            /// </summary>
            private Func<TResult> supplier;

            /// <summary>
            /// MyThreadPool that created this task
            /// </summary>
            private MyThreadPool threadPool;

            /// <summary>
            /// Result of task calculation
            /// </summary>
            private TResult taskResult;

            /// <summary>
            /// Blocks the thread until it returns task result
            /// </summary>
            private ManualResetEvent threadBlocker = new ManualResetEvent(false);


            /// <summary>
            /// Exception that we catch from supplier function and rethrow as AggregateException to MyThreadPool
            /// </summary>
            private Exception exception = null;

            public MyTask(MyThreadPool pool, Func<TResult> supplier)
            {
                this.threadPool = pool;
                this.supplier = supplier;
            }

            public bool IsCompleted { get; private set; } = false;

            public TResult Result
            {
                get
                {
                    threadBlocker.WaitOne();

                    if (exception == null)
                    {
                        return taskResult;
                    }

                    throw new AggregateException(exception);
                }
            }

            /// <summary>
            /// Generates new task
            /// </summary>
            /// <param name="function">New function</param>
            /// <returns>Newly generated task</returns>
            public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function)
            {
                while (!IsCompleted)
                {
                    threadBlocker.Set();
                }
                threadBlocker.WaitOne();

                TNewResult wrapper () => function(Result);

                return threadPool.AddTask(wrapper);
            }

            /// <summary>
            /// Executes task synchronically
            /// </summary>
            public void ExecuteTask()
            {
                try
                {
                    this.taskResult = supplier();
                }

                catch (Exception e)
                {
                    exception = e;
                }

                finally
                {
                    supplier = null;
                    IsCompleted = true;
                    threadBlocker.Set();
                }
            }
        }

        /// <summary>
        /// Amount of available threads
        /// </summary>
        private volatile int availableThreads;

        public MyThreadPool(int threadAmount)
        {
            MaxAmount = threadAmount;
            availableThreads = threadAmount;

            threads = new Thread[threadAmount];
            for (int i = 0; i < threadAmount; ++i)
            {
                threads[i] = new Thread(() => 
                {
                    while (!cancel.IsCancellationRequested)
                    {
                        if (taskQueue.TryDequeue(out Action task))
                        {
                            Interlocked.Decrement(ref availableThreads);
                            task();
                            Interlocked.Increment(ref availableThreads);
                        }

                        else
                        {
                            threadBlocker.WaitOne();

                            if (cancel.IsCancellationRequested)
                            {
                                threadBlocker.Set();
                            }
                        }
                    }
                });
                threads[i].IsBackground = true;
                threads[i].Start();
            }
        }

        /// <summary>
        /// Max amount of working threads
        /// </summary>
        public int MaxAmount { get; }

        /// <summary>
        /// Amount of available threads
        /// </summary>
        public int AvailableThreads => this.availableThreads;

        /// <summary>
        /// Inserts a task into a queue
        /// </summary>
        /// <param name="supplier">Supplier function for the task</param>
        public IMyTask<TResult> AddTask<TResult>(Func<TResult> supplier)
        {
            CancellationCheck();

            var newTask = new MyTask<TResult>(this, supplier);

            lock (lockObject)
            {
                if (!cancel.IsCancellationRequested)
                {
                    taskQueue.Enqueue(newTask.ExecuteTask);
                }

                threadBlocker.Set();

                CancellationCheck();
                return newTask;
            }
        }

        /// <summary>
        /// Shuts down the thread pool
        /// </summary>
        public void Shutdown()
        {
            lock (lockObject)
            {
                cancel.Cancel();
                threadBlocker.Set();
                availableThreads = 0;

                foreach (var thread in threads)
                {
                    if (thread.IsAlive)
                    {
                        thread.Join();
                    }
                }

                taskQueue = null;
            }
        }
    }
}