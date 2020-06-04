namespace Network

/// Network state logger
type ConsoleLog() =
    let mutable step = 0

    interface ILog with
        /// Prints current network state
        member this.LogState state =
            let rec printList number list =
                match list with
                | [] -> printf "\n"
                | head :: tail ->
                    match head with
                    | true -> printfn "Computer №%d: Infected" number
                    | false -> printfn "Computer №%d: Healthy" number

                    printList (number + 1) tail

            printfn "Step №%d. " step
            printList 1 (state |> List.ofArray)

            step <- step + 1
            step