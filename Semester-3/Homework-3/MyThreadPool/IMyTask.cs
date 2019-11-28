using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPool
{
    /// <summary>
    /// ThreadPool tasks interface
    /// </summary>
    public interface IMyTask<TResult>
    {
        /// <summary>
        /// Returns true if the task is completed, false if not.
        /// </summary>
        bool IsCompleted { get; private set; }

        /// <summary>
        /// Returns task result. BLocks called thread until the result is ready.
        /// </summary>
        /// <value></value>
        TResult Result { get; }

        /// <summary>
        /// Generates new task based on the current task.
        /// </summary>
        /// <param name="function">New task function</param>
        /// <typeparam name="TNewResult">Type of new function result</typeparam>
        /// <returns>Result of composotion of functions</returns>
        IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function);
    }
}