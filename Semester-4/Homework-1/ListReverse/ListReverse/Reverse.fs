module ListReverse

///Reverses the list
let reverse list =
    let rec reverseRec list acc = 
        match list with
        | [] -> acc
        | head :: tail -> 
            reverseRec tail (head :: acc)
    reverseRec list []