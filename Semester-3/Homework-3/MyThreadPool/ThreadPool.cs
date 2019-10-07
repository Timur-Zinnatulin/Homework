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

        private bool[] isOccupied;

        private ConcurrentQueue<MyTask> taskQueue;

        public ThreadPool(int n)
        {
            threads = new Thread[n];
            isOccupied = new bool[n];
            for (int i = 0; i < n; ++i)
            {
                isOccupied[i] = false;
            }

            taskQueue = new ConcurrentQueue<MyTask>();
        }

        public void Submit(MyTask task)
            => taskQueue.Enqueue(task);

        public void Shutdown()
        {
            
        }
    }
}
