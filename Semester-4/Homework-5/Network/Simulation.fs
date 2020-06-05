namespace Network

/// Simulates network infection process
type Simulator(
                computers   : IOperatingSystem array,
                graph       : int list array,
                log         : ILog) =

    let random = System.Random()


    /// Starts the simulation
    member this.Start (startState : bool array) =

        /// Carries out the simulation steps
        let rec nextStep (handlingQueue : int list) (used : bool array) (newQueue : int list) =
            match handlingQueue with
             
            /// Computer gets infected
            | head :: tail when 
                        not used.[head] && 
                        (random.NextDouble() < computers.[head].InfectionChance) ->
                used.[head] <- true
                nextStep tail used (newQueue @ graph.[head])

            /// Computer does not get infected
            /// Keeps trying to infect it
            | head :: tail when not used.[head] ->

                /// If the computer is invincible...
                if (computers.[head].InfectionChance = 0.0) then
                    /// ...there's no need in trying to infect it
                    nextStep tail used newQueue
                else
                    nextStep tail used (newQueue @ [head])

            /// Already infected computer
            | head :: tail ->
                nextStep tail used newQueue

            /// Empty queue
            | [] -> 
                (newQueue, used)

        /// Launches the virus into the network
        let rec virusJump queue states =
            match queue with
            | [] -> states
            | virusQueue -> 
                states |> log.LogState |> ignore
                let newNetwork = nextStep virusQueue states List.Empty
                virusJump (fst newNetwork) (snd newNetwork)

        let infected = startState |> Array.indexed |> Array.filter (fun (i, x) -> x = true)
                    |> Array.map (fun (i, x) -> graph.[i]) |> List.concat 
        virusJump infected startState