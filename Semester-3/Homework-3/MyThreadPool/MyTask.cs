using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPool
{
    /// <summary>
    /// ThreadPool generated task
    /// </summary>
    public class MyTask<TResult> : IMyTask<TResult>
    {
        /// <summary>
        /// Task supplier function
        /// </summary>
        private readonly Func<TResult> supplier;

        /// <summary>
        /// MyThreadPool that created this task
        /// </summary>
        private ThreadPool threadPool;

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

        public MyTask(ThreadPool pool, Func<TResult> supplier)
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

            IsCompleted = true;
            threadBlocker.Set();
        }
    }
}