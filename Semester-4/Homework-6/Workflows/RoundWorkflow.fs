module RoundWorkflow

open System

/// Workflow for calculation with given accuracy
type RoundWorkflow(accuracy : int) =
    let calcAccuracy = accuracy
    member this.Bind(x : double, f : double -> double) =
        f (Math.Round (x, accuracy))

    member this.Return(x : double) =
        Math.Round(x, accuracy)