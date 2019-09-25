using System;

namespace LazyCalculation
{
    /// <summary>
    /// Single thread lazy calculation class
    /// </summary>
    public class LazySingleThread<T> : ILazy<T>
    {
        private Func<T> supplier;

        private bool isCalculated = false;

        private T value;

        public LazySingleThread(Func<T> supplier)
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
                value = supplier();
                isCalculated = true;
            }
            
            return value;
        }
    }
}