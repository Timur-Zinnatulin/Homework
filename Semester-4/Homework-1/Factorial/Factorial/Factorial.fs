module Factorial

///Counts factorial of n
let factorial n =
    let rec factorialRec x acc =
        if x < 0 then
            None
        elif x <= 1 then
            Some(acc)
        else
            factorialRec (x - 1) (acc * x)

    factorialRec n 1