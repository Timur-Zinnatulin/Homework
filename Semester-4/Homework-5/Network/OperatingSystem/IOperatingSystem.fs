namespace Network

/// Describes the operating system interface
type IOperatingSystem =
    /// Chance of the computer getting infected
    abstract member InfectionChance : float