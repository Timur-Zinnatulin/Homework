module StrToIntWorkflow

open System

/// Converts string number to double
let convertToDouble (str : string) =
    match System.Double.TryParse(str) with
        | true, value -> Some value
        | false, _ -> None

/// Workflow for calculating string numbers
type CalculationWorkflow() =
    member this.Bind(x : string, f) =
        let converted = x |> convertToDouble
        match converted with
            | Some value -> value |> f
            | None -> None
    member this.Return(x) =
        Some x