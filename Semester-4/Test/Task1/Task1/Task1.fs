module Task1

open System

let min a b =
    if a < b then a
    else b

let minElement list =
    list |> List.fold min Int32.MaxValue
