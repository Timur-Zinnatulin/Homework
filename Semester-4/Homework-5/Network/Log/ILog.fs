namespace Network

/// Network state logger interface
type ILog =
    /// Prints current network state
    abstract member LogState : bool array -> int