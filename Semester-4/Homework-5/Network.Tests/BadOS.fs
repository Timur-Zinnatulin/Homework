namespace Network

type BadOS () =
    interface IOperatingSystem with
        member this.Name = "Bad"
        member this.InfectionChance = 1.0