module EvensInList

open System

/// Counts the amount of even numbers in list using List.map
let evensMap list =
    list |> List.map (fun x -> (x + 1) % 2 |> abs) |> List.sum

/// Counts the amount of even numbers in list using List.filter
let evensFilter list =
    list |> List.filter (fun x -> (x % 2) = 0) |> List.length

/// Counts the amount of even numbers in list using List.fold
let evensFold list =
    list |> List.fold (fun acc x -> acc + ((x + 1) % 2 |> abs)) 0