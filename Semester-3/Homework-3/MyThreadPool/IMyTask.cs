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

        IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function);
    }
}