namespace Network

module Tests =
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``Simulator should work correctly with overall chance = 1`` () =
        let computers = [| for i in 1..6 -> (new BadOS() :> IOperatingSystem) |]
        let graph = 
            [|
                [1]
                [0]
                [3]
                [2; 4; 5]
                [3; 5]
                [3; 4]
            |]

        let logger = new LogBFS()
        let simulator = new Simulator(computers, graph, logger)
        simulator.Start() |> ignore

        logger.IsSomeoneHealthy() |> should be False

    [<Test>]
    let ``Simulator should work correctly with overall chance = 0`` () =
        let computers = [| for i in 1..6 -> (new GoodOS() :> IOperatingSystem) |]
        let graph = 
            [|
                [1]
                [0]
                [3]
                [2; 4; 5]
                [3; 5]
                [3; 4]
            |]
        let expectedState = [| for i in 1..6 -> false |]

        let simulator = new Simulator(computers, graph, new LogZeroChance(6))
        try
            simulator.Start() |> should be True
        with
            | Failure("Test success!") -> Assert.Pass()
            | Failure("Test failure!") -> 
                Assert.Fail("Probabiliy == 0, but some computers were infected")
            
        Assert.Fail("The simulation stopped, although it shouldn't have to!")

    [<Test>]
    let ``Infection should work like BFS with infection chance == 1`` () =
        let computers = [| for i in 1..6 -> (new BadOS() :> IOperatingSystem) |]
        let graph = 
            [|
                [1]
                [0; 2]
                [1; 3]
                [2; 4]
                [3; 5]
                [4]
            |]

        let logger = new LogBFS()
        let simulator = new Simulator(computers, graph, logger)
        simulator.Start() |> ignore

        logger.IsBFS() |> should be True
