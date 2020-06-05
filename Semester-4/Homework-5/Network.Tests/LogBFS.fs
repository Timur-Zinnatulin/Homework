namespace Network

/// Logger for computers with 100% infection chance
type LogBFS() =
    let mutable stepNumber = 0
    let mutable isSomeoneHealthy = true
    let mutable isBFS = true

    member this.IsSomeoneHealthy = isSomeoneHealthy
    member this.IsBFS = isBFS

    interface ILog with
        member this.LogState state =
            
            if (state.[2 - stepNumber] = false || state.[2 + stepNumber] = false) then
                isBFS <- false

            if stepNumber >= 500 then
                failwith "Simulation was not stopped, but probability is 1!"
            else
                isSomeoneHealthy <- Array.contains false <| state
                stepNumber <- stepNumber + 1


            stepNumber