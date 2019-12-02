using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ThreadPool
{
    /// <summary>
    /// Self-made ThreadPool class
    /// </summary>
    public class ThreadPool
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

        /// <summary>
        /// Amount of available threads
        /// </summary>
        private volatile int availableThreads;

        public ThreadPool(int threadAmount)
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
                            task();
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

                    --availableThreads;
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
            if (cancel.IsCancellationRequested)
            {
                return null;
            }

            var newTask = new MyTask<TResult>(this, supplier);
            taskQueue.Enqueue(newTask.ExecuteTask);
            threadBlocker.Set();

            return newTask;
        }

        /// <summary>
        /// Shuts down the thread pool
        /// </summary>
        public void Shutdown()
        {
            cancel.Cancel();
            threadBlocker.Set();

            foreach (var thread in threads)
            {
                if (thread.IsAlive)
                {
                    thread.Join();
                }
            }
        }
    }
}
