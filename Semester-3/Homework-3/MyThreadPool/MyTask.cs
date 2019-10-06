using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPool
{
    /// <summary>
    /// ThreadPool tasks interface
    /// </summary>
    public class MyTask<TResult> : IMyTask<TResult>
    {
        public MyTask(Func<TResult> function)
        {
            this.Function = function;
            this.Result = null;
            this.IsCompleted = false;
        }

        TResult Result { get; private set; }

        MyTask<TNewResult> ContinueWith(Func<TResult, TNewResult> function)
            => new MyTask<TNewResult>(() => function(this.Result));
    }
}