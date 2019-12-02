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
        private MyThreadPool threadPool;

        /// <summary>
        /// Result of task calculation
        /// </summary>
        private TResult taskResult;

        /// <summary>
        /// Blocks the thread until it returns task result
        /// </summary>
        private ManualResetEvent threadBlocker = new ManualResetEvent(false);

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

                if (!IsCompleted)
                {
                    
                }
            }
        }
    }
}