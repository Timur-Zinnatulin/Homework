using System;
using System.Collections.Generic;
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
        /// <returns></returns>
        private CancellationTokenSource cancel = new CancellationTokenSource();

        /// <summary>
        /// Unlocks availeble threads
        /// </summary>
        private readonly AutoResetEvent threadBlocker = new AutoResetEvent(false);

        /// <summary>
        /// Amount of available threads
        /// </summary>
        private volatile int availableThreads;

        
    }
}
