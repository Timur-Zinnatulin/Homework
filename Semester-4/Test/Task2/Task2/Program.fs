module Task2

open System

let createSquare size =
    let fullRow = 
        String.replicate size "*"
    let emptyRow =
        match size with
        | x when x > 1 ->
            "*" + (String.replicate (size - 2) " ") + "*"
        | _ -> ""

    let rec linePrinter acc str =
        match acc with
        | n when n = size - 1 -> str + fullRow
        | 0 -> linePrinter (acc + 1) (str + fullRow + "\n")
        | _ -> linePrinter (acc + 1) (str + emptyRow + "\n")

    linePrinter 0 ""