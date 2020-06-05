namespace Network

type LogBFS() =
    let mutable stepNumber = 0
    let mutable isSomeoneHealthy = true
    let mutable isBFS = true

    member this.IsSomeoneHealthy() = isSomeoneHealthy
    member this.IsBFS() = isBFS

    interface ILog with
        member this.LogState state =
            let rec printList number list =
                match list with
                | [] -> printf "\n"
                | head :: tail ->
                    match head with
                    | true -> printfn "Computer #%d: Infected" number
                    | false -> printfn "Computer #%d: Healthy" number

                    printList (number + 1) tail

            printfn "Step %d: " stepNumber
            printList 1 (state |> List.ofArray)

            if (state.[stepNumber] = false) then
                isBFS <- false

            if stepNumber >= 500 then
                failwith "Simulation was not stopped, but probability is 1!"
            else
                isSomeoneHealthy <- Array.contains false <| state
                stepNumber <- stepNumber + 1


            stepNumber