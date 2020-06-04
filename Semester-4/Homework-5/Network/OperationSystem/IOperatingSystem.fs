namespace Network

/// Describes the operating system interface
type IOperatingSystem =
    abstract member Name : string
    abstract member InfectionChance : float