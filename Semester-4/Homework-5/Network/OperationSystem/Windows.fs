namespace Network

/// Windows OS
type Windows() =
    interface IOperatingSystem with
        member this.Name = "Windows"
        member this.InfectionChance = 0.8