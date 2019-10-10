using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPool
{
    /// <summary>
    /// ThreadPool task
    /// </summary>
    public class MyTask<TResult> : IMyTask<TResult>
    {
        public MyTask(Func<TResult> function)
        {
            this.Function = function;
            this.Result = null;
            this.IsCompleted = false;
        }

        private object lockObject = new Object();

        /// <summary>
        /// Result of Task result calculation
        /// </summary>
        public TResult Result 
        { 
            get
            {
                if (!IsCompleted)
                {
                    lock (lockObject)
                    {
                        if (isCompleted)
                        {
                            return Result;
                        }

                        Result = Function();
                        Function = null;
                        IsCompleted = true;
                    }
                }
                return Result;
            } 
        }

        /// <summary>
        /// Method that lets us calculate composition of functions in a single task
        /// </summary>
        /// <returns>Result of composition</returns>
        public MyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function)
            => new MyTask<TNewResult>(() => function(this.Result));
    }
}