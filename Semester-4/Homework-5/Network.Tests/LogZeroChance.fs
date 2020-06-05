namespace Network

/// Logger for network of uninfectable computers
type LogZeroChance() =
    let mutable stepNumber = 0

    interface ILog with
        member this.LogState state =

            stepNumber <- stepNumber + 1
            stepNumber