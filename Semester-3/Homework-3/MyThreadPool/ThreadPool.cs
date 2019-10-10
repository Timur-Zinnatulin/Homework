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
        private Thread[] threads;

        private volatile bool[] isOccupied;

        private ConcurrentQueue<MyTask> taskQueue;
        private CancellationTokenSource source;
        private CancellationToken token;

        public ThreadPool(int n)
        {
            threads = new Thread[n];
            isOccupied = new bool[n];
            taskQueue = new ConcurrentQueue<MyTask>();
            source = new CancellationTokenSource();
            token = source.Token;
            for (int i = 0; i < n; ++i)
            {
                var index = i;
                isOccupied[i] = false;
                threads[index] = new Thread(() => 
                    {
                        while (!token.IsCancellationRequested)
                        {
                            if (!isOccupied[index] && !taskQueue.IsEmpty)
                            {
                                isOccupied[index] = true;
                                var answer = taskQueue.Dequeue().Result;
                                isOccupied[index] = false;
                            }
                        }
                    }
                );
                threads[index].Start();
            }
        }

        public void Submit(MyTask task)
        {
            if (!token.IsCancellationRequested)
            {
                taskQueue.Enqueue(task);
                return;
            }
            throw new AggregateException("Attempted to add task after shutdownn.");
        }

        public void Shutdown()
            => source.Cancel;
    }
}
