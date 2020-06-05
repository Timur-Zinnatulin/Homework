namespace Network

/// Simulates network infection process
type Simulator(
                computers   : IOperatingSystem array,
                graph       : int list array,
                log         : ILog) =

    let random = System.Random()

    /// Starts the simulation
    member this.Start () =

        /// Carries out the simulation steps
        let rec nextStep (handlingQueue : int list) (used : bool array) =
            match handlingQueue with
             
            /// Computer gets infected
            | head :: tail when 
                        not used.[head] && 
                        (random.NextDouble() < computers.[head].InfectionChance) ->
                used.[head] <- true
                used |> log.LogState |> ignore

                nextStep (handlingQueue @ graph.[head]) used

            /// Computer does not get infected
            /// Keeps trying to infect it
            | head :: tail when not used.[head] ->
                used |> log.LogState |> ignore
                nextStep (handlingQueue @ [head]) used

            /// Already infected computer
            | head :: tail ->
                nextStep tail used

            /// Empty queue
            | [] -> used

        /// Launches the virus into the network
        let rec virusJump i (state : bool array) =

            /// All the computers are infected
            if (i = computers.Length) then
                true
            else
                match state.[i] with
                | true -> virusJump (i + 1) state
                | false -> 
                    /// Tries to infect i-th computer
                    let newState = nextStep [i] state
                    virusJump (i + 1) newState

        let startingState = [| for i in 1 .. computers.Length -> false|]

        virusJump 0 startingState