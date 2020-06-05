namespace Lazy

open System.Threading

/// Lock-free multi thread version of Lazy
type LazyLockFree<'a> (supplier : unit -> 'a) =
    let mutable result = None
    let emptyResult = result

    interface ILazy<'a> with
        
        /// Launches calculation and returns the result
        member this.Get () =
            match result with
            | None -> 
                let value = supplier ()
                Interlocked.CompareExchange(&result, Some value, emptyResult) |> ignore
                match result with
                | Some x -> x
                | None -> value

            | Some value ->
                value