namespace Lazy

/// Lazy calculator interface
type ILazy<'a> =

    /// Launches calculation and returns the result
    abstract member Get: unit -> 'a