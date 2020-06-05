namespace Network

module Tests =
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``Simulator should work correctly with overall chance = 1`` () =
        let computers = [| for i in 1..6 -> ({new IOperatingSystem with
                                                member this.InfectionChance = 1.0}) |]
        let graph = 
            [|
                [1]
                [0; 2]
                [3; 1]
                [2; 4; 5]
                [3; 5]
                [3; 4]
            |]

        let logger = new LogBFS()
        let simulator = new Simulator(computers, graph, logger)
        simulator.Start [|false; false; true; false; false; false|] |> ignore

        logger.IsSomeoneHealthy |> should be False

    [<Test>]
    let ``Simulator should work correctly with overall chance = 0`` () =
        let computers = [| for i in 1..6 -> ({new IOperatingSystem with
                                                member this.InfectionChance = 0.0}) |]
        let graph = 
            [|
                [1]
                [0; 2]
                [1; 3]
                [2; 4; 5]
                [3; 5]
                [3; 4]
            |]
        let expectedState = Array.concat[ [|true|]; [| for i in 1..5 -> false |] ]
        let log = new LogZeroChance()

        let simulator = new Simulator(computers, graph, log)
        let resultingNetwork = simulator.Start(expectedState)
        resultingNetwork |> should equal expectedState

    [<Test>]
    let ``Infection should work like BFS with infection chance == 1`` () =
        let computers = [| for i in 1..6 -> ({new IOperatingSystem with
                                                member this.InfectionChance = 1.0}) |]
        let graph = 
            [|
                [1]
                [0; 2]
                [1; 3]
                [2; 4]
                [3]
            |]

        let logger = new LogBFS()
        let simulator = new Simulator(computers, graph, logger)
        simulator.Start [|false; false; true; false; false|] |> ignore

        logger.IsBFS |> should be True
