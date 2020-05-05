open System

///Finds the first occurence of x in list
let firstInList x list =
    let rec listSearcher i x list =
        match list with
        | [] -> None
        | head :: tail ->
            if (head = x) then
                Some(i)
            else 
                listSearcher (i + 1) x tail
    listSearcher 0 x list