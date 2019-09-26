using System;

namespace LazyCalculation
{
    /// <summary>
    /// Multi-thread lazy calculation class
    /// </summary>
    public class LazyParallel<T> : ILazy<T>
    {
        private Func<T> supplier;

        private volatile bool isCalculated = false;

        private T value;

        private object lockObject = new Object();

        public LazyParallel(Func<T> supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }
            this.supplier = supplier;
        }

        /// <summary>
        /// Get calculation result
        /// </summary>
        public T Get()
        {
            if (!isCalculated)
            {
                lock (lockObject)
                {
                    if (isCalculated)
                    {
                        return value;
                    }

                    value = supplier();
                    supplier = null;
                    isCalculated = true;
                }
            }
            
            return value;
        }
    }
}