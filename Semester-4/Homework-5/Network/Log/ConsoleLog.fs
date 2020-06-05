namespace Network

/// Network state logger
type ConsoleLog() =
    let mutable step = 0

    interface ILog with
        /// Prints current network state
        member this.LogState state =
            printfn "Step №%d. " step
            state |> Array.iteri (fun i item ->
                                    match item with
                                    | true -> printfn "Computer #%d: Infected" i
                                    | false -> printfn "Computer #%d: Healthy" i)

            step <- step + 1
            step