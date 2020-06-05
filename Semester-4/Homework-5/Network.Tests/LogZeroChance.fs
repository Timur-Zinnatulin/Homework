namespace Network

type LogZeroChance(compNumber) =
    let mutable stepNumber = 0

    interface ILog with
        member this.LogState state =
            if stepNumber >= 500 then
                let expectedState = [| for i in 1..compNumber -> false |]

                if state = expectedState then
                    failwith "Test success!"
                else
                    failwith "Test failure!"
            else
                stepNumber <- stepNumber + 1

            stepNumber