namespace Network

type GoodOS () =
    interface IOperatingSystem with
        member this.Name = "Good"
        member this.InfectionChance = 0.0