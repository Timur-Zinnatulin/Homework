using System;

namespace LazyCalculation
{
    /// <summary>
    /// Lazy calculation object creator
    /// </summary>
    public static class LazyFactory<T>
    {
        /// <summary>
        /// Creates a single thread lazy calculation function
        /// </summary>
        /// <param name="supplier">Supplier function</param>
        public static LazySingleThread<T> CreateSingleThread(Func<T> supplier)
            => new LazySingleThread<T>(supplier);

        /// <summary>
        /// Creates a multi thread lazy calculation function
        /// </summary>
        /// <param name="supplier">Supplier function</param>
        public static LazyParallel<T> CreateMultiThread(Func<T> supplier)
            => new LazyParallel<T>(supplier);
    }
}