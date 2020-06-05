namespace Network

module Main =
    open System

    let computers = [| for i in 1..5 -> ( {new IOperatingSystem with
                                            member this.InfectionChance = 1.0}) |] 
    let graph = 
        [|
            [1]
            [0; 2]
            [1; 3]
            [2; 4]
            [3]
        |]

    let logger = new ConsoleLog()
    let simulator = new Simulator(computers, graph, logger)

    simulator.Start [|true; false; true; false; true|] |> ignore