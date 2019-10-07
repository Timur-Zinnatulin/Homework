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
        bool IsCompleted { get; private set; }

        TResult Result { get; }

        Func<TResult> Function {get; private set;}

        MyTask<TNewResult> ContinueWith(Func<TResult, TNewResult> function);
    }
}