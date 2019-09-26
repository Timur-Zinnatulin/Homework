using System;

namespace LazyCalculation
{
    /// <summary>
    /// Lazy calculation interface
    /// </summary>
    /// <typeparam name="T">Type of parameter that is returned</typeparam>    
    public interface ILazy<T>
    {
        /// <summary>
        /// Get calculation result
        /// </summary>
        T Get();   
    }
}
