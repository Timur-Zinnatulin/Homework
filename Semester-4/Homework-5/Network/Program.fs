namespace Network

module Main =
    open System

    let computers = Array.concat [ [| for i in 1..3 -> (new Windows() :> IOperatingSystem) |] 
                                        ; [| for i in 1..3 -> (new Linux() :> IOperatingSystem) |] ]
    let graph = 
        [|
            [1]
            [0]
            [3]
            [2; 4; 5]
            [3; 5]
            [3; 4]
        |]

    let logger = new ConsoleLog()
    let simulator = new Simulator(computers, graph, logger)

    simulator.Start () |> ignore