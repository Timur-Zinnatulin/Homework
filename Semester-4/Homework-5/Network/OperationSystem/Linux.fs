namespace Network

/// Linux OS
type Linux() =
    interface IOperatingSystem with
        member this.Name = "Linux"
        member this.InfectionChance = 0.3