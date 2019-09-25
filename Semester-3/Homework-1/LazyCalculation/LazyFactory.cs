using System;

namespace LazyCalculation
{
    /// <summary>
    /// Lazy calculation object creator
    /// </summary>
    public static class LazyFactory<T>
    {
        public static LazySingleThread<T> CreateSingleThread(Func<T> supplier)
            => new LazySingleThread<T>(supplier);

        public static LazyParallel<T> CreateMultiThread(Func<T> supplier)
            => new LazyParallel<T>(supplier);
    }
}