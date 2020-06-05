namespace Lazy

/// Single thread version of Lazy
type LazySingleThread<'a> (supplier : unit -> 'a) =
    let mutable result = None

    interface ILazy<'a> with
        
        /// Launches calculation and returns the result
        member this.Get () =
            match result with
            | None -> 
                let value = supplier ()
                result <- Some value
                value
            | Some value ->
                value