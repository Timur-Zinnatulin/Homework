namespace Lazy

open System
open System.Threading

/// Multi thread version of Lazy
type LazyParallel<'a> (supplier : unit -> 'a) =
    let mutable result = None
    let lockObj = new Object()

    interface ILazy<'a> with
        
        /// Launches calculation and returns the result
        member this.Get () =
            match result with
            | None ->
                lock lockObj (fun () ->
                    match result with
                    | Some x -> x
                    | None ->
                        let value = supplier ()
                        result <- Some value
                        value
                    )
            | Some value ->
                value