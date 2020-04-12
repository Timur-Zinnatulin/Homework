open System

///Creates a list of power of 2 from "a" to "a + b"
let powerList a b =
    let powerOfTwo x =
        let rec multiply i acc =
            match i with
            | 0 -> acc
            | _ -> multiply (i - 1) (acc * 2)
        multiply x 1
    if (a < 0 || b < 0) then
        None
    else
        Some(List.map (fun x -> powerOfTwo x) <| [a..a + b])