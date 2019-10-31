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
            this.function = function;
            this.Result = null;
            this.IsCompleted = false;
        }
        private object lockObject = new Object();
        private Func<TResult> function;
        private ManualResetEvent waitResult = new ManualResetEvent(false);

        private Exception internalException = null;

        private TResult calculationResult;

        /// <summary>
        /// Result of Task result calculation
        /// </summary>
        public TResult Result 
        { 
            get
            {
                waitResult.WaitOne();
                if (internalException == null)
                {
                    return calculationResult;
                }

                throw new AggregateException(internalException);
            } 
        }

        public void ExecuteTask(bool normalExecution = false)
        {
            
        }
        /// <summary>
        /// Method that lets us calculate composition of functions in a single task
        /// </summary>
        /// <returns>Result of composition</returns>
        public MyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function)
            => new MyTask<TNewResult>(() => function(this.Result));
    }
}