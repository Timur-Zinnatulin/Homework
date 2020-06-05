namespace Lazy

/// Type for Lazy factory
type LazyFactory () =
    
    /// Creates a single thread version of Lazy
    static member CreateSingleThreadLazy<'a>(supplier : unit -> 'a) =
        new LazySingleThread<'a>(supplier) :> ILazy<'a>

    /// Creates a locking multi thread version of Lazy
    static member CreateParallelLazy<'a>(supplier : unit -> 'a) =
        new LazyParallel<'a>(supplier) :> ILazy<'a>

    /// Creates a lock-free multi thread version of Lazy
    static member CreateLockFreeLazy<'a>(supplier : unit -> 'a) =
        new LazyLockFree<'a>(supplier) :> ILazy<'a>